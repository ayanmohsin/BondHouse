using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using ExchangeCompanySoftware.Reports;

namespace ExchangeCompanySoftware
{
    public partial class frmRemitenceBlotter : BaseForm, IToolBar
    {
       
        DataGridView grd;

        public frmRemitenceBlotter()
        {
            InitializeComponent();
        }

        private void frmRemitenceBlotter_Load(object sender, EventArgs e)
        {
            dtbMaster.Visible = false;
            statusStrip1.Visible = false;
            txtStatus.Visible = false;
          //  dtTransDate.Value = General.dtSystemDate;
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
                string strDate = "";

                    strDate = " and TransDate <= '"+ dtTransDate.Value.ToString("dd/MMM/yyyy") +"'";

                string strQuery = "Select BranchName as Booth,";
                strQuery = strQuery + " isnull((Select Sum(case When Flag = 'D' then Debit else -Credit end) Amount ";
                strQuery = strQuery + "  from EX_PrsTransactions Where BranchCode = '35' " + strDate + " and Status = 'A' and AccountNo = a.AccountNo Group by AccountNo),0) as Amount ";
                strQuery = strQuery + "  ,isnull((Select Sum(case When Flag = 'D' then Debit else -Credit end) Amount ";
                strQuery = strQuery + "  from EX_PrsTransactions Where BranchCode = '35' and Status = 'A' " + strDate + "   and AccountNo = a.Commission Group by AccountNo),0) as Commission,(Select Count(*) from Franchise..EX_TransRemittenceMaster Where Status = 'A' " + strDate + " and BranchCode =  b.BranchCode) as Count";
                strQuery = strQuery + "  from EX_BoothAccounts a ";
                strQuery = strQuery + "  Inner Join Franchise..EX_Branch b on a.BoothNo = b.BranchCode ";
                strQuery = strQuery + "  WHERE a.branchNo = 0 ";


                //string strQuery = " Select BranchName as Booth,Sum(Amount) as Amount,Sum(Commission) as Commission,Count(*) as Count from EX_TransRemittenceMAster a";
                //strQuery = strQuery + " Inner Join EX_Branch b on a.BRanchCode = b.BRanchCode Where Status = 'A' ";
                //strQuery = strQuery + " and TransDate between '" + dtTransDate.Value.ToString("dd/MMM/yyyy") + "' and '" + dtFrom.Value.ToString("dd/MMM/yyyy") + "' ";
                //strQuery = strQuery + " Group by BranchName Union All";

                //strQuery = strQuery + " Select BranchName as Booth,Sum(Amount) as Amount,Sum(Commission) as Commission,Count(*) as Count from Franchise..EX_TransRemittenceMAster a";
                //strQuery = strQuery + " Inner Join Franchise..EX_Branch b on a.BRanchCode = b.BRanchCode Where Status = 'A' ";
                //strQuery = strQuery + " and TransDate between '" + dtTransDate.Value.ToString("dd/MMM/yyyy") + "' and '" + dtFrom.Value.ToString("dd/MMM/yyyy") + "' ";
                //strQuery = strQuery + " Group by BranchName ";



                GetData.ServiceSoapClient objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                DataSet ds = new DataSet();
                ds = objGetData.GetDataSet(strQuery);


                dtbTB.DataSource = ds.Tables[0];
                dtbTB.Columns["Commission"].DefaultCellStyle.ForeColor = Color.Black;
                dtbTB.Columns["Amount"].DefaultCellStyle.ForeColor = Color.Black;
                dtbTB.Columns["Booth"].DefaultCellStyle.ForeColor = Color.Black;
                dtbTB.Columns["Count"].DefaultCellStyle.ForeColor = Color.Black; 

                dtbTB.Columns["Booth"].Width = 300;
                dtbTB.Columns["Booth"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dtbTB.Columns["Amount"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dtbTB.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtbTB.Columns["Commission"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtbTB.Columns["Commission"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dtbTB.Columns["Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtbTB.Columns["Count"].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                lblDebit.Text = "0";
                lblCredit.Text = "0";
                lblNoofTrans.Text = "0";
                for (int i = 0; i < dtbTB.Rows.Count; i++)
                {
                    lblDebit.Text = (Convert.ToDouble(lblDebit.Text) + Convert.ToDouble(dtbTB.Rows[i].Cells["Amount"].Value.ToString())).ToString();
                    lblCredit.Text = (Convert.ToDouble(lblCredit.Text) + Convert.ToDouble(dtbTB.Rows[i].Cells["Commission"].Value.ToString())).ToString();
                    lblNoofTrans.Text = (Convert.ToDouble(lblNoofTrans.Text) + Convert.ToDouble(dtbTB.Rows[i].Cells["Count"].Value.ToString())).ToString();

                }
                lblDebit.Text = string.Format("{0:0,0}", Convert.ToDouble(lblDebit.Text));
                lblCredit.Text = string.Format("{0:0,0}", Convert.ToDouble(lblCredit.Text));
                dtbTB.Columns["Amount"].DefaultCellStyle.Format = "#,0;(#,#);-";
                dtbTB.Columns["Commission"].DefaultCellStyle.Format = "#,0;(#,#);-";
                dtbTB.Columns["Count"].DefaultCellStyle.Format = "N0";
              
            }

            catch (Exception ex)
            {
            }
        }
        private void dtbTB_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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


        #region IToolBar Members

        public bool ADD()
        {
            throw new NotImplementedException();
        }

        public bool SAVE()
        {
            throw new NotImplementedException();
        }

        public bool EDIT()
        {
            throw new NotImplementedException();
        }

        public bool QUERY()
        {
            throw new NotImplementedException();
        }

        public bool UNDO()
        {
            throw new NotImplementedException();
        }

        public bool EXIT()
        {
            throw new NotImplementedException();
        }

        public bool DELETE()
        {
            throw new NotImplementedException();
        }

        public bool NEXT()
        {
            throw new NotImplementedException();
        }

        public bool PREVIOUS()
        {
            throw new NotImplementedException();
        }

        public bool LAST()
        {
            throw new NotImplementedException();
        }

        public bool FIRST()
        {
            throw new NotImplementedException();
        }

        public bool AUTHORIZE()
        {
            throw new NotImplementedException();
        }

        public bool PRINT()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string strDate = " and TransDate <= '" + dtTransDate.Value.ToString("dd/MMM/yyyy") + "'";


            string strQuery = "Select BranchName as Booth,";
            strQuery = strQuery + " isnull((Select Sum(case When Flag = 'D' then Debit else -Credit end) Amount ";
            strQuery = strQuery + "  from EX_PrsTransactions Where BranchCode = '35' " + strDate + " and Status = 'A' and AccountNo = a.AccountNo Group by AccountNo),0) as Amount ";
            strQuery = strQuery + "  ,isnull((Select Sum(case When Flag = 'D' then Debit else -Credit end) Amount ";
            strQuery = strQuery + "  from EX_PrsTransactions Where BranchCode = '35' and Status = 'A' " + strDate + "   and AccountNo = a.Commission Group by AccountNo),0) as Commission,(Select Count(*) from Franchise..EX_TransRemittenceMaster Where Status = 'A' " + strDate + " and BranchCode =  b.BranchCode) as Count";
            strQuery = strQuery + "  from EX_BoothAccounts a ";
            strQuery = strQuery + "  Inner Join Franchise..EX_Branch b on a.BoothNo = b.BranchCode ";
            strQuery = strQuery + "  WHERE a.branchNo = 0 ";



            GetData.ServiceSoapClient objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            ds = objGetData.GetDataSet(strQuery);

            XtraReport1 devrep = new XtraReport1();
            devrep.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
            devrep.Parameters["CompanyName"].Value = General.strCompanyName;
            devrep.Parameters["BranchName"].Value = General.strAddress;
            devrep.RequestParameters = false;
            devrep.DataSource = ds.Tables[0];
            devrep.CreateDocument();
            devrep.ShowPreview();
        }
    }
}
