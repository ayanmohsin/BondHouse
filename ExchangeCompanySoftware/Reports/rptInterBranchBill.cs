using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ExchangeCompanySoftware.Reports
{
    public partial class rptInterBranchBill : DevExpress.XtraReports.UI.XtraReport
    {
        public rptInterBranchBill()
        {
            InitializeComponent();
        }

        private void xrLabel21_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
         
        }

        private void xrLabel9_AfterPrint(object sender, EventArgs e)
        {
            if (xrLabel9.Text == "Purchase")
            {
                xrLabel21.Text = "Dr";
                xrLabel20.Text = "Cr";

            }
            else
            {
                xrLabel21.Text = "Cr";
                xrLabel20.Text = "Dr";
            }
        }

    }
}
