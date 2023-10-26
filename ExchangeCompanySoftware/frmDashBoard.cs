using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using ExchangeCompanySoftware.GetData;
using System.Drawing.Drawing2D;

namespace ExchangeCompanySoftware
{
    public partial class frmDashBoard : BaseForm,IToolBar
    {
       
        string strQuery;
        DataSet ds;
        DataTable dtb;
        PivotGridField fd5;
        DataGridView grd;
        DataGridView grd1;
        string strCurrencyCode;
        public frmDashBoard()
        {
            InitializeComponent();
        }

        #region IToolBar Members

        public bool ADD()
        {
            return true;
        }

        public bool SAVE()
        {
            return true;
        }

        public bool EDIT()
        {
            return true;
        }

        public bool QUERY()
        {
            return true;
        }

        public bool UNDO()
        {
            return true;
        }

        public bool EXIT()
        {
            return true;
        }

        public bool DELETE()
        {
            return true;
        }

        public bool NEXT()
        {
            return true;
        }

        public bool PREVIOUS()
        {
            return true;
        }

        public bool LAST()
        {
            return true;
        }

        public bool FIRST()
        {
            return true;
        }

        public bool AUTHORIZE()
        {
            return true;
        }

        public bool PRINT()
        {
            return true;
        }

        #endregion
        private void FetchData()
        {
            General cls = new General();
            string strQuery = " Select CurrencyCode,ItemName,Round(OpQty,2) as OpQty,Round(Case When OPQty > 0 then OPAmt/OpQty else 0 end,4) as OPAVG,Round(OPAmt,2) as OPAmt ";
            strQuery = strQuery + " ,PQty,Round(Case When PQty > 0 then PAmt/pQty else 0 end,4) as PAVG,Round(PAmt,2) as PAmt ";
            strQuery = strQuery + " ,SQty,Round(Case When SQty > 0 then SAmt/SQty else 0 end,4) as SAVG,Round(SAmt,2) as SAmt";
            strQuery = strQuery + " ,BLQty,Round(Case When BLQty > 0 then BLAmt/BLQty else 0 end,2) as BLAVG,Round(BLAmt,2) as BLAmt ";
            strQuery = strQuery + " from (Select a.CurrencyCode,ItemName,ShortName, ";
            strQuery = strQuery + " isnull((Select Sum(Case When Flag = 'D' then Quantity else - Quantity end) as Quantity ";
            strQuery = strQuery + " From EX_PrsTransactions Where TransDate < '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = a.BranchCode  and Status = 'A' and CurrencyCode = a.CurrencyCode";
            strQuery = strQuery + " ),0) as OpQty,isnull((Select Sum(Case When Flag = 'D' then Debit else - Credit end) as Amount ";
            strQuery = strQuery + " From EX_PrsTransactions Where TransDate < '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = a.BranchCode   and Status = 'A' and CurrencyCode = a.CurrencyCode),0) as OpAmt, ";
            strQuery = strQuery + " (Select Sum(Quantity) from EX_PrsTransactions Where Flag = 'D' ";
            strQuery = strQuery + " and CurrencyCode = a.CurrencyCode and TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = a.BranchCode  and Status = 'A') as PQty, ";
            strQuery = strQuery + " isnull((Select Sum(Debit) from EX_PrsTransactions Where Flag = 'D' ";
            strQuery = strQuery + " and CurrencyCode = a.CurrencyCode and TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = a.BranchCode  and Status = 'A' ),0) as PAmt ";
            strQuery = strQuery + " ,isnull((Select Sum(Quantity) from EX_PrsTransactions Where Flag = 'C' and CurrencyCode = a.CurrencyCode ";
            strQuery = strQuery + " and TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'  and Status = 'A' and BranchCode = a.BranchCode),0) as SQty, ";
            strQuery = strQuery + " isnull((Select Sum(Credit) from EX_PrsTransactions Where Flag = 'C' and CurrencyCode = a.CurrencyCode ";
            strQuery = strQuery + " and TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'  and Status = 'A' and BranchCode = a.BranchCode),0) as SAmt, ";
            strQuery = strQuery + " isnull(Sum(case When Flag = 'D' then Quantity else -Quantity end),0) as BLQty, ";
            strQuery = strQuery + " isnull(Sum(case When Flag = 'D' then Debit else -Credit end),0) as BLAmt ";
            strQuery = strQuery + " from EX_PrsTransactions a  ";
            strQuery = strQuery + " Inner join EX_SetupItems b on a.CurrencyCode = b.ItemCode and b.Status = 'A' ";
            strQuery = strQuery + " Where a.TransDate <= '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and a.CurrencyCode != (Select Description From EX_System Where Flag = 'BC') and a.Status = 'A' and a.BranchCode = '" + General.strBranchCode + "'";
            strQuery = strQuery + " Group by ItemName,ShortName,a.CurrencyCode,a.BranchCode ";
            strQuery = strQuery + " )qry ;Select * from VU_UnAuthorizedRecord Where Status > 0 and BranchCode = '" + General.strBranchCode + "' ;Select Title,Amount,[Head Office],Round(Abs(Amount)-[Head Office],4) as Differnce from ( ";
            strQuery = strQuery + " Select b.Title ,sum(case When Flag = 'D' then Debit else -Credit end) as Amount  ";
            strQuery = strQuery + " ,isnull((Select sum(case When Flag = 'D' then Debit else -Credit end) from EX_PrsTransactions  ";
            strQuery = strQuery + " Inner Join EX_SetupAccount d on EX_PrsTransactions.AccountNo = d.AccountNo  ";
            strQuery = strQuery + " and d.Status = 'A' and d.BranchCodeTag = a.BranchCode Where EX_PrsTransactions.BranchCode = '"+ General.strHeadOfficeCode +"' ";
            strQuery = strQuery + " Group by EX_PrsTransactions.BranchCode ),0) as [Head Office] ";
            strQuery = strQuery + " from EX_PrsTransactions a Inner Join EX_SetupAccount b on a.AccountNo = b.AccountNo and b.Status = 'A' ";
            strQuery = strQuery + " Where isBranch = 'true' and a.BranchCode = '"+ General.strBranchCode +"' ";
            strQuery = strQuery + " Group by a.AccountNo,b.Title,a.BranchCode)qry ";

             
            DataSet ds = new DataSet();
            ds =cls.GetDataSet(strQuery);
            int intWidth = 70;
           
            dtbCurrency.DataSource = ds.Tables[0];
            dtbStatus.DataSource = ds.Tables[1];
            dtbMO.DataSource = ds.Tables[2];


            dtbMO.Columns[1].DefaultCellStyle.Format = "N0";
            dtbMO.Columns[2].DefaultCellStyle.Format = "N0";
            dtbMO.Columns[3].DefaultCellStyle.Format = "N0";
           
            dtbCurrency.Columns["ItemName"].DefaultCellStyle.ForeColor = Color.Black;
            dtbCurrency.Columns["ItemName"].Width = 125;
            dtbCurrency.Columns["OPQty"].Width = intWidth;
            dtbCurrency.Columns["OPAvg"].Width = intWidth;
            dtbCurrency.Columns["OPAmt"].Width = intWidth;
            dtbCurrency.Columns["PQty"].Width = intWidth;
            dtbCurrency.Columns["PAvg"].Width = intWidth;
            dtbCurrency.Columns["PAmt"].Width = intWidth;
            dtbCurrency.Columns["SQty"].Width = intWidth;
            dtbCurrency.Columns["SAvg"].Width = intWidth;
            dtbCurrency.Columns["SAmt"].Width = intWidth;
            dtbCurrency.Columns["BLQty"].DefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
            dtbCurrency.Columns["BLAvg"].DefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
            dtbCurrency.Columns["BLAmt"].DefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;

            dtbCurrency.Columns["BLQty"].DefaultCellStyle.ForeColor = Color.Black;
            dtbCurrency.Columns["BLAvg"].DefaultCellStyle.ForeColor = Color.Black;
            dtbCurrency.Columns["BLAmt"].DefaultCellStyle.ForeColor = Color.Black;

            dtbCurrency.Columns["OPQty"].DefaultCellStyle.ForeColor = Color.Black;
            dtbCurrency.Columns["OPAvg"].DefaultCellStyle.ForeColor = Color.Black;
            dtbCurrency.Columns["OPAmt"].DefaultCellStyle.ForeColor = Color.Black;

            dtbCurrency.Columns["SQty"].DefaultCellStyle.ForeColor = Color.Black;
            dtbCurrency.Columns["SAvg"].DefaultCellStyle.ForeColor = Color.Black;
            dtbCurrency.Columns["SAmt"].DefaultCellStyle.ForeColor = Color.Black;

            dtbCurrency.Columns["PQty"].DefaultCellStyle.ForeColor = Color.Black;
            dtbCurrency.Columns["PAvg"].DefaultCellStyle.ForeColor = Color.Black;
            dtbCurrency.Columns["PAmt"].DefaultCellStyle.ForeColor = Color.Black;

            dtbCurrency.Columns["PQty"].HeaderText = "Purchase Quantity";
            dtbCurrency.Columns["PAVG"].HeaderText = "Purchase Average";
            dtbCurrency.Columns["PAMT"].HeaderText = "Purchase Amount";
            dtbCurrency.Columns["SQty"].HeaderText = "Sale Quantity";
            dtbCurrency.Columns["SAVG"].HeaderText = "Sale Average";
            dtbCurrency.Columns["SAMT"].HeaderText = "Sale Amount";
            dtbCurrency.Columns["OPQty"].HeaderText = "Opening Quantity";
            dtbCurrency.Columns["OPAVG"].HeaderText = "Opening Average";
            dtbCurrency.Columns["OPAMT"].HeaderText = "Opening Amount";
            dtbCurrency.Columns["BLQty"].HeaderText = "Balance Quantity";
            dtbCurrency.Columns["BLAVG"].HeaderText = "Balance Average";
            dtbCurrency.Columns["BLAMT"].HeaderText = "Balance Amount";


            dtbCurrency.Columns["BLQty"].Width = intWidth;
            dtbCurrency.Columns["BLAvg"].Width = intWidth;
            dtbCurrency.Columns["BLAmt"].Width = intWidth;
           // dtbCurrency.Columns["AvgRate"].Width = 200;
           // dtbCurrency.Columns["Amount"].Width = 200;
            dtbCurrency.Columns["ItemName"].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //dtbCurrency.Columns["Quantity"].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           // dtbCurrency.Columns["Amount"].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           // dtbCurrency.Columns["AvgRate"].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dtbCurrency.Columns["CurrencyCode"].Visible = false;

            dtbCurrency.Columns["PQty"].DefaultCellStyle.Format = "N4";
            dtbCurrency.Columns["PAVG"].DefaultCellStyle.Format = "N4";
            dtbCurrency.Columns["PAMT"].DefaultCellStyle.Format = "N2";
            dtbCurrency.Columns["SQty"].DefaultCellStyle.Format = "N4";
            dtbCurrency.Columns["SAVG"].DefaultCellStyle.Format = "N4";
            dtbCurrency.Columns["SAMT"].DefaultCellStyle.Format = "N2";
            dtbCurrency.Columns["OPQty"].DefaultCellStyle.Format = "N4";
            dtbCurrency.Columns["OPAVG"].DefaultCellStyle.Format = "N4";
            dtbCurrency.Columns["OPAMT"].DefaultCellStyle.Format = "N2";
            dtbCurrency.Columns["BLQty"].DefaultCellStyle.Format = "N4";
            dtbCurrency.Columns["BLAVG"].DefaultCellStyle.Format = "N4";
            dtbCurrency.Columns["BLAMT"].DefaultCellStyle.Format = "N2";

            for (int i = 0; i < dtbCurrency.Rows.Count; i++)
            {
                lblCAmt.Text = (Convert.ToDouble(lblCAmt.Text) + Convert.ToDouble(dtbCurrency.Rows[i].Cells["BLAmt"].Value.ToString())).ToString();
                lblOAmt.Text = (Convert.ToDouble(lblOAmt.Text) + Convert.ToDouble(dtbCurrency.Rows[i].Cells["OPAmt"].Value.ToString())).ToString();
                lblPAmt.Text = (Convert.ToDouble(lblPAmt.Text) + Convert.ToDouble(dtbCurrency.Rows[i].Cells["PAmt"].Value.ToString())).ToString();
                lblSAmt.Text = (Convert.ToDouble(lblSAmt.Text) + Convert.ToDouble(dtbCurrency.Rows[i].Cells["SAmt"].Value.ToString())).ToString();
            }
            float fval = System.Convert.ToSingle((Convert.ToDouble(lblCAmt.Text) / (1000000)));
            arcScaleComponent2.Value = fval;

            strQuery = "Select Round(Sum(case When Flag = 'D' then Debit else - Credit end),2) as CashinHand from EX_PrsTransactions a";
            strQuery = strQuery + " Where AccountNo = (Select Cashinhand From EX_ControlAccounts Where BranchCode = a.BranchCode) and BranchCode = '" + General.strBranchCode + "'";

            ds =cls.GetDataSet(strQuery);
            lblCashinHand.Text = ds.Tables[0].Rows[0]["CashinHand"].ToString();

            dtbCurrency.Columns["OPQty"].Visible = false;
            dtbCurrency.Columns["OPAvg"].Visible = false;
            dtbCurrency.Columns["OPAmt"].Visible = false;
            dtbCurrency.Columns["PQty"].Visible = false;
            dtbCurrency.Columns["PAvg"].Visible = false;
            dtbCurrency.Columns["PAmt"].Visible = false;
            dtbCurrency.Columns["SQty"].Visible = false;
            dtbCurrency.Columns["SAvg"].Visible = false;
            dtbCurrency.Columns["SAmt"].Visible = false;
            if (lblCashinHand.Text == "")
            {
                lblCashinHand.Text = "0";
            }
            lblCashinHand.Text = string.Format("{0:0,0}", Convert.ToDouble(lblCashinHand.Text));
            lblCAmt.Text = string.Format("{0:0,0}", Convert.ToDouble(lblCAmt.Text));
            lblOAmt.Text = string.Format("{0:0,0}", Convert.ToDouble(lblOAmt.Text));
            lblPAmt.Text = string.Format("{0:0,0}", Convert.ToDouble(lblPAmt.Text));
            lblSAmt.Text = string.Format("{0:0,0}", Convert.ToDouble(lblSAmt.Text));
        }
        //private void PopulateCurrencyPosition()
        //{
        //    ds = new DataSet();
        //    strQuery = "Select * from VU_CurrencyPosition;Select * from VU_UnAuthorizedRecord Where Status > 0";
        //    objGetData = new ServiceSoapClient();
        //    ds =cls.GetDataSet(strQuery);
        //    dtb = ds.Tables[0];

