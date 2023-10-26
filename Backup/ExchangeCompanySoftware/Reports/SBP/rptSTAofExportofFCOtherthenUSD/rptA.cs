using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace ExchangeCompanySoftware.Reports.SBP
{
    public partial class rptA : DevExpress.XtraReports.UI.XtraReport
    {
        DataSet dsMain = new DataSet();
        public rptA()
        {
            InitializeComponent();
        }

        private void rptA_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            dsMain = General.dsSubReport;
            rptB rptB = new rptB();
            rptB.DataSource = dsMain.Tables[1];
            rptB.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
            xrSubreport1.ReportSource = rptB;
        }
    }
}
