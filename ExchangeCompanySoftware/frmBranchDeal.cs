using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExchangeCompanySoftware.Reports;

using DevExpress.XtraReports.UI;
namespace ExchangeCompanySoftware
{
    public partial class frmBranchDeal : BaseForm,IToolBar
    {
        enum DataPop {Trans,CustName,Account,Item,ExRate,ReportAccount};
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataSet dsPopulateCombo;
        DataTable dtSearchMaster;
        DataTable dtSearchDetail;
        string strAccountNo = "";
        public string strButtonState = null;
        string strTransType = "IBRT";
        public string strError = "";
        string strCondition;
        string strValue;
        double dblQty = 0;
        double dbllastvalue;
        MainForm Mainfrm;
           
        AutoCompleteStringCollection namesCollection =
       new AutoCompleteStringCollection();
        public frmBranchDeal()
        {
            InitializeComponent();
        }
        private void AddColumninDetailGrid()
        {

            DataGridViewTextBoxColumn clmnSno = new DataGridViewTextBoxColumn();
            clmnSno.Name = "Sno";
            clmnSno.HeaderText = "Sno";
            clmnSno.Width = 40;
            clmnSno.ReadOnly = true;
            clmnSno.Visible = false;
            dtbDetail.Columns.Add(clmnSno);


            DataGridViewTextBoxColumn clmnSymbol = new DataGridViewTextBoxColumn();
            clmnSymbol.Name = "Symbol";
            clmnSymbol.HeaderText = "Symbol";
            clmnSymbol.Width = 70;
            dtbDetail.Columns.Add(clmnSymbol);

            DataGridViewTextBoxColumn cboTitle = new DataGridViewTextBoxColumn();
            cboTitle.Name = "ItemName";
            cboTitle.HeaderText = "Name of Currency";
            cboTitle.Width = 200;
            dtbDetail.Columns.Add(cboTitle);

            DataGridViewTextBoxColumn clmnitCode = new DataGridViewTextBoxColumn();
            clmnitCode.Name = "ItemCode";
            clmnitCode.HeaderText = "Code";
            clmnitCode.Width = 0;
            clmnitCode.Visible = false;
            dtbDetail.Columns.Add(clmnitCode);

            DataGridViewTextBoxColumn clmnQty = new DataGridViewTextBoxColumn();
            clmnQty.Name = "Quantity";
            clmnQty.HeaderText = "Quantity";
            clmnQty.DefaultCellStyle.Format = "N4";
            clmnQty.ValueType = typeof(System.Double);
            clmnQty.DefaultCellStyle.NullValue = "0";
            clmnQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnQty.Width = 70;
            dtbDetail.Columns.Add(clmnQty);

            DataGridViewTextBoxColumn clmnRate = new DataGridViewTextBoxColumn();
            clmnRate.Name = "Rate";
            clmnRate.HeaderText = "Rate";
            clmnRate.DefaultCellStyle.Format = "N4";
            clmnRate.ValueType = typeof(System.Double);
            clmnRate.DefaultCellStyle.NullValue = "0";
            clmnRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnRate.Width = 70;
            dtbDetail.Columns.Add(clmnRate);

            DataGridViewTextBoxColumn clmnAmount = new DataGridViewTextBoxColumn();
            clmnAmount.Name = "Amount";
            clmnAmount.HeaderText = "Amount";
            clmnAmount.DefaultCellStyle.Format = "N0";
            clmnAmount.ValueType = typeof(System.Double);
            clmnAmount.DefaultCellStyle.NullValue = "0";
            clmnAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnAmount.Width = 100;
            clmnAmount.ReadOnly = true;
            dtbDetail.Columns.Add(clmnAmount);

            DataGridViewTextBoxColumn clmnEQU = new DataGridViewTextBoxColumn();
            clmnEQU.Name = "usEquilent";
            clmnEQU.HeaderText = "US$ Equilent Amount";
            clmnEQU.DefaultCellStyle.Format = "N2";
            clmnEQU.ValueType = typeof(System.Double);
            clmnEQU.DefaultCellStyle.NullValue = "0";
            clmnEQU.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnEQU.Width = 120;
            clmnEQU.ReadOnly = true;

            dtbDetail.Columns.Add(clmnEQU);

            DataGridViewTextBoxColumn clmnVNo = new DataGridViewTextBoxColumn();
            clmnVNo.Name = "VoucherNo";
            clmnVNo.HeaderText = "VoucherNo";
            clmnVNo.Width = 0;
            clmnVNo.Visible = false;
            dtbDetail.Columns.Add(clmnVNo);

            DataGridViewTextBoxColumn clmnBranch = new DataGridViewTextBoxColumn();
            clmnBranch.Name = "BranchCode";
            clmnBranch.HeaderText = "BranchCode";
            clmnBranch.Width = 0;
            clmnBranch.Visible = false;
            dtbDetail.Columns.Add(clmnBranch);
          
            DataGridViewTextBoxColumn clmnStock = new DataGridViewTextBoxColumn();
            clmnStock.Name = "Stock";
            clmnStock.HeaderText = "Stock";
            clmnStock.Width = 0;
            clmnStock.Visible = false;
            dtbDetail.Columns.Add(clmnStock);

        }
        void dtbMaster_SelectionChanged(object sender, EventArgs e)
        {
            DataRow[] dr = new DataRow[0];
            if (ditxtVoucherNo.Text != "" && strButtonState != "ADD")
            {
                if (dtSearchDetail != null)
                {
                    dr = dtSearchDetail.Select("VoucherNo = '" + ditxtVoucherNo.Text + "' ", "VoucherNo");
                    dtbDetail.Rows.Clear();
                    for (int i = 0; i < dr.Count(); i++)
                    {
                        dtbDetail.Rows.Add();
                        dtbDetail.Rows[i].Cells["Sno"].Value = dr[i]["Sno"].ToString();
                        dtbDetail.Rows[i].Cells["ItemCode"].Value = dr[i]["ItemCode"].ToString();
                        dtbDetail.Rows[i].Cells["ItemName"].Value = dr[i]["ItemName"].ToString();
                        dtbDetail.Rows[i].Cells["Symbol"].Value = dr[i]["ShortName"].ToString();
                        dtbDetail.Rows[i].Cells["Quantity"].Value = dr[i]["Quantity"].ToString();
                        dtbDetail.Rows[i].Cells["Rate"].Value = dr[i]["Rate"].ToString();
                        dtbDetail.Rows[i].Cells["Amount"].Value = dr[i]["Amount"].ToString();
                        dtbDetail.Rows[i].Cells["VoucherNo"].Value = dr[i]["VoucherNo"].ToString();
                        dtbDetail.Rows[i].Cells["usEquilent"].Value = Convert.ToDecimal(dr[i]["Amount"].ToString()) / numEXRAtes.Value;
                        dtbDetail.Rows[i].Cells["BranchCode"].Value = dr[i]["BranchCode"].ToString();
                    }
                    CalculateAmount();

                }

            }
        }
        void dtbDetail_KeyDown(object sender, KeyEventArgs e)
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
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Quantity"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Rate"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Amount"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["usEquilent"].Value = 0;


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

