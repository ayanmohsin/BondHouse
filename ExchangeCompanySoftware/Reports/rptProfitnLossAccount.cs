using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ExchangeCompanySoftware.Reports
{
    public partial class rptProfitnLossAccount : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProfitnLossAccount()
        {
            InitializeComponent();
        }

        private void GroupFooter1_AfterPrint(object sender, EventArgs e)
        {
          

        }

        private void GroupFooter1_BandLevelChanged(object sender, EventArgs e)
        {
          
        }

    }
}