        //    if (pivotGridControl1 == null) return;

        //    fd5 = new PivotGridField();
        //    fd5.FieldName = "Amount";
        //    fd5.Caption = "Amount";
        //    fd5.SortOrder = PivotSortOrder.Ascending;
        //    fd5.SetAreaPosition(PivotArea.DataArea, 2);
        //    fd5.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
        //    fd5.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
        //    fd5.Width = 70;
        //    pivotGridControl1.Fields.Add(fd5);

        //    PivotGridField fd8 = new PivotGridField();
        //    fd8.FieldName = "AvgRate";
        //    fd8.Caption = "Rate";
        //    fd8.SortOrder = PivotSortOrder.Ascending;
        //    fd8.SetAreaPosition(PivotArea.DataArea, 1);
        //    fd8.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
        //    fd8.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
        //    fd8.Width = 70;
        //    pivotGridControl1.Fields.Add(fd8);


        //    pivotGridControl1.DataSource = dtb;
        //    PivotGridField fd = new PivotGridField();
        //    fd.FieldName = "Quantity";
        //    fd.Caption = "Quantity";
        //    fd.SortOrder = PivotSortOrder.Ascending;
        //    fd.SetAreaPosition(PivotArea.DataArea, 0);
        //    fd.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
        //    fd.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
        //    fd.Width = 70;
        //    pivotGridControl1.Fields.Add(fd);


