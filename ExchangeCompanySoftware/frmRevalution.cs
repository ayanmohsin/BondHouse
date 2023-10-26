using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraReports.UI;
namespace ExchangeCompanySoftware
{
    public partial class frmRevalution : BaseForm,IToolBar
    {
       
        General cls;
        DataTable dtSearchMaster;
        enum DataPop { VT, Party, Currency, AccountNo };
        string strButtonState = null;
        string strTransType = "REVALUE";
        public string strError = "";
        string strFormButton;
        string strCondition;
        DataSet dsPopulateCombo;
        DataTable dtSearchDetail;
        MainForm Mainfrm;
        public frmRevalution()
        {
            InitializeComponent();
        }

        private void AddColumninDetailGrid()
        {

            DataGridViewTextBoxColumn clmnSno = new DataGridViewTextBoxColumn();
            clmnSno.Name = "Sno";
            clmnSno.HeaderText = "Sno";
            clmnSno.Width = 40;
            clmnSno.ReadOnly = true;
            clmnSno.Visible = false;
            dtbDetail.Columns.Add(clmnSno);

         
         
            DataGridViewTextBoxColumn clmnAccount = new DataGridViewTextBoxColumn();
            clmnAccount.Name = "Account";
            clmnAccount.HeaderText = "Account";
            clmnAccount.Width = 0;
            clmnAccount.ReadOnly = true;
            dtbDetail.Columns.Add(clmnAccount);

            DataGridViewTextBoxColumn clmnSymbol = new DataGridViewTextBoxColumn();
            clmnSymbol.Name = "Symbol";
            clmnSymbol.HeaderText = "Symbol";
            clmnSymbol.Width = 50;
            clmnSymbol.ReadOnly = true;
            clmnSymbol.Visible= false;
            dtbDetail.Columns.Add(clmnSymbol);


            DataGridViewTextBoxColumn cboTitle = new DataGridViewTextBoxColumn();
            cboTitle.Name = "ItemName";
            cboTitle.HeaderText = "Currency";
            cboTitle.Width = 100;
            cboTitle.ReadOnly = true;
            dtbDetail.Columns.Add(cboTitle);

            DataGridViewTextBoxColumn clmnitCode = new DataGridViewTextBoxColumn();
            clmnitCode.Name = "ItemCode";
            clmnitCode.HeaderText = "Code";
            clmnitCode.Width = 0;
            clmnitCode.Visible = false;
            clmnitCode.ReadOnly = true;
            dtbDetail.Columns.Add(clmnitCode);

            DataGridViewTextBoxColumn clmnAccountNo = new DataGridViewTextBoxColumn();
            clmnAccountNo.Name = "AccountNo";
            clmnAccountNo.HeaderText = "AccountNo";
            clmnAccountNo.Width = 0;
            clmnAccountNo.Visible = false;
            clmnAccountNo.ReadOnly = true;
            dtbDetail.Columns.Add(clmnAccountNo);


            DataGridViewTextBoxColumn clmnQty = new DataGridViewTextBoxColumn();
            clmnQty.Name = "Quantity";
            clmnQty.HeaderText = "Quantity";
            clmnQty.DefaultCellStyle.Format = "N4";
            clmnQty.ValueType = typeof(System.Double);
            clmnQty.DefaultCellStyle.NullValue = "0";
            clmnQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnQty.Width = 100;
            clmnQty.ReadOnly = true;
            dtbDetail.Columns.Add(clmnQty);

            DataGridViewTextBoxColumn clmnRate = new DataGridViewTextBoxColumn();
            clmnRate.Name = "Rate";
            clmnRate.HeaderText = "Rate";
            clmnRate.DefaultCellStyle.Format = "N6";
            clmnRate.ValueType = typeof(System.Double);
            clmnRate.DefaultCellStyle.NullValue = "0";
            clmnRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnRate.Width = 70;
            clmnRate.ReadOnly = true;
            dtbDetail.Columns.Add(clmnRate);

            DataGridViewTextBoxColumn clmnAmount = new DataGridViewTextBoxColumn();
            clmnAmount.Name = "Amount";
            clmnAmount.HeaderText = "Amount";
            clmnAmount.DefaultCellStyle.Format = "N2";
            clmnAmount.ValueType = typeof(System.Double);
            clmnAmount.DefaultCellStyle.NullValue = "0";
            clmnAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnAmount.Width = 100;
            clmnAmount.ReadOnly = true;
            dtbDetail.Columns.Add(clmnAmount);

            DataGridViewTextBoxColumn clmnEQU = new DataGridViewTextBoxColumn();
            clmnEQU.Name = "RevRate";
            clmnEQU.HeaderText = "RevRate";
            clmnEQU.DefaultCellStyle.Format = "N6";
            clmnEQU.ValueType = typeof(System.Double);
            clmnEQU.DefaultCellStyle.NullValue = "0";
            clmnEQU.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnEQU.Width = 70;
            dtbDetail.Columns.Add(clmnEQU);

            DataGridViewTextBoxColumn clmnPL = new DataGridViewTextBoxColumn();
            clmnPL.Name = "ProfitLoss";
            clmnPL.HeaderText = "Profit/Loss";
            clmnPL.DefaultCellStyle.Format = "N2";
            clmnPL.ValueType = typeof(System.Double);
            clmnPL.DefaultCellStyle.NullValue = "0";
            clmnPL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnPL.Width = 80;
            clmnPL.ReadOnly = true;
            dtbDetail.Columns.Add(clmnPL);

            DataGridViewTextBoxColumn clmnVNo = new DataGridViewTextBoxColumn();
            clmnVNo.Name = "TransNo";
            clmnVNo.HeaderText = "TransNo";
            clmnVNo.Width = 0;
            clmnVNo.Visible = false;
            dtbDetail.Columns.Add(clmnVNo);

            DataGridViewTextBoxColumn clmnBranch = new DataGridViewTextBoxColumn();
            clmnBranch.Name = "BranchCode";
            clmnBranch.HeaderText = "BranchCode";
            clmnBranch.Width = 0;
            clmnBranch.Visible = false;
            dtbDetail.Columns.Add(clmnBranch);

       }
        private void frmRevalution_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            cls.EnableDisble(PnlMain, false);
            General.strTableName[0] = "EX_Revaluetion";
            General.strTableName[1] = "EX_RevaluetionDetail";
            General.strPKColumn = "TransNo";
            General.strAuthorizeTableName = General.strTableName[0];
            AddColumninDetailGrid();
            dtDate.Value = General.dtSystemDate;
            dtbMaster.CellValueChanged += new DataGridViewCellEventHandler(dtbMaster_CellValueChanged);
            dtbMaster.CellContentClick += new DataGridViewCellEventHandler(dtbMaster_CellContentClick);
            dtbMaster.RowEnter += new DataGridViewCellEventHandler(dtbMaster_RowEnter);
            Mainfrm = (MainForm)this.ParentForm;
         }

