using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ExchangeCompanySoftware.Reports
{
    public partial class rptTRB : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTRB()
        {
            InitializeComponent();
        }

        private void xrLabel26_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel25_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
        
        private void lblCredit_AfterPrint(object sender, EventArgs e)
        {
            if (xrLabel25.Text != null)
            {
                   if (xrLabel25.Text != "-")
                    {
                        lblCredit.ForeColor = Color.Red;
                        xrLabel25.ForeColor = Color.Red;
                        xrLabel24.ForeColor = Color.Red;
                        xrLabel23.ForeColor = Color.Red;
                        xrLabel22.ForeColor = Color.Red;
                        lblDebit.ForeColor =  Color.Red;
                    }
                   else
                   {
                       lblCredit.ForeColor = Color.Green;
                       xrLabel25.ForeColor = Color.Green;
                       xrLabel24.ForeColor = Color.Green;
                       xrLabel23.ForeColor = Color.Green;
                       xrLabel22.ForeColor = Color.Green;
                       lblDebit.ForeColor = Color.Green;

                   }
            }
        }

    }
}
