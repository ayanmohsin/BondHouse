using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace ExchangeCompanySoftware.Reports.SBP
{
    public partial class rptSBPFCSalePurStaDetail : DevExpress.XtraReports.UI.XtraReport
    {
        DataSet dsMain;
        public rptSBPFCSalePurStaDetail()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            dsMain = General.dsSubReport;
            rptSBPFCSalePurStaDetailA rpMiddle = new rptSBPFCSalePurStaDetailA();
            rpMiddle.DataSource = dsMain.Tables[0];
            rpMiddle.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
            xrSubreport1.ReportSource = rpMiddle;

            rptSBPFCSalePurStaDetailB rpMiddle1 = new rptSBPFCSalePurStaDetailB();
            rpMiddle1.DataSource = dsMain.Tables[1];
            rpMiddle1.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
            xrSubreport2.ReportSource = rpMiddle1;
        }
    }
}
