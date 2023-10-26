using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ExchangeCompanySoftware.Reports.SBP
{
    public partial class rptSEC6 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSEC6()
        {
            InitializeComponent();
        }

        private void lblPTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = (Convert.ToDouble(lblPRes.Text) + Convert.ToDouble(lblPNRM.Text) + Convert.ToDouble(lblPExchange.Text) + Convert.ToDouble(lblImp.Text)).ToString();
        }

        private void lblGrandTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = (Convert.ToDouble(lblPTotal.Text) + Convert.ToDouble(lblOpening.Text)).ToString();
        }

        private void lblSaleTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = (Convert.ToDouble(lblSaleContra.Text) + Convert.ToDouble(lblSaleBank.Text) + Convert.ToDouble(lblSaleExchange.Text) + Convert.ToDouble(lblSaleNRes.Text) + Convert.ToDouble(lblSaleRes.Text)).ToString();
        }

        private void lblClosing_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = (Convert.ToDouble(lblGrandTotal.Text) - Convert.ToDouble(lblSaleTotal.Text)).ToString();
        }

//            lblPOTH.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblPOTH_BeforePrint);
//            lblPOUN.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblPOUN_BeforePrint);
//            lblPOMILL.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblPOMILL_BeforePrint);
//            lblPConMill.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblPConMill_BeforePrint);
//            lblPConTH.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblPConTH_BeforePrint);
//            lblPConUnit.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblPConUnit_BeforePrint);
//            lblPEXM.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblPEXM_BeforePrint);
//            lblPEXT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblPEXT_BeforePrint);
//            lblPEXU.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblPEXU_BeforePrint);
//            lblNRESM.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblNRESM_BeforePrint);
//            lblNREST.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblNREST_BeforePrint);
//            lblNRESU.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblNRESU_BeforePrint);
//            lblResM.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblResM_BeforePrint);
//            lblResT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblResT_BeforePrint);
//            lblResU.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblResU_BeforePrint);
//            lblSResM.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSResM_BeforePrint);
//            lblSResT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSResT_BeforePrint);
//            lblSResU.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSResU_BeforePrint);
//            lblSNresM.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSNresM_BeforePrint);
//            lblSNresT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSNresT_BeforePrint);
//            lblSNresU.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSNresU_BeforePrint);
//            lblSEXM.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSEXM_BeforePrint);
//            lblSEXT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSEXT_BeforePrint);
//            lblSEXU.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSEXU_BeforePrint);
//            lblBNKM.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblBNKM_BeforePrint);
//            lblBNKT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblBNKT_BeforePrint);
//            lblBNKU.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblBNKU_BeforePrint);
//            lblSConM.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSConM_BeforePrint);
//            lblSConT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSConT_BeforePrint);
//            lblSConU.BeforePrint += new System.Drawing.Printing.PrintEventHandler(lblSConU_BeforePrint);
//        }

//        void lblSConU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblSContra.Text)).ToString();
//        }

//        void lblSConT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblSContra.Text)).ToString();
//        }

//        void lblSConM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblSContra.Text)).ToString();
//        }

//        void lblBNKU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblBank.Text)).ToString();
//        }

//        void lblBNKT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblBank.Text)).ToString();
//        }

//        void lblBNKM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblBank.Text)).ToString();
//        }

//        void lblSEXU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblSExchange.Text)).ToString();
//        }

//        void lblSEXT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblSExchange.Text)).ToString();
//        }

//        void lblSEXM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblSExchange.Text)).ToString();
//        }

//        void lblSNresU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblSNRes.Text)).ToString();
//        }
//        void lblSNresT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblSNRes.Text)).ToString();
//        }
//        void lblSNresM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblSNRes.Text)).ToString();
//        }
//        void lblSResU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblSRes.Text)).ToString();
//        }
//        void lblSResT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblSRes.Text)).ToString();
//        }
//        void lblSResM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblSRes.Text)).ToString();
//        }
        
//        #region Purchase Event
//        void lblResU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblRes.Text)).ToString();
//        }

//        void lblResT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblRes.Text)).ToString();
//        }

//        void lblResM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblRes.Text)).ToString();
//        }

//        void lblNRESU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblNonRes.Text)).ToString();
//        }

