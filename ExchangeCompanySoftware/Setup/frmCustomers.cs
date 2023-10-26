using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExchangeCompanySoftware
{
    public partial class frmCustomers : BaseForm,IToolBar
    {
       
        General cls;
        DataTable dtSearchMaster;
        string strButtonState = null;
        string strTransType = "SCT";
        public string strError = "";
        string strFormButton;
       
        string strCondition;

        public frmCustomers()
        {
            InitializeComponent();
        }
        private void populateCombo()
        {
                General cls = new General();
            cls = new General();
            string strQuery = "Select Code,Description From EX_System Where Flag = 'C';Select BranchCode,BranchName from EX_Branch";
            DataTable dtb = new DataTable();
            dtb =cls.GetDataSet(strQuery).Tables[0];
            cls.PopulateCombo(dicboCustomerType, dtb, "Description", "Code");
            dtb =cls.GetDataSet(strQuery).Tables[1];
            cls.PopulateCombo(docboBranch, dtb, "BranchName", "BranchCode");
      
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            
            cls = new General();
            cls.EnableDisble(PnlMain, false);
            General.strTableName[0] = "EX_SetupCustomer";
            General.strPKColumn = "CustCode";
            General.strAuthorizeTableName = General.strTableName[0];
            populateCombo();
            dtDate.Value = General.dtSystemDate;
            this.Tag = "S";
            dtDate.Value = General.dtSystemDate;

        }

        #region IToolBar Members
        public bool HISTORY()
        {
            return true;
        }
        public bool ADD()
        {
            ditxtCode.Enabled = false;
            strButtonState = "ADD";
            strFormButton = General.strStateAddEDIT;
            ditxtNAME.Focus();
            return true;

        }

        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();
            strFormButton = General.strStateALL;
               
            if (strButtonState == "ADD")
            {
                ditxtCode.Text = cls.GetTransNo(strTransType);
            }
            if (ValidatingControls() == true)
            {
                strCondition = "Where CustCode = '" + ditxtCode.Text + "'";
                ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "UserId=" + General.strUserId + "");
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster,"BranchCode",null);
                strButtonState = "SAVE";
                cls.EnableDisble(PnlMain, false);
                return true;
            }
            else
            {
                MessageBox.Show(strError, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                General.strButtonState = strButtonState;
                return false;
            }

        }

        public bool EDIT()
        {
            ditxtCode.Enabled = false;
            strFormButton = General.strStateAddEDIT;
            strButtonState = "EDIT";
            return true;
        }

        public bool QUERY()
        {
            strFormButton = General.strStateALL;
                General cls = new General();
            DataSet ds = new DataSet();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_SetupCustomer " + General.strStatusCondition + "";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            ds =cls.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster,"BranchCode",null);
            strButtonState = "QUERY";
            return true;
        }

        public bool UNDO()
        {
            strFormButton = General.strStateALL;
            strButtonState = "UNDO";
            return true;
        }

        public bool EXIT()
        {
            strFormButton = General.strStateALL;
            strButtonState = "EXIT";
            return true;
        }

        public bool DELETE()
        {
            cls = new General();
            strCondition = "Where CustCode = '" + ditxtCode.Text + "'";
            cls.DeleteRecord(General.strTableName, strCondition);
            strButtonState = "DELETE";
            return true;
        }

        public bool NEXT()
        {
            strFormButton = General.strStateALL;
            strButtonState = "NEXT";
            return true;
        }

        public bool PREVIOUS()
        {
            strFormButton = General.strStateALL;
            strButtonState = "PREVIOUS";
            return true;
        }

        public bool LAST()
        {
            strButtonState = "LAST";
            return true;
        }

        public bool FIRST()
        {
            strButtonState = "FIRST";
            return true;
        }

        public bool AUTHORIZE()
        {
            strButtonState = "AUTHORIZE";
            return true;

        }

        public bool PRINT()
        {
            strButtonState = "PRINT";
            return true;
        }

        #endregion
        public Boolean ValidatingControls()
        {
            Boolean bolState;

            cls.Validate(PnlMain);
            if (cls.StrMessage != null)
            {
                strError = cls.StrMessage;
                bolState = false;
            }
            else
            {
                bolState = true;
            }
            return bolState;
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cstBranch_CheckedChanged(object sender, EventArgs e)
        {
            docboBranch.Visible = dochkBranch.Checked;
            lblBranch.Visible = dochkBranch.Checked;
        }

        private void frmCustomers_Activated(object sender, EventArgs e)
        {
                MainForm Mainfrm = (MainForm)this.ParentForm;
                Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }

        private void dicboCustomerType_Validated(object sender, EventArgs e)
        {
            if (dicboCustomerType.SelectedValue.ToString() == "303")
            {
                    General cls = new General();
                cls = new General();
                string strQuery = "Select * from EX_SetupAccount Where Status = 'A' and isTransactional = 1 and BranchCode = '" + General.strHeadOfficeCode + "'";
                DataTable dtb = new DataTable();
                dtb =cls.GetDataSet(strQuery).Tables[0];
                cls.PopulateCombo(docboAccount, dtb, "Title", "AccountNo");
            }
        }
    }
}
