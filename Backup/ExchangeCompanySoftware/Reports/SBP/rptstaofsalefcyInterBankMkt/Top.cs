using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace ExchangeCompanySoftware.Reports.SBP
{
    public partial class Top : DevExpress.XtraReports.UI.XtraReport
    {
        DataSet dsMain;
        public Top()
        {
            InitializeComponent();
            
        }

        private void Top_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            dsMain = General.dsSubReport;
            rptstaofsalefcyInterBankMkt.Middle rpMiddle = new ExchangeCompanySoftware.Reports.SBP.rptstaofsalefcyInterBankMkt.Middle();
            rpMiddle.DataSource = dsMain.Tables[1];
            rpMiddle.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
            xrSubreport1.ReportSource = rpMiddle;
            rptstaofsalefcyInterBankMkt.Bottom rpdBottom = new ExchangeCompanySoftware.Reports.SBP.rptstaofsalefcyInterBankMkt.Bottom();
            rpdBottom.DataSource = dsMain.Tables[2];
            rpdBottom.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
            xrSubreport2.ReportSource = rpdBottom;
        }

        private void xrSubreport2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
