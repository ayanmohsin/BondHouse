using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ExchangeCompanySoftware.Reports
{
    public partial class rptExposure : DevExpress.XtraReports.UI.XtraReport
    {
        private double groupTotal = 0;
        private double Exposure = 0;

        public rptExposure()
        {
            InitializeComponent();
        }

        private void rptExposure_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
       
        }

        private void lblExposure_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
         
       
        }

        private void lblSumofamount_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            groupTotal = Convert.ToDouble(((XRLabel)sender).Text.Replace("(","-").Replace(")",""));
        }

        private void lblExposur_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            Exposure = Convert.ToDouble(((XRLabel)sender).Text);
          
        }

        private void rptExposure_AfterPrint(object sender, EventArgs e)
        {
         
        }

        private void lblExposure_PrintOnPage_1(object sender, PrintOnPageEventArgs e)
        {
            if (Exposure > 0 && groupTotal > 0)
            {
                if (Convert.ToDouble((groupTotal / Exposure) * 100) > 50)
                {
                    lblExposure.Text = "Over Limit";
                    lblExposure.ForeColor = Color.Red;
                   
                }
                else
                {
                    lblExposure.Text = "Under Limit";
                    lblExposure.ForeColor = Color.Blue;
                }
            }
        }

        private void lblLimit_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            lblLimit.Text = (Exposure - groupTotal).ToString();

        }

        private void xrLabel24_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //double avgrate = Convert.ToDouble(xrLabel8.Text);
            //double revrate = Convert.ToDouble(xrLabel24.Text);
            //double quantity = Convert.ToDouble(xrLabel6.Text);
            //double profit = Math.Round((avgrate - revrate) * quantity,0);
            //xrLabel32.Text = profit.ToString();
        }

        private void xrLabel28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double dbl;
            if (xrLabel28.Text != "-")
            {
                dbl = Convert.ToDouble(xrLabel28.Text.Replace("(", "-").Replace(")", ""));
            }
            else
            {
                dbl = 0;
            }
            if (dbl > 0)
            {
                xrLabel28.ForeColor = Color.Red;
            }
            else
            {
                xrLabel28.ForeColor = Color.Blue;
            }
        }

        private void xrLabel28_AfterPrint(object sender, EventArgs e)
        {
           
        }

    }
}
