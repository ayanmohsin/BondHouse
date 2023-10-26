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
    public partial class frmTransJV : BaseForm,IToolBar
    {
        enum DataPop {Account};
       
        General cls;
        DataSet dsPopulateCombo;
        DataTable dtSearchMaster;
        DataTable dtSearchDetail;
        string strAccountNo = "";
        string strButtonState = null;
        string strTransType = "JV";
        public string strError = "";
        string strCondition;
        MainForm Mainfrm;
        public frmTransJV()
        {
            InitializeComponent();
        }

        private void AddColumninDetailGrid()
        {

            DataGridViewTextBoxColumn clmnSno = new DataGridViewTextBoxColumn();
            clmnSno.Name = "Sno";
            clmnSno.HeaderText = "Sno";
            clmnSno.Width = 40;
            clmnSno.Visible = false;
            dtbDetail.Columns.Add(clmnSno);

            DataGridViewTextBoxColumn clmnitCode = new DataGridViewTextBoxColumn();
            clmnitCode.Name = "AccountNo";
            clmnitCode.HeaderText = "Account No";
            clmnitCode.Width = 70;
            clmnitCode.Visible = false;
            dtbDetail.Columns.Add(clmnitCode);

            DataGridViewTextBoxColumn cboTitle = new DataGridViewTextBoxColumn();
            cboTitle.Name = "Title";
            cboTitle.HeaderText = "Account Name";
            cboTitle.Width = 200;
            dtbDetail.Columns.Add(cboTitle);

            DataGridViewComboBoxColumn cboDRCR = new DataGridViewComboBoxColumn();
            cboDRCR.Name = "DRCR";
            cboDRCR.HeaderText = "DR/CR";
            cboDRCR.Width = 55;
            cboDRCR.Items.Add("DR");
            cboDRCR.Items.Add("CR");
            dtbDetail.Columns.Add(cboDRCR);

            DataGridViewTextBoxColumn cboItemCode = new DataGridViewTextBoxColumn();
            cboItemCode.Name = "ItemCode";
            cboItemCode.HeaderText = "ItemCode";
            cboItemCode.Width = 200;
            cboItemCode.Visible = false;
            dtbDetail.Columns.Add(cboItemCode);

            DataGridViewTextBoxColumn cboItem = new DataGridViewTextBoxColumn();
            cboItem.Name = "ShortName";
            cboItem.HeaderText = "Currency";
            cboItem.Width = 55;
            cboItem.ReadOnly = true;
            dtbDetail.Columns.Add(cboItem);

            DataGridViewTextBoxColumn cboNarration = new DataGridViewTextBoxColumn();
            cboNarration.Name = "Narration";
            cboNarration.HeaderText = "Narration";
            cboNarration.Width = 150;
            dtbDetail.Columns.Add(cboNarration);

            DataGridViewTextBoxColumn clmnQty = new DataGridViewTextBoxColumn();
            clmnQty.Name = "Quantity";
            clmnQty.HeaderText = "Quantity";
            clmnQty.DefaultCellStyle.Format = "N2";
            clmnQty.ValueType = typeof(System.Double);
            clmnQty.DefaultCellStyle.NullValue = "0";
            clmnQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnQty.Width = 80;
            dtbDetail.Columns.Add(clmnQty);

            DataGridViewTextBoxColumn clmnRate = new DataGridViewTextBoxColumn();
            clmnRate.Name = "Rate";
            clmnRate.HeaderText = "Rate";
            clmnRate.DefaultCellStyle.Format = "N4";
            clmnRate.ValueType = typeof(System.Double);
            clmnRate.DefaultCellStyle.NullValue = "0";
            clmnRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnRate.Width = 50;
            dtbDetail.Columns.Add(clmnRate);


            DataGridViewTextBoxColumn clmnDebit = new DataGridViewTextBoxColumn();
            clmnDebit.Name = "Debit";
            clmnDebit.HeaderText = "Debit";
            clmnDebit.DefaultCellStyle.Format = "N0";
            clmnDebit.ValueType = typeof(System.Double);
            clmnDebit.DefaultCellStyle.NullValue = "0";
            clmnDebit.ReadOnly = true;
            clmnDebit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnDebit.Width = 90;
            dtbDetail.Columns.Add(clmnDebit);

            DataGridViewTextBoxColumn clmncredit = new DataGridViewTextBoxColumn();
            clmncredit.Name = "Credit";
            clmncredit.HeaderText = "Credit";
            clmncredit.DefaultCellStyle.Format = "N0";
            clmncredit.ValueType = typeof(System.Double);
            clmncredit.DefaultCellStyle.NullValue = "0";
            clmncredit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmncredit.ReadOnly = true;
            clmncredit.Width = 90;
            dtbDetail.Columns.Add(clmncredit);


            DataGridViewTextBoxColumn clmnVNo = new DataGridViewTextBoxColumn();
            clmnVNo.Name = "VoucherNo";
            clmnVNo.HeaderText = "VoucherNo";
            clmnVNo.Width = 50;
            clmnVNo.Visible = false;
            dtbDetail.Columns.Add(clmnVNo);

            DataGridViewTextBoxColumn clmnbrCode = new DataGridViewTextBoxColumn();
            clmnbrCode.Name = "BranchCode";
            clmnbrCode.HeaderText = "";
            clmnbrCode.Visible = false;
            dtbDetail.Columns.Add(clmnbrCode);

        }

        private void GenerateVoucherNo()
        {
            string strTransNo = cls.GetTransNo(strTransType).ToString();
            cls = new General();
            ditxtvoucherNo.Text = strTransType + "-" + strTransNo + "-" + General.strBranchCode;
        }
        
        public Boolean ValidatingControls()
        {
            Boolean bolState;
            strError = "";
            cls.Validate(PnlMain);
            if (cls.StrMessage != null)
            {
                strError = cls.StrMessage;
                bolState = false;
            }
            else
            {
                bolState = true;
            }
            CalculateAmount();
            if (lblDebit.Text  != lblCredit.Text)
            {
                strError = strError + "\n" + "Debit and Credit Amount Should be equal";
                bolState = false;
            }
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (dtbDetail.Rows[i].Cells["AccountNo"].Value == null)
                {
                    strError = strError + "\n" + "Account Should not be Empty on line no " + i + "";
                    bolState = false;
                }
                if (dtbDetail.Rows[i].Cells["AccountNo"].Value != null)
                {
                    if (dtbDetail.Rows[i].Cells["AccountNo"].Value.ToString() != "")
                    {
                        if (dtbDetail.Rows[i].Cells["Quantity"].Value != null)
                        {
                            if (dtbDetail.Rows[i].Cells["Quantity"].Value.ToString() == "0" || dtbDetail.Rows[i].Cells["Quantity"].Value.ToString() == "")
                            {
                                strError = strError + "\n" + "Amount Should not be 0 on line no " + i + "";
                                bolState = false;
                            }
                        }
                        if (dtbDetail.Rows[i].Cells["Quantity"].Value == null)
                        {
                            strError = strError + "\n" + "Amount Should not be 0 on line no " + i + "";
                            bolState = false;
                        }
                    }
                }
           }
            return bolState;
        }

        #region IToolBar Members

        public bool ADD()
        {
            dtbDetail.Rows.Clear();
            if (dtbDetail.Rows.Count == 0)
            {
                dtbDetail.Rows.Add();
            }
            ditxtvoucherNo.Enabled = false;
            strButtonState = "ADD";
            dtbDetail.Focus();
            dtbDetail.Rows[0].Cells["DRCR"].Value = "DR";

            dtbDetail.Rows[0].DefaultCellStyle.BackColor = Color.Teal;
            dtbDetail.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            dtbDetail.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            dtDate.Value = General.dtSystemDate;

            return true;
        }

        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();
            if (strButtonState == "ADD")
            {
                GenerateVoucherNo();
              
            }
            if (ValidatingControls() == true)
            {
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    if (dtbDetail.Rows[i].Cells["Sno"].Value != null)
                    {
                        dtbDetail.Rows[i].Cells["VoucherNo"].Value = ditxtvoucherNo.Text;
                        dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                        dtbDetail.Rows[i].Cells["Sno"].Value = i;
                    }
                }
                strCondition = "Where VoucherNo = '" + ditxtvoucherNo.Text + "' and BranchCode='" + General.strBranchCode + "'";
                ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "Posted=False;BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + "");
                cls.EnableDisble(PnlMain, false);
                dtSearchDetail = ds.Tables[1];
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster,"",null);
                strButtonState = "SAVE";
            }
            else
            {
                MessageBox.Show(strError, "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            return true;
        }

        public bool EDIT()
        {

            ditxtvoucherNo.Enabled = false;
            strButtonState = "EDIT";
            return true;
        }

        public bool QUERY()
        {
                General cls = new General();
            DataSet ds = new DataSet();
            dtSearchDetail = new DataTable();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_JournalVoucherMaster a " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "' ";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            }
            strQuery = strQuery + "  Order by VoucherNo ";
            strQuery = strQuery + ";Select Sno,c.VoucherNo,c.AccountNo,Narration,Title,Debit,Credit,d.ShortName,c.Quantity,c.Rate from EX_JournalVoucherDetail c Inner Join EX_JournalVoucherMaster a on a.VoucherNo = c.VoucherNo and a.RecNo = c.RecNo and a.BranchCode = c.BranchCode Inner Join EX_SetupAccount b on c.Accountno = b.AccountNo and c.BranchCode = b.BranchCode and b.Status = 'A'  Inner Join EX_SetupItems d on b.CurrencyCode = d.ItemCode and d.Status = 'A' Where c.BranchCode = '" + General.strBranchCode + "' ";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            }
            strQuery = strQuery + "  Order by c.VoucherNo,c.Sno";
            ds =cls.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtSearchDetail = ds.Tables[1];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster, "",null);
            dtbMaster_SelectionChanged(dtbMaster, null);
            strButtonState = "QUERY";
            CalculateAmount();
            return true;
        }

        public bool UNDO()
        {
            strButtonState = "UNDO";
            return true;
        }

        public bool EXIT()
        {
            strButtonState = "EXIT";
            return true;
        }

        public bool DELETE()
        {
            cls = new General();
            strCondition = "Where VoucherNo = '" + ditxtvoucherNo.Text + "' And BranchCode = '" + General.strBranchCode + "'";
            if (General.dtSystemDate == dtDate.Value)
            {
                cls.DeleteRecord(General.strTableName, strCondition);
            }
            else
            {
                MessageBox.Show("Current Date Record Should be Change", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            strButtonState = "DELETE";
            return true;
        }

        public bool NEXT()
        {
            strButtonState = "EXIT";
            return true;
        }

        public bool PREVIOUS()
        {
            strButtonState = "PREVIOUS";
            return true;
        }

        public bool LAST()
        {
            strButtonState = "LAST";
            return true;
        }

        public bool FIRST()
        {
            strButtonState = "FIRST";
            return true;
        }

        public bool AUTHORIZE()
        {
            strButtonState = "AUTHORIZE";
            return true;
        }

        public bool PRINT()
        {
            if (txtStatus.Text == "A")
            {
                if (ditxtvoucherNo.Text != "")
                {
                    cls = new General();
                    cls.GenerateVoucher("JV", ditxtvoucherNo.Text);
                    strButtonState = "PRINT";
                }
                else
                {
                    MessageBox.Show("Select Voucher For Print", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Authorized The Voucher", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        #endregion

        private void frmTransJV_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            AddColumninDetailGrid();
            cls.EnableDisble(PnlMain, false);
            General.strTableName[0]= "EX_JournalVoucherMaster";
            General.strTableName[1]= "EX_JournalVoucherDetail";
            General.strPKColumn = "VoucherNo";
            General.strAuthorizeTableName = General.strTableName[0];
            dtbDetail.KeyDown += new KeyEventHandler(dtbDetail_KeyDown);
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            dtbDetail.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dtbDetail_EditingControlShowing);
            dtDate.Value = General.dtSystemDate;

            PopulateCombo();
            dtbMaster.CellValueChanged += new DataGridViewCellEventHandler(dtbMaster_CellValueChanged);
            dtbMaster.CellContentClick += new DataGridViewCellEventHandler(dtbMaster_CellContentClick);

        }

        void dtbMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //dtbMaster.Rows[0].Cells[1].Selected = true;
                SendKeys.Send("{Right}");
                //  dtbMaster.Rows[e.RowIndex].Cells[0].Value = false;
            }
        }

        void dtbMaster_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dtbMaster.Rows[e.RowIndex].Cells[0].Value) == true)
                {
                    if (ValidatingControls() == true)
                    {
                        dtbMaster.Rows[e.RowIndex].Cells[0].Value = true;
                    }
                    else
                    {
                        dtbMaster.Rows[e.RowIndex].Cells[0].Value = false;
                        MessageBox.Show(strError, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                dtbMaster.Rows[e.RowIndex].Cells[0].Value = false;
            }
        }

        void dtbMaster_SelectionChanged(object sender, EventArgs e)
        {
            if (ditxtvoucherNo.Text != "" && strButtonState != "ADD")
            {

                DataRow[] dr = new DataRow[0];
                dr = dtSearchDetail.Select("VoucherNo = '" + ditxtvoucherNo.Text + "'", "VoucherNo");
                dtbDetail.Rows.Clear();
                try
                {
                    for (int i = 0; i < dr.Count(); i++)
                    {
                        dtbDetail.Rows.Add();
                        dtbDetail.Rows[i].Cells["Sno"].Value = dr[i]["Sno"].ToString();
                        dtbDetail.Rows[i].Cells["AccountNo"].Value = dr[i]["AccountNo"].ToString();
                        dtbDetail.Rows[i].Cells["Narration"].Value = dr[i]["Narration"].ToString();
                        dtbDetail.Rows[i].Cells["Debit"].Value = dr[i]["Debit"].ToString();
                        dtbDetail.Rows[i].Cells["Credit"].Value = dr[i]["Credit"].ToString();
                        dtbDetail.Rows[i].Cells["Quantity"].Value = dr[i]["Quantity"].ToString();
                        dtbDetail.Rows[i].Cells["Rate"].Value = dr[i]["Rate"].ToString();
                        dtbDetail.Rows[i].Cells["ShortName"].Value = dr[i]["ShortName"].ToString();
                        dtbDetail.Rows[i].Cells["VoucherNo"].Value = dr[i]["VoucherNo"].ToString();
                        dtbDetail.Rows[i].Cells["Title"].Value = dr[i]["Title"].ToString();
                        if (Convert.ToDouble(dr[i]["Debit"].ToString()) > 0)
                        {
                            dtbDetail.Rows[i].Cells["DRCR"].Value = "DR";
                            dtbDetail.Rows[i].DefaultCellStyle.BackColor = Color.Teal;
                            dtbDetail.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                            dtbDetail.Rows[i].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        }
                        else if (Convert.ToDouble(dr[i]["Credit"].ToString()) > 0)
                        {
                            dtbDetail.Rows[i].Cells["DRCR"].Value = "CR";
                            dtbDetail.Rows[i].DefaultCellStyle.BackColor = Color.Salmon ;
                            dtbDetail.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                            dtbDetail.Rows[i].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            CalculateAmount();
        }
        private void PopulateCombo()
        {
            string strQuery = "Select AccountNo,Title,ItemCode,ShortName,MinimumRate from EX_SetupAccount a Inner Join EX_SetupItems b on a.CurrencyCode = b.ItemCode and b.Status = 'A' Where BranchCode = '" + General.strBranchCode + "' and isTransactional = 'True' and a.Locked = 'false' and a.Status = 'A'";
            dsPopulateCombo = new DataSet();
            cls = new General();
          
            dsPopulateCombo =cls.GetDataSet(strQuery);
        }


        void dtbDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (General.strButtonState == "ADD" || General.strButtonState == "SAVE" || General.strButtonState == "EDIT")
            {

                if (e.KeyValue == 13)
                {
                    SendKeys.Send("{Right}");
                    if (dtbDetail.CurrentCell.ColumnIndex == dtbDetail.Columns["Rate"].Index)
                    {
                        if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["SNo"].Value != null)
                        {
                            dtbDetail.Rows.Add();
                            SendKeys.Send("{Home}");
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["DEBIT"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Credit"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Narration"].Value = "";
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Title"].Value = "";
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["AccountNo"].Value = "";
                            if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["DRCR"].Value.ToString() == "DR")
                            {
                                dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["DRCR"].Value = "CR";
                                dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].DefaultCellStyle.BackColor = Color.Salmon;
                                dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].DefaultCellStyle.ForeColor = Color.White;
                                dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                            }
                            else
                            {
                                dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["DRCR"].Value = "DR";
                                dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].DefaultCellStyle.BackColor = Color.Teal;
                                dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].DefaultCellStyle.ForeColor = Color.White;
                                dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                            }
                        }
                        else
                        {
                            DialogResult dr =
                            MessageBox.Show("Are you sure to Save this Record", "Confirmation Save",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (Convert.ToString(dr) == "Yes")
                            {
                                SAVE();
                            }
                        }
                    }
                }
                if (e.KeyValue == 113)
                {

                    if (dtbDetail.Columns[dtbDetail.CurrentCell.ColumnIndex].Name == "AccountNo")
                    {
                        frmListSearch childForm = new frmListSearch(dsPopulateCombo.Tables[(int)DataPop.Account],"S",null);
                        childForm.ShowDialog();
                        if (frmListSearch.strArg[0] != "")
                        {
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["AccountNo"].Value = frmListSearch.strArg[0];
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Title"].Value = frmListSearch.strArg[1];                            
                        }
                    }
                }
            }
        }

        private void dtbDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dtb = new DataTable();
            dtb = dsPopulateCombo.Tables[(int)DataPop.Account];

            if (dtbDetail.Columns["Debit"].ToString() == dtbDetail.Columns[e.ColumnIndex].ToString())
            {
                if (dtbDetail.Rows[e.RowIndex].Cells["Debit"].Value != null)
                {
                    if (dtbDetail.Rows[e.RowIndex].Cells["Debit"].Value.ToString() != "0")
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Credit"].Value = "0";
                    }
                    CalculateAmount();
                }
            }
            if (dtbDetail.Columns["Credit"].ToString() == dtbDetail.Columns[e.ColumnIndex].ToString())
            {
                if (dtbDetail.Rows[e.RowIndex].Cells["Credit"].Value != null)
                {
                    if (dtbDetail.Rows[e.RowIndex].Cells["Credit"].ToString() != "0")
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Debit"].Value = "0";
                    }
                    CalculateAmount();
                }
            }
            if (dtbDetail.Columns["Rate"].Index == e.ColumnIndex || dtbDetail.Columns["Quantity"].Index == e.ColumnIndex)
            {
                if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == false || dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString() == "" || cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == false || dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString() == "")
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
                    dtbDetail.Rows[e.RowIndex].Cells["Debit"].Value = 0;
                    dtbDetail.Rows[e.RowIndex].Cells["Credit"].Value = 0;
                }
         
                //if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == true || cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == true)
                //{
                    
                //}
               
            }
            if (dtbDetail.Columns["DRCR"].Index == e.ColumnIndex || dtbDetail.Columns["Quantity"].Index == e.ColumnIndex || dtbDetail.Columns["Rate"].Index == e.ColumnIndex)
            {
                if (dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value != null)
                {
                    if (dtbDetail.Rows[e.RowIndex].Cells["DRCR"].Value != null && cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == true || cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == true)
                    {
                        if (dtbDetail.Rows[e.RowIndex].Cells["DRCR"].Value.ToString() == "DR")
                        {
                            dtbDetail.Rows[e.RowIndex].Cells["Debit"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value);
                            dtbDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Teal;
                            dtbDetail.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                            dtbDetail.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        }
                        else
                        {
                            dtbDetail.Rows[e.RowIndex].Cells["Debit"].Value = "0";
                        }

                        if (dtbDetail.Rows[e.RowIndex].Cells["DRCR"].Value.ToString() == "CR")
                        {
                            dtbDetail.Rows[e.RowIndex].Cells["Credit"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value);
                            dtbDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
                            dtbDetail.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                            dtbDetail.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        }
                        else
                        {
                            dtbDetail.Rows[e.RowIndex].Cells["Credit"].Value = "0";
                        }

                    }
                }
            }
          
            if (dtbDetail.Rows[e.RowIndex].Cells["AccountNo"].Value != null || dtbDetail.Rows[e.RowIndex].Cells["Title"].Value != null)
            {
                dtbDetail.Rows[e.RowIndex].Cells["Sno"].Value = e.RowIndex + 1;
            }

            if (dtbDetail.Columns["Accountno"].Index == e.ColumnIndex)
            {
                DataRow[] dRow = dtb.Select("AccountNo = '" + dtbDetail.Rows[e.RowIndex].Cells["AccountNo"].Value + "'");
                if (dRow.Count() > 0)
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Title"].Value = dRow[0]["Title"].ToString();
                }
                else
                {
                    MessageBox.Show("Acocunt is not available","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                      dtbDetail.Rows[e.RowIndex].Cells["AccountNo"].Value = "";
                      dtbDetail.Rows[e.RowIndex].Cells["Title"].Value = "";
                }
               
            }
            if (dtbDetail.Columns["Title"].Index == e.ColumnIndex)
            {
                if (dtbDetail.Rows[e.RowIndex].Cells["Title"].Value != null)
	                {
                        if (dtbDetail.Rows[e.RowIndex].Cells["Title"].Value.ToString().Length >= 3)
                        {
                            DataRow[] dr = dtb.Select("Title Like '" + dtbDetail.Rows[e.RowIndex].Cells["Title"].Value.ToString().Trim() + "%'", "Title");
                            if (dr.GetUpperBound(0) >= 0)
                            {
                                dtb.DefaultView.Sort = "Title";
                                dtbDetail.Rows[e.RowIndex].Cells["Title"].Value = dr[0]["Title"].ToString();
                                dtbDetail.Rows[e.RowIndex].Cells["AccountNo"].Value = dr[0]["AccountNo"].ToString();
                                dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value = dr[0]["ItemCode"].ToString();
                                dtbDetail.Rows[e.RowIndex].Cells["ShortName"].Value = dr[0]["ShortName"].ToString();
                                dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = dr[0]["MinimumRate"].ToString();
                                dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = "0";
                                dtbDetail.Rows[e.RowIndex].Cells["Debit"].Value = "0";
                                dtbDetail.Rows[e.RowIndex].Cells["Credit"].Value = "0";
                                if (dr[0]["ItemCode"].ToString() == "304")
                                {
                                    dtbDetail.Columns["Rate"].ReadOnly = true;
                                }
                                else
                                {
                                    dtbDetail.Columns["Rate"].ReadOnly = false;
                                }
                            }
                        }
                		 
	                }     
            }
            CalculateAmount();
        }

        private void CalculateAmount()
        {
            lblDebit.Text = "0";
            lblCredit.Text = "0";
            try
            {
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    if (dtbDetail.Rows[i].Cells["Debit"].Value != null && dtbDetail.Rows[i].Cells["Debit"].Value.ToString() != "0")
                    {
                        lblDebit.Text = (Convert.ToDouble(lblDebit.Text) + Convert.ToDouble(dtbDetail.Rows[i].Cells["Debit"].Value.ToString())).ToString();
                    }
                    else if (dtbDetail.Rows[i].Cells["Credit"].Value != null && dtbDetail.Rows[i].Cells["Credit"].Value.ToString() != "0" && dtbDetail.Rows[i].Cells["Credit"].Value.ToString() != "")
                    {
                        lblCredit.Text = (Convert.ToDouble(lblCredit.Text) + Convert.ToDouble(dtbDetail.Rows[i].Cells["Credit"].Value.ToString())).ToString();
                    }
                }

                lblDebit.Text = string.Format("{0:0,0}", Convert.ToDouble(lblDebit.Text));
                lblCredit.Text = string.Format("{0:0,0}", Convert.ToDouble(lblCredit.Text));

            }
            catch (Exception)
            {
               
            }
        }

        private void frmTransJV_Activated(object sender, EventArgs e)
        {
            Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }

        void dtbDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataTable dtb = new DataTable();
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridViewTextBoxEditingControl te;
                if (dtbDetail.CurrentCell.ColumnIndex == 2)
                {
                    te = new DataGridViewTextBoxEditingControl();
                    te.Clear();
                    te = (DataGridViewTextBoxEditingControl)e.Control;
                    te.AutoCompleteMode = AutoCompleteMode.Suggest;
                    te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    dtb = dsPopulateCombo.Tables[(int)DataPop.Account];
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        te.AutoCompleteCustomSource.Add(dtb.Rows[i]["Title"].ToString());
                    }
                }
            }
        }

        private void frmTransJV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (strButtonState != "ADD" || strButtonState != "Edit")
            {
                if (e.KeyChar == (char)19)
                {
                    DialogResult dr =
                    MessageBox.Show("Are you sure to Save this Record", "Confirmation Save",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (Convert.ToString(dr) == "Yes")
                    {
                        SAVE();
                    }

                }
                if (e.KeyChar == '')
                {
                    ADD();
                    Mainfrm.EnableDisbale(strButtonState, true, "S");
                }
            }
        }
    }
}
