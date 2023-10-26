using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExchangeCompanySoftware.Reports;

namespace ExchangeCompanySoftware
{
    public partial class frmDDIssue : BaseForm,IToolBar
    {
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataTable dtSearchMaster;
        enum DataPop { Purpose,Country,Branch, Party ,Currency,OrgCurrency,AccountNo,PaymentMode};

        string strButtonState = null;
        string strTransType = "DDIS";
        public string strError = "";
        string strFormButton;
        string strCondition;
        DataSet dsPopulateCombo;
        DataTable dtSearchDetail;
        private void populateCombo()
        {
            string strQuery = "Select * from EX_SetupPurpose Where Status = 'A';Select * from EX_System Where Flag = 'S';Select * from EX_Branch;Select * from EX_SetupCustomer Where Status = 'A';Select * from EX_SetupItems Where Status = 'A';Select * from EX_SetupItems Where Status = 'A';Select AccountNo,Title from EX_SetupAccount Where BranchCode = '" + General.strHeadOfficeCode + "' and isTransactional = 'True' and Locked = 'false' and Status = 'A' and CurrencyCode != (Select Description from EX_SYstem Where Flag = 'BC') order by Title;Select * from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Status = 'A' and isTransactional = 'True' order by Title";
            dsPopulateCombo = new DataSet();
            cls = new General();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicboReportBranch, dsPopulateCombo.Tables[(int)DataPop.Branch], "BranchName", "BranchCode");
            cls.PopulateCombo(dicboCountry, dsPopulateCombo.Tables[(int)DataPop.Country], "Description", "Code");
            cls.PopulateCombo(dicboPurpose, dsPopulateCombo.Tables[(int)DataPop.Purpose], "Purpose", "PurposeCode");
            cls.PopulateCombo(dicboparty, dsPopulateCombo.Tables[(int)DataPop.Party], "CustName", "CustCode");
            cls.PopulateCombo(dicboCurrency , dsPopulateCombo.Tables[(int)DataPop.Currency], "ShortName", "ItemCode");
            cls.PopulateCombo(dicboOrgCurrency, dsPopulateCombo.Tables[(int)DataPop.OrgCurrency], "ShortName", "ItemCode");
            cls.PopulateCombo(dicboHoBank, dsPopulateCombo.Tables[(int)DataPop.AccountNo], "Title", "AccountNo");
            cls.PopulateCombo(dicboPaymentMode, dsPopulateCombo.Tables[(int)DataPop.PaymentMode], "Title", "AccountNo");                
        }
        public frmDDIssue()
        {
            InitializeComponent();
        }
        private void Calculate()
        {
            if (dinumQuantity.Value > 0 || dinumRate.Value > 0)
            {
                dinumAmount.Value = dinumQuantity.Value * dinumRate.Value;
            }
            dinumTotalAmountRec.Value = dinumAmount.Value + donumHOCharges.Value + donumTTCharges.Value + donumWHT.Value;
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
        private void frmTTIssue_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            cls.EnableDisble(PnlMain, false);
            General.strTableName[0] = "EX_DDIssuance";
            General.strTableName[1] = "EX_DDIssuanceDetail";
            General.strPKColumn = "TransNo";
            General.strAuthorizeTableName = General.strTableName[0];
            populateCombo();
            AddColumninDetailGrid();
            dtDate.Value = General.dtSystemDate;

            dinumAmount.DecimalPlaces = 0;
            donumHOCharges.DecimalPlaces = 0;
            donumTTCharges.DecimalPlaces = 0;
            dinumTotalAmountRec.DecimalPlaces = 0;

            dtbDetail.KeyDown += new KeyEventHandler(dtbDetail_KeyDown);
            dtbDetail.CellEndEdit +=new DataGridViewCellEventHandler(dtbDetail_CellEndEdit);
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
            clmnDebit.DefaultCellStyle.Format = "N0";
            clmnDebit.ValueType = typeof(System.Double);
            clmnDebit.DefaultCellStyle.NullValue = "0";
            clmnDebit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnDebit.Width = 100;
            dtbDetail.Columns.Add(clmnDebit);


            DataGridViewTextBoxColumn clmnCredit = new DataGridViewTextBoxColumn();
            clmnCredit.Name = "Credit";
            clmnCredit.HeaderText = "Credit";
            clmnCredit.DefaultCellStyle.Format = "N0";
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
                CheckTTDDStopped(ditxtTransNo.Text);
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

                    if (dtbDetail.Columns[dtbDetail.CurrentCell.ColumnIndex].Name == "AccountNo")
                    {
                        frmListSearch childForm = new frmListSearch(dsPopulateCombo.Tables[(int)DataPop.AccountNo], "S", null);
                        childForm.ShowDialog();
                        dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Sno"].Value = dtbDetail.Rows.Count;
                        dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["AccountNo"].Value = frmListSearch.strArg[0];
                        dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Title"].Value = frmListSearch.strArg[1];
                    }
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
           
            ditxtFTTNo.Focus();
            ditxtTransNo.Enabled = false;
            strButtonState = "ADD";
            dinumAmount.Enabled = false;
            dinumTotalAmountRec.Enabled = false;
            strFormButton = General.strStateAddEDIT;
            dicboReportBranch.Enabled = false;
            dotxtReportNo.Enabled = false;
            dicboReportBranch.SelectedValue = General.strHeadOfficeCode;
            dicboPaymentMode.SelectedValue = cls.strControlAccount("CashinHand");
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
                ditxtTransNo.Text = ditxtTransNo.Text = "DD-" + cls.GetTransNo(strTransType) + "-" + General.strBranchCode;
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                }
            }
            string strRemarls = "DD Issue for " + ditxtAppfavour.Text + " of " + dinumQuantity.Value.ToString() + " for " + dicboCurrency.Text + " of " + dinumTotalAmountRec.Value.ToString();
            dtbDetail.Rows.Clear();
            if (General.strBranchCode != General.strHeadOfficeCode)
            {
              
                dotxtReportNo.Text = ditxtTransNo.Text;
                dtbDetail.Rows.Add();
                dtbDetail.Rows[0].Cells["Sno"].Value = 0;
                dtbDetail.Rows[0].Cells["TransNo"].Value = ditxtTransNo.Text;
                dtbDetail.Rows[0].Cells["BranchCode"].Value = General.strBranchCode;
                dtbDetail.Rows[0].Cells["AccountNo"].Value = dicboPaymentMode.SelectedValue.ToString();
                dtbDetail.Rows[0].Cells["DEBIT"].Value = dinumTotalAmountRec.Value.ToString();
                dtbDetail.Rows[0].Cells["CREDIT"].Value = 0;
                dtbDetail.Rows.Add();

                dtbDetail.Rows[1].Cells["Sno"].Value = 1;
                dtbDetail.Rows[1].Cells["TransNo"].Value = ditxtTransNo.Text;
                dtbDetail.Rows[1].Cells["BranchCode"].Value = General.strBranchCode;
                dtbDetail.Rows[1].Cells["AccountNo"].Value = cls.strControlAccount("ExchangeGainLossDD");
                decimal dblProfitLoss = (dinumRate.Value - dinumBaseRate.Value) * dinumQuantity.Value;
                if (dblProfitLoss < 0)
                {
                    dtbDetail.Rows[1].Cells["DEBIT"].Value = -dblProfitLoss;
                    dtbDetail.Rows[1].Cells["CREDIT"].Value = 0;
                }
                else
                {
                    dtbDetail.Rows[1].Cells["DEBIT"].Value = 0;
                    dtbDetail.Rows[1].Cells["CREDIT"].Value = dblProfitLoss;
                }

                dtbDetail.Rows.Add();
                dtbDetail.Rows[2].Cells["Sno"].Value = 2;
                dtbDetail.Rows[2].Cells["TransNo"].Value = ditxtTransNo.Text;
                dtbDetail.Rows[2].Cells["BranchCode"].Value = General.strBranchCode;
                dtbDetail.Rows[2].Cells["AccountNo"].Value = cls.strControlAccount("DDCharges");
                dtbDetail.Rows[2].Cells["DEBIT"].Value = 0;
                dtbDetail.Rows[2].Cells["CREDIT"].Value = donumTTCharges.Value;
                dtbDetail.Rows.Add();

                dtbDetail.Rows[3].Cells["Sno"].Value = 3;
                dtbDetail.Rows[3].Cells["TransNo"].Value = ditxtTransNo.Text;
                dtbDetail.Rows[3].Cells["BranchCode"].Value = General.strBranchCode;
                dtbDetail.Rows[3].Cells["AccountNo"].Value = cls.strControlAccount("HeadOffice");
                dtbDetail.Rows[3].Cells["DEBIT"].Value = 0;
                dtbDetail.Rows[3].Cells["CREDIT"].Value = ((dinumTotalAmountRec.Value - (dinumRate.Value - dinumBaseRate.Value) * dinumQuantity.Value) - donumTTCharges.Value) - donumWHT.Value;
                if (donumWHT.Value > 0)
                {
                    dtbDetail.Rows.Add();
                    dtbDetail.Rows[4].Cells["Sno"].Value = 4;
                    dtbDetail.Rows[4].Cells["TransNo"].Value = ditxtTransNo.Text;
                    dtbDetail.Rows[4].Cells["BranchCode"].Value = General.strBranchCode;
                    dtbDetail.Rows[4].Cells["AccountNo"].Value = cls.strControlAccount("WHT");
                    dtbDetail.Rows[4].Cells["DEBIT"].Value = 0;
                    dtbDetail.Rows[4].Cells["CREDIT"].Value = donumWHT.Value;
                }
            }
            
            if (ValidatingControls() == true)
            {
                strCondition = "Where TransNo = '" + ditxtTransNo.Text + "' and BranchCode = '"+ General.strBranchCode +"'";
                ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "UserId=" + General.strUserId + ";BranchCode=" + General.strBranchCode + ";Remarks="+ strRemarls +"");
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
            if (pnlNavigation.Visible == false)
            {
                ditxtTransNo.Enabled = false;
                dicboReportBranch.Enabled = false;
                dotxtReportNo.Enabled = false;
                strFormButton = General.strStateAddEDIT;
                strButtonState = "EDIT";
                dinumAmount.Enabled = false;
                dinumTotalAmountRec.Enabled = false;
            }
            return true;
        }

        public bool QUERY()
        {
            strFormButton = General.strStateALL;
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_DDIssuance a " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "' ";

            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate + "'";
            }
            strQuery = strQuery + " ;Select c.Sno,c.TransNo,c.AccountNo,c.Debit,c.Credit,b.Title,c.BranchCode from EX_DDIssuanceDetail c  Inner Join EX_DDIssuance a on a.TransNo = c.TransNo and a.BranchCode = c.BranchCode and a.RecNo = c.RecNo  Inner Join EX_SetupAccount b on c.Accountno = b.AccountNo and c.BranchCode = b.BranchCode and b.Status = 'A' Where a.BranchCode = '" + General.strBranchCode + "'";

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
            dtSearchDetail = ds.Tables[1];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
            strButtonState = "QUERY";
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            dtbMaster_SelectionChanged(dtbMaster, null);
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
            if (pnlNavigation.Visible == false)
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
            }
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
                    objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                    DataTable dtb = new DataTable();

                    string strQuery = " Select * from ( ";
                    strQuery = strQuery + " Select a.TransNo,FDDNo,AppName, ";
                    strQuery = strQuery + " AppAddress,AppPhone,AppNic,AppSWD,Favour,Rate,Quantity,Amount,AmountRec,BaseRate, ";
                    strQuery = strQuery + " HOCharges,Charges,WHT,HOBANK,a.TransDate,a.Remarks, ";
                    strQuery = strQuery + " k.Title as AccountName,b.Debit,b.Credit ";
                    strQuery = strQuery + " ,e.ItemName,e.ShortName,f.Description,g.Purpose,h.CustName,i.Title as BANKNAME ";
                    strQuery = strQuery + " from EX_DDIssuance a ";
                    strQuery = strQuery + " Inner Join EX_DDIssuanceDetail b on a.TransNo = b.TransNo and a.BranchCode = b.BranchCode and a.RecNo = b.RecNo ";
                    strQuery = strQuery + " Inner Join EX_Branch c on a.ReportBranch = c.BranchCode  ";
                    strQuery = strQuery + " Inner Join EX_Branch d on a.BranchCode = d.BranchCode  ";
                    strQuery = strQuery + " Inner Join EX_SetupItems e on a.CurrencyCode = e.ItemCOde and e.Status = 'A' ";
                    strQuery = strQuery + " Inner Join EX_System f on a.CountryCode = f.Code and f.Flag = 'S' ";
                    strQuery = strQuery + " Inner Join EX_SetupPurpose g on a.PurposeCode = g.PurposeCode  and g.Status = 'A' ";
                    strQuery = strQuery + " Inner Join EX_SetupCustomer h on a.PartyCode = h.CustCode and h.Status = 'A' ";
                    strQuery = strQuery + " Left Outer Join EX_SetupAccount i on a.HOBank = i.AccountNo and i.Status = 'A' and i.BranchCode = a.BranchCode ";
                    strQuery = strQuery + " Inner Join EX_SetupAccount k on b.AccountNo = k.AccountNo and k.Status = 'A' and k.BranchCode = a.BranchCode ";
                    strQuery = strQuery + " Inner Join EX_SetupItems j on a.ORGCurrencyCode = j.ItemCOde and j.Status = 'A' ";
                    strQuery = strQuery + " Where a.BranchCode = '" + General.strBranchCode + "' ";
                    strQuery = strQuery + " )qry ";
                    strQuery = strQuery + " Where TransNo = '" + ditxtTransNo.Text + "'  ";



                    dtb = objGetData.GetDataSet(strQuery).Tables[0];
                    rptDDTicket devrep = new rptDDTicket();
                    dtb = objGetData.GetDataSet(strQuery).Tables[0];
                    devrep.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
                    devrep.DataSource = dtb;
                    devrep.Parameters["UserId"].Value = General.strUserId;
                    devrep.Parameters["ReportName"].Value = General.strReportCaption + " Voucher";
                    devrep.Parameters["CompanyName"].Value = General.strCompanyName;
                    devrep.Parameters["BranchName"].Value = General.strBranchName;
                    devrep.Parameters["Criteria"].Value = "";
                    devrep.RequestParameters = false;
                    devrep.CreateDocument();
                    devrep.ShowPreview();

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
        private void dinumRate_Validated(object sender, EventArgs e)
        {
            Calculate();
        }

        private void dinumQuantity_Validated(object sender, EventArgs e)
        {
            Calculate();
        }
        private void MakeSettlement()
        {
            dtbDetail.Rows.Clear();
            if (dtbDetail.Rows.Count == 0)
            {
                dtbDetail.Rows.Add();
            }

            string strValue = dicboPaymentMode.SelectedValue.ToString();//cls.strControlAccount("CashinHand");
            dtbDetail.Rows[0].Cells["AccountNo"].Value = strValue;
            DataRow[] dRow = dsPopulateCombo.Tables[(int)DataPop.AccountNo].Select("AccountNo = '" + strValue + "'");
            if (dRow.Count() > 0)
            {
                dtbDetail.Rows[0].Cells["Sno"].Value = 1;
                dtbDetail.Rows[0].Cells["Title"].Value = dRow[0]["Title"].ToString();
                dtbDetail.Rows[0].Cells["Debit"].Value = dinumTotalAmountRec.Value;
                dtbDetail.Rows[0].Cells["Credit"].Value = 0;
                lblCalculate.Text = dinumTotalAmountRec.Value.ToString();
            }
        }
        private void dicboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CheckTTDDStopped(string strTransNo)
        {
            string strQuery = "Select * from EX_TransStopOver Where ORGTransNo = '" + strTransNo + "' and Status in ('U','A')";
            DataTable dtb = new DataTable();
            cls = new General();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dtb = objGetData.GetDataSet(strQuery).Tables[0];
            if (dtb.Rows.Count > 0)
            {
                pnlNavigation.Visible = true;
            }
            else
            {
                pnlNavigation.Visible = false;
            }
        }
        private void donumTTCharges_Validated(object sender, EventArgs e)
        {
            Calculate();
           
        }

        private void donumHOCharges_Validated(object sender, EventArgs e)
        {
            Calculate();
            MakeSettlement();
        }

        private void dtbDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dicboCurrency_Validated(object sender, EventArgs e)
        {
            if (dicboCurrency.Text != "")
            {
                DataSet ds = new DataSet();
                cls = new General();
                string strQry = "Select AccountNo,Title from EX_SetupAccount Where BranchCode = '" + General.strHeadOfficeCode +"' and isTransactional = 'True' and Locked = 'false' and Status = 'A' and CurrencyCode = '"+ dicboCurrency.SelectedValue +"'";
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                ds = objGetData.GetDataSet(strQry);
                cls.PopulateCombo(dicboHoBank, ds.Tables[0], "Title", "AccountNo");                
            }

        }

        private void frmDDIssue_Activated(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }

        private void donumWHT_Validating(object sender, CancelEventArgs e)
        {
            Calculate();
        }

        
    }
}
