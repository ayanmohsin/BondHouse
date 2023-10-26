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
    public partial class frmCurrencyTransfer : BaseForm,IToolBar
    {
        
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataTable dtSearchMaster;
        enum DataPop {VT,Party,Currency, AccountNo };
        string strButtonState = null;
        string strTransType = "TTIS";
        public string strError = "";
        string strFormButton;
        string strCondition;
        DataSet dsPopulateCombo;
        DataTable dtSearchDetail;
        MainForm Mainfrm;

        public frmCurrencyTransfer()
        {
            InitializeComponent();
        }
        void dtbDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (General.strButtonState == "ADD" || strButtonState == "ADD" || General.strButtonState == "SAVE" || General.strButtonState == "EDIT")
            {
                if (e.KeyValue == 13)
                {
                    SendKeys.Send("{Right}");
                    if (dtbDetail.Columns.Count == dtbDetail.CurrentCell.ColumnIndex + 3)
                    {
                        if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["SNo"].Value != null)
                        {
                            dtbDetail.Rows.Add();
                            SendKeys.Send("{Home}");
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Quantity"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Rate"].Value = 0;
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
                //if (e.KeyValue == 40)
                //{
                //    if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["SNo"].Value != null)
                //    {
                //        dtbDetail.Rows.Add();
                //    }
                //}
                if (e.KeyValue == 113)
                {

                    if (dtbDetail.Columns[dtbDetail.CurrentCell.ColumnIndex].Name == "Currency")
                    {
                        DataTable dtb = new DataTable();
                        dtb = dsPopulateCombo.Tables[(int)DataPop.Currency];
                        frmListSearch childForm = new frmListSearch(dtb, "S", null);
                        childForm.ShowDialog();
                        if (frmListSearch.strArg != null)
                        {
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["CurrencyCode"].Value = frmListSearch.strArg[0];
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Currency"].Value = frmListSearch.strArg[1];
//                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Symbol"].Value = frmListSearch.strArg[2];
                        }
                    }
                }
            }
        }
        void dtbDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            cls = new General();

            try
            {
                cls = new General();
                if (dtbDetail.Rows[e.RowIndex].Cells["AccountNoFrom"].Value != null)
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Sno"].Value = e.RowIndex + 1;
                }
                else
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Sno"].Value = "";
                    dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = "0";
                    dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = "0";
                    dtbDetail.Rows[e.RowIndex].Cells["Currency"].Value = "";
                    dtbDetail.Rows[e.RowIndex].Cells["AccountNoFrom"].Value = "";
                    dtbDetail.Rows[e.RowIndex].Cells["TransNo"].Value = "";


                }

                if (dtbDetail.Columns["Rate"].Index == e.ColumnIndex)
                {
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == false || dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString() == "")
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                    }
                }
                if (dtbDetail.Columns["Currency"].Index == e.ColumnIndex)
                {
                    FetchCurrencyGrid(e.RowIndex, e.ColumnIndex);
                }
                if (dtbDetail.Columns["TitleFrom"].Index == e.ColumnIndex)
                {
                    FetchCurrencyGrid(e.RowIndex, e.ColumnIndex);
                }
                if (dtbDetail.Columns["TitleTo"].Index == e.ColumnIndex)
                {
                    FetchCurrencyGrid(e.RowIndex, e.ColumnIndex);
                }
                dtbDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                dtbDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Selected = true;

            }
            catch (Exception)
            {

            }
        }
        void dtbDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataTable dtb = new DataTable();
            DataGridViewTextBoxEditingControl te;
          
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                if (dtbDetail.CurrentCell.ColumnIndex == 4)
                {

                    te = new DataGridViewTextBoxEditingControl();
                    te.Clear();
                    te = (DataGridViewTextBoxEditingControl)e.Control;
                    te.AutoCompleteMode = AutoCompleteMode.Suggest;
                    te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    dtb = dsPopulateCombo.Tables[(int)DataPop.Currency];
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        te.AutoCompleteCustomSource.Add(dtb.Rows[i]["ItemName"].ToString());
                    }

                }
                else if (dtbDetail.CurrentCell.ColumnIndex == 2)
                {
                    te = new DataGridViewTextBoxEditingControl();
                    te.Clear();
                    te = (DataGridViewTextBoxEditingControl)e.Control;
                    te.AutoCompleteMode = AutoCompleteMode.Suggest;
                    te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    dtb = dsPopulateCombo.Tables[(int)DataPop.AccountNo];
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        te.AutoCompleteCustomSource.Add(dtb.Rows[i]["Title"].ToString());
                    }
                }
                else if (dtbDetail.CurrentCell.ColumnIndex == 8)
                {
                    te = new DataGridViewTextBoxEditingControl();
                    te.Clear();
                    te = (DataGridViewTextBoxEditingControl)e.Control;
                    te.AutoCompleteMode = AutoCompleteMode.Suggest;
                    te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    dtb = dsPopulateCombo.Tables[(int)DataPop.AccountNo];
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        te.AutoCompleteCustomSource.Add(dtb.Rows[i]["Title"].ToString());
                    }
                }
            }
        }
        void dtbDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
                
        }
        void dtbDetail_SelectionChanged(object sender, EventArgs e)
        {
            //if (strButtonState == "EDIT")
            //{
            //    FetchCurrencyGrid(dtbDetail.CurrentCell.RowIndex, 1);
            //}
        }
        private void populateCombo()
        {
            string strQuery = "Select * from EX_System Where Flag = 'TY';Select * from EX_SetupCustomer Where Status = 'A';Select * from EX_SetupItems Where Status = 'A';Select AccountNo,Title,b.ItemCode,b.ItemName,b.ShortName,b.MinimumRate  from EX_SetupAccount a Inner Join EX_SetupItems b on b.ItemCode = a.CurrencyCode and b.Status = 'A' Where BranchCode = '" + General.strBranchCode + "' and isTransactional = 'True' and a.Locked = 'false' and a.Status = 'A'";
            dsPopulateCombo = new DataSet();
            cls = new General();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicboParty, dsPopulateCombo.Tables[(int)DataPop.Party], "CustName", "CustCode");
            cls.PopulateCombo(dicboVoucherType, dsPopulateCombo.Tables[(int)DataPop.VT], "Description", "Code");
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AddColumninDetailGrid()
        {

            DataGridViewTextBoxColumn clmnSno = new DataGridViewTextBoxColumn();
            clmnSno.Name = "Sno";
            clmnSno.HeaderText = "Sno";
            clmnSno.Width = 40;
            clmnSno.Visible = false;
            dtbDetail.Columns.Add(clmnSno);

            DataGridViewTextBoxColumn clmnAcCodeFrom = new DataGridViewTextBoxColumn();
            clmnAcCodeFrom.Name = "AccountNoFrom";
            clmnAcCodeFrom.HeaderText = "Settlement Code From";
            clmnAcCodeFrom.Width = 150;
            clmnAcCodeFrom.Visible = false;
            dtbDetail.Columns.Add(clmnAcCodeFrom);

            DataGridViewTextBoxColumn clmnitCode = new DataGridViewTextBoxColumn();
            clmnitCode.Name = "TitleFrom";
            clmnitCode.HeaderText = "Credit";
            clmnitCode.Width = 195;
            clmnitCode.DefaultCellStyle.BackColor = Color.Salmon;
            clmnitCode.DefaultCellStyle.ForeColor = Color.White;
            clmnitCode.DefaultCellStyle.Font= new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            dtbDetail.Columns.Add(clmnitCode);


            DataGridViewTextBoxColumn cboCurCode = new DataGridViewTextBoxColumn();
            cboCurCode.Name = "CurrencyCode";
            cboCurCode.HeaderText = "Currency";
            cboCurCode.Width = 20;
            cboCurCode.Visible = false;
            dtbDetail.Columns.Add(cboCurCode);

            DataGridViewTextBoxColumn cboTitle = new DataGridViewTextBoxColumn();
            cboTitle.Name = "Currency";
            cboTitle.HeaderText = "Currency";
            cboTitle.Width = 70;
            dtbDetail.Columns.Add(cboTitle);

            DataGridViewTextBoxColumn clmnDebit = new DataGridViewTextBoxColumn();
            clmnDebit.Name = "Amount";
            clmnDebit.HeaderText = "Amount";
            clmnDebit.DefaultCellStyle.Format = "N4";
            clmnDebit.ValueType = typeof(System.Double);
            clmnDebit.DefaultCellStyle.NullValue = "0";
            clmnDebit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnDebit.Width = 100;
            dtbDetail.Columns.Add(clmnDebit);
            
            DataGridViewTextBoxColumn clmnRate = new DataGridViewTextBoxColumn();
            clmnRate.Name = "Rate";
            clmnRate.HeaderText = "Rate";
            clmnRate.DefaultCellStyle.Format = "N4";
            clmnRate.ValueType = typeof(System.Double);
            clmnRate.DefaultCellStyle.NullValue = "0";
            clmnRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnRate.Width = 100;
            dtbDetail.Columns.Add(clmnRate);
            
            DataGridViewTextBoxColumn clmnAccountNoCodeTo = new DataGridViewTextBoxColumn();
            clmnAccountNoCodeTo.Name = "AccountNoTo";
            clmnAccountNoCodeTo.Visible = false;
            clmnAccountNoCodeTo.HeaderText = "Settlement Code To";
            clmnAccountNoCodeTo.Width = 100;    
            dtbDetail.Columns.Add(clmnAccountNoCodeTo);


            DataGridViewTextBoxColumn clmnAccountNoTo = new DataGridViewTextBoxColumn();
            clmnAccountNoTo.Name = "TitleTo";
            clmnAccountNoTo.HeaderText = "Debit";
            clmnAccountNoTo.Width = 190;
            clmnAccountNoTo.DefaultCellStyle.BackColor = Color.Teal;
            clmnAccountNoTo.DefaultCellStyle.ForeColor = Color.White;
            clmnAccountNoTo.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            dtbDetail.Columns.Add(clmnAccountNoTo);

            DataGridViewTextBoxColumn clmnVNo = new DataGridViewTextBoxColumn();
            clmnVNo.Name = "TransNo";
            clmnVNo.HeaderText = "TransNo";
            clmnVNo.Visible = false;
            dtbDetail.Columns.Add(clmnVNo);

            DataGridViewTextBoxColumn clmnbrCode = new DataGridViewTextBoxColumn();
            clmnbrCode.Name = "BranchCode";
            clmnbrCode.HeaderText = "";
            clmnbrCode.Visible = false;
            dtbDetail.Columns.Add(clmnbrCode);


            DataGridViewTextBoxColumn clmnCURCodeTO = new DataGridViewTextBoxColumn();
            clmnCURCodeTO.Name = "CurrencyCodeTo";
            clmnCURCodeTO.HeaderText = "";
            clmnCURCodeTO.Visible = false;
            dtbDetail.Columns.Add(clmnCURCodeTO);

        }
        private void frmCurrencyTransfer_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            cls.EnableDisble(PnlMain, false);
            General.strTableName[0] = "EX_CurrencyTransfer";
            General.strTableName[1] = "EX_CurrencyTransferDetail";
            General.strPKColumn = "TransNo";
            General.strAuthorizeTableName = General.strTableName[0];
            populateCombo();
            AddColumninDetailGrid();
            dtbDetail.SelectionChanged += new EventHandler(dtbDetail_SelectionChanged);
            dtbDetail.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dtbDetail_EditingControlShowing);
            dtbDetail.CellBeginEdit += new DataGridViewCellCancelEventHandler(dtbDetail_CellBeginEdit);
            dtbDetail.CellEndEdit += new DataGridViewCellEventHandler(dtbDetail_CellEndEdit);
            dtbDetail.KeyDown += new KeyEventHandler(dtbDetail_KeyDown);
            Mainfrm = (MainForm)this.ParentForm;
            dtDate.Value = General.dtSystemDate;
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
            if (ditxtTransNo.Text != "" && strButtonState != "ADD")
            {

                DataRow[] dr = new DataRow[0];
                dr = dtSearchDetail.Select("TransNo = '" + ditxtTransNo.Text + "'", "TransNo");
                dtbDetail.Rows.Clear();
                for (int i = 0; i < dr.Count(); i++)
                {
                    dtbDetail.Rows.Add();
                    dtbDetail.Rows[i].Cells["Sno"].Value = dr[i]["Sno"].ToString();
                    dtbDetail.Rows[i].Cells["AccountNoTo"].Value = dr[i]["AccountNoTo"].ToString();
                    dtbDetail.Rows[i].Cells["AccountNoFrom"].Value = dr[i]["AccountNoFrom"].ToString();
                    dtbDetail.Rows[i].Cells["TitleFrom"].Value = dr[i]["TitleFrom"].ToString();
                    dtbDetail.Rows[i].Cells["TitleTo"].Value = dr[i]["TitleTo"].ToString();
                    dtbDetail.Rows[i].Cells["CurrencyCode"].Value = dr[i]["CurrencyCode"].ToString();
                    dtbDetail.Rows[i].Cells["Currency"].Value = dr[i]["ShortName"].ToString();
                    dtbDetail.Rows[i].Cells["Amount"].Value = dr[i]["Amount"].ToString();
                    dtbDetail.Rows[i].Cells["TransNo"].Value = dr[i]["TransNo"].ToString();
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = dr[i]["BranchCode"].ToString();
                    dtbDetail.Rows[i].Cells["RAte"].Value = dr[i]["Rate"].ToString();
                }
            }
            //            CalculateAmount();
        }
      
        #region IToolBar Members
        public bool HISTORY()
        {
            return true;
        }
        public bool ADD()
        {
            dtbDetail.Rows.Clear();
            if (dtbDetail.Rows.Count == 0)
            {
                dtbDetail.Rows.Add();
            }
            dtbDetail.ReadOnly = false;
            ditxtTransNo.Enabled = false;
            strButtonState = "ADD";
            strFormButton = General.strStateAddEDIT;
            dicboVoucherType.Focus();
            dtDate.Value = General.dtSystemDate;

            return true;

        }

        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();
            strFormButton = General.strStateALL;
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            if (strButtonState == "ADD")
            {
                ditxtTransNo.Text = "ACT-" + cls.GetTransNo(strTransType) + "-" + General.strBranchCode.ToString();
               
            }
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (dtbDetail.Rows[i].Cells["AccountNoFrom"].Value != null)
                {
                    if (string.IsNullOrEmpty(dtbDetail.Rows[i].Cells["AccountNoFrom"].Value.ToString()) == false)
                    {
                        dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                        dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                        dtbDetail.Rows[i].Cells["Sno"].Value = i;
                    }
                    
                }
            }
            if (ValidatingControls() == true)
            {
                strCondition = "Where TransNo = '" + ditxtTransNo.Text + "' and BranchCode = '" + General.strBranchCode + "'";
                ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "UserId=" + General.strUserId + ";BranchCode=" + General.strBranchCode + "");
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
                strButtonState = "SAVE";
                cls.EnableDisble(PnlMain, false);
            }
            else
            {
                MessageBox.Show(strError, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                General.strButtonState = strButtonState;
            }
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            return false;
        }

        public bool EDIT()
        {
            ditxtTransNo.Enabled = false;
            strFormButton = General.strStateAddEDIT;
            strButtonState = "EDIT";
            dtbDetail.ReadOnly = false;
            return true;
        }

        public bool QUERY()
        {
            strFormButton = General.strStateALL;
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_CurrencyTransfer a " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "' ";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate + "'";
            }

            strQuery = strQuery + " ;Select e.Sno,e.TransNo,e.AccountNoTo,e.CurrencyCode,e.AccountNoFrom,e.Amount,b.Title,c.Title As TitleTo,e.Rate,b.Title as TitleFrom,d.ShortName,e.BranchCode from EX_CurrencyTransferDetail e  Inner Join EX_CurrencyTransfer a on a.TransNo = e.TransNo and a.BranchCode = e.BRanchcode and a.RecNo = e.RecNo Left Outer Join EX_SetupAccount b on e.AccountNoFrom = b.AccountNo and e.BranchCode = b.BranchCode and b.Status = 'A' Left Outer Join EX_SetupAccount c on e.AccountNoTo = c.AccountNo and e.BranchCode = c.BranchCode and c.Status = 'A' Inner Join EX_SetupItems d on d.ItemCode = e.CurrencyCode and d.Status = 'A' Where e.BranchCode = '" + General.strBranchCode + "'";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            }
            ds = objGetData.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtSearchDetail = ds.Tables[1];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
            dtbDetail.ReadOnly = true;
            strButtonState = "QUERY";
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            dtbMaster_SelectionChanged(dtbDetail, null);
            return true;
        }
        public bool UNDO()
        {
            strFormButton = General.strStateALL;
            strButtonState = "UNDO";
            dtbDetail.Rows.Clear();
            return true;
        }

        public bool EXIT()
        {
            strFormButton = General.strStateALL;
            strButtonState = "EXIT";
            return true;
        }

        public bool DELETE()
        {
            cls = new General();
            strCondition = "Where TransNo = '" + ditxtTransNo.Text + "'";
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
            strFormButton = General.strStateALL;
            strButtonState = "NEXT";
            return true;
        }

        public bool PREVIOUS()
        {
            strFormButton = General.strStateALL;
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
                if (ditxtTransNo.Text != "")
                {
                    cls = new General();
                    cls.GenerateVoucher("ACT", ditxtTransNo.Text);
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
            if (dtbDetail.Rows.Count > 0)
            {
                for (int i = 0; i < dtbDetail.Rows.Count ; i++)
                {
                    if (dtbDetail.Rows[i].Cells["Sno"].Value != null)
                    {
                        if (dtbDetail.Rows[i].Cells["CurrencyCodeTo"].Value != null)
                        {
                            if (dtbDetail.Rows[i].Cells["CurrencyCode"].Value.ToString() != dtbDetail.Rows[i].Cells["CurrencyCodeTo"].Value.ToString())
                            {
                                strError = "Accounts Dealing Currency Should be Same on line " + i + 1 + "";
                                bolState = false;

                            }
                        }
                        if (dtbDetail.Rows[i].Cells["AccountNoTo"].Value.ToString() == dtbDetail.Rows[i].Cells["AccountNoFrom"].Value.ToString())
                        {
                            strError = "Accounts Should be not Same on line " + i + 1 + "";
                            bolState = false;
                        }
                        if (dtbDetail.Rows[i].Cells["AccountNoTo"].Value == null || dtbDetail.Rows[i].Cells["AccountNoFrom"].Value == null)
                        {
                                strError = "Accounts Should be not Empty on line " + i + 1 + "";
                                bolState = false;
                        }

                        if (dtbDetail.Rows[i].Cells["AccountNoTo"].Value != null || dtbDetail.Rows[i].Cells["AccountNoFrom"].Value != null)
                        {
                            if (dtbDetail.Rows[i].Cells["AccountNoTo"].Value.ToString() == "" || dtbDetail.Rows[i].Cells["AccountNoFrom"].Value.ToString() == "")
                            {
                                strError = "Accounts Should be not Empty on line " + i + 1 + "";
                                bolState = false;
                            }
                        }
                    }
                }
            }
            else
            {
                strError = "Atleast One Record Should be Added";
            }
            return bolState;
        }

        private void FetchCurrencyGrid(int intRow, int intColumn)
        {
            DataTable dtb = new DataTable();
            //if (dtbDetail.Columns["Currency"].Index == intColumn)
            //{
            //    dtb = dsPopulateCombo.Tables[(int)DataPop.Currency];
            //    DataRow[] dRow = dtb.Select("ItemName = '" + dtbDetail.Rows[intRow].Cells["Currency"].Value + "'");
            //    if (dRow.Count() > 0)
            //    {
            //        dtbDetail.Rows[intRow].Cells["Currency"].Value = dRow[0]["ItemName"].ToString();
            //        dtbDetail.Rows[intRow].Cells["CurrencyCode"].Value = dRow[0]["ItemCode"].ToString();
            //        dtbDetail.Rows[intRow].Cells["Rate"].Value = dRow[0]["MinimumRate"].ToString();
            //    }
            //    else
            //    {
            //        dtbDetail.Rows[intRow].Cells["Currency"].Value = "";
            //        dtbDetail.Rows[intRow].Cells["CurrencyCode"].Value = "";
            //        dtbDetail.Rows[intRow].Cells["Rate"].Value = "0";
            //    }
            
            //}
            if (dtbDetail.Columns["TitleFrom"].Index == intColumn)
            {
                dtb = dsPopulateCombo.Tables[(int)DataPop.AccountNo];
                DataRow[] dRow = dtb.Select("Title = '" + dtbDetail.Rows[intRow].Cells["TitleFrom"].Value + "'");
                if (dRow.Count() > 0)
                {
                    dtbDetail.Rows[intRow].Cells["TitleFrom"].Value = dRow[0]["Title"].ToString();
                    dtbDetail.Rows[intRow].Cells["AccountNoFrom"].Value = dRow[0]["AccountNo"].ToString();
                    dtbDetail.Rows[intRow].Cells["Currency"].Value = dRow[0]["ShortName"].ToString();
                    dtbDetail.Rows[intRow].Cells["CurrencyCode"].Value = dRow[0]["ItemCode"].ToString();
                    dtbDetail.Rows[intRow].Cells["Rate"].Value = dRow[0]["MinimumRate"].ToString();
                    if (dRow[0]["ItemCode"].ToString() == "304")
                    {
                        dtbDetail.Columns["Rate"].ReadOnly = true;
                    }
                    else
                    {
                        dtbDetail.Columns["Rate"].ReadOnly = false;
                    }
                    dtbDetail.Columns["Currency"].ReadOnly = true;
                }
                else
                {
                    dtbDetail.Rows[intRow].Cells["TitleFrom"].Value = "";
                    dtbDetail.Rows[intRow].Cells["AccountNoFrom"].Value = "";
                    dtbDetail.Rows[intRow].Cells["Currency"].Value = "";
                    dtbDetail.Rows[intRow].Cells["CurrencyCode"].Value = "";
                    dtbDetail.Rows[intRow].Cells["Rate"].Value = "0";

                }
            }
               else if (dtbDetail.Columns["TitleTo"].Index == intColumn)
            {
                dtb = dsPopulateCombo.Tables[(int)DataPop.AccountNo];
                DataRow[] dRow = dtb.Select("Title = '" + dtbDetail.Rows[intRow].Cells["TitleTo"].Value + "'");
                if (dRow.Count() > 0)
                {
                    dtbDetail.Rows[intRow].Cells["TitleTo"].Value = dRow[0]["Title"].ToString();
                    dtbDetail.Rows[intRow].Cells["AccountNoTo"].Value = dRow[0]["AccountNo"].ToString();
                    dtbDetail.Rows[intRow].Cells["CurrencyCodeTo"].Value = dRow[0]["ItemCode"].ToString();
                }
                else
                {
                    dtbDetail.Rows[intRow].Cells["TitleTo"].Value = "";
                    dtbDetail.Rows[intRow].Cells["AccountNoTo"].Value = "";
                    dtbDetail.Rows[intRow].Cells["CurrencyCodeTo"].Value = "0";
                }
            }
          
          }

        private void frmCurrencyTransfer_Activated(object sender, EventArgs e)
        {
            Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }
        
        private void dotxtRemarks_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                dtbDetail.Focus();
                dtbDetail.Rows[0].Cells[0].Selected = false;
                dtbDetail.Rows[0].Cells[1].Selected = true;

            }
            catch (Exception)
            {


            }
        }

        private void dtbDetail_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (General.strButtonState == "ADD" || strButtonState == "ADD" || General.strButtonState == "SAVE" || General.strButtonState == "EDIT")
            {
                if (e.KeyValue == 13)
                {
                    SendKeys.Send("{Right}");
                    if (dtbDetail.Columns.Count == dtbDetail.CurrentCell.ColumnIndex + 4)
                    {
                        if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["SNo"].Value != null)
                        {
                            dtbDetail.Rows.Add();
                            SendKeys.Send("{Home}");
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Amount"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Rate"].Value = 0;
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
            }
        }
    }
}
