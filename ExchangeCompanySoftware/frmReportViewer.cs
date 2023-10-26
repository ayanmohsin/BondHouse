using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ExchangeCompanySoftware
{
    public partial class frmReportViewer : Form
    {
        DataTable dtb;
        string strReportName;
        public frmReportViewer(DataTable pdtb,string pstrReportName)
        {
            InitializeComponent();
            dtb = pdtb;
            strReportName = pstrReportName + ".rpt";
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {

            ReportDocument lrd = null;
            lrd = new ReportDocument();
            string strPath = Application.StartupPath.ToString();
            strPath = strPath.Replace("\\bin\\Debug", "");
            strPath = strPath + "\\Reports\\" + strReportName;
            string rptFileName = strPath;
            lrd.Load(rptFileName);
            lrd.SetDataSource(dtb);
            lrd.SetParameterValue("BranchName", General.strBranchName);
            lrd.SetParameterValue("CompanyName", General.strCompanyName);
            lrd.SetParameterValue("Phone", General.strPhone);
            lrd.SetParameterValue("Fax", General.strFax);
            lrd.SetParameterValue("Address", General.strAddress);
            lrd.SetParameterValue("ReportTitle", General.strReportCaption);
            lrd.SetParameterValue("User", General.strUserId);
            crViewer.ReportSource = lrd;
            
        }

    }
}
