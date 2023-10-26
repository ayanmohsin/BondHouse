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
    public partial class frmTransDemandDraft : BaseForm,IToolBar
    {
        enum DataPop { Item, Country, Purpose, BenName, Party };
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataSet dsPopulateCombo;
        DataTable dtSearchMaster;
        DataTable dtSearchDetail;
        string strAccountNo = "";
        public string strButtonState = null;
        string strTransType = "TDD";
        string strError;
        public string[] strTableName = new string[3];
        string strCondition;
        public frmTransDemandDraft()
        {
            InitializeComponent();
        }

        private void PopulateCombo()
        {
            string strQuery = "Select * from EX_SetupItems Where Status = 'A';Select * from EX_System Where Flag = 'S';Select * from EX_System Where Flag = 'L';Select * from EX_SetupCustomer Where Status = 'A' and isBranch = 'true';Select * from EX_SetupCustomer Where Status = 'A'";
            dsPopulateCombo = new DataSet();
            cls = new General();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicboCurrency, dsPopulateCombo.Tables[(int)DataPop.Item], "ShortName", "ItemCode");
            cls.PopulateCombo(dicboCountry, dsPopulateCombo.Tables[(int)DataPop.Country], "Description", "Code");
            cls.PopulateCombo(dicboPurpose, dsPopulateCombo.Tables[(int)DataPop.Purpose], "Description", "Code");
            cls.PopulateCombo(dicboBenName, dsPopulateCombo.Tables[(int)DataPop.BenName], "CustName", "CustCode");
            cls.PopulateCombo(dicboParty, dsPopulateCombo.Tables[(int)DataPop.Party], "CustName", "CustCode");
        }
        #region IToolBar Members

        public bool ADD()
        {
            dicboBenName.SelectedIndex = 0;
            dicboCountry.SelectedIndex = 0;
            dicboCurrency.SelectedIndex = 1;
            //dicboAccounts.Enabled = false;
            ditxtTransNo.Enabled = false;
            strButtonState = "ADD";
            //dicboAccounts.SelectedIndex = 1;
            //dicboAccounts.SelectedValue = General.strAccountCurrencyCash;
            ditxtFavour.Focus();
            dinumGAmount.Enabled = false;
            dinumNetAmount.Enabled = false;
            return true;

        }
       
        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();
            string strValue = "";
            if (strButtonState == "ADD")
            {
                GenerateVoucherNo();
            
            }
            if (ValidatingControls() == true)
            {
                strCondition = "Where TransNo = '" + ditxtTransNo.Text + "'";
                ds = cls.SaveRecord(strButtonState, null, strTableName, PnlMain, strTransType, strCondition, "Posted=False;BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + "");
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster,"",null);
                cls.EnableDisble(PnlMain, false);
                strButtonState = "SAVE";
            }
            else
            {
                MessageBox.Show(strError, "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
       
        public bool EDIT()
        {

            ditxtTransNo.Enabled = false;
            strButtonState = "EDIT";
            dinumGAmount.Enabled = false;
            dinumNetAmount.Enabled = false;
            return true;
        }

        public bool QUERY()
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            dtSearchDetail = new DataTable();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_TransDemandDraft Where BranchCode = '" + General.strBranchCode + "' AND Posted = 'false'";
            ds = objGetData.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster,"",null);
            strButtonState = "QUERY";
            return true;
        }

        public bool UNDO()
        {
            strButtonState = "UNDO";
            return true;
        }

        public bool EXIT()
        {
            strButtonState = "EXIT";
            return true;
        }

        public bool DELETE()
        {
            cls = new General();
            strCondition = "Where TransNo = '" + ditxtTransNo.Text + "'";
            cls.DeleteRecord(strTableName, strCondition);
            strButtonState = "DELETE";
            return true;
        }

        public bool NEXT()
        {
            strButtonState = "EXIT";
            return true;
        }

        public bool PREVIOUS()
        {
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
        private void GenerateVoucherNo()
        {
            string strTransNo = string.Format("{0:D5}", Convert.ToInt32(cls.GetTransNo(strTransType)));
            ditxtTransNo.Text = strTransType + "-" + strTransNo + "-" + General.strBranchCode;
        }
        private Boolean ValidatingControls()
        {
            Boolean bolState;
            strError = "";
            cls.Validate(PnlMain);
            if (!String.IsNullOrEmpty(cls.StrMessage))
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

        private void frmTransDemandDraft_Load(object sender, EventArgs e)
        {
            cls = new General();
            strTableName[0] = "EX_TransDemandDraft";
            General.strAuthorizeTableName = strTableName[0];
            PopulateCombo();
            cls.EnableDisble(PnlMain, false);
     
        }
        private void Calculation()
        {
            if (strButtonState == "ADD" || strButtonState == "EDIT")
            {
                if (dinumQty.Value > 0 || dinumRate.Value > 0)
                {
                    dinumNetAmount.Value = dinumQty.Value * dinumRate.Value;
                }
                if (dinumQty.Value > 0 || dinumRate.Value > 0 || dinumCharges.Value > 0 || donumOCharges.Value > 0)
                {
                    dinumGAmount.Value = ((dinumQty.Value * dinumRate.Value) - dinumCharges.Value) - donumOCharges.Value;
                }        
                
            }
            
        }

        private void dinumQty_ValueChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void dinumRate_ValueChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void dinumCharges_ValueChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void donumOCharges_ValueChanged(object sender, EventArgs e)
        {
            Calculation();
        }
       
    }
}
