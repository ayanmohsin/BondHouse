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
    public partial class frmBankCharges : BaseForm,IToolBar
    {
        enum DataPop { Bank,ChargesType,Currency };
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataTable dtSearchMaster;
        string strButtonState = null;
        string strTransType = "SBNKCH";
        public string strError = "";
        string strFormButton;
        string strCondition;
        DataSet dsPopulateCombo;
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
        
        private void populateCombo()
        {
            cls = new General();
            string strQuery = "Select * from EX_SetupAccount Where Status = 'A' and isTransactional='true' and BankCash = 'B' ;Select * from EX_SetupAccount Where Status = 'A' and isTransactional='true' and HeaderCode = '" + cls.strControlAccount("EXPENSE") + "';Select ItemCode,ShortName From EX_SetupItems Where Status = 'A'";
            dsPopulateCombo = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicboBank, dsPopulateCombo.Tables[(int)DataPop.Bank], "Title", "AccountNo");
            cls.PopulateCombo(dicboChargesType, dsPopulateCombo.Tables[(int)DataPop.ChargesType], "Title", "AccountNo");
            cls.PopulateCombo(dicboCurrency, dsPopulateCombo.Tables[(int)DataPop.Currency], "ShortName", "ItemCode");
        }
       
        public frmBankCharges()
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
            ditxtTransno.Enabled = false;
            strButtonState = "ADD";
            strFormButton = General.strStateAddEDIT;
            dinumEqAmount.Enabled = false;
            dicboChargesType.Focus();
            dicboCurrency.Enabled = false;
            dtDate.Value = General.dtSystemDate;
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
                ditxtTransno.Text = cls.GetTransNo(strTransType);
            }
            if (ValidatingControls() == true)
            {
                strCondition = "Where TransNo = '" + ditxtTransno.Text + "'";
                ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "UserID=" + General.strUserId + ";BranchCode="+ General.strBranchCode +"");
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
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
            ditxtTransno.Enabled = false;
            strFormButton = General.strStateAddEDIT;
            strButtonState = "EDIT";
            dinumEqAmount.Enabled = false;
            dicboCurrency.Enabled = false;
            return true;
        }

        public bool QUERY()
        {
            strFormButton = General.strStateALL;
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_BankCharges a " + General.strStatusCondition + " ";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            }

            ds = objGetData.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
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
            strCondition = "Where TransNo = '" + ditxtTransno.Text + "'";
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
            if (txtStatus.Text == "A")
            {
                if (ditxtTransno.Text != "")
                {
                    cls = new General();
                    cls.GenerateVoucher("BCH", ditxtTransno.Text);
                    strButtonState = "PRINT";
                }
                else
                {
                    MessageBox.Show("Select Voucher For Print", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Authorized The Voucher", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        #endregion

        private void frmBankCharges_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            General.strTableName[0] = "EX_BankCharges";
            General.strPKColumn = "TransNo";
            General.strAuthorizeTableName = General.strTableName[0];
            cls = new General();
            cls.EnableDisble(PnlMain, false);
            populateCombo();
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

        public void Calc()
        {
            dinumEqAmount.Value = dinumAmount.Value * dinumRate.Value;
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dinumRate_Validated(object sender, EventArgs e)
        {
            Calc();
        }

        private void dinumAmount_Validated(object sender, EventArgs e)
        {
            Calc();
        }

        private void frmBankCharges_Activated(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }

        private void dicboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
              }

        private void dicboBank_Validated(object sender, EventArgs e)
        {
            DataRow[] dr = new DataRow[0];
            DataTable dtb = dsPopulateCombo.Tables[(int)DataPop.Bank];
            dr = dtb.Select("AccountNo = '" + dicboBank.SelectedValue + "'", "AccountNo");
            dicboCurrency.SelectedValue = dr[0]["CurrencyCode"].ToString();
 
        }

    }
}
