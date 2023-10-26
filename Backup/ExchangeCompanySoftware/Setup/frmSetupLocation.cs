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
    public partial class frmSetupLocation : BaseForm,IToolBar
    {
        enum DataPop { Trans, CustName, Account, Item, ExRate };
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataTable dtSearchMaster;
        string strButtonState = null;
        string strTransType = "SETLOC";
        public string strError = "";
        string strFormButton;
        string strCondition;
        public frmSetupLocation()
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
                ditxtLocationCode.Enabled = false;
                strButtonState = "ADD";
                strFormButton = General.strStateAddEDIT;
                ditxtDescription.Focus();
                return true;

            }
     
            public bool SAVE()
            {
                cls = new General();
                DataSet ds = new DataSet();
                strFormButton = General.strStateALL;
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                if (strButtonState == "ADD")
                {
                    ditxtLocationCode.Text = cls.GetTransNo(strTransType);   
                }
                if (ValidatingControls() == true)
                {
                    strCondition = "Where LocationCode = '" + ditxtLocationCode.Text + "'";
                    ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "UserID=" + General.strUserId + "");
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
                ditxtLocationCode.Enabled = false;
                strFormButton = General.strStateAddEDIT;
                strButtonState = "EDIT";
                return true;
            }

            public bool QUERY()
            {
                strFormButton = General.strStateALL;
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                DataSet ds = new DataSet();
                dtSearchMaster = new DataTable();
                string strQuery;
                strQuery = "Select * from EX_SetupLocation " + General.strStatusCondition + "";
                ds = objGetData.GetDataSet(strQuery);
                dtSearchMaster = ds.Tables[0];
                dtbMaster.DataSource = dtSearchMaster;
                cls.BindGridwithTextBox(PnlMain, dtbMaster, "BranchCode", null);
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
                strCondition = "Where LocationCode = '" + ditxtLocationCode.Text + "'";
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
            General.strTableName[0]= "EX_SetupLocation";
            General.strPKColumn = "LocationCode";
            General.strAuthorizeTableName = General.strTableName[0];

            cls = new General();
            cls.EnableDisble(PnlMain, false);
            dtDate.Value = General.dtSystemDate;

        }
    }
}