        //    PivotGridField fd1 = new PivotGridField();
        //    fd1.FieldName = "Title";
        //    fd1.Caption = "Created On";
        //    fd1.SortOrder = PivotSortOrder.Ascending;
        //    fd1.SetAreaPosition(PivotArea.ColumnArea, 0);
        //    fd1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
        //    fd1.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
        //    fd1.Width = 120;
        //    pivotGridControl1.Fields.Add(fd1);

        //    PivotGridField fd4 = new PivotGridField();
        //    fd4.FieldName = "ItemName";
        //    fd4.Caption = "Currency Name";
        //    fd4.SortOrder = PivotSortOrder.Ascending;
        //    fd4.SetAreaPosition(PivotArea.RowArea, 0);
        //    fd4.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
        //    fd4.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
        //    fd4.Width = 100;
        //    pivotGridControl1.Fields.Add(fd4);
        //    pivotGridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        //    dtb = ds.Tables[1];
        //    dtbStatus.DataSource = dtb;
        //}
   
        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            FetchData();
           // PopulateCurrencyPosition();
            arcScaleComponent1.Value = 50;
            dtbMaster.Visible = false;
            Timer t1 = new Timer();
            t1.Interval = 100;
            t1.Tick += new EventHandler(t1_Tick);
            txtStatus.Visible = false;
        }

