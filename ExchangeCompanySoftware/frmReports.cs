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
    public partial class frmReports : Form 
    {
        string strOrderby;
        string strQuery;
        public string strError = "";
        GetData.ServiceSoapClient objGetData; 
        DataTable dtb;
        enum Grid { not, Query, Caption, Criteria, btn, Man, DataType, Operator, Order };
        private string objectname1 = String.Empty;

        public frmReports(string objectname)
        {
            InitializeComponent();
            objectname1 = objectname;
        }

        private void populateAllQueryField()
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dtb = new DataTable();
            strQuery = "Select * from AllqueryField Where ObjectName = '" + objectname1 + "';Select * from EX_System Where Flag = 'O'";
            dtb = objGetData.GetDataSet(strQuery).Tables[0];
            int l = dtb.Rows.Count;
            for (int i = 0; i < l; i++)
            {
                int n = dtbDetail.Rows.Add();
                dtbDetail.Rows[n].Cells[(int)Grid.not].Value = dtb.Rows[i][2].ToString();
                if (dtb.Rows[i][4].ToString().Contains("strBranch") == true)
                {
                    dtb.Rows[i][4] = dtb.Rows[i][4].ToString().Replace("strBranch", General.strBranchCodeFrom.ToString());
                }
                dtbDetail.Rows[n].Cells[(int)Grid.Query].Value = dtb.Rows[i][4].ToString();
                dtbDetail.Rows[n].Cells[(int)Grid.Caption].Value = dtb.Rows[i][3].ToString();
                dtbDetail.Rows[n].Cells[(int)Grid.Man].Value = dtb.Rows[i][5].ToString();
                dtbDetail.Rows[n].Cells[(int)Grid.DataType].Value = dtb.Rows[i][6].ToString();   
            }
            dtb = new DataTable();
            dtb = objGetData.GetDataSet(strQuery).Tables[1];
            string[] words = dtb.Rows[0][1].ToString().Split(';');
            dtb = new DataTable();
            dtb.Columns.Add();
            dtb.Columns[0].ColumnName = "Operator";
            for (int i = 0; i < words.Count(); i++)
            {
                dtb.Rows.Add();
                dtb.Rows[i]["Operator"] = words[i];
            }
            DataGridViewComboBoxColumn cboTitle = new DataGridViewComboBoxColumn();
            cboTitle.Name = "Operator";
            cboTitle.HeaderText = "Operator";
            cboTitle.Width = 50;
            cboTitle.DataSource = dtb;
            cboTitle.DisplayMember = "Operator";
            cboTitle.ValueMember = "Operator";   
            dtbDetail.Columns.Add(cboTitle);
            dtbDetail.Columns["Operator"].DisplayIndex = 3;
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                dtbDetail.Rows[i].Cells[(int)Grid.Operator].Value = "=";
            }
            DataGridViewCheckBoxColumn chkOrder = new DataGridViewCheckBoxColumn();
            chkOrder.Name = "Order";
            chkOrder.HeaderText = "Order";
            chkOrder.Width = 50;
            dtbDetail.Columns.Add(chkOrder);
        
        
        }
        private Boolean CheckMandatory()
        {
            Boolean blnState = true;
            strError = "";
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtbDetail.Rows[i].Cells[(int)Grid.Man].Value) == true)
                {
                    if (dtbDetail.Rows[i].Cells[(int)Grid.Criteria].Value == null)
                    {
                        blnState =  false;
                        if (strError == "")
                        {
                            strError = "must be Enter " + dtbDetail.Rows[i].Cells[(int)Grid.Caption].Value + "";
                        }
                        else
                        {
                            strError = strError + "\n" + "must be Enter " + dtbDetail.Rows[i].Cells[(int)Grid.Caption].Value + "";
                        }
                    }
                    else
                    {
                        blnState =  true;
                    }
                }
                
            }
            return blnState;
        }
        public void WhereClause(string strq)
        {
            string strqry;
            strqry = strQuery;
            Boolean bolstate;
            if (strqry.Contains("qryBranchFrom") == true || strqry.Contains("qryBranchTo") == true)
            {
                strqry = strqry.Replace("qryBranchFrom", General.strBranchCodeFrom.ToString());
                strqry = strqry.Replace("qryBranchTo", General.strBranchCodeTo.ToString());
            }
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (dtbDetail.Rows[i].Cells[(int)Grid.Criteria].Value != String.Empty && dtbDetail.Rows[i].Cells[(int)Grid.Criteria].Value != null)
                {
                    if (strqry.Contains("DateFrom") == true || strqry.Contains("Dateason") == true || strqry.Contains("DateTo") == true || strqry.Contains("qryStringValue") == true || strqry.Contains("qryBranchFrom") == true || strqry.Contains("qryBranchTo") == true)
                    {
                        if (dtbDetail.Rows[i].Cells[(int)Grid.not].Value.ToString() == "Dateason")
                        {
                            strqry = strqry.Replace("Dateason", Convert.ToDateTime(dtbDetail.Rows[i].Cells[(int)Grid.Criteria].Value.ToString()).ToString("dd-MMM-yyyy"));
                        }
                        else if (dtbDetail.Rows[i].Cells[(int)Grid.not].Value.ToString() == "DateFrom")
                        {
                            strqry = strqry.Replace("DateFrom", Convert.ToDateTime(dtbDetail.Rows[i].Cells[(int)Grid.Criteria].Value.ToString()).ToString("dd-MMM-yyyy"));
                            strqry = strqry.Replace("DateTo", Convert.ToDateTime(dtbDetail.Rows[i + 1].Cells[(int)Grid.Criteria].Value.ToString()).ToString("dd-MMM-yyyy"));
                        }
                        else if (dtbDetail.Rows[i].Cells[(int)Grid.not].Value.ToString() == "qryStringValue")
                        {
                            strqry = strqry.Replace("qryStringValue", dtbDetail.Rows[i].Cells[(int)Grid.Criteria].Value.ToString());
                        }
                        else if (dtbDetail.Rows[i].Cells[(int)Grid.not].Value.ToString() == "qryBranchFrom")
                        {
                            strqry = strqry.Replace("qryBranchFrom", General.strBranchCode.ToString());
                        }
                        else if (dtbDetail.Rows[i].Cells[(int)Grid.not].Value.ToString() == "qryBranchTo")
                        {
                            strqry = strqry.Replace("qryBranchTo", General.strBranchCodeTo.ToString());
                        }
                    }
                    if (dtbDetail.Rows[i].Cells[(int)Grid.not].Value.ToString() != "Dateason".ToString() && dtbDetail.Rows[i].Cells[(int)Grid.not].Value.ToString() != "DateFrom".ToString() && dtbDetail.Rows[i].Cells[(int)Grid.not].Value.ToString() != "DateTo".ToString() && dtbDetail.Rows[i].Cells[(int)Grid.not].Value.ToString() != "qryStringValue".ToString())
                    {
                        strqry = strqry + " and " + dtbDetail.Rows[i].Cells[(int)Grid.not].Value + " " + dtbDetail.Rows[i].Cells[(int)Grid.Operator].Value + "  ('" + dtbDetail.Rows[i].Cells[(int)Grid.Criteria].Value + "')";
                    }
                }
                strQuery = strqry;
            }

        }
        public void OrderbyClause()
        {
            string strOrderbyClause = null;
            if (strOrderby != "")
            {
                strOrderbyClause = "Order by " + strOrderby;
            }
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtbDetail.Rows[i].Cells[(int)Grid.Order].Value) == true)
                {
                    if (strOrderbyClause == null)
                    {
                        strOrderbyClause = "Order by " + dtbDetail.Rows[i].Cells[(int)Grid.not].Value + "";
                    }
                    else
                    {
                        strOrderbyClause = strOrderbyClause + "," + dtbDetail.Rows[i].Cells[(int)Grid.not].Value + "";
                    }
                }
            }
            strQuery = strQuery + "  " + strOrderbyClause;
        }
        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            if (CheckMandatory() == true)
            {
                string strReportName;
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                dtb = objGetData.GetDataSet("Select * from AllQuery Where  ObjectName = '" + objectname1 + "'").Tables[0];
                strQuery = dtb.Rows[0][1].ToString();
                strOrderby = dtb.Rows[0]["OrderbyClause"].ToString();
                WhereClause(strQuery);
                OrderbyClause();
                strReportName = dtb.Rows[0][2].ToString();
                dtb = objGetData.GetDataSet(strQuery).Tables[0];
                frmReportViewer frmrpt = new frmReportViewer(dtb, strReportName);
                frmrpt.Show();    
            }
            else
            {
                MessageBox.Show(strError);
            }
        }
        
        
        private void frmReports_Load(object sender, EventArgs e)
        {
            populateAllQueryField();
                 }

        private void dtbDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if (e.ColumnIndex == (int)Grid.btn)
                {
                    objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                    string strqry = dtbDetail.Rows[e.RowIndex].Cells[(int)Grid.Query].Value.ToString();
                    dtb = new DataTable();
                    dtb = objGetData.GetDataSet(strqry).Tables[0];
                    frmListSearch childForm = new frmListSearch(dtb, dtbDetail.Rows[e.RowIndex].Cells[(int)Grid.DataType].Value.ToString(), dtbDetail.Rows[e.RowIndex].Cells[(int)Grid.Operator].Value.ToString());
                    childForm.ShowDialog();
                    dtbDetail.Rows[e.RowIndex].Cells[(int)Grid.Criteria].Value = frmListSearch.strArg[0];
                }
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region IToolBar Members

        public bool ADD()
        {
           return true;
        }

        public bool SAVE()
        {
           return true;
        }

        public bool EDIT()
        {
           return true;
        }

        public bool QUERY()
        {
           return true;
        }

        public bool UNDO()
        {
           return true;
        }

        public bool EXIT()
        {
           return true;
        }

        public bool DELETE()
        {
           return true;
        }

        public bool NEXT()
        {
           return true;
        }

        public bool PREVIOUS()
        {
           return true;
        }

        public bool LAST()
        {
           return true;
        }

        public bool FIRST()
        {
           return true;
        }

        public bool AUTHORIZE()
        {
           return true;
        }

        public bool PRINT()
        {
           return true;
        }

        #endregion
    }
}