//        void lblNREST_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblNonRes.Text)).ToString();
//        }

//        void lblNRESM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblNonRes.Text)).ToString();
//        }

//        void lblPEXU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblPEX.Text)).ToString();
//        }

//        void lblPEXT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblPEX.Text)).ToString();
//        }

//        void lblPEXM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblPEX.Text)).ToString();
//        }

//        void lblPConUnit_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblpconM.Text)).ToString();
//        }
//        void lblPConTH_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblpconM.Text)).ToString();
//        }
//        void lblPConMill_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblpconM.Text)).ToString();
//        }
//        void lblPOTH_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblOpening.Text)).ToString();
//        }
//        void lblPOUN_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblOpening.Text)).ToString();
//        }

//        void lblPOMILL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblOpening.Text)).ToString();
//        }
//#endregion

//        private int Million(double Million)
//        {
//            int intMillion = (int)Convert.ToDouble(Million) / 1000000;
//            return intMillion;
//        }
//        private int Thousand(double Million)
//        {
//            int intMillion = (int)Convert.ToDouble(Million % 1000000) / 1000;
//            return intMillion;
//        }
//        private int Unit(double Million)
//        {
//            int intMillion = (int)Convert.ToDouble((Million % 1000000) % 1000);
//            return intMillion;
//        }

//        private void lblTotM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = (Convert.ToDouble(lblNRESM.Text)+Convert.ToDouble(lblpconM.Text) + Convert.ToDouble(lblPEXM.Text) + Convert.ToDouble(lblResM.Text)).ToString();
//        }

//        private void lbltotT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = (Convert.ToDouble(lblNREST.Text) + Convert.ToDouble(lblPConTH.Text) + Convert.ToDouble(lblPEXT.Text) + Convert.ToDouble(lblResT.Text)).ToString();
//        }

//        private void lblTOTU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = (Convert.ToDouble(lblNRESU.Text) + Convert.ToDouble(lblPConUnit.Text) + Convert.ToDouble(lblPEXU.Text) + Convert.ToDouble(lblResU.Text)).ToString();
//        }

//        private void xrLabel31_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = (Convert.ToDouble(lblTotM.Text) + Convert.ToDouble(lblPOMILL.Text)).ToString(); 
//        }

//        private void xrLabel32_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = (Convert.ToDouble(lbltotT.Text) + Convert.ToDouble(lblPOTH.Text)).ToString(); 
//        }

//        private void xrLabel33_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = (Convert.ToDouble(lblTOTU.Text) + Convert.ToDouble(lblPOUN.Text)).ToString(); 
//        }

//        private void lblSTotM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Million(Convert.ToDouble(lblBank.Text) + Convert.ToDouble(lblSContra.Text) + Convert.ToDouble(lblSExchange.Text) + Convert.ToDouble(lblSNRes.Text) + Convert.ToDouble(lblSRes.Text)).ToString();
//        }

//        private void lblSTotT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Thousand(Convert.ToDouble(lblBank.Text) + Convert.ToDouble(lblSContra.Text) + Convert.ToDouble(lblSExchange.Text) + Convert.ToDouble(lblSNRes.Text) + Convert.ToDouble(lblSRes.Text)).ToString();
//        }

//        private void lblSTotU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = Unit(Convert.ToDouble(lblBank.Text) + Convert.ToDouble(lblSContra.Text) + Convert.ToDouble(lblSExchange.Text) + Convert.ToDouble(lblSNRes.Text) + Convert.ToDouble(lblSRes.Text)).ToString();
//        }

//        private void lblCloM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = (Convert.ToDouble(lblTotM.Text) + Convert.ToDouble(lblPOMILL.Text) - Convert.ToDouble(lblSTotM.Text)).ToString();
//        }

//        private void lblCloT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = (Convert.ToDouble(lbltotT.Text) + Convert.ToDouble(lblPOTH.Text) - Convert.ToDouble(lblSTotT.Text)).ToString();
//        }

//        private void lblCloU_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//        {
//            ((XRLabel)sender).Text = (Convert.ToDouble(lblTOTU.Text) + Convert.ToDouble(lblPOUN.Text) - Convert.ToDouble(lblSTotU.Text)).ToString();
//        }
    }
}