        void dtbMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            PopulateDetail();
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

        #region IToolBar Members
        public bool HISTORY()
        {
            return true;
        }
        public bool ADD()
        {
            DataSet ds = new DataSet();
            DataTable dtb = new DataTable();
            DataTable dtbUnAuth = new DataTable();

            string strQuery = " Select * from EX_Revaluetion Where TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = '" + General.strBranchCode + "' and Status in ('U','A');Select * from VU_UnAuthorizedRecord Where Status > 0 and BranchCode = '" + General.strBranchCode + "'";
            string strError ="";
                General cls = new General();
            ds =cls.GetDataSet(strQuery);
            dtb = ds.Tables[0];
            dtbUnAuth = ds.Tables[1];
  
            if (dtbUnAuth.Rows.Count != 0)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    strError = strError + "\n UN-Authorized Records on ";
                    strError = strError + " \n" + dtbUnAuth.Rows[i]["Form"] + " = " + dtbUnAuth.Rows[i]["Status"] + "";
                }
            }
            if (dtb.Rows.Count != 0)
            {
                    strError = strError + "\nSpot Rates Already have been Entered";
            }
            if (strError == "")
            {
                strButtonState = "ADD";
                strFormButton = General.strStateAddEDIT;
                dotxtRemarks.Focus();
            }
            else
            {
                MessageBox.Show(strError, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainForm Mainfrm = (MainForm)this.ParentForm;
                Mainfrm.EnableDisbale(strButtonState, true, "S");
                cls.EnableDisble(PnlMain, false);

            }
            dtDate.Value = General.dtSystemDate;
            FetchGrid();
            return true;

        }

        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();
            strFormButton = General.strStateALL;
           
            if (strButtonState == "ADD")
            {
                ditxtTransNo.Text = cls.GetTransNo(strTransType);
              
            }
            if (ValidatingControls() == true)
            {
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    dtbDetail.Rows[i].Cells["Sno"].Value = i;
                    dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                }
                strCondition = "Where TransNo = '" + ditxtTransNo.Text + "' and BranchCode = '" + General.strBranchCode + "'";
                ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "UserId=" + General.strUserId + ";BranchCode=" + General.strBranchCode + "");
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
                strButtonState = "SAVE";
                cls.EnableDisble(PnlMain, false);
                Mainfrm.EnableDisbale(strButtonState, true, "S");
                return true;
            }
            else
            {
                MessageBox.Show(strError, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                General.strButtonState = strButtonState;
                Mainfrm.EnableDisbale(strButtonState, true, "S");
                return false;
            }

        }

        public bool EDIT()
        {
            ditxtTransNo.Enabled = false;
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
            strQuery = " Select * from EX_Revaluetion a " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "' ";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            }
            strQuery = strQuery + " ;Select e.Sno,f.AccountNo,f.Title,e.TransNo,e.ItemCode,e.Quantity,e.Amount,e.Rate,e.RevRate,ProfitLoss,d.ItemName,d.ShortName,e.BranchCode from EX_RevaluetionDetail e Inner Join EX_Revaluetion a on a.TransNo = e.TransNo and a.RecNo = e.RecNo and a.BranchCode = e.BranchCode Inner Join EX_SetupItems d on d.ItemCode = e.ItemCode and d.Status = 'A' Inner Join EX_SetupAccount f on e.AccountNo = f.AccountNo and e.BranchCode = f.BranchCode and f.Status = 'A'   Where e.BranchCode = '" + General.strBranchCode + "'";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            }
            ds =cls.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtSearchDetail = ds.Tables[1];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
            strButtonState = "QUERY";
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            PopulateDetail();
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
                if (ditxtTransNo.Text != "")
                {
                        General cls = new General();
                    DataTable dtb = new DataTable();


                     
                    string strQuery = " SELECT a.TransNo,a.TransDate,ShortName,ItemName,Revrate,BranchName ";
                    strQuery = strQuery + " FROM EX_Revaluetion A ";
                    strQuery = strQuery + " iNNER JOIN EX_RevaluetionDetail b on a.TransNo = b.TransNo and a.BranchCode = b.BranchCode and a.recNo = b.Recno ";
                    strQuery = strQuery + " inner join ex_setupItems c on b.ItemCode = c.ItemCode and c.Status = 'A' ";
                    strQuery = strQuery + " inner join EX_Branch d on a.Branchcode = d.Branchcode ";
                    strQuery = strQuery + " Where a.Status = 'A' ";
                    strQuery = strQuery + " and a.TransNo = '" + ditxtTransNo.Text + "'  ";
                    strQuery = strQuery + " and a.BranchCode = '" + General.strBranchCode + "' order by ItemName";

                    dtb =cls.GetDataSet(strQuery).Tables[0];
                    rptSpotRate devrep = new rptSpotRate();
                    dtb =cls.GetDataSet(strQuery).Tables[0];
                    devrep.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
                    devrep.DataSource = dtb;
                    devrep.Parameters["UserId"].Value = General.strUserId;
                    devrep.Parameters["ReportName"].Value = " Spot Rate History";
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
            cls.StrMessage = "";
            Boolean bolState;

            cls.Validate(PnlMain);
            //for (int i = 0; i < dtbDetail.Rows.Count ; i++)
            //{
            //    if (dtbDetail.Rows[i].Cells["RevRate"].Value != null)
            //    {
            //        if (dtbDetail.Rows[i].Cells["RevRate"].Value.ToString() == "0" || dtbDetail.Rows[i].Cells["RevRate"].Value.ToString() == "")
            //        {
            //            strError = strError + "\n" + "Amount Should not be 0 on line no " + i + "";
            //            dtbDetail.Rows[i].Cells["RevRate"].Selected = true;
            //            bolState = false;
            //            cls.StrMessage = strError;
            //        }
            //    }
            //    else
            //    {
            //        strError = strError + "\n" + "Amount Should not be 0 on line no " + i + "";
            //        dtbDetail.Rows[i].Cells["RevRate"].Selected = true;
            //        bolState = false;
            //        cls.StrMessage = strError;
            //    }
            //}
           
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
        void dtbMaster_SelectionChanged(object sender, EventArgs e)
        {
            PopulateDetail();
            //            CalculateAmount();
        }
        private void PopulateDetail()
        {
            if (ditxtTransNo.Text != "" && strButtonState != "ADD")
            {

                DataRow[] dr = new DataRow[0];
                dr = dtSearchDetail.Select("TransNo = '" + ditxtTransNo.Text + "'", "TransNo");
                dtbDetail.Rows.Clear();
                lblTotalAmount.Text = "0";
                for (int i = 0; i < dr.Count(); i++)
                {
                    dtbDetail.Rows.Add();
                    dtbDetail.Rows[i].Cells["Sno"].Value = dr[i]["Sno"].ToString();
                    dtbDetail.Rows[i].Cells["ItemCode"].Value = dr[i]["ItemCode"].ToString();
                    dtbDetail.Rows[i].Cells["ItemName"].Value = dr[i]["ItemName"].ToString();
                    dtbDetail.Rows[i].Cells["Symbol"].Value = dr[i]["ShortName"].ToString();
                    dtbDetail.Rows[i].Cells["Amount"].Value = dr[i]["Amount"].ToString();
                    dtbDetail.Rows[i].Cells["TransNo"].Value = dr[i]["TransNo"].ToString();
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = dr[i]["BranchCode"].ToString();
                    dtbDetail.Rows[i].Cells["Rate"].Value = dr[i]["Rate"].ToString();
                    dtbDetail.Rows[i].Cells["Quantity"].Value = dr[i]["Quantity"].ToString();
                    dtbDetail.Rows[i].Cells["RevRate"].Value = dr[i]["RevRate"].ToString();
                    dtbDetail.Rows[i].Cells["ProfitLoss"].Value = dr[i]["ProfitLoss"].ToString();
                    dtbDetail.Rows[i].Cells["AccountNo"].Value = dr[i]["AccountNo"].ToString();
                    dtbDetail.Rows[i].Cells["Account"].Value = dr[i]["Title"].ToString();
                    lblTotalAmount.Text = (Convert.ToDouble(lblTotalAmount.Text) + Convert.ToDouble(dtbDetail.Rows[i].Cells["Amount"].Value)).ToString();
                }
                lblTotalPL.Text = "0";
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    lblTotalPL.Text = (Convert.ToDouble(lblTotalPL.Text) + Convert.ToDouble(dtbDetail.Rows[i].Cells["ProfitLoss"].Value)).ToString();
                }

            }
        
        }
        private void FetchGrid()
        {
            string strQuery = "";
            
            strQuery = " SELECT     b.ItemName, b.ShortName, b.ItemCode, a.BranchCode, ROUND(SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE - Quantity END),  ";
            strQuery = strQuery + "4) AS Quantity, ROUND(CASE WHEN SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE - Quantity END)  ";
            strQuery = strQuery + "> 0 THEN SUM(CASE WHEN Flag = 'D' THEN Debit ELSE - Credit END) / SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE - Quantity END) ELSE 0 END,  ";
            strQuery = strQuery + "5) AS AvgRate, ROUND(SUM(CASE WHEN Flag = 'D' THEN Debit ELSE - Credit END), 4) AS Amount, a.BranchCode AS Expr1 ,a.AccountNo,c.Title ";//,d.Title as Vendor,PaymentMode ";
            strQuery = strQuery + "FROM         dbo.EX_PrsTransactions AS a INNER JOIN ";
            //strQuery = strQuery + "dbo.EX_TransactionsMaster AS cb ON a.VoucherNo = cb.VoucherNo AND a.BranchCode = cb.BranchCode and cb.Status = 'A' INNER JOIN ";
            strQuery = strQuery + "dbo.EX_SetupItems AS b ON a.CurrencyCode = b.ItemCode AND b.Status = 'A' INNER JOIN ";
            strQuery = strQuery + "dbo.EX_SetupAccount AS c ON a.AccountNo = c.AccountNo AND a.BranchCode = c.BranchCode AND c.Status = 'A' ";
//            strQuery = strQuery + "Inner Join  dbo.EX_SetupAccount AS d ON cb.PaymentMode = d.AccountNo AND cb.BranchCode = d.BranchCode AND d.Status = 'A' ";
            strQuery = strQuery + "WHERE     (a.CurrencyCode NOT IN ('304')) AND (a.Status = 'A') and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            strQuery = strQuery + "GROUP BY b.ItemName, b.ShortName, b.ItemCode, a.BranchCode,a.AccountNo,c.Title ";//,d.Title ,PaymentMode ";
            strQuery = strQuery + "having Round(SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE - Quantity END),4)  != 0;Select ItemCode,RevRate from EX_Revaluetion a Inner Join EX_RevaluetionDetail b on a.TransNo = b.TransNo and a.BranchCode = b.BRanchCode Where a.Status = 'A' and TransDate = '" + General.dtSystemDate.AddDays(-1).ToString("dd/MMM/yyyy") + "'";
                General cls = new General();
            DataSet ds = new DataSet();
            DataTable dtb = new DataTable();
            ds =cls.GetDataSet(strQuery);
            dtb = ds.Tables[0];
            DataTable dtb1 = new DataTable();
            dtb1 = ds.Tables[1];

            
            dtbDetail.Rows.Clear();
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                dtbDetail.Rows.Add();
                dtbDetail.Rows[i].Cells["ItemCode"].Value = dtb.Rows[i]["ItemCode"];
                dtbDetail.Rows[i].Cells["ItemName"].Value = dtb.Rows[i]["ItemName"];
                dtbDetail.Rows[i].Cells["Symbol"].Value = dtb.Rows[i]["ShortName"];
                dtbDetail.Rows[i].Cells["Quantity"].Value = dtb.Rows[i]["Quantity"];
                dtbDetail.Rows[i].Cells["Amount"].Value = dtb.Rows[i]["Amount"];
                dtbDetail.Rows[i].Cells["Rate"].Value = Convert.ToDouble(dtb.Rows[i]["Amount"]) / Convert.ToDouble(dtb.Rows[i]["Quantity"]);
                for (int i2 = 0; i2 < dtb1.Rows.Count; i2++)
                {
                    if (dtb.Rows[i]["ItemCode"].ToString() == dtb1.Rows[i2]["ItemCode"].ToString())
                    {
                        dtbDetail.Rows[i].Cells["RevRate"].Value = dtb1.Rows[i2]["RevRate"].ToString();
                    }
                }
                dtbDetail.Rows[i].Cells["AccountNo"].Value = dtb.Rows[i]["AccountNo"];
                dtbDetail.Rows[i].Cells["Account"].Value = dtb.Rows[i]["Title"];
//                dtbDetail.Rows[i].Cells["PaymentMode"].Value = dtb.Rows[i]["PaymentMode"];
  //              dtbDetail.Rows[i].Cells["Vendor"].Value = dtb.Rows[i]["Vendor"];



                //dtbDetail.Rows[i].Cells["VendorCode"].Value = dtb.Rows[i]["VendorCode"];
                //dtbDetail.Rows[i].Cells["Vendor"].Value = dtb.Rows[i]["Vendor"];

                lblTotalAmount.Text = (Convert.ToDouble(lblTotalAmount.Text) + Convert.ToDouble(dtbDetail.Rows[i].Cells["Amount"].Value)).ToString(); 
            }

        }
        private void dtbDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtbDetail.Columns["RevRate"].Index == e.ColumnIndex )
            {
                if (String.IsNullOrEmpty(dtbDetail.Rows[e.RowIndex].Cells["RevRate"].Value.ToString()) != true)
                {
                    if (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["RevRate"].Value.ToString()) != 0)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["ProfitLoss"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value) - Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["RevRate"].Value)) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value);
                        if (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["ProfitLoss"].Value) > 0)
                        {
                            dtbDetail.Rows[e.RowIndex].Cells["ProfitLoss"].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            dtbDetail.Rows[e.RowIndex].Cells["ProfitLoss"].Style.ForeColor = Color.Green;
                        }
                      
                    }
                    else
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["ProfitLoss"].Value = 0;
                    }
                }
                else
                {
                    dtbDetail.Rows[e.RowIndex].Cells["ProfitLoss"].Value = 0;
                }
                lblTotalPL.Text = "0";
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    lblTotalPL.Text = (Convert.ToDouble(lblTotalPL.Text) + Convert.ToDouble(dtbDetail.Rows[i].Cells["ProfitLoss"].Value)).ToString();
                }
            }
            
        }

        private void frmRevalution_Activated(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }
    }
}
