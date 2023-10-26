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
    public partial class frmTransStopTTDD : BaseForm,IToolBar
    {
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataTable dtSearchMaster;
        enum DataPop { Type, Currency, BranchAccount, HOAccount,ReportBranch};

        string strButtonState = null;
        string strTransType = "SO";
        public string strError = "";
        string strFormButton;
        string strCondition;
        DataSet dsPopulateCombo;
        DataTable dtSearchDetail;
        DataSet dsMainTable;
        
        private void populateCombo()
        {
            string strQuery = "Select * from EX_System Where Flag = 'ST' and Description in ('TT','DD');Select * from EX_SetupItems Where Status = 'A';Select * from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Status = 'A' and isTransactional = 'True' order by Title;Select AccountNo,Title from EX_SetupAccount Where BranchCode = '" + General.strHeadOfficeCode + "' and isTransactional = 'True' and Locked = 'false' and Status = 'A' and CurrencyCode != (Select Description from EX_SYstem Where Flag = 'BC') order by Title;Select * from EX_Branch";
            dsPopulateCombo = new DataSet();
            cls = new General();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicboReportBranch , dsPopulateCombo.Tables[(int)DataPop.ReportBranch], "BranchName", "BranchCode");
            cls.PopulateCombo(dicboTransType, dsPopulateCombo.Tables[(int)DataPop.Type], "Description", "Code");
            cls.PopulateCombo(dicboCurrency, dsPopulateCombo.Tables[(int)DataPop.Currency], "ShortName", "ItemCode");
            cls.PopulateCombo(dicboNostro, dsPopulateCombo.Tables[(int)DataPop.HOAccount], "Title", "AccountNo");
            cls.PopulateCombo(dicboAccount, dsPopulateCombo.Tables[(int)DataPop.BranchAccount], "Title", "AccountNo");
        }
        
        private void Calculate()
        {
            if (dinumTTQuantity.Value > 0 || dinumTTRate.Value > 0)
            {
                donumAmount.Value = dinumTTQuantity.Value * dinumTTRate.Value;
            }
          //  dinumTotalAmountRec.Value = dinumAmount.Value + donumHOCharges.Value + donumTTCharges.Value;
        }
        
        private void CalculateSettlement()
        {
            lblCredit.Text = "0";
            lblCalculate.Text = "0";

            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                lblCalculate.Text = (Convert.ToDouble(lblCalculate.Text.ToString()) + Convert.ToDouble(dtbDetail.Rows[i].Cells["Debit"].Value.ToString())).ToString();
                lblCredit.Text = (Convert.ToDouble(lblCredit.Text.ToString()) + Convert.ToDouble(dtbDetail.Rows[i].Cells["Credit"].Value.ToString())).ToString();

            }

        }
     
        public frmTransStopTTDD()
        {
            InitializeComponent();
        }

        private void frmTransStopTTDD_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            cls.EnableDisble(PnlMain, false);
            General.strTableName[0] = "EX_TransStopOver";
            General.strTableName[1] = "EX_TransStopOverDetail";
            General.strPKColumn = "TransNo";
            General.strAuthorizeTableName = General.strTableName[0];
            populateCombo();
            AddColumninDetailGrid();
            dtTransDate.Value = General.dtSystemDate;

            dtbDetail.KeyDown += new KeyEventHandler(dtbDetail_KeyDown);
            dtbDetail.CellEndEdit += new DataGridViewCellEventHandler(dtbDetail_CellEndEdit);
            dtbMaster.CellValueChanged += new DataGridViewCellEventHandler(dtbMaster_CellValueChanged);
            dtbMaster.CellContentClick += new DataGridViewCellEventHandler(dtbMaster_CellContentClick);
          //  dtbMaster.CellValueChanged += new DataGridViewCellEventHandler(dtbMaster_CellValueChanged);
            if (General.strBranchCode == "35")
            {
                dicboAccount.Name = "docboAccount";
            }

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

        private void AddColumninDetailGrid()
        {

            DataGridViewTextBoxColumn clmnSno = new DataGridViewTextBoxColumn();
            clmnSno.Name = "Sno";
            clmnSno.HeaderText = "Sno";
            clmnSno.Width = 40;
            dtbDetail.Columns.Add(clmnSno);

            DataGridViewTextBoxColumn clmnitCode = new DataGridViewTextBoxColumn();
            clmnitCode.Name = "AccountNo";
            clmnitCode.HeaderText = "Account No";
            clmnitCode.Width = 70;
            dtbDetail.Columns.Add(clmnitCode);

            DataGridViewTextBoxColumn cboTitle = new DataGridViewTextBoxColumn();
            cboTitle.Name = "Title";
            cboTitle.HeaderText = "Account Name";
            cboTitle.Width = 200;
            dtbDetail.Columns.Add(cboTitle);

            DataGridViewTextBoxColumn clmnDebit = new DataGridViewTextBoxColumn();
            clmnDebit.Name = "Debit";
            clmnDebit.HeaderText = "Debit";
            clmnDebit.DefaultCellStyle.Format = "N4";
            clmnDebit.ValueType = typeof(System.Double);
            clmnDebit.DefaultCellStyle.NullValue = "0";
            clmnDebit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnDebit.Width = 100;
            dtbDetail.Columns.Add(clmnDebit);


            DataGridViewTextBoxColumn clmnCredit = new DataGridViewTextBoxColumn();
            clmnCredit.Name = "Credit";
            clmnCredit.HeaderText = "Credit";
            clmnCredit.DefaultCellStyle.Format = "N4";
            clmnCredit.ValueType = typeof(System.Double);
            clmnCredit.DefaultCellStyle.NullValue = "0";
            clmnCredit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnCredit.Width = 100;
            dtbDetail.Columns.Add(clmnCredit);


            DataGridViewTextBoxColumn clmnVNo = new DataGridViewTextBoxColumn();
            clmnVNo.Name = "TransNo";
            clmnVNo.HeaderText = "TransNo";
            clmnVNo.Width = 50;
            clmnVNo.Visible = false;
            dtbDetail.Columns.Add(clmnVNo);

            DataGridViewTextBoxColumn clmnbrCode = new DataGridViewTextBoxColumn();
            clmnbrCode.Name = "BranchCode";
            clmnbrCode.HeaderText = "";
            clmnbrCode.Visible = false;
            dtbDetail.Columns.Add(clmnbrCode);

        }
        
        void dtbMaster_SelectionChanged(object sender, EventArgs e)
        {
            if (ditxtTransNo.Text != "" && strButtonState != "ADD")
            {

                DataRow[] dr = new DataRow[0];
                dr = dtSearchDetail.Select("TransNo = '" + ditxtTransNo.Text + "'", "TransNo");
                dtbDetail.Rows.Clear();
                for (int i = 0; i < dr.Count(); i++)
                {
                    dtbDetail.Rows.Add();
                    dtbDetail.Rows[i].Cells["Sno"].Value = dr[i]["Sno"].ToString();
                    dtbDetail.Rows[i].Cells["AccountNo"].Value = dr[i]["AccountNo"].ToString();
                    dtbDetail.Rows[i].Cells["Title"].Value = dr[i]["Title"].ToString();
                    dtbDetail.Rows[i].Cells["Debit"].Value = dr[i]["Debit"].ToString();
                    dtbDetail.Rows[i].Cells["Credit"].Value = dr[i]["Credit"].ToString();
                    dtbDetail.Rows[i].Cells["TransNo"].Value = dr[i]["TransNo"].ToString();
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = dr[i]["BranchCode"].ToString();
                }
            }
            CalculateSettlement();
            //            CalculateAmount();
        }
        
        void dtbDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (General.strButtonState == "ADD" || General.strButtonState == "SAVE" || General.strButtonState == "EDIT")
            {

                if (e.KeyValue == 40)
                {
                    if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["SNo"].Value != null)
                    {
                        for (int i = 0; i < dtbDetail.Rows.Count; i++)
                        {
                            if (dtbDetail.Rows[i].Cells["Sno"].Value == null)
                            {
                                dtbDetail.Rows.RemoveAt(i);
                            }
                        }
                        dtbDetail.Rows.Add();
                    }
                }
                if (e.KeyValue == 113)
                {

                    //if (dtbDetail.Columns[dtbDetail.CurrentCell.ColumnIndex].Name == "AccountNo")
                    //{
                    //    frmListSearch childForm = new frmListSearch(dsPopulateCombo.Tables[(int)DataPop.AccountNo], "S", null);
                    //    childForm.ShowDialog();
                    //    dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Sno"].Value = dtbDetail.Rows.Count;
                    //    dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["AccountNo"].Value = frmListSearch.strArg[0];
                    //    dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Title"].Value = frmListSearch.strArg[1];
                    //}
                }
            }
        }

        void dtbDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtbDetail.Columns["Debit"].ToString() == dtbDetail.Columns[e.ColumnIndex].ToString())
            {
                lblCalculate.Text = "0";
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    lblCalculate.Text = (Convert.ToDouble(lblCalculate.Text) + Convert.ToDouble(dtbDetail.Rows[i].Cells["Debit"].Value)).ToString();
                }
            }
            if (dtbDetail.Columns["Credit"].ToString() == dtbDetail.Columns[e.ColumnIndex].ToString())
            {
                lblCredit.Text = "0";
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    lblCredit.Text = (Convert.ToDouble(lblCredit.Text) + Convert.ToDouble(dtbDetail.Rows[i].Cells["Credit"].Value)).ToString();
                }
            }
        }
        
        #region IToolBar Members
        public bool HISTORY()
        {
            return true;
        }
        public bool ADD()
        {

            strButtonState = "ADD";
            dicboAccount.SelectedValue = cls.strControlAccount("CashinHand");
            strFormButton = General.strStateAddEDIT;
            dinumTTQuantity.Enabled = false;
            dinumTTRate.Enabled = false;
            dicboCurrency.Enabled = false;
            donumTTAmount.Enabled = false;
            //donumBaseRate.Enabled = false;
            dicboTransType.Focus();
            ditxtTransNo.Enabled = false;
            dicboNostro.Enabled = false;
            dicboReportBranch.Enabled = false;
            dotxtReportNo.Enabled = false;
            dtTransDate.Enabled = false;
            dicboReportBranch.SelectedValue = General.strHeadOfficeCode;
            rdoIN.Checked = true;
            dtTransDate.Value = General.dtSystemDate;
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
                ditxtTransNo.Text = ditxtTransNo.Text = "SO-" + cls.GetTransNo(strTransType) + "-" + General.strBranchCode;
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                }
            }
            dtbDetail.Rows.Clear();
            
            if (General.strBranchCode != General.strHeadOfficeCode)
            {

                int i = 0;
              //  dotxtReportNo.Text = ditxtTransNo.Text;
                dtbDetail.Rows.Add();
                dtbDetail.Rows[i].Cells["Sno"].Value = 0;
                dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                dtbDetail.Rows[i].Cells["AccountNo"].Value = cls.strControlAccount("HeadOffice");
                dtbDetail.Rows[i].Cells["DEBIT"].Value = (donumAmount.Value + donumHOCharges.Value);
                dtbDetail.Rows[i].Cells["CREDIT"].Value = 0;
                dtbDetail.Rows.Add();
                i = i + 1;
                dtbDetail.Rows[i].Cells["Sno"].Value = 1;
                dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                dtbDetail.Rows[i].Cells["AccountNo"].Value = dicboAccount.SelectedValue;
                dtbDetail.Rows[i].Cells["DEBIT"].Value = 0;
                dtbDetail.Rows[i].Cells["CREDIT"].Value = ((donumAmount.Value) - donumCharges.Value) + (donumRate.Value - dinumBaseRate.Value) * donumQty.Value;
                i = i + 1;
                if (donumHOCharges.Value > 0)
                {
                    dtbDetail.Rows.Add();
                    dtbDetail.Rows[i].Cells["Sno"].Value = 2;
                    dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                    dtbDetail.Rows[i].Cells["AccountNo"].Value = dicboAccount.SelectedValue;
                    dtbDetail.Rows[i].Cells["DEBIT"].Value = 0;
                    dtbDetail.Rows[i].Cells["CREDIT"].Value = donumHOCharges.Value;
                    i = i + 1;
                }
                if ((donumRate.Value-dinumBaseRate.Value)*donumQty.Value != 0)
                {
                    dtbDetail.Rows.Add();
                    dtbDetail.Rows[i].Cells["Sno"].Value = 3;
                    dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                    dtbDetail.Rows[i].Cells["AccountNo"].Value = cls.strControlAccount("ExchangeGainLoss" + dicboTransType.Text); ;
                    if ((donumRate.Value-dinumBaseRate.Value)*donumQty.Value < 0)
                    {
                        dtbDetail.Rows[i].Cells["CREDIT"].Value = Math.Abs((donumRate.Value - dinumBaseRate.Value) * donumQty.Value);
                        dtbDetail.Rows[i].Cells["DEBIT"].Value = 0;
                    }
                    else
                    {
                        dtbDetail.Rows[i].Cells["CREDIT"].Value = 0;
                        dtbDetail.Rows[i].Cells["DEBIT"].Value = (donumRate.Value - dinumBaseRate.Value) * donumQty.Value;
                    }
                    i = i + 1;   
                }
                dtbDetail.Rows.Add();
                dtbDetail.Rows[i].Cells["Sno"].Value = 4;
                dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                dtbDetail.Rows[i].Cells["AccountNo"].Value = cls.strControlAccount(dicboTransType.Text+"Charges");
                dtbDetail.Rows[i].Cells["DEBIT"].Value = 0;
                dtbDetail.Rows[i].Cells["CREDIT"].Value = donumCharges.Value;
                dtbDetail.Rows.Add();


            }

            if (ValidatingControls() == true)
            {
                strCondition = "Where TransNo = '" + ditxtTransNo.Text + "' and BranchCode = '" + General.strBranchCode + "'";
                ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "UserId=" + General.strUserId + ";BranchCode=" + General.strBranchCode + "");
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
            strFormButton = General.strStateAddEDIT;
            strButtonState = "EDIT";
            dinumTTQuantity.Enabled = false;
            dinumTTRate.Enabled = false;
            dtTransDate.Enabled = false;
            dicboCurrency.Enabled = false;
            donumTTAmount.Enabled = false;
            //donumBaseRate.Enabled = false;
            dicboTransType.Focus();
            ditxtTransNo.Enabled = false;
            dicboNostro.Enabled = false;
            return true;
        }

        public bool QUERY()
        {
            
            strFormButton = General.strStateALL;
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_TransStopOver a " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "' ";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
               // strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            }
            strQuery = strQuery + " ;Select c.Sno,c.TransNo,c.AccountNo,c.Debit,c.Credit,b.Title,c.BranchCode from EX_TransStopOverDetail c  Inner Join EX_TransStopOver a on a.TransNo = c.TransNo and a.BranchCode = c.BranchCode and a.RecNo = c.RecNo  Inner Join EX_SetupAccount b on c.Accountno = b.AccountNo and c.BranchCode = b.BranchCode and b.Status = 'A' Where c.BranchCode = '" + General.strBranchCode + "'";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
              //  strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            }
            ds = objGetData.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtSearchDetail = ds.Tables[1];
            dtbMaster.DataSource = dtSearchMaster;
            if (dtSearchMaster.Rows.Count > 0)
            {
                cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
            }
            strButtonState = "QUERY";
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            populateTTDDCombo();
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
            strCondition = "Where TransNo = '" + ditxtTransNo.Text + "'";
            if (General.dtSystemDate == dtTransDate.Value)
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
                if (ditxtTransNo.Text != "")
                {
                    cls = new General();
                    cls.GenerateVoucher("SO", ditxtTransNo.Text);
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
            strButtonState = "PRINT";
            return true;
        }

        #endregion
        
        private void CalculateCharges()
        {
            donumAmount.Value = donumQty.Value * donumRate.Value;
            donumTTAmount.Value = dinumTTQuantity.Value * dinumTTRate.Value;   
            donumCharges.Value = donumChQty.Value * donumRate.Value;
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
            //lblCalculate.Text = "0";
            //lblCredit.Text = "0";
            //for (int i = 0; i < dtbDetail.Rows.Count ; i++)
            //{

            //    lblCalculate.Text = (Convert.ToDouble(lblCalculate.Text) + Convert.ToDouble(dtbDetail.Rows[i].Cells["Debit"].Value)).ToString();
            //}
            //for (int i = 0; i < dtbDetail.Rows.Count; i++)
            //{
            //    lblCredit.Text = (Convert.ToDouble(lblCredit.Text) + Convert.ToDouble(dtbDetail.Rows[i].Cells["Credit"].Value)).ToString();
            //}

            //if (Convert.ToDecimal(lblCalculate.Text.ToString()) != dinumTotalAmountRec.Value)
            //{
            //    strError = "Settlement Amount Should be Equal to Total Amount Rec";
            //    bolState = false;
            //}
            //else
            //{
            //    bolState = true;
            //}
            return bolState;
        }
        
        //private void MakeSettlement()
        //{
        //    dtbDetail.Rows.Clear();
        //    if (dtbDetail.Rows.Count == 0)
        //    {
        //        dtbDetail.Rows.Add();
        //    }

        //    string strValue = dicboPaymentMode.SelectedValue.ToString();//cls.strControlAccount("CashinHand");
        //    dtbDetail.Rows[0].Cells["AccountNo"].Value = strValue;
        //    DataRow[] dRow = dsPopulateCombo.Tables[(int)DataPop.AccountNo].Select("AccountNo = '" + strValue + "'");
        //    if (dRow.Count() > 0)
        //    {
        //        dtbDetail.Rows[0].Cells["Sno"].Value = 1;
        //        dtbDetail.Rows[0].Cells["Title"].Value = dRow[0]["Title"].ToString();
        //        dtbDetail.Rows[0].Cells["Debit"].Value = dinumTotalAmountRec.Value;
        //        dtbDetail.Rows[0].Cells["Credit"].Value = 0;
        //        lblCalculate.Text = dinumTotalAmountRec.Value.ToString();
        //    }
        //}

        private void frmTransStopTTDD_Activated(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
         
        }

        private void dicboTransType_Validated(object sender, EventArgs e)
        {
            populateTTDDCombo();
        }
        
        private void populateTTDDCombo()
        {
            string strTable="";
            if (rdoOut.Checked == true)
            {
                docboTransNo.Enabled = false;
                label4.Enabled = false;
                dinumTTQuantity.Enabled = true;
                dinumTTRate.Enabled = true;
                dicboCurrency.Enabled = true;
                donumTTAmount.Enabled = true;
                dinumTTQuantity.Value = 0;
                dinumTTRate.Value = 0;
                donumTTAmount.Value = 0;
                docboTransNo.DataSource = null;
                dicboNostro.Enabled = true;
            }
            else if (rdoIN.Checked == true)
            {
                docboTransNo.Enabled = true;
                dicboNostro.Enabled = false;
                label4.Enabled = true;
                if (dicboTransType.Text == "DD")
                {
                    strTable = "EX_DDIssuance";
                }
                else if (dicboTransType.Text == "TT")
                {
                    strTable = "EX_TTIssuance";
                }
                string strQuery = "Select * from " + strTable + " Where Status = 'A' and BranchCode = '" + General.strBranchCode + "' and TransDate = '"+ dtSearchDate.Value.ToString("dd/MMM/yyyy") +"'";
                dsMainTable = new DataSet();
                cls = new General();
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                dsMainTable = objGetData.GetDataSet(strQuery);
                cls.PopulateCombo(docboTransNo, dsMainTable.Tables[0], "TransNo", "TransNo");
                dinumTTQuantity.Enabled = false;
                dinumTTRate.Enabled = false;
                dicboCurrency.Enabled = false;
                donumTTAmount.Enabled = false;
            }
        }

        private void dicboTransNo_Validated(object sender, EventArgs e)
        {
            if (docboTransNo.Text != "" && docboTransNo.Text != null)
            {
                DataRow[] dr = new DataRow[0];
                dr = dsMainTable.Tables[0].Select("TransNo = '" + docboTransNo.Text + "'", "TransNo");
                dicboCurrency.SelectedValue = dr[0]["CurrencyCode"];
                dinumTTQuantity.Value = Convert.ToDecimal(dr[0]["Quantity"].ToString());
                dinumTTRate.Value = Convert.ToDecimal(dr[0]["Rate"].ToString());
                donumTTAmount.Value = Convert.ToDecimal(dr[0]["Amount"].ToString());
                donumAmount.Value = Convert.ToDecimal(dr[0]["Amount"].ToString());
                donumQty.Value = Convert.ToDecimal(dr[0]["Quantity"].ToString());
                donumRate.Value = Convert.ToDecimal(dr[0]["Rate"].ToString());
                //donumAmount.Value = Convert.ToDecimal(dr[0]["Amount"].ToString());
                //donumBaseRate.Value = Convert.ToDecimal(dr[0]["BaseRate"].ToString());
                donumBranchCharges.Value = Convert.ToDecimal(dr[0]["Charges"].ToString());
                donumHOCharges.Value = Convert.ToDecimal(dr[0]["HOCharges"].ToString());
                dicboNostro.SelectedValue = dr[0]["HOBank"];
                dotxtRemarks.Text = dicboTransType.Text + " Stop For " + dr[0]["APPNAME"].ToString() + " of " + dr[0]["Quantity"].ToString() + " for " + dicboCurrency.Text + "  " + dr[0]["Amount"].ToString();
            }
        }

        private void donumQty_Validating(object sender, CancelEventArgs e)
        {
            CalculateCharges();
        }

        private void donumRate_Validating(object sender, CancelEventArgs e)
        {
            CalculateCharges();
        }

        private void donumChQty_Validating(object sender, CancelEventArgs e)
        {
            CalculateCharges();
        }

        private void dinumTTQuantity_Validating(object sender, CancelEventArgs e)
        {
            CalculateCharges();
            donumQty.Value = dinumTTQuantity.Value;
            donumAmount.Value = donumTTAmount.Value;
        }

        private void dinumTTRate_Validating(object sender, CancelEventArgs e)
        {
            CalculateCharges();
            donumRate.Value = dinumTTRate.Value;
            donumAmount.Value = donumTTAmount.Value;
        }

        private void rdoIN_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoOut_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtSearchDate_Validating(object sender, CancelEventArgs e)
        {
            populateTTDDCombo();
        }
    }
}
