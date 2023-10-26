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
    public partial class frmGeneralLedger : BaseForm,IToolBar
    {
        General cls;
        GetData.ServiceSoapClient objGetData;
        
        public frmGeneralLedger()
        {
            InitializeComponent();
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
        private void frmGeneralLedger_Load(object sender, EventArgs e)
        {
            dtbMaster.Visible = false;
          //  dtTransDate.Visible = false;
            statusStrip1.Visible = false;
            PopulateCombo();
        }
        
        private void PopulateCombo()
        {
            cls = new General();
            string strQuery = "Select AccountNo,Title from EX_SetupAccount Where isTransactional = 'True' and BranchCode = '" + General.strBranchCode + "' and Status = 'A' ";
            if (!General.bolisMainUser)
            {
                strQuery += " and NatureCode != 3";
            }
            strQuery += " order by Title";

            DataSet ds = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            ds = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicboAccounts, ds.Tables[0], "Title", "AccountNo");
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            XtraReport devrep;
            string strQuery;

            strQuery = "Select * from AllQuery Where ObjectName = 'rptGL'";
            DataSet ds = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            ds = objGetData.GetDataSet(strQuery);
            strQuery = ds.Tables[0].Rows[0]["Query"].ToString();
            strQuery = strQuery.Replace("DateFrom", dtFromDate.Value.ToString("dd/MMM/yyyy"));
            strQuery = strQuery.Replace("DateTo", dtToDate.Value.ToString("dd/MMM/yyy"));

            strQuery = strQuery + " Where AccountNo = '"+ dicboAccounts.SelectedValue +"'" ;
            strQuery = strQuery + " Order by TransDate";
            
            string strReportName;
            if (dicboTypfoGL.Text != "")
            {
                strReportName = ds.Tables[0].Rows[0]["ReportName"].ToString() + dicboTypfoGL.Text;
            }
            else
            {
                MessageBox.Show("Select GL Type");
                return;
            }
            ds = objGetData.GetDataSet(strQuery);
            strReportName = "ExchangeCompanySoftware" + "." + "Reports." + strReportName;
            devrep = (XtraReport)Activator.CreateInstance(Type.GetType(strReportName, true, true));
            devrep.Margins = new System.Drawing.Printing.Margins(40, 0, 10, 10);
            devrep.DataSource = ds.Tables[0];
            devrep.Parameters["UserId"].Value = General.strUserId;
            devrep.Parameters["ReportName"].Value = General.strReportCaption;
            devrep.Parameters["CompanyName"].Value = General.strCompanyName;
            devrep.Parameters["BranchName"].Value = General.strBranchName;
            devrep.Parameters["Criteria"].Value = "";
            devrep.RequestParameters = false;
            devrep.CreateDocument();
            devrep.ShowPreview();
        }

        private void btnTB_Click(object sender, EventArgs e)
        {
            XtraReport devrep;
            string strQuery;
            strQuery = "Select * from AllQuery Where ObjectName = 'rptRangeTB'";
            DataSet ds = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            ds = objGetData.GetDataSet(strQuery);

            strQuery = ds.Tables[0].Rows[0]["Query"].ToString();
            strQuery = strQuery.Replace("DateFrom", dtFromDate.Value.ToString("dd/MMM/yyyy"));
            strQuery = strQuery.Replace("DateTo", dtToDate.Value.ToString("dd/MMM/yyy"));
            strQuery = strQuery.Replace("qryBranchFrom", General.strBranchCodeFrom);
            strQuery = strQuery.Replace("qryBranchTo", General.strBranchCodeTo);

            string strReportName;
            strReportName = ds.Tables[0].Rows[0]["ReportName"].ToString();
         
            ds = objGetData.GetDataSet(strQuery);
            strReportName = "ExchangeCompanySoftware" + "." + "Reports." + strReportName;
            devrep = (XtraReport)Activator.CreateInstance(Type.GetType(strReportName, true, true));
            devrep.Margins = new System.Drawing.Printing.Margins(45, 0, 10, 10);
            devrep.DataSource = ds.Tables[0];
            devrep.Parameters["UserId"].Value = General.strUserId;
            devrep.Parameters["ReportName"].Value = General.strReportCaption;
            devrep.Parameters["CompanyName"].Value = General.strCompanyName;
            devrep.Parameters["BranchName"].Value = General.strBranchName;
            devrep.Parameters["Criteria"].Value = "";
            devrep.RequestParameters = false;
            devrep.CreateDocument();
            devrep.ShowPreview();
        }

        private void btnBL_Click(object sender, EventArgs e)
        {
            XtraReport devrep;
            string strQuery;
            strQuery = "Select * from AllQuery Where ObjectName = 'rptBalanceSheet'";
            DataSet ds = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            ds = objGetData.GetDataSet(strQuery);

            strQuery = ds.Tables[0].Rows[0]["Query"].ToString();
            strQuery = strQuery.Replace("Dateason", dtFromDate.Value.ToString("dd/MMM/yyyy"));
            strQuery = strQuery.Replace("qryBranchFrom", General.strBranchCodeFrom);
            strQuery = strQuery.Replace("qryBranchTo", General.strBranchCodeTo);

            string strReportName;
            strReportName = ds.Tables[0].Rows[0]["ReportName"].ToString();

            ds = objGetData.GetDataSet(strQuery);
            strReportName = "ExchangeCompanySoftware" + "." + "Reports." + strReportName;
            devrep = (XtraReport)Activator.CreateInstance(Type.GetType(strReportName, true, true));
            devrep.Margins = new System.Drawing.Printing.Margins(45, 0, 10, 10);
            devrep.DataSource = ds.Tables[0];
            devrep.Parameters["UserId"].Value = General.strUserId;
            devrep.Parameters["ReportName"].Value = General.strReportCaption;
            devrep.Parameters["CompanyName"].Value = General.strCompanyName;
            devrep.Parameters["BranchName"].Value = General.strBranchName;
            devrep.Parameters["Criteria"].Value = "";
            devrep.RequestParameters = false;
            devrep.CreateDocument();
            devrep.ShowPreview();
        }
   
    }
}
