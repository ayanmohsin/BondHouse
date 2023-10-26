using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ExchangeCompanySoftware.Reports
{
    public partial class rptTransInterBranch : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTransInterBranch()
        {
            InitializeComponent();
        }

        private void xrLabel11_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel19_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel21_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel9_AfterPrint(object sender, EventArgs e)
        {
            if (xrLabel9.Text == "Purchase")
            {
                xrLabel42.Text = "Dr";
                xrLabel41.Text = "Cr";

            }
            else
            {
                xrLabel42.Text = "Cr";
                xrLabel41.Text = "Dr";
            }
        }

    }
}