                    if (dtbDetail.Columns[dtbDetail.CurrentCell.ColumnIndex].Name == "Symbol")
                    {
                        DataTable dtb = new DataTable();
                        dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
                        frmListSearch childForm = new frmListSearch(dtb, "S",null);
                        childForm.ShowDialog();
                        if (frmListSearch.strArg != null)
                        {
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["ItemCode"].Value = frmListSearch.strArg[0];
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["itemName"].Value = frmListSearch.strArg[1];
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Symbol"].Value = frmListSearch.strArg[2];
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
                if (dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value != null)
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Sno"].Value = e.RowIndex + 1;
                }
                else
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Sno"].Value = "";
                    dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = "0";
                    dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = "0";
                    dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = "0";
                    dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value = "";
                    dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value = "";
                    dtbDetail.Rows[e.RowIndex].Cells["VoucherNo"].Value = "";

                }
                if (dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value == null)
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
                }
                if (dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value == null)
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
                }
                if (dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value == null)
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                }
                if (dtbDetail.Rows[e.RowIndex].Cells["usEquilent"].Value == null)
                {
                    dtbDetail.Rows[e.RowIndex].Cells["usEquilent"].Value = 0;
                }

                if (dtbDetail.Columns["Quantity"].Index == e.ColumnIndex)
                {
                    if (dicboTransaction.SelectedValue.ToString() == "2")
                    {
                        //if (strButtonState == "ADD" || strButtonState == null)
                        //{
                        //    if (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) > Convert.ToDouble(donumStock.Value))
                        //    {
                        //        MessageBox.Show("Stock is not available of this Currency");
                        //        dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
                        //        dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Selected = true;
                        //    }

                        //}
                        //else if (strButtonState == "EDIT")
                        //{
                        //    //double dblQty = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) + Convert.ToDouble(donumStock.Value);
                        //    if (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) > dblQty)
                        //    {
                        //        MessageBox.Show("Stock is not available of this Currency");
                        //        dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = dbllastvalue;
                        //        dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Selected = true;
                        //    }
                        //}

                    }
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == false)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                    }
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == true && cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == true)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = Math.Round(Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value),0);
                        dtbDetail.Rows[e.RowIndex].Cells["usEquilent"].Value =  Math.Round((Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value) / Convert.ToDouble(numEXRAtes.Value)),4);
                    }
                    CalculateAmount();
                }

                if (dtbDetail.Columns["Rate"].Index == e.ColumnIndex)
                {
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == false || dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString() == "")
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                    }
                    if (Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value) < Convert.ToDecimal(donumMinRate.Value))
                    {

                        dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
                        MessageBox.Show("Rate Should not be Minimum from Defined Rate", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value) > Convert.ToDecimal(donumMax.Value))
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
                        MessageBox.Show("Rate Should not be Maximum from Defined Rate", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == true)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value =  Math.Round(Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value),0);
                        dtbDetail.Rows[e.RowIndex].Cells["usEquilent"].Value =  Math.Round((Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value) / Convert.ToDouble(numEXRAtes.Value)),4);
                    }
                    CalculateAmount();
                }
                if (dtbDetail.Columns["Symbol"].Index == e.ColumnIndex)
                {
                    FetchCurrencyGrid(e.RowIndex, e.ColumnIndex);
                }
                if (dtbDetail.Columns["ItemName"].Index == e.ColumnIndex)
                {
                    FetchCurrencyGrid(e.RowIndex, e.ColumnIndex);
                }

                if (dtbDetail.Columns["Quantity"].Index == e.ColumnIndex)
                {
                    //if (dicboTransaction.SelectedValue.ToString() == "2")
                    //{
                    //    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == true)
                    //    {
                    //        if (Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) > donumStockV.Value)
                    //        {
                    //            MessageBox.Show("Insufficent Balance in HAND", "Error",
                    //              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = "0";
                    //            dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = "0";
                    //            dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = "0";
                    //            dtbDetail.Rows[e.RowIndex].Cells["usEquilent"].Value = "0";

                    //        }
                    //    }
                        
                    //}
                 
                }
                //dtbDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                //dtbDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Selected = true;

            }
            catch (Exception)
            {

            }
        }
        void dtbDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataTable dtb = new DataTable();
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridViewTextBoxEditingControl te;
                if (dtbDetail.CurrentCell.ColumnIndex == 1)
                {
                    te = new DataGridViewTextBoxEditingControl();
                    te.Clear();
                    te = (DataGridViewTextBoxEditingControl)e.Control;
                    te.AutoCompleteMode = AutoCompleteMode.Suggest;
                    te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        te.AutoCompleteCustomSource.Add(dtb.Rows[i]["ShortName"].ToString());
                    }

                }
                else if (dtbDetail.CurrentCell.ColumnIndex == 2)
                {
                    te = new DataGridViewTextBoxEditingControl();
                    te.Clear();
                    te = (DataGridViewTextBoxEditingControl)e.Control;
                    te.AutoCompleteMode = AutoCompleteMode.Suggest;
                    te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        te.AutoCompleteCustomSource.Add(dtb.Rows[i]["ItemName"].ToString());
                    }
                }
            }
        }
        void dtbDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dicboTransaction.SelectedValue.ToString() == "2")
            {
                if (dtbDetail.Columns["Quantity"].Index == e.ColumnIndex)
                {
                    if (strButtonState == "EDIT")
                    {
                        if (dbllastvalue == 0)
                        {
                            dbllastvalue = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                        }
                        dblQty = dbllastvalue + Convert.ToDouble(donumStock.Value);
                    }
                }
            }
        }
        void dtbDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (strButtonState == "EDIT")
            {
                FetchCurrencyGrid(dtbDetail.CurrentCell.RowIndex, 1);
            }
        }
        private void FetchCurrencyGrid(int intRow, int intColumn)
        {
            DataTable dtb = new DataTable();
            dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
            if (dtbDetail.Columns["Symbol"].Index == intColumn)
            {
                DataRow[] dRow = dtb.Select("ShortName = '" + dtbDetail.Rows[intRow].Cells["Symbol"].Value + "'");
                if (dRow.Count() > 0)
                {
                    dtbDetail.Rows[intRow].Cells["ItemName"].Value = dRow[0]["ItemName"].ToString();
                    dtbDetail.Rows[intRow].Cells["ItemCode"].Value = dRow[0]["ItemCode"].ToString();
                    donumMax.Value = Convert.ToDecimal(dRow[0]["MaximumRate"].ToString());
                    donumMinRate.Value = Convert.ToDecimal(dRow[0]["MinimumRate"].ToString());
                    DataTable dtbstock = cls.GetStockds(General.dtSystemDate, dtbDetail.Rows[intRow].Cells["ItemCode"].Value.ToString()).Tables[0];

                    if (dtbstock.Rows.Count > 0)
                    {
                        //donumStock.Value = Convert.ToDecimal(dtbstock.Rows[1]["FCAmount"].ToString());
                        //donumStockV.Value = Convert.ToDecimal(dtbstock.Rows[0]["FCAmount"].ToString());

                      //  donumStock.Value = Convert.ToDecimal(dtbstock.Rows[0]["FCAmount"].ToString());
                        donumAverage.Value = Convert.ToDecimal(dtbstock.Rows[0]["AvgRate"].ToString());
                      //  dtbDetail.Rows[intRow].Cells["Stock"].Value = dtbstock.Rows[0]["FCAmount"].ToString();
                    }
                }
                else
                {
                    dtbDetail.Rows[intRow].Cells["ItemName"].Value = "";
                    dtbDetail.Rows[intRow].Cells["ItemCode"].Value = "";
                    dtbDetail.Rows[intRow].Cells["Symbol"].Value = "";
                    donumMax.Value = 0;
                    donumMinRate.Value = 0;
                }
            }
            if (dtbDetail.Columns["ItemName"].Index == intColumn)
            {

                if (dtbDetail.Rows[intRow].Cells["ItemName"].Value.ToString().Length >= 3)
                {
                    DataRow[] dr = dtb.Select("ItemName Like '" + dtbDetail.Rows[intRow].Cells["ItemName"].Value + "%'", "ItemName");
                    if (dr.Count() > 0)
                    {
                        if (dr.GetUpperBound(0) >= 0)
                        {
                            dtb.DefaultView.Sort = "ItemName";
                            dtbDetail.Rows[intRow].Cells["ItemName"].Value = dr[0]["ItemName"].ToString();
                            dtbDetail.Rows[intRow].Cells["ItemCode"].Value = dr[0]["ItemCode"].ToString();
                            dtbDetail.Rows[intRow].Cells["Symbol"].Value = dr[0]["ShortName"].ToString();
                            donumMax.Value = Convert.ToDecimal(dr[0]["MaximumRate"].ToString());
                            donumMinRate.Value = Convert.ToDecimal(dr[0]["MinimumRate"].ToString());
                            DataTable dtbstock = cls.GetStockds(General.dtSystemDate, dtbDetail.Rows[intRow].Cells["ItemCode"].Value.ToString()).Tables[0];

                            if (dtbstock.Rows.Count > 0)
                            {
                                donumStock.Value = Convert.ToDecimal(dtbstock.Rows[1]["FCAmount"].ToString());
                                donumStockV.Value = Convert.ToDecimal(dtbstock.Rows[0]["FCAmount"].ToString());

                                donumAverage.Value = Convert.ToDecimal(dtbstock.Rows[0]["AvgRate"].ToString());
                            }

                        }
                    }
                    else
                    {
                        dtb.DefaultView.Sort = "";
                        dtbDetail.Rows[intRow].Cells["ItemName"].Value = "";
                        dtbDetail.Rows[intRow].Cells["ItemCode"].Value = "";
                        dtbDetail.Rows[intRow].Cells["Symbol"].Value = "";

                    }
                }
            }

        }
        private void PopulateCombo()
        {
            cls = new General();

            strValue = cls.strControlAccount("PurchaseSale");
            string strQuery = "Select * from EX_System Where Flag = 'T';Select * from EX_Branch Where BranchCode != '" + General.strBranchCode + "' ;Select * from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and AccountNo = '" + strValue + "' and Status = 'A';Select * from EX_SetupItems Where Locked = 'False' and Status = 'A';Select * from EX_System Where Flag = 'E';Select * from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Status = 'A' and isTransactional = 'true'";
            dsPopulateCombo = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicboTransaction, dsPopulateCombo.Tables[(int)DataPop.Trans], "Description", "Code");
            cls.PopulateCombo(dicboBranch, dsPopulateCombo.Tables[(int)DataPop.CustName], "BranchName", "BranchCode");
            cls.PopulateCombo(dicboAccount, dsPopulateCombo.Tables[(int)DataPop.ReportAccount], "Title", "AccountNo");
        }

        private void GenerateVoucherNo()
        {
            string strTransNo = string.Format("{0:D5}", Convert.ToInt32(cls.GetTransNo(strTransType)));
            ditxtVoucherNo.Text = strTransType + "-" + strTransNo + "-" + General.strBranchCode;
        }
        #region IToolBar Members
        
        public bool ADD()
        {
   
            dicboTransaction.SelectedIndex = 1;
            dicboTransaction.SelectedIndex = 0;
            //dicboBranch.SelectedIndex = 1;
            //dicboBranch.SelectedIndex = 0;
            dtbDetail.Rows.Clear();
            if (dtbDetail.Rows.Count == 0)
            {
                dtbDetail.Rows.Add();    
            }
            ditxtVoucherNo.Enabled = false;
            strButtonState = "ADD";
            dicboTransaction.Focus();
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
                if (strButtonState == "ADD" || strButtonState == "EDIT")
                {
                    if (ValidatingControls() == true)
                    {
                        for (int i = 0; i < dtbDetail.Rows.Count; i++)
                        {
                            dtbDetail.Rows[i].Cells["Sno"].Value = i;
                            dtbDetail.Rows[i].Cells["VoucherNo"].Value = ditxtVoucherNo.Text;
                            dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                        }
                    
                        if (dicboTransaction.SelectedValue == "1")
                        {
                            strTransType = "IBRTP";
                        }
                        else if (dicboTransaction.SelectedValue == "2")
                        {
                            strTransType = "IBRTS";
                        }
                        strCondition = "Where VoucherNo = '" + ditxtVoucherNo.Text + "'";
                        ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "Posted=False;Process=Green;AccountNo=" + strValue + ";BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + "");
                        dtbMaster.DataSource = ds.Tables[0];
                        //dtSearchDetail = ds.Tables[1];
                        cls.BindGridwithTextBox(PnlMain, dtbMaster, "",null);
                        cls.EnableDisble(PnlMain, false);
                        strButtonState = "SAVE";
                    }
                    else
                    {
                        MessageBox.Show(strError, "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Mainfrm.EnableDisbale(strButtonState, true, "S");
                    
                }
            return true;
        }

        public bool EDIT()
        {
           ditxtVoucherNo.Enabled = false;
           strButtonState = "EDIT";
           return true;
        }

        public bool QUERY()
        {
           objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
           DataSet ds = new DataSet();
           dtSearchDetail = new DataTable();
           dtSearchMaster = new DataTable();        
           string strQuery;
           strQuery = "Select * from EX_TransInterBranchMaster a " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "'";
           if (General.strFormQueryCriteria != "")
           {
               strQuery = strQuery + General.strFormQueryCriteria;
           }
           else
           {
               strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
           }
           strQuery = strQuery + " ;Select c.RecNo,SNO,c.ItemCode,ItemName,ShortName,Quantity,Rate,Amount,c.VoucherNo,c.BranchCode from EX_TransInterBranchDetail c Inner Join EX_TransInterBranchMaster a on a.VoucherNo = c.VoucherNo and a.RecNo = c.RecNo Inner Join EX_SetupItems b on c.ItemCode = b.ItemCode and b.Status = 'A'";
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
           cls.BindGridwithTextBox(PnlMain, dtbMaster,"",null);
           dtbMaster_SelectionChanged(dtbMaster, null);
           strButtonState = "QUERY";
           return true;
        }

        public bool UNDO()
        {
            strButtonState = "UNDO";
            dtbDetail.Rows.Clear();
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
            strCondition = "Where VoucherNo = '" + ditxtVoucherNo.Text + "'";
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

            //if (txtStatus.Text == "A")
            //{
                if (ditxtVoucherNo.Text != "")
                {
                    objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                    DataTable dtb = new DataTable();


                    string strQuery = " Select a.TransDate,c.Description as TransType,a.VoucherNo,e.ItemName,Quantity,b.Rate,Amount,";
                    strQuery = strQuery + " a.Remarks,d.Title,a.UserID";
                    strQuery = strQuery + " from EX_TransInterBranchMaster a ";
                    strQuery = strQuery + " Inner Join EX_TransInterBranchDetail b on a.VoucherNo = b.VoucherNo  ";
                    strQuery = strQuery + " and a.BranchCode = b.BranchCode and a.REcNo = b.RecNo ";
                    strQuery = strQuery + " Inner Join EX_System c on a.TransType = c.Code and Flag = 'T' ";
                    strQuery = strQuery + " Inner join EX_SetupAccount d on a.ReportAccountNo = d.AccountNo and a.BranchCode = d.BranchCode and d.Status = 'A' ";
                    strQuery = strQuery + " Inner Join EX_SetupItems e on b.ItemCode = e.ItemCode and e.Status = 'A' ";
                    strQuery = strQuery + " Where a.VoucherNo = '" + ditxtVoucherNo.Text + "'  ";
                    strQuery = strQuery + " and a.BranchCode = '" + General.strBranchCode + "' ";
                    strQuery = strQuery + " Order by e.ItemName ";

                    dtb = objGetData.GetDataSet(strQuery).Tables[0];
                    rptInterBranchBill devrep = new rptInterBranchBill();
                    dtb = objGetData.GetDataSet(strQuery).Tables[0];
                    devrep.Margins = new System.Drawing.Printing.Margins(40, 0, 10, 10);
                    devrep.DataSource = dtb;
                    devrep.Parameters["UserId"].Value = General.strUserId;
                    devrep.Parameters["ReportName"].Value = General.strReportCaption + " Voucher";
                    devrep.Parameters["CompanyName"].Value = General.strCompanyName;
                    devrep.Parameters["BranchName"].Value = General.strBranchName;
                    devrep.Parameters["Criteria"].Value = "";
                    devrep.RequestParameters = false;
                    devrep.CreateDocument();
                    devrep.ShowPreview();


                    strButtonState = "PRINT";
                }
                else
                {
                    MessageBox.Show("Select Voucher For Print", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
            //else
            //{
            //    MessageBox.Show("Authorized The Voucher", "Saved",
            //    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            return true;

        }

        #endregion
        public Boolean ValidatingControls()
        {
            Boolean bolState;
            strError = "";
            cls.Validate(PnlMain);
            if (!String.IsNullOrEmpty(cls.StrMessage))
            {
                strError = cls.StrMessage;
                bolState= false;
            }
            else
            {
                bolState = true;
            }
            for (int i = 0; i < dtbDetail.Rows.Count ; i++)
            {
                if (dtbDetail.Rows[i].Cells["Sno"].Value != null)
                {
                    if (String.IsNullOrEmpty(dtbDetail.Rows[i].Cells["ItemCode"].Value.ToString()) == false)
                    {
                        //if (dicboTransaction.SelectedValue.ToString() == "2")
                        //{
                        //    if (dtbDetail.Rows[i].Cells["Stock"].Value != null)
                        //    {
                        //        if (Convert.ToDouble(dtbDetail.Rows[i].Cells["Quantity"].Value.ToString()) > Convert.ToDouble(dtbDetail.Rows[i].Cells["Stock"].Value.ToString()))
                        //        {
                        //            strError = strError + "\n" + "Quantity is not Available of " + dtbDetail.Rows[i].Cells["ShortName"].Value.ToString() + "";
                        //        }                            
                        //    }
                        //}
                        if (dtbDetail.Rows[i].Cells["Amount"].Value.ToString() == "0" || dtbDetail.Rows[i].Cells["Amount"].Value == null)
                        {
                            strError = strError + "\n" + "Amount Should not be 0 on line no "+ i +"";
                            bolState = false;
                        }
                    }
                }
            }

            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (dtbDetail.Rows[i].Cells["Sno"].Value != null )
                {
                    if (String.IsNullOrEmpty(dtbDetail.Rows[i].Cells["ItemCode"].Value.ToString()))
                    {
                        strError = strError + "\n" + "Item Should not be Empty on line no " + i + "";
                        bolState = false;
                    }
                }
            }
      
            return bolState;
        }
        private void cboTransaction_Validated(object sender, EventArgs e)
        {
            switch (dicboTransaction.SelectedValue.ToString())
            {
                case "1":
                    strTransType = "PUR";
                    break;
                case "2":
                    strTransType = "SAL";
                    break;

            }
        }
        private void CalculateAmount()
        {
            lblTotalAmount.Text = "0";
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (Convert.ToDouble(lblTotalAmount.Text) == Convert.ToDouble("0"))
                {
                    if (dtbDetail.Rows[i].Cells["usEquilent"].Value == null)
                    {
                        dtbDetail.Rows[i].Cells["usEquilent"].Value = "0";
                    }
                    if (dtbDetail.Rows[i].Cells["Amount"].Value == null)
                    {
                        dtbDetail.Rows[i].Cells["Amount"].Value = "0";
                    }
                    lblTotalAmount.Text = dtbDetail.Rows[i].Cells["Amount"].Value.ToString();
                    lblusdAmount.Text = dtbDetail.Rows[i].Cells["usEquilent"].Value.ToString();
                }
                else
                {
                    if (dtbDetail.Rows[i].Cells["usEquilent"].Value == null)
                    {
                        dtbDetail.Rows[i].Cells["usEquilent"].Value = "0";
                    }
                    if (dtbDetail.Rows[i].Cells["Amount"].Value == null)
                    {
                        dtbDetail.Rows[i].Cells["Amount"].Value = "0";
                    }
                    lblTotalAmount.Text =
                        (Convert.ToDouble(lblTotalAmount.Text) +
                        Convert.ToDouble(dtbDetail.Rows[i].Cells["Amount"].Value)).ToString();
                    lblusdAmount.Text =
                                            (Convert.ToDouble(lblusdAmount.Text) +
                                            Convert.ToDouble(dtbDetail.Rows[i].Cells["usEquilent"].Value)).ToString();

                }
            }

            decimal d = Math.Round(Convert.ToDecimal(lblusdAmount.Text.ToString()),2);
            lblusdAmount.Text = d.ToString();
            d = Math.Round(Convert.ToDecimal(lblTotalAmount.Text.ToString()), 0);
            lblTotalAmount.Text = d.ToString();
            lblTotalAmount.Text = string.Format("{0:0,0}", Convert.ToDouble(lblTotalAmount.Text));
            lblusdAmount.Text = string.Format("{0:0,0}", Convert.ToDouble(lblusdAmount.Text));

        }
        private void dotxtRemarks_Validating(object sender, CancelEventArgs e)
        {
            dtbDetail.Focus();
            dtbDetail.Rows[0].Cells[0].Selected = false;
            dtbDetail.Rows[0].Cells[1].Selected = true;
   
        }

        private void frmBranchDeal_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            General.strTableName[1] = "EX_TransInterBranchDetail";
            General.strTableName[0] = "EX_TransInterBranchMaster";
            General.strPKColumn = "VoucherNo";
            General.strAuthorizeTableName = General.strTableName[0];
            PopulateCombo();
            AddColumninDetailGrid();
            cls.EnableDisble(PnlMain, false);
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            dtbMaster.CellValueChanged += new DataGridViewCellEventHandler(dtbMaster_CellValueChanged);
            dtbMaster.CellContentClick += new DataGridViewCellEventHandler(dtbMaster_CellContentClick);

            dtbDetail.SelectionChanged += new EventHandler(dtbDetail_SelectionChanged);
            dtbDetail.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dtbDetail_EditingControlShowing);
            dtbDetail.CellBeginEdit += new DataGridViewCellCancelEventHandler(dtbDetail_CellBeginEdit);
            dtbDetail.CellEndEdit += new DataGridViewCellEventHandler(dtbDetail_CellEndEdit);
            dtbDetail.KeyDown += new KeyEventHandler(dtbDetail_KeyDown);
            numEXRAtes.Value = Convert.ToDecimal(dsPopulateCombo.Tables[(int)DataPop.ExRate].Rows[0]["Description"].ToString());
            Mainfrm = (MainForm)this.ParentForm;
            dtDate.Value = General.dtSystemDate;
           

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

        private void frmBranchDeal_Activated(object sender, EventArgs e)
        {
            Mainfrm.EnableDisbale(strButtonState, true, "S");
  
        }  
    }
}
