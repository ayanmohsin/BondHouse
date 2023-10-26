using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ExchangeCompanySoftware.Reports.Tickets
{
    public partial class rptDealTicket : DevExpress.XtraReports.UI.XtraReport
    {
        string strBranchAddress;
        private int intRows;
        public rptDealTicket(string BranchAddress)
        {
            InitializeComponent();
            strBranchAddress = BranchAddress;
        }

        private void rptDealTicket_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel2.Text = strBranchAddress;
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {
           
        }

        private void xrLabel24_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel24_AfterPrint(object sender, EventArgs e)
        {
            if (intRows == 6)
            {
                Detail.PageBreak = PageBreak.AfterBand;

            }
            else
            {
                intRows += 1;
                Detail.PageBreak = PageBreak.None;
            }
          
        }

        private void rptDealTicket_PrintProgress(object sender, DevExpress.XtraPrinting.PrintProgressEventArgs e)
        {
           
        }

    }
}
