using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace ExchangeCompanySoftware
{

    public partial class BaseForm : Form
    {
       
        Form frm;
        string pintBlink = "";
        public string BaseButtonState { get; set; }

        public BaseForm()
        {
            InitializeComponent();
            // dtTransDate.Value = General.dtSystemDate;
            dtbMaster.Columns["Select"].ContextMenuStrip = ContMenu;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //  this.Controls.Add(new TransparentPanel());

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.Height != 0)
            {
                LinearGradientBrush GBrush = new LinearGradientBrush(
                new Point(0, this.Height), new Point(0, 0), Color.RoyalBlue, Color.LightBlue);
                Rectangle rc = new Rectangle(0, 0, this.Width, this.Height);
                if (this.ClientSize.Width != 0)
                {
                    using (GBrush)
                    {
                        e.Graphics.FillRectangle(GBrush, rc);
                    }
                }
            }
        }

        private void dtTransDate_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dtbMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void BaseForm_Load(object sender, EventArgs e)
        {
            dtbMaster.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            dtbMaster.DefaultCellStyle.SelectionForeColor = Color.White;
        }
        private void BaseForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void BaseForm_Validating(object sender, CancelEventArgs e)
        {

        }
        private void BaseForm_RegionChanged(object sender, EventArgs e)
        {

        }
        private void BaseForm_Leave(object sender, EventArgs e)
        {
            Form frm = (Form)sender;
            if (BaseButtonState == "ADD" || BaseButtonState == "EDIT")
            {
                General.strFormButtonState = General.strFormButtonState + ";" + frm.Name;
            }
        }
        private void BaseForm_Enter(object sender, EventArgs e)
        {
            frm = (Form)sender;
            MainForm Mainfrm = (MainForm)frm.ParentForm;
            if (!String.IsNullOrEmpty(General.strFormButtonState))
            {
                //ToolStrip tool = (ToolStrip)Mainfrm.Controls["Tool"];
                if (General.strFormButtonState.Contains(frm.Name) == true)
                {
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.Add)].Enabled = false;
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.UNDO)].Enabled = true;
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.SAVE)].Enabled = true;
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.EDIT)].Enabled = false;
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.DELETE)].Enabled = false;
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.EXIT)].Enabled = false;
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.FIRST)].Enabled = false;
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.LAST)].Enabled = false;
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.NEXT)].Enabled = false;
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.PREVIOUS)].Enabled = false;
                    Mainfrm.Tool.Items[Convert.ToInt16(MainForm.BtnState.QUERY)].Enabled = false;
                }

            }
        }
        private void dtbMaster_DataSourceChanged(object sender, EventArgs e)
        {
            ChangeGridDisplay();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtbMaster.Rows.Count; i++)
            {
                if (dtbMaster.Rows[i].Cells["Status"].Value.ToString() == "U")
                {
                    dtbMaster.Rows[i].Cells["Select"].Value = true;
                }
            }
        }
        private void unToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtbMaster.Rows.Count; i++)
            {
                dtbMaster.Rows[i].Cells["Select"].Value = false;
            }
        }
        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["Select"].Value = true;
        }
        private void authorizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExchangeCompanySoftware.GetData.ServiceSoapClient objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            objGetData.Endpoint.Address = new System.ServiceModel.EndpointAddress(General.gendPoint);
            General cls = new General();
            DialogResult dr =
             MessageBox.Show("are you sure to Authorized That Record", "Confirmation Authorized",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                           if (Convert.ToString(dr) == "Yes")
                                           {

                                               if (General.isAuthriozationRights == true)
                                               {

                                                   string strWhereClause = "";
                                                   string strTable = General.strAuthorizeTableName;

                                                   string strQuery = "Exec sp_pkeys '" + strTable + "';Select * from EX_SetupAccount Where BranchCode = '" + General.strHeadOfficeCode + "' and Status = 'A' and isTransactional = 'True' and isBranch = 'True' and BranchCodeTag = '" + General.strBranchCode + "';Select * from EX_ControlAccounts Where BranchCode = '" + General.strHeadOfficeCode + "'";
                                                     
                                                   DataSet ds =cls.GetDataSet(strQuery);
                                                   for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                                   {
                                                       if (strWhereClause == "")
                                                       {
                                                           strWhereClause = ds.Tables[0].Rows[i]["Column_Name"].ToString();
                                                       }
                                                       else
                                                       {
                                                           strWhereClause = strWhereClause + ";" + ds.Tables[0].Rows[i]["Column_Name"].ToString();
                                                       }
                                                   }
                                                   string[] strWhere = strWhereClause.Split(';');
                                                   string strQryWhere = "";
                                                   for (int i = 0; i < dtbMaster.Rows.Count; i++)
                                                   {
                                                       if (Convert.ToBoolean(dtbMaster.Rows[i].Cells[0].Value) == true)
                                                       {
                                                           for (int j = 0; j < strWhere.Count(); j++)
                                                           {
                                                               if (strQryWhere == "")
                                                               {
                                                                   strQryWhere = "Where  " + strWhere[j] + " " + "= '" + dtbMaster.Rows[i].Cells[strWhere[j].ToString()].Value.ToString() + "'  ";
                                                               }
                                                               else
                                                               {
                                                                   strQryWhere = strQryWhere + "and " + strWhere[j] + " " + "= '" + dtbMaster.Rows[i].Cells[strWhere[j].ToString()].Value.ToString() + "'  ";
                                                               }
                                                           }
                                                           string StrError = "";
                                                           //frm.GetType().GetMethod("ValidatingControls").Invoke(frm, null);
                                                           StrError = frm.GetType().GetField("strError").GetValue((object)frm).ToString();
                                                           if (StrError == "")
                                                           {
                          

                                //string StrError = frm.GetType().GetField("strError").GetValue();
                                strQuery = "Update " + strTable + " set Status = 'A',AUserId = '" + General.strUserId + "',ADate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' " + strQryWhere;
                                                               
                                cls.ExecuteDML(strQuery);
                                                                
                                                               strQryWhere = "";
                                                               dtbMaster.Rows[i].Selected = false;
                                                               if (dtbMaster.Rows.Count - 1 > i)
                                                               {
                                                                   dtbMaster.Rows[i + 1].Selected = true;
                                                               }
                                                               dtbMaster.Rows[i].Cells["Status"].Value = "A";
                                                               Application.DoEvents();
                                                               dtbMaster.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                                                               dtbMaster.Rows[i].Cells["Select"].Value = false;
                                                               dtbMaster.Rows[i].Cells["Select"].ReadOnly = true;
                                                               dtbMaster.Rows[i].DefaultCellStyle.Font = new Font(dtbMaster.Font, FontStyle.Regular);

                                                               MessageBox.Show("Authorized Successfully", "Authorize",
                                                                       MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                           }
                                                           else
                                                           {
                                                               MessageBox.Show(StrError, "Error",
                                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                               StrError = "";
                                                           }
                                                       }
                                                   }
                                               }
                                               else
                                               {
                                                   MessageBox.Show("User don't Have Authorization Rights", "Error",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                                               }
                                           }
        }
        private void ChangeGridDisplay()
        {
            int intAuth = 0;
            int intUnAuth = 0;
            int intDelete = 0;
            int intHistory = 0;
            pintBlink = "";
            for (int i = 1; i < dtbMaster.Columns.Count; i++)
            {
                dtbMaster.Columns[i].ReadOnly = true;
            }
            for (int i = 0; i < dtbMaster.Rows.Count; i++)
            {
                // ======================== Delete Record =========================
                if (dtbMaster.Rows[i].Cells["Status"].Value.ToString() == "X")
                {
                    dtbMaster.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dtbMaster.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Red;
                    dtbMaster.Rows[i].Cells["Select"].Value = false;
                    dtbMaster.Rows[i].Cells["Select"].ReadOnly = true;
                    intDelete = intDelete + 1;
                }
                // ======================== UnAuthorize Record =========================
                else if (dtbMaster.Rows[i].Cells["Status"].Value.ToString() == "U")
                {

                    dtbMaster.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                    dtbMaster.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Blue;
                    dtbMaster.Rows[i].DefaultCellStyle.Font = new Font(dtbMaster.Font, FontStyle.Bold);
                    dtbMaster.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    dtbMaster.Rows[i].Cells["Select"].Value = false;
                    dtbMaster.Rows[i].Cells["Select"].ReadOnly = false;
                    intUnAuth = intUnAuth + 1;
                    if (pintBlink == "")
                    {
                        pintBlink = i.ToString();
                    }
                    else
                    {
                        pintBlink = pintBlink + ";" + i.ToString();
                    }
                    timer1.Enabled = true;

                }
                // ======================== Authorize Record =========================
                else if (dtbMaster.Rows[i].Cells["Status"].Value.ToString() == "A")
                {
                    dtbMaster.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                    dtbMaster.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Green;
                    dtbMaster.Rows[i].Cells["Select"].Value = false;
                    dtbMaster.Rows[i].Cells["Select"].ReadOnly = true;
                    dtbMaster.Rows[i].DefaultCellStyle.Font = new Font(dtbMaster.Font, FontStyle.Regular);
                    intAuth = intAuth + 1;
                }
                else if (dtbMaster.Rows[i].Cells["Status"].Value.ToString() == "H")
                {
                    dtbMaster.Rows[i].DefaultCellStyle.ForeColor = Color.LightGray;
                    dtbMaster.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dtbMaster.Rows[i].DefaultCellStyle.ForeColor = Color.LightGray;
                    dtbMaster.Rows[i].DefaultCellStyle.Font = new Font(dtbMaster.Font, FontStyle.Regular);
                    dtbMaster.Rows[i].Cells["Select"].Value = false;
                    dtbMaster.Rows[i].Cells["Select"].ReadOnly = true;
                    intHistory = intHistory + 1;
                }

            }
            Unauthorized.Text = intUnAuth.ToString();
            authorized.Text = intAuth.ToString();
            Delete.Text = intDelete.ToString();
            History.Text = intHistory.ToString();
        }
        public string AuthorizedTable { get; set; }
        private void dtbMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dtbMaster.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "U")
            //{
            //    dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["Select"].Value = true;
            //}
        }
        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }
        private void dtbMaster_SelectionChanged(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)frm.ParentForm;
            ToolStripItem tol = Mainfrm.Tool.Items[1];
            ToolStripItem tol1 = Mainfrm.Tool.Items[2];
            ToolStripItem tolEDIT = Mainfrm.Tool.Items[(int)MainForm.BtnState.EDIT];

            txtStatus.Text = dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["Status"].Value.ToString();
            if (dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["Status"].Value.ToString() == "X" || dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["Status"].Value.ToString() == "H")
            {

                tol.Enabled = false;
                tol1.Enabled = false;
                if (this.Tag == "T")
                {
                    tolEDIT.Enabled = false;
                }

            }
            else
            {

                tol.Enabled = true;
                tol1.Enabled = true;
                General.bolNoEDITDelete = false;

                if (dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["Status"].Value.ToString() == "A")
                {
                    if (this.Tag == "T")
                    {
                        tolEDIT.Enabled = false;
                    }
                }
                else
                {
                    if (this.Tag == "T")
                    {
                        tolEDIT.Enabled = true;
                    }
                }
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
        //    BlinkData();
        }
        private void BlinkData()
        {
            try
            {
                string[] strBlink = pintBlink.Split(';');

                for (int ig = 0; ig < strBlink.Count(); ig++)
                {
                    if (strBlink.Count() > 0)
                    {
                        int i = Convert.ToInt16(strBlink[ig]);
                        if (i < dtbMaster.Rows.Count)
                        {
                            if (dtbMaster.Rows[i].Cells["Status"].Value.ToString() == "U")
                            {
                                if (dtbMaster.Rows[i].DefaultCellStyle.ForeColor == Color.Blue)
                                {
                                    dtbMaster.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                                    dtbMaster.Rows[i].DefaultCellStyle.Font = new Font(dtbMaster.Font, FontStyle.Regular);

                                }
                                else
                                {
                                    dtbMaster.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                                    dtbMaster.Rows[i].DefaultCellStyle.Font = new Font(dtbMaster.Font, FontStyle.Bold);

                                }
                            }

                        }

                    }
                }

            }
            catch (Exception)
            {
            }
        }
        private void dtbMaster_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void dtbMaster_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            General cls = new General();
            DataSet ds = new DataSet();
            string strQuery = "Select * from " + General.strTableName[0] + " Where Status = 'H' and " + General.strPKColumn + "= '" + dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells[General.strPKColumn].Value + "'";
            ds =cls.GetDataSet(strQuery);
            dtbHistory.DataSource = ds.Tables[0];
            dtbHistory.Visible = true;
            dtbHistory.BringToFront();
        }
        private void dtbMaster_MouseClick(object sender, MouseEventArgs e)
        {
            dtbHistory.Visible = false;

        }
        private void PnlBase_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dtbMaster_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void dtbMaster_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtbMaster.IsCurrentCellDirty)
            {
                dtbMaster.CommitEdit(DataGridViewDataErrorContexts.Commit);                
            }
        }

        private void dtbHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtbMaster_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            bool handle;
            if (dtbMaster.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(DBNull.Value))
            {
                handle = true;

            }
            else
            {
                handle = false;
            }
            e.Cancel = handle;
        }


    }
}
////if (General.strBranchCode != General.strHeadOfficeCode)
////                           {
////                               if (strTable == "EX_TTIssuance" || strTable == "EX_DDIssuance")
////                               {
////                                   General cls = new General();
////                                   string[] strTable1 = new string[3];
////                                   strTable1[0] = General.strTableName[0];
////                                   strTable1[1] = General.strTableName[1];
////                                   string strTransType;
////                                   string strChargesType;
////                                   Panel pnl = (Panel)frm.Controls["PnlMain"];
////                                   if (strTable == "EX_TTIssuance")
////                                   {
////                                       strTransType = "TTIS";
////                                       strChargesType = "TTCharges";
////                                       pnl.Controls["ditxtTransNo"].Text = "TT-" + cls.GetTransNo(strTransType).ToString() + "-" + General.strHeadOfficeCode;
////                                   }
////                                   else
////                                   {
////                                       strTransType = "DDIS";
////                                       strChargesType = "DDCharges";
////                                       pnl.Controls["ditxtTransNo"].Text = "DD-" + cls.GetTransNo(strTransType).ToString() + "-" + General.strHeadOfficeCode;
////                                   }
////                                   DataTable dtb = ds.Tables[1];
////                                   DataTable dtbCharge = ds.Tables[2];
////                                   DataGridView dtbDetail = (DataGridView)frm.Controls["dtbDetail"];
////                                   NumericUpDown dinumTotalAmountRec = (NumericUpDown)pnl.Controls["dinumTotalAmountRec"];
////                                   NumericUpDown dinumRate = (NumericUpDown)pnl.Controls["dinumRate"];
////                                   NumericUpDown dinumQuantity = (NumericUpDown)pnl.Controls["dinumQuantity"];
////                                   NumericUpDown dinumBaseRate = (NumericUpDown)pnl.Controls["dinumBaseRate"];
////                                   NumericUpDown donumTTCharges = (NumericUpDown)pnl.Controls["donumTTCharges"];
////                                   NumericUpDown donumHOCharges = (NumericUpDown)pnl.Controls["donumHOCharges"];
////                                   ComboBox dicboHoBank = (ComboBox)pnl.Controls["dicboHoBank"];
////                                   ComboBox dicboReportBranch = (ComboBox)pnl.Controls["dicboReportBranch"];
////                                   dicboReportBranch.SelectedValue = General.strBranchCode;
////                                   dtbDetail.Rows.Clear();
////                                   dtbDetail.Rows.Add();

