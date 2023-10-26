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
    public partial class frmtransRemittence : BaseForm,IToolBar
    {
        enum DataPop { TransType, Country, RemitCountry, Purpose, Account, BankCash, Items, Slab };
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataSet dsPopulateCombo;
        DataTable dtSearchMaster;
        DataTable dtSearchDetail;
        string strAccountNo = "";
        public string strButtonState = null;
        string strTransType = "REM";
        public string strError = "";
        string strCondition;
        public frmtransRemittence()
        {
            InitializeComponent();
        }
        private void frmtransRemittence_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            General.strTableName[0]= "EX_TransRemittenceMaster";
            General.strPKColumn = "TransNo";
            General.strAuthorizeTableName = General.strTableName[0];
            PopulateCombo();
            cls.EnableDisble(PnlMain, false);
            dtDate.Value = General.dtSystemDate;
            dtbMaster.CellValueChanged += new DataGridViewCellEventHandler(dtbMaster_CellValueChanged);
            dtbMaster.CellContentClick += new DataGridViewCellEventHandler(dtbMaster_CellContentClick);

        }
        void dtbMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //dtbMaster.Rows[0].Cells[1].Selected = true;
                SendKeys.Send("{Right}");
                //  dtbMaster.Rows[e.RowIndex].Cells[0].Value = false;
            }
        }

        void dtbMaster_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dtbMaster.Rows[e.RowIndex].Cells[0].Value) == true)
                {
                    if (ValidatingControls() == true)
                    {
                        dtbMaster.Rows[e.RowIndex].Cells[0].Value = true;
                    }
                    else
                    {
                        dtbMaster.Rows[e.RowIndex].Cells[0].Value = false;
                        MessageBox.Show(strError, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                dtbMaster.Rows[e.RowIndex].Cells[0].Value = false;
            }
        }

        private void PopulateCombo()
        {
            string strQuery = "Select * from EX_SetupCustomer Where CustomerType = '303' and Status = 'A';Select * from EX_System Where Flag = 'S';Select * from EX_System Where Flag = 'S';Select * from EX_System Where Flag = 'L';Select AccountNo,Title from EX_SetupAccount Where isTransactional = 'true'  and Status = 'A' and BranchCode = '"+ General.strBranchCode +"';Select * from EX_System Where Flag = 'M';Select Itemcode,ShortName From EX_SetupItems Where Status = 'A';Select * from CommissionSlab";
            dsPopulateCombo = new DataSet();
            cls = new General();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicboTransactionType, dsPopulateCombo.Tables[(int)DataPop.TransType], "CustName", "CustCode");
            cls.PopulateCombo(dicboCountry, dsPopulateCombo.Tables[(int)DataPop.Country], "Description", "Code");
            cls.PopulateCombo(dicboPurpose, dsPopulateCombo.Tables[(int)DataPop.Purpose], "Description", "Code");
            cls.PopulateCombo(dicboRemittercountry, dsPopulateCombo.Tables[(int)DataPop.RemitCountry], "Description", "Code");
            cls.PopulateCombo(dicboBankCash, dsPopulateCombo.Tables[(int)DataPop.BankCash], "Description", "Code");
          //  cls.PopulateCombo(dicboParty, dsPopulateCombo.Tables[(int)DataPop.Party], "CustName", "CustCode");
            cls.PopulateCombo(dicboCurrency, dsPopulateCombo.Tables[(int)DataPop.Items], "ShortName", "ItemCode");
        }
        #region IToolBar Members

        public bool ADD()
        {
            //dicboTransactionType.SelectedIndex = 0;
            dicboCountry.SelectedIndex = 0;
            dicboBankCash.SelectedIndex = 1;
            //dicboAccounts.Enabled = false;
            ditxtTransNo.Enabled = false;
            strButtonState = "ADD";
            //dicboAccounts.SelectedIndex = 1;
            //dicboAccounts.SelectedValue = General.strAccountCurrencyCash;
            dicboTransactionType.Focus();
            dinumRate.Enabled = false;
            donumCommission.Enabled = false;
            dicboCurrency.SelectedValue = "2";
            dtDate.Value = General.dtSystemDate;
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
            DataTable dtb = dsPopulateCombo.Tables[(int)DataPop.Slab];
            string strCri = "" + dinumAmount.Value + " >= slabFrom and " + dinumAmount.Value + " <= slabTo";
            DataRow[] ldatarows2 = dtb.Select(strCri);
            foreach (DataRow ldatarow2 in ldatarows2)
            {
                donumCommission.Value = Convert.ToDecimal(ldatarow2["Commission"].ToString());
            }
            if (ValidatingControls() == true)
            {
                if (dicboBankCash.SelectedValue.ToString() == "273")
                {
                    strValue = docboAccount.SelectedValue.ToString();
                }
                else if (dicboBankCash.SelectedValue.ToString() == "274")
                {
                    strValue = strValue = cls.strControlAccount("CashinHand");
                }
                strCondition = "Where TransNo = '" + ditxtTransNo.Text + "'";
                ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "Posted=False;AccountNo=" + strValue + ";BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + ";BranchCodeTag=" + General.strHeadOfficeCode + "");
                dtbMaster.DataSource = ds.Tables[0];
              //  dtSearchDetail = ds.Tables[1];
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
            dinumRate.Enabled = false;
            donumCommission.Enabled = false;
            return true;
        }

        public bool QUERY()
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            dtSearchDetail = new DataTable();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_TransRemittenceMaster a " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "' AND Posted = 'false'";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate + "'";
            }
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
            if (General.dtSystemDate == dtDate.Value)
            {
                cls.DeleteRecord(General.strTableName, strCondition);
            }
            else
            {
                MessageBox.Show("Current Date Record Should be Change", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
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
            string strTransNo = Convert.ToInt32(cls.GetTransNo(strTransType)).ToString();
            ditxtTransNo.Text = strTransType + "-" + strTransNo + "-" + General.strBranchCode;
        }
        public Boolean ValidatingControls()
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

        private void dicboBankCash_Validating(object sender, CancelEventArgs e)
        {
            if (dicboBankCash.SelectedValue.ToString() == "273")
            {
                docboAccount.Visible = true;
                lblAccount.Visible = true;
                cls.PopulateCombo(docboAccount, dsPopulateCombo.Tables[(int)DataPop.Account], "Title", "AccountNo");
            }
            else if (dicboBankCash.SelectedValue.ToString() == "274")
            {
                docboAccount.Visible = false;
                lblAccount.Visible = false;
                docboAccount.DataSource = null;
            }

        }

        private void frmtransRemittence_Activated(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }

        private void dinumRate_Validated(object sender, EventArgs e)
        {
          
        }

        private void dinumQuantity_Validated(object sender, EventArgs e)
        {
            if (dinumQuantity.Value !=0 && dinumAmount.Value !=0)
            {
                dinumRate.Value = dinumAmount.Value / dinumQuantity.Value;
                DataTable dtb = dsPopulateCombo.Tables[(int)DataPop.Slab];
                string strCri = "" + dinumAmount.Value + " >= slabFrom and " + dinumAmount.Value + " <= slabTo";
                DataRow[] ldatarows2 = dtb.Select(strCri);
                foreach (DataRow ldatarow2 in ldatarows2)
                {
                    donumCommission.Value = Convert.ToDecimal(ldatarow2["Commission"].ToString());
                }
            }
        }

        private void dinumAmount_Validating(object sender, CancelEventArgs e)
        {
            if (dinumQuantity.Value != 0 && dinumAmount.Value != 0)
            {
                dinumRate.Value = dinumAmount.Value / dinumQuantity.Value;
                DataTable dtb = dsPopulateCombo.Tables[(int)DataPop.Slab];
                string strCri = "" + dinumAmount.Value + " >= slabFrom and " + dinumAmount.Value + " <= slabTo";
                DataRow[] ldatarows2 = dtb.Select(strCri);
                foreach (DataRow ldatarow2 in ldatarows2)
                {
                    donumCommission.Value = Convert.ToDecimal(ldatarow2["Commission"].ToString());
                }
                DialogResult dr =
               MessageBox.Show("are you sure to Save Record", "Confirmation Save",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Convert.ToString(dr) == "Yes")
                {
                    SAVE();
                }
            }
        }
    }
}
