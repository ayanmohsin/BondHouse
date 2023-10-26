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
    public partial class frmFormQueryBuilder : BaseForm,IToolBar
    {
        string strOrderby;
        string strQuery;
        public string strError = "";
        GetData.ServiceSoapClient objGetData;
        DataTable dtb;
        enum Grid { not, Query, Caption, Criteria, btn, Man, DataType, Operator, Order };
        string strDefaultColumn = "";
        string strSupressDefaultColumn = "";
        int intSupressChk;
        private string objectname1 = String.Empty;
        public frmFormQueryBuilder(string objectname)
        {
            InitializeComponent();
            objectname1 = objectname;
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
        private void populateAllQueryField()
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dtb = new DataTable();

            strQuery = "Select * from AllqueryField Where ObjectName = '" + objectname1 + "';Select * from EX_System Where Flag = 'O';Select * from EX_System Where Flag = 'OP'";
            dtb = objGetData.GetDataSet(strQuery).Tables[0];
            int l = dtb.Rows.Count;
            int intDefault = 0;
            for (int i = 0; i < l; i++)
            {
                int n = dtbDetail.Rows.Add();
                dtbDetail.Rows[n].Cells["Not"].Value = dtb.Rows[i][2].ToString();
                if (dtb.Rows[i][4].ToString().Contains("strBranch") == true)
                {
                    dtb.Rows[i][4] = dtb.Rows[i][4].ToString().Replace("strBranch", General.strBranchCodeFrom.ToString());
                }
                dtbDetail.Rows[n].Cells["Query"].Value = dtb.Rows[i][4].ToString();
                dtbDetail.Rows[n].Cells["Caption"].Value = dtb.Rows[i][3].ToString();
                dtbDetail.Rows[n].Cells["Man"].Value = dtb.Rows[i][5].ToString();
                dtbDetail.Rows[n].Cells["DataType"].Value = dtb.Rows[i][6].ToString();
                dtbDetail.Rows[i].Cells["Criteria"].Value = "";
              
                DataGridViewComboBoxColumn cboTitle = new DataGridViewComboBoxColumn();
                cboTitle.Name = "Operator";
                cboTitle.HeaderText = "Operator";
                cboTitle.Width = 50;
                cboTitle.DataSource = dtb;
                cboTitle.DisplayMember = "Operator";
                cboTitle.ValueMember = "Operator";

             //   dtbDetail.Columns.Add(cboTitle);

             //   dtbDetail.Columns["Operator"].DisplayIndex = 2;
                //for (int iv = 0; iv < dtbDetail.Rows.Count; iv++)
                //{
                //    dtbDetail.Rows[iv].Cells["Operator"].Value = "=";
                //}
            }      
        }
   
        private void frmFormQueryBuilder_Load(object sender, EventArgs e)
        {
            AddColumn();
            populateAllQueryField();
            dtbDetail.CellContentClick += new DataGridViewCellEventHandler(dtbDetail_CellContentClick);
    
            dtbMaster.Visible = false;
            txtStatus.Visible = false;
            statusStrip1.Visible = false;
        }
        void dtbDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.ColumnIndex == dtbDetail.Columns["Click"].Index)
                {
                    objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                    string strqry = dtbDetail.Rows[e.RowIndex].Cells["Query"].Value.ToString();
                    dtb = new DataTable();
                    dtb = objGetData.GetDataSet(strqry).Tables[0];
                    frmListSearch childForm = new frmListSearch(dtb, dtbDetail.Rows[e.RowIndex].Cells["DataType"].Value.ToString(), "=");
                    childForm.ShowDialog();
                    dtbDetail.Rows[e.RowIndex].Cells["Criteria"].Value = frmListSearch.strArg[0];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        private void AddColumn()
        {
            DataGridViewTextBoxColumn clmnQuery = new DataGridViewTextBoxColumn();
            clmnQuery.Name = "Query";
            clmnQuery.HeaderText = "Query";
            clmnQuery.Width = 40;
            clmnQuery.Visible = false;
            clmnQuery.ReadOnly = true;

            dtbDetail.Columns.Add(clmnQuery);

            DataGridViewTextBoxColumn clmnCaption = new DataGridViewTextBoxColumn();
            clmnCaption.Name = "Caption";
            clmnCaption.HeaderText = "Caption";
            clmnCaption.Width = 100;
            clmnCaption.ReadOnly = true;
            dtbDetail.Columns.Add(clmnCaption);


            DataGridViewTextBoxColumn clmnCriteria = new DataGridViewTextBoxColumn();
            clmnCriteria.Name = "Criteria";
            clmnCriteria.HeaderText = "Criteria";
            clmnCriteria.Width = 150;
            dtbDetail.Columns.Add(clmnCriteria);

            DataGridViewButtonColumn clmnbtn = new DataGridViewButtonColumn();
            clmnbtn.Name = "Click";
            clmnbtn.HeaderText = "Click";
            clmnbtn.Width = 60;
            dtbDetail.Columns.Add(clmnbtn);

            DataGridViewTextBoxColumn clmnMan = new DataGridViewTextBoxColumn();
            clmnMan.Name = "Man";
            clmnMan.HeaderText = "Man";
            clmnMan.Width = 40;
            clmnMan.Visible = false;
            clmnMan.ReadOnly = true;

            dtbDetail.Columns.Add(clmnMan);

            DataGridViewTextBoxColumn clmnDataType = new DataGridViewTextBoxColumn();
            clmnDataType.Name = "DataType";
            clmnDataType.HeaderText = "DataType";
            clmnDataType.Width = 40;
            clmnDataType.ReadOnly = true;
            clmnDataType.Visible = false;
            dtbDetail.Columns.Add(clmnDataType);

            DataGridViewTextBoxColumn clmnnot = new DataGridViewTextBoxColumn();
            clmnnot.Name = "not";
            clmnnot.HeaderText = "not";
            clmnnot.Width = 40;
            clmnnot.ReadOnly = true;
            clmnnot.Visible = false;
            dtbDetail.Columns.Add(clmnnot);

       
        }
       
        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            string strqry = "";
            General.strFormQueryCriteria = "";
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (dtbDetail.Rows[i].Cells["Criteria"].Value != "" && dtbDetail.Rows[i].Cells["Criteria"].Value != null)
                {
                    if (dtbDetail.Rows[i].Cells["Not"].Value.ToString() != "Dateason".ToString() && dtbDetail.Rows[i].Cells["Not"].Value.ToString() != "DateFrom".ToString() && dtbDetail.Rows[i].Cells["Not"].Value.ToString() != "DateTo".ToString() && dtbDetail.Rows[i].Cells["Not"].Value.ToString() != "qryStringValue".ToString())
                    {
                        strqry = strqry + " and " + dtbDetail.Rows[i].Cells["Not"].Value + " = (" + dtbDetail.Rows[i].Cells["Criteria"].Value + ")";
                    }
                }
                General.strFormQueryCriteria = strqry;
            }
            this.Close();
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                dtbDetail.Rows[i].Cells["Criteria"].Value = "";
            }
        }
    }
}