////                                   dtbDetail.Rows[0].Cells["Sno"].Value = 0;
////                                   dtbDetail.Rows[0].Cells["TransNo"].Value = pnl.Controls["ditxtTransNo"].Text;
////                                   dtbDetail.Rows[0].Cells["BranchCode"].Value = General.strHeadOfficeCode;
////                                   dtbDetail.Rows[0].Cells["AccountNo"].Value = dtb.Rows[0]["AccountNo"].ToString();
////                                   dtbDetail.Rows[0].Cells["DEBIT"].Value = (dinumTotalAmountRec.Value - (dinumRate.Value - dinumBaseRate.Value) * dinumQuantity.Value) - donumTTCharges.Value;
////                                   dtbDetail.Rows[0].Cells["CREDIT"].Value = 0;
////                                   dtbDetail.Rows.Add();
////                                   dtbDetail.Rows[1].Cells["Sno"].Value = 1;
////                                   dtbDetail.Rows[1].Cells["TransNo"].Value = pnl.Controls["ditxtTransNo"].Text;
////                                   dtbDetail.Rows[1].Cells["BranchCode"].Value = General.strHeadOfficeCode;
////                                   dtbDetail.Rows[1].Cells["AccountNo"].Value = dtbCharge.Rows[0][strChargesType].ToString();
////                                   dtbDetail.Rows[1].Cells["DEBIT"].Value = 0;
////                                   dtbDetail.Rows[1].Cells["CREDIT"].Value = donumHOCharges.Value;
////                                   dtbDetail.Rows.Add();
////                                   dtbDetail.Rows[2].Cells["Sno"].Value = 2;
////                                   dtbDetail.Rows[2].Cells["TransNo"].Value = pnl.Controls["ditxtTransNo"].Text;
////                                   dtbDetail.Rows[2].Cells["BranchCode"].Value = General.strHeadOfficeCode;
////                                   dtbDetail.Rows[2].Cells["AccountNo"].Value = dicboHoBank.SelectedValue;
////                                   dtbDetail.Rows[2].Cells["DEBIT"].Value = 0;
////                                   dtbDetail.Rows[2].Cells["CREDIT"].Value = Convert.ToDecimal(dtbDetail.Rows[0].Cells["DEBIT"].Value.ToString()) - donumHOCharges.Value;


////                              //     DataSet ds23 = cls.SaveRecord("ADD", dtbDetail, strTable1, pnl, strTransType, strQryWhere, "UserId=" + General.strUserId + ";BranchCode=" + General.strHeadOfficeCode + "");
////                               }
////                           }