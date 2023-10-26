using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace ExchangeCompanySoftware
{
    public partial class frmSBP : BaseForm,IToolBar
    {
        General cls;
        GetData.ServiceSoapClient objGetData;
        string strMainObject;
        public frmSBP(string strObject)
        {
            InitializeComponent();
            strMainObject = strObject;
        }

        private void frmstaofsalefcyInterBankMkt_Load(object sender, EventArgs e)
        {
            dtbMaster.Visible = false;
            statusStrip1.Visible = false;
        }

        #region IToolBar Members

        public bool ADD()
        {
            throw new NotImplementedException();
        }

        public bool SAVE()
        {
            throw new NotImplementedException();
        }

        public bool EDIT()
        {
            throw new NotImplementedException();
        }

        public bool QUERY()
        {
            throw new NotImplementedException();
        }

        public bool UNDO()
        {
            throw new NotImplementedException();
        }

        public bool EXIT()
        {
            throw new NotImplementedException();
        }

        public bool DELETE()
        {
            throw new NotImplementedException();
        }

        public bool NEXT()
        {
            throw new NotImplementedException();
        }

        public bool PREVIOUS()
        {
            throw new NotImplementedException();
        }

        public bool LAST()
        {
            throw new NotImplementedException();
        }

        public bool FIRST()
        {
            throw new NotImplementedException();
        }

        public bool AUTHORIZE()
        {
            throw new NotImplementedException();
        }

        public bool PRINT()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            XtraReport devrep;
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataTable dtb = new DataTable();
            string strReport;
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dtb = objGetData.GetDataSet("Select * from AllQuery Where  ObjectName = '" + strMainObject + "'").Tables[0];
            strReport = dtb.Rows[0]["ReportName"].ToString();
            string strReportName = "ExchangeCompanySoftware" + "." + "Reports.SBP." + strReport;
            devrep = (XtraReport)Activator.CreateInstance(Type.GetType(strReportName, true, true));
            string strQuery = dtb.Rows[0][1].ToString();
            DataSet ds = null;
            if (strQuery != "")
            {
                strQuery = "EXEC  [" + strQuery + "]	'" + dtFromDate.Value.ToString("dd/MMM/yyyy") + "',	'" + dtToDate.Value.ToString("dd/MMM/yyyy") + "'," + General.strBranchCodeFrom + "," + General.strBranchCodeTo + "";
                ds = new DataSet();
                ds = objGetData.GetDataSet(strQuery);
                General.dsSubReport = ds;
                devrep.DataSource = ds.Tables[0];
            }
            devrep.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
            devrep.Parameters["ReportName"].Value = General.strReportCaption;
            devrep.Parameters["CompanyName"].Value = General.strCompanyName;
            devrep.Parameters["BranchName"].Value = General.strAddress;
            devrep.Parameters["Criteria"].Value = "For The Date From "+ dtFromDate.Value.ToString("dd/MMM/yyyy")  +" TO  "+ dtToDate.Value.ToString("dd/MMM/yyyy") +" ";
            devrep.RequestParameters = false;
            devrep.CreateDocument();
            devrep.ShowPreview();
        }
    }
}
