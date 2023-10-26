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
    public partial class frmTCSetup : BaseForm,IToolBar
    {

        enum DataPop { Party,Currency,Denomation };
       
        General cls;
        DataTable dtSearchMaster;
        string strButtonState = null;
        string strTransType = "STC";
        public string strError = "";
        string strFormButton;
        DataSet dsPopulateCombo;
        string strCondition;
        string[] strShowText;
        #region IToolBar Members
        public bool ADD()
        {
            ditxtTCCode.Enabled = false;
            strButtonState = "ADD";
            strFormButton = General.strStateAddEDIT;
            return true;

        }

        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();
            strFormButton = General.strStateALL;
             
            if (strButtonState == "ADD")
            {
                ditxtTCCode.Text = cls.GetTransNo(strTransType);
            }
            if (ValidatingControls() == true)
            {
                strCondition = "Where TCCode = '" + ditxtTCCode.Text + "'";
                ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "UserID=" + General.strUserId + ";Denomination="+ dicboDenomination.SelectedText +"");
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster, "BranchCode", strShowText);
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
            ditxtTCCode.Enabled = false;
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
            strQuery = "Select * from EX_TCSetup " + General.strStatusCondition + "";
            ds =cls.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster, "BranchCode",strShowText);
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
            strCondition = "Where TCCODE = '" + ditxtTCCode.Text + "'";
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
        private void PopulateCombo()
        {
            cls = new General();
//            strValue = cls.strControlAccount("PurchaseSale");
            string strQuery = "Select * from EX_SetupItems Where Locked = 'False' and Status = 'A';Select * from EX_SetupCustomer Where Status = 'A';Select * from EX_System Where Flag = 'B'";
            dsPopulateCombo = new DataSet();
             
            dsPopulateCombo =cls.GetDataSet(strQuery);
            cls.PopulateCombo(dicboCurrency, dsPopulateCombo.Tables[(int)DataPop.Party], "ItemName", "ItemCode");
            cls.PopulateCombo(dicboParty, dsPopulateCombo.Tables[(int)DataPop.Currency], "CustName", "CustCode");
            cls.PopulateCombo(dicboDenomination, dsPopulateCombo.Tables[(int)DataPop.Denomation], "Description", "Code");
        }
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
        public frmTCSetup()
        {
            InitializeComponent();
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTCSetup_Load(object sender, EventArgs e)
        {
            General.strTableName[0]= "EX_TCSetup";
            General.strAuthorizeTableName = General.strTableName[0];
            General.strPKColumn = "TCCode";
            string showText = "Denomination";
            strShowText = showText.Split(';');
            cls = new General();
            cls.EnableDisble(PnlMain, false);
            PopulateCombo();
        }

      
    }
}
