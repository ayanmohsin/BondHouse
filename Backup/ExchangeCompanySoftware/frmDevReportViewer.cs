using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExchangeCompanySoftware.Reports;

namespace ExchangeCompanySoftware
{
    public partial class frmDevReportViewer : Form
    {
        public frmDevReportViewer(rptDynamic devrep)
        {
            InitializeComponent();

            devrep.CreateDocument();
            this.devViewer.UpdatePageView();
            this.devViewer.PrintingSystem = devrep.PrintingSystem;
     
        }
    }
}
