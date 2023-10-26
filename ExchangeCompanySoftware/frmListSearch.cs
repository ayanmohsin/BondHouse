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
    public partial class frmListSearch : Form
    {
        DataTable dtbdetail;
        string strData;
        string strsearching;
        string strOperator;
        public static string[] strArg;
        public frmListSearch(DataTable dtb,string strDataType,string Operator)
        {
            InitializeComponent();
            dtbdetail = new DataTable();
            dtbdetail = dtb;
            strData = strDataType;
            strOperator = Operator;
        }

        private void frmListSearch_Load(object sender, EventArgs e)
        {
            if (strOperator == "IN" || strOperator == "NOT IN")
            {
                DataGridViewCheckBoxColumn clmn = new DataGridViewCheckBoxColumn();
                clmn.Name = "Select";
                clmn.HeaderText = "Select";
                clmn.Width = 20;
                clmn.ReadOnly = false;
                clmn.Selected = false; 
                clmn.FlatStyle = FlatStyle.Standard;
                dataGridView1.Columns.Add(clmn);
                dataGridView1.Columns["Select"].DisplayIndex = 0;
            }
            if (strData == "D")
            {
                dataGridView1.Visible = false;
                dtDate.Visible = true;
                txtsearch.Visible = false;
                this.Width = 270;
                this.Height = 150;
                this.Top = txtsearch.Top;
                cmdOk.Location = new System.Drawing.Point(47, 74);
                cmdCancel.Location = new System.Drawing.Point(128, 74);
                dtDate.Value = General.dtSystemDate;
            }
            else
            {
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dtbdetail;
                dataGridView1.ColumnHeadersVisible = true;
                dtDate.Visible = false;
                this.Width = 270;
                this.Height = 359;
                txtsearch.Visible = true;
                cmdOk.Location = new System.Drawing.Point(80, 295);
                cmdCancel.Location = new System.Drawing.Point(161, 295);
            }
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_ColumnHeaderMouseClick);
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (strsearching != null)
            {
                dtbdetail.DefaultView.RowFilter = "" + strsearching + " like '%" + txtsearch.Text + "%'";
                dataGridView1.DataSource = dtbdetail;
        
            }
            else
            {
                MessageBox.Show("Click on Column");
            }
        
        }

         void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            strsearching = dataGridView1.Columns[e.ColumnIndex].Name;
            this.Text = strsearching;
 
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            strArg = new string[dataGridView1.Columns.Count];
            try
            {
                
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    strArg[i] = "'" + dataGridView1.Rows[e.RowIndex].Cells[i].Value.ToString() + "'";
                }
                dataGridView1.DataSource = null;
                strsearching = null;
                this.Close();
            }
            catch (Exception ex)
            { }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtDate_Validated(object sender, EventArgs e)
        {
            //strArg = new string[1];
            //strArg[0] = dtDate.Value.ToString("dd/MMM/yyyy");
            //this.Close();

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            strArg = new string[1];
            strArg[0] = ""; 
            this.Close();

        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (strData != "D")
            {
                strArg = new string[dataGridView1.Columns.Count - 1];
                if (strOperator == "IN" || strOperator == "NOT IN")
                {
                    try
                    {
                        for (int iRow = 0; iRow < dataGridView1.Rows.Count; iRow++)
                        {
                            int iChk = 0;
                            if (Convert.ToBoolean(dataGridView1.Rows[iRow].Cells["SELECT"].Value) == true)
                            {
                                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                                {

                                    if (strArg[iChk] == null)
                                    {
                                        strArg[iChk] = "'"+ dataGridView1.Rows[iRow].Cells[i].Value.ToString() + "'";
                                    }
                                    else
                                    {
                                        strArg[iChk] = strArg[iChk] + "," + "'" + dataGridView1.Rows[iRow].Cells[i].Value.ToString() + "'";
                                    }
                                    iChk = iChk + 1;
                                }
                            }
                        }
                        dataGridView1.DataSource = null;
                        strsearching = null;
                        this.Close();
                    }
                    catch (Exception ex)
                    { }

                }
                else
                {
                    try
                    {

                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            strArg[i] = "'" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[i].Value.ToString() + "'"  ;
                        }
                        dataGridView1.DataSource = null;
                        strsearching = null;
                        this.Close();
                    }
                    catch (Exception ex)
                    { }

                }
            }
            else
            {
                strArg = new string[1];
                strArg[0] = "'" + dtDate.Value.ToString("dd/MMM/yyyy") + "'" ;
                this.Close();

            }

      
        }

    }
}
