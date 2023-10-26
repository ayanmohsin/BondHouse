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
    public partial class frmSetupItem : BaseForm,IToolBar
    {
        enum DataPop { Trans, CustName, Account, Item, ExRate };
       
        General cls;
        DataTable dtSearchMaster;
        string strButtonState = null;
        string strTransType = "SIT";
        public string strError = "";
        string strFormButton;
        string strCondition;
        public frmSetupItem()
        {
            InitializeComponent();
        }

        #region IToolBar Members
        public bool HISTORY()
        {
            return true;
        }
            public bool ADD()
            {
                ditxtItemCode.Enabled = false;
                strButtonState = "ADD";
                strFormButton = General.strStateAddEDIT;
                ditxtItemName.Focus();
                return true;

            }
     
            public bool SAVE()
            {
                cls = new General();
                DataSet ds = new DataSet();
                strFormButton = General.strStateALL;
                 
                if (strButtonState == "ADD")
                {
                    ditxtItemCode.Text = cls.GetTransNo(strTransType);   
                }
                if (ValidatingControls() == true)
                {
                    strCondition = "Where ItemCode = '" + ditxtItemCode.Text + "'";
                    
                    ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "UserID=" + General.strUserId + "",true);
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
                ditxtItemCode.Enabled = false;
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
                strQuery = "Select * from EX_SetupItems " + General.strStatusCondition + "";
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
                strCondition = "Where ItemCode = '" + ditxtItemCode.Text + "'";
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
        private void frmSetupItem_Load(object sender, EventArgs e)
        {
            General.strTableName[0]= "EX_SetupItems";
            General.strPKColumn = "ItemCode";
            General.strAuthorizeTableName = General.strTableName[0];
            this.Tag = "S";
            cls = new General();
            cls.EnableDisble(PnlMain, false);
            dtDate.Value = General.dtSystemDate;
            PopulateCombo();

        }
        private void PopulateCombo()
        {
            string strQuery = "Select * from EX_SetupItems Where Status = 'A'";
            DataSet dsPopulateCombo = new DataSet();
            cls = new General();
         
            dsPopulateCombo =cls.GetDataSet(strQuery);
            AutoCompleteStringCollection acItemName = new AutoCompleteStringCollection();
            AutoCompleteStringCollection acShortName = new AutoCompleteStringCollection();

            foreach (DataRow row in dsPopulateCombo.Tables[0].Rows)
            {
                acItemName.Add(row["ItemName"].ToString());
                acShortName.Add(row["ShortName"].ToString());
            }

            ditxtItemName.AutoCompleteMode = AutoCompleteMode.Suggest;
            ditxtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            ditxtItemName.AutoCompleteCustomSource = acItemName;

            ditxtShortName.AutoCompleteMode = AutoCompleteMode.Suggest;
            ditxtShortName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            ditxtShortName.AutoCompleteCustomSource = acShortName;

        }
        private void frmSetupItem_Activated(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }
    }
}