        void t1_Tick(object sender, EventArgs e)
        {
            FetchData();
           // PopulateCurrencyPosition();
        }
        private void pivotGridControl1_CustomDrawCell(object sender, PivotCustomDrawCellEventArgs e)
        {
            if (e.ColumnValueType == PivotGridValueType.GrandTotal ||
            e.RowValueType == PivotGridValueType.GrandTotal)
            {
                e.GraphicsCache.FillRectangle(new LinearGradientBrush(e.Bounds, Color.LightBlue,
                  Color.Blue, LinearGradientMode.Vertical), e.Bounds);
                Rectangle innerRect = Rectangle.Inflate(e.Bounds, -3, -3);
                e.GraphicsCache.FillRectangle(new LinearGradientBrush(e.Bounds, Color.Blue,
                  Color.LightSkyBlue, LinearGradientMode.Vertical), innerRect);
                e.GraphicsCache.DrawString(e.DisplayText, e.Appearance.Font,
                  new SolidBrush(Color.White), innerRect, e.Appearance.GetStringFormat());
                e.Handled = true;
                float fval = System.Convert.ToSingle((Convert.ToDouble(e.GetColumnGrandTotal(fd5)) / (1000000)));
                arcScaleComponent1.Value = fval;
            }
        }

        private void dtbCurrency_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtbCurrency.Rows[e.RowIndex].Cells["CurrencyCode"].Value != null)
            {
                strCurrencyCode = dtbCurrency.Rows[e.RowIndex].Cells["CurrencyCode"].Value.ToString();
                string strQuery = " Select AccountNo,Title,Sum(OpQty) as OPQty,Case When Sum(OPQty) > 0 then Sum(OPAmt)/Sum(OpQty) else 0 end as OPAVG,Sum(OPAmt) as OPAMT";
                strQuery = strQuery + " ,isnull(Sum(PQty),0) as PQty,Case When Sum(PQty) > 0 then Sum(PAmt)/Sum(pQty) else 0 end as PAVG,isnull(sum(PAmt),0) as PAmt ";
                strQuery = strQuery + " ,isnull(Sum(SQty),0) as SQty,Case When Sum(SQty) > 0 then Sum(SAmt)/Sum(SQty) else 0 end as SAVG,isnull(Sum(SAmt),0) as SAmt ";
                strQuery = strQuery + " ,Sum(BLQty) as BLQty,Case When Sum(BLQty) > 0 then Sum(BLAmt)/Sum(BLQty) else 0 end as BLAVG,Sum(BLAmt) as BLAMT ";
                strQuery = strQuery + " from (Select a.CurrencyCode,Title,a.AccountNo, ";
                strQuery = strQuery + " isnull((Select Sum(Case When Flag = 'D' then Quantity else - Quantity end) as Quantity ";
                strQuery = strQuery + " From EX_PrsTransactions Where TransDate < '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = a.BranchCode  and Status = 'A' and CurrencyCode = a.CurrencyCode  ";
                strQuery = strQuery + " ),0) as OpQty,isnull((Select Sum(Case When Flag = 'D' then Debit else - Credit end) as Amount ";
                strQuery = strQuery + " From EX_PrsTransactions Where TransDate < '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = a.BranchCode  and Status = 'A' and CurrencyCode = a.CurrencyCode),0) as OpAmt, ";
                strQuery = strQuery + " (Select Sum(Quantity) from EX_PrsTransactions Where Flag = 'D' ";
                strQuery = strQuery + " and AccountNo = a.AccountNo and CurrencyCode = a.CurrencyCode and TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = a.BranchCode  and Status = 'A') as PQty, ";
                strQuery = strQuery + " (Select Sum(Debit) from EX_PrsTransactions Where Flag = 'D' ";
                strQuery = strQuery + " and AccountNo = a.AccountNo and TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = a.BranchCode  and Status = 'A' ) as PAmt ";
                strQuery = strQuery + " ,(Select Sum(Quantity) from EX_PrsTransactions Where Flag = 'C' and AccountNo = a.AccountNo ";
                strQuery = strQuery + " and TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'  and BranchCode = a.BranchCode   and Status = 'A' and CurrencyCode = a.CurrencyCode ) as SQty, ";
                strQuery = strQuery + " (Select Sum(Credit) from EX_PrsTransactions Where Flag = 'C' and AccountNo = a.AccountNo ";
                strQuery = strQuery + " and TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'  and BranchCode = a.BranchCode   and Status = 'A' and CurrencyCode = a.CurrencyCode ) as SAmt, ";
                strQuery = strQuery + " Sum(case When Flag = 'D' then Quantity else -Quantity end) as BLQty, ";
                strQuery = strQuery + " Sum(case When Flag = 'D' then Debit else -Credit end) as BLAmt ";
                strQuery = strQuery + " from EX_PrsTransactions a  ";
                strQuery = strQuery + " Inner join EX_SetupAccount b on a.AccountNo = b.AccountNo and b.Status = 'A' ";
                strQuery = strQuery + " Where a.TransDate <= '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and a.Status = 'A' and a.BranchCode = '" + General.strBranchCode + "' ";
                strQuery = strQuery + " Group by Title,a.AccountNo,a.CurrencyCode,a.BranchCode ";
                strQuery = strQuery + " )qry  Where CurrencyCode = '" + dtbCurrency.Rows[e.RowIndex].Cells["CurrencyCode"].Value + "'";
                strQuery = strQuery + " Group by Title,AccountNo";
                General cls = new General();
                DataSet ds = new DataSet();
                ds =cls.GetDataSet(strQuery);

                Form frm = new Form();
                grd = new DataGridView();
                grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grd.ReadOnly = true;
                frm.Controls.Add(grd);
                grd.Dock = DockStyle.Fill;
                grd.DataSource = ds.Tables[0];

                grd.Columns["PQty"].HeaderText = "Purchase Quantity";
                grd.Columns["PAVG"].HeaderText = "Purchase Average";
                grd.Columns["PAMT"].HeaderText = "Purchase Amount";
                grd.Columns["SQty"].HeaderText = "Sale Quantity";
                grd.Columns["SAVG"].HeaderText = "Sale Average";
                grd.Columns["SAMT"].HeaderText = "Sale Amount";
                grd.Columns["OPQty"].HeaderText = "Opening Quantity";
                grd.Columns["OPAVG"].HeaderText = "Opening Average";
                grd.Columns["OPAMT"].HeaderText = "Opening Amount";
                grd.Columns["BLQty"].HeaderText = "Balance Quantity";
                grd.Columns["BLAVG"].HeaderText = "Balance Average";
                grd.Columns["BLAMT"].HeaderText = "Balance Amount";
                grd.Columns["AccountNo"].Visible = false;

                grd.CellDoubleClick += new DataGridViewCellEventHandler(grd_CellDoubleClick);
                frm.Width = 800;
                frm.ShowDialog();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Dispose();
            }
        }

        void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grd.Rows[e.RowIndex].Cells["AccountNo"].Value != null)
            {
                string strQuery = " Select TransType,a.VoucherNo,a.TransDate,a.Remarks,ItemName,Case When Flag = 'D' then Quantity else 0 end as [FC Debit],Case When Flag = 'C' then Quantity else 0 end as [FC Credit],Rate,Debit,Credit from EX_PrsTransactions a";
                strQuery = strQuery + " Inner Join EX_SetupAccount c on a.AccountNo = c.AccountNo and c.Status = 'A' and a.BranchCode= c.BranchCode";
                strQuery = strQuery + " Inner Join EX_SetupItems d on a.CurrencyCode = d.ItemCode and d.Status = 'A' ";
                strQuery = strQuery + " Where a.AccountNo = '" + grd.Rows[e.RowIndex].Cells["AccountNo"].Value + "' and a.CurrencyCode = '"+ strCurrencyCode +"' and a.Status = 'A' and a.BranchCode = '" + General.strBranchCode + "'";

                    General cls = new General();
                DataSet ds = new DataSet();
                ds =cls.GetDataSet(strQuery);

                Form frm = new Form();
                grd1 = new DataGridView();
                grd1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grd1.ReadOnly = true;
                frm.Controls.Add(grd1);
                grd1.Dock = DockStyle.Fill;
                grd1.DataSource = ds.Tables[0];
                grd1.CellDoubleClick += new DataGridViewCellEventHandler(grd1_CellDoubleClick);
                frm.Width = 800;
                frm.ShowDialog();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Dispose();
            }
        }

        void grd1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grd1.Rows[e.RowIndex].Cells["VoucherNo"].Value != null)
            {
                string strQuery = " Select Title,ShortName,VoucherNo,Quantity,Rate,Debit,Credit,Remarks from EX_PrsTransactions a";
                strQuery = strQuery + " Inner Join EX_SetupAccount c on a.AccountNo = c.AccountNo and c.Status = 'A' and a.BranchCode= c.BranchCode";
                strQuery = strQuery + " Inner Join EX_SetupItems d on a.CurrencyCode = d.ItemCode and d.Status = 'A' ";
                strQuery = strQuery + " Where a.VoucherNo = '" + grd1.Rows[e.RowIndex].Cells["VoucherNo"].Value + "' and a.Status = 'A' and a.BranchCode = '" + General.strBranchCode + "' and a.CurrencyCode = '"+ strCurrencyCode +"'";

                    General cls = new General();
                DataSet ds = new DataSet();
                ds =cls.GetDataSet(strQuery);

                Form frm = new Form();
                DataGridView grd2 = new DataGridView();
                grd2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grd2.ReadOnly = true;
                frm.Controls.Add(grd2);
                grd2.Dock = DockStyle.Fill;
                grd2.DataSource = ds.Tables[0];
                frm.Width = 800;
                frm.ShowDialog();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Dispose();
            }
        }

        private void pnlMain1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtbCurrency_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex != -1))
            {
                // fill gradient background
                Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                e.CellBounds, Color.LightGray, Color.White,
                System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
                gradientBrush.Dispose();

                // paint rest of cell
                e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
                DataGridViewPaintParts.ContentForeground);
                e.Handled = true;
            }
            else
            {
                Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                e.CellBounds, Color.Orange, Color.Yellow,
                System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
                gradientBrush.Dispose();

                // paint rest of cell
                e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
                DataGridViewPaintParts.ContentForeground);
                e.Handled = true;
          
            }

        }

        private void dtbMO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dtbCurrency.Columns["OPQty"].Visible == false)
            {
                dtbCurrency.Columns["OPQty"].Visible = true;
                dtbCurrency.Columns["OPAvg"].Visible = true;
                dtbCurrency.Columns["OPAmt"].Visible = true;
                dtbCurrency.Columns["PQty"].Visible = true;
                dtbCurrency.Columns["PAvg"].Visible = true;
                dtbCurrency.Columns["PAmt"].Visible = true;
                dtbCurrency.Columns["SQty"].Visible = true;
                dtbCurrency.Columns["SAvg"].Visible = true;
                dtbCurrency.Columns["SAmt"].Visible = true;
            }
            else
            {
                dtbCurrency.Columns["OPQty"].Visible = false;
                dtbCurrency.Columns["OPAvg"].Visible = false;
                dtbCurrency.Columns["OPAmt"].Visible = false;
                dtbCurrency.Columns["PQty"].Visible = false;
                dtbCurrency.Columns["PAvg"].Visible = false;
                dtbCurrency.Columns["PAmt"].Visible = false;
                dtbCurrency.Columns["SQty"].Visible = false;
                dtbCurrency.Columns["SAvg"].Visible = false;
                dtbCurrency.Columns["SAmt"].Visible = false;

            }
        }
    }
}
