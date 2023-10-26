using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ExchangeCompanySoftware.Reports.Tickets
{
    public partial class rptPrePrinted : DevExpress.XtraReports.UI.XtraReport
    {
        int i = 0;
        int i1 = 0;

        public rptPrePrinted()
        {
            InitializeComponent();
        }

        private void xrLabel63_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lbl = (XRLabel)sender;
            i = i + 1;
            lbl.Text = i.ToString();
        }

        private void xrLabel61_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lbl = (XRLabel)sender;
            i1 = i1 + 1;
            lbl.Text = i1.ToString();
        }

    }
}
