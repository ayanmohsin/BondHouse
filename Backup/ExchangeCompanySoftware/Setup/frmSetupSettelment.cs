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
    public partial class frmSetupSettelment : BaseForm,IToolBar
    {
        enum DataPop { PartyType, Location };
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataTable dtSearchMaster;
        string strButtonState = null;
        string strTransType = "SETSETL";
        public string strError = "";
        string strFormButton;
        string strCondition;
        DataSet dsPopulateCombo;
        public frmSetupSettelment()
        {
            InitializeComponent();
        }

        private void populateCombo()
        {
            string strQuery = "Select * from EX_System Where Flag = 'S';Select * From Ex_SetupLocation";
            dsPopulateCombo = new DataSet();
            cls = new General();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(diCboLocation, dsPopulateCombo.Tables[1], "LocationName", "LocationCode");
            //cls.PopulateCombo(dicboPartyType, dsPopulateCombo.Tables[(int)DataPop.PartyType], "Description", "Code");
        }
        private void frmSetupSettelment_Load(object sender, EventArgs e)
        {
            General.strTableName[0] = "Ex_SetupSettlement";
            General.strPKColumn = "SettelmentCode";
            General.strAuthorizeTableName = General.strTableName[0];

            cls = new General();
            cls.EnableDisble(PnlMain, false);
            populateCombo();
            dtDate.Value = General.dtSystemDate;

        }
        #region IToolBar Members
        public bool HISTORY()
        {
            return true;
        }
        public bool ADD()
        {
            ditxtSettelmentCode.Enabled = false;
            strButtonState = "ADD";
            strFormButton = General.strStateAddEDIT;
            ditxtName.Focus();
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
                ditxtSettelmentCode.Text = cls.GetTransNo(strTransType);
            }
            if (ValidatingControls() == true)
            {
                strCondition = "Where SettelmentCode = '" + ditxtSettelmentCode.Text + "'";
                ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "UserID=" + General.strUserId + "");
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster, "BranchCode", null);
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
            ditxtSettelmentCode.Enabled = false;
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
            strQuery = "Select * from Ex_SetupSettlement " + General.strStatusCondition + "";
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
            strCondition = "Where SettelmentCode = '" + ditxtSettelmentCode.Text + "'";
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
    }
}
