using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace ExchangeCompanySoftware.Reports
{
    public partial class rptBalanceSheet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBalanceSheet()
        {
            InitializeComponent();
            
        
        }

        private void lbShowHide_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void lbShowHide_PreviewClick(object sender, PreviewMouseEventArgs e)
        {


        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
        

    }
}
