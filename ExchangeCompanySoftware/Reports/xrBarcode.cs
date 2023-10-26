using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ExchangeCompanySoftware.Reports
{
    public partial class xrBarcode : DevExpress.XtraReports.UI.XtraReport
    {
        int i;
        public xrBarcode()
        {
            InitializeComponent();
        }

        private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
         
        }

        private void xrLabel2_AfterPrint(object sender, EventArgs e)
        {
            //i = i + 1;
            //if (i==78)
            //{
            //    Detail.PageBreak = PageBreak.AfterBand;
            //    i = 0;
            //}
            //if (i==1)
            //{
            //    Detail.PageBreak = PageBreak.None;
            //}
        }

    }
}
