using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using DevExpress.Data.Filtering;
using System.Drawing.Drawing2D;

namespace ExchangeCompanySoftware
{
    public partial class frmTrailBalance : BaseForm,IToolBar
    {
        PivotGridField fdDr;
        DataGridView grd;

        public frmTrailBalance()
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

        private void frmTrailBalance_Load(object sender, EventArgs e)
        {
            dtbMaster.Visible = false;
            statusStrip1.Visible = false;
            txtStatus.Visible = false;
            dtTransDate.Value = General.dtSystemDate;
            FetchData();
            Timer tm = new Timer();
            tm.Interval = 9000;
            tm.Enabled = true;
            tm.Tick += new EventHandler(tm_Tick);
        }

        void tm_Tick(object sender, EventArgs e)
        {
           
        }
    
        private void FetchData()
        {
            try
            {
                string strQuery = "Select AccountNo,Title,Debit,";
                strQuery = strQuery + " Credit,Round(Amount,0) as Balance from (";
                strQuery = strQuery + " Select a.AccountNo,Title,Sum(Debit) as Debit,Sum(Credit) as Credit,Sum(case When Flag = 'D' then Debit else -Credit end) as Amount ,";
                strQuery = strQuery + " case When c.CurrencyCode != (Select Description From EX_System Where Flag = 'BC') then ";
                strQuery = strQuery + " SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE -Quantity END) else 0 end  AS Quantity ";
                strQuery = strQuery + " from EX_PrsTransactions a";
                strQuery = strQuery + " Left Outer Join EX_SetupAccount c on a.AccountNo = c.AccountNo and c.Status = 'A' and a.BranchCode= c.BranchCode Where A.Status = 'A'   and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + dtTransDate.Value.ToString("dd/MMM/yyyy") + "'";
                strQuery = strQuery + " and TransType not in (Select TransType from EX_Closing Where '" + dtTransDate.Value.ToString("dd/MMM/yyyy") + "' <= ClosedDate) and NatureCode  not in ('3','7') and c.AccountNo not in (Select PurchaseSale from EX_ControlAccounts)";
                strQuery = strQuery + " Group by Title,a.AccountNo,c.CurrencyCode )qry Where Round(Amount,0) <> 0";

                GetData.ServiceSoapClient objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                DataSet ds = new DataSet();
                ds = objGetData.GetDataSet(strQuery);


                dtbTB.DataSource = ds.Tables[0];
                dtbTB.Columns["Credit"].DefaultCellStyle.ForeColor = Color.Black;
                dtbTB.Columns["Debit"].DefaultCellStyle.ForeColor = Color.Black;
                dtbTB.Columns["Title"].DefaultCellStyle.ForeColor = Color.Black;
                dtbTB.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Black;

                dtbTB.Columns["Title"].Width = 300;
                dtbTB.Columns["Title"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dtbTB.Columns["Debit"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dtbTB.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtbTB.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtbTB.Columns["Credit"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dtbTB.Columns["Balance"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dtbTB.Columns["AccountNo"].Visible = false;
                lblDebit.Text = "0";
                lblCredit.Text = "0";
                for (int i = 0; i < dtbTB.Rows.Count; i++)
                {
                    lblDebit.Text = (Convert.ToDouble(lblDebit.Text) + Convert.ToDouble(dtbTB.Rows[i].Cells["Debit"].Value.ToString())).ToString();
                    lblCredit.Text = (Convert.ToDouble(lblCredit.Text) + Convert.ToDouble(dtbTB.Rows[i].Cells["Credit"].Value.ToString())).ToString();
                }
                lblDebit.Text = string.Format("{0:0,0}", Convert.ToDouble(lblDebit.Text));
                lblCredit.Text = string.Format("{0:0,0}", Convert.ToDouble(lblCredit.Text));
                dtbTB.Columns["Debit"].DefaultCellStyle.Format = "N2";
                dtbTB.Columns["Credit"].DefaultCellStyle.Format = "N2";     
                dtbTB.Columns["Balance"].DefaultCellStyle.Format = "N2";     
           }
               
            catch (Exception ex)
            {
            }
        }
        
        private void dtbTB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtbTB.Rows[e.RowIndex].Cells["AccountNo"].Value != null)
            {
                string strQuery = " Select TransType,a.VoucherNo,a.TransDate,a.Remarks,ItemName,Case When Flag = 'D' then Quantity else 0 end as [FC Debit],Case When Flag = 'C' then Quantity else 0 end as [FC Credit],Rate,Debit,Credit from EX_PrsTransactions a";
                strQuery = strQuery + " Inner Join EX_SetupAccount c on a.AccountNo = c.AccountNo and c.Status = 'A' and a.BranchCode= c.BranchCode";
                strQuery = strQuery + " Inner Join EX_SetupItems d on a.CurrencyCode = d.ItemCode and d.Status = 'A' ";
                strQuery = strQuery + " Where a.AccountNo = '" + dtbTB.Rows[e.RowIndex].Cells["AccountNo"].Value + "' and a.Status = 'A' and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + dtTransDate.Value + "'";

                GetData.ServiceSoapClient objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                DataSet ds = new DataSet();
                ds = objGetData.GetDataSet(strQuery);

                Form frm = new Form();
                grd = new DataGridView();
                grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grd.ReadOnly = true;
                frm.Controls.Add(grd);
                grd.Dock = DockStyle.Fill;
                grd.DataSource = ds.Tables[0];
                grd.CellDoubleClick += new DataGridViewCellEventHandler(grd_CellDoubleClick);
                frm.Width = 800;
                frm.ShowDialog();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Dispose();
            }
        }

        void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
            if (grd.Rows[e.RowIndex].Cells["VoucherNo"].Value != null)
            {
                string strQuery = " Select Title,ShortName,VoucherNo,Quantity,Rate,Debit,Credit,Remarks from EX_PrsTransactions a";
                strQuery = strQuery + " Inner Join EX_SetupAccount c on a.AccountNo = c.AccountNo and c.Status = 'A' and a.BranchCode= c.BranchCode";
                strQuery = strQuery + " Inner Join EX_SetupItems d on a.CurrencyCode = d.ItemCode and d.Status = 'A' ";
                strQuery = strQuery + " Where a.VoucherNo = '" + grd.Rows[e.RowIndex].Cells["VoucherNo"].Value + "' and a.Status = 'A' and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + dtTransDate.Value + "'";

                GetData.ServiceSoapClient objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                DataSet ds = new DataSet();
                ds = objGetData.GetDataSet(strQuery);

                Form frm = new Form();
                DataGridView grd1 = new DataGridView();
                grd1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grd1.ReadOnly = true;
                frm.Controls.Add(grd1);
                grd1.Dock = DockStyle.Fill;
                grd1.DataSource = ds.Tables[0];
                frm.Width = 800;
                frm.ShowDialog();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Dispose();
            }
                
            }
                
        }
        private void dtbTB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtbTB.Rows[dtbTB.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Gold)
            {
                dtbTB.Rows[dtbTB.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                dtbTB.Rows[dtbTB.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Gold;
            }


        }
        private void dtbTB_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if ((e.RowIndex != -1))
            //{
            //    // fill gradient background
            //    Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
            //    e.CellBounds, Color.LightGray, Color.White,
            //    System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            //    e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
            //    gradientBrush.Dispose();

            //    // paint rest of cell
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
            //    DataGridViewPaintParts.ContentForeground);
            //    e.Handled = true;
            //}
            //else
            //{
            //    Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
            //    e.CellBounds, Color.Orange, Color.Yellow,
            //    System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            //    e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
            //    gradientBrush.Dispose();

            //    // paint rest of cell
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
            //    DataGridViewPaintParts.ContentForeground);
            //    e.Handled = true;

            //}
        }

        private void cstDateTimePicker1_Validated(object sender, EventArgs e)
        {
            
        }

        private void dtTransDate_ValueChanged(object sender, EventArgs e)
        {
            FetchData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        
    }
}
