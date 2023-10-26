using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExchangeCompanySoftware.Reports.Tickets;

namespace ExchangeCompanySoftware
{
    public partial class frmSales : BaseForm,IToolBar
    {
        enum DataPop { Account, Item, SalesMen };
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataSet dsPopulateCombo;
        DataTable dtSearchMaster;
        DataTable dtSearchDetail;
        string strAccountNo = "";
        public string strButtonState = null;
        string strTransType = "SAL";
        public string strError = "";
        string strCondition;
        string strValue;
        double dblQty = 0;
        double dbllastvalue;
        MainForm Mainfrm;

        AutoCompleteStringCollection acShortName = new AutoCompleteStringCollection();
        AutoCompleteStringCollection acItemName = new AutoCompleteStringCollection();
      
        public frmSales()
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

            DataGridViewTextBoxColumn clmnBarCode = new DataGridViewTextBoxColumn();
            clmnBarCode.Name = "BarCode";
            clmnBarCode.HeaderText = "BarCode";
            clmnBarCode.Width = 70;
            clmnBarCode.Visible = false;

            dtbDetail.Columns.Add(clmnBarCode);



            DataGridViewTextBoxColumn clmnSymbol = new DataGridViewTextBoxColumn();
            clmnSymbol.Name = "Symbol";
            clmnSymbol.HeaderText = "Symbol";
            clmnSymbol.Width = 70;
            clmnSymbol.Visible = false;

            dtbDetail.Columns.Add(clmnSymbol);

            DataGridViewTextBoxColumn cboTitle = new DataGridViewTextBoxColumn();
            cboTitle.Name = "ItemName";
            cboTitle.HeaderText = "Item Name";
            cboTitle.Width = 200;
            //cboTitle.ReadOnly = true;
            dtbDetail.Columns.Add(cboTitle);

            DataGridViewTextBoxColumn clmnitCode = new DataGridViewTextBoxColumn();
            clmnitCode.Name = "ItemCode";
            clmnitCode.HeaderText = "Code";
            clmnitCode.Width = 0;
            clmnitCode.Visible = false;
            dtbDetail.Columns.Add(clmnitCode);


            DataGridViewTextBoxColumn clmnPerPcsRAte = new DataGridViewTextBoxColumn();
            clmnPerPcsRAte.Name = "Discount";
            clmnPerPcsRAte.HeaderText = "Discount";
            clmnPerPcsRAte.DefaultCellStyle.Format = "N4";
            clmnPerPcsRAte.ValueType = typeof(System.Double);
            clmnPerPcsRAte.DefaultCellStyle.NullValue = "0";
            clmnPerPcsRAte.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnPerPcsRAte.Width = 120;
            dtbDetail.Columns.Add(clmnPerPcsRAte);

            DataGridViewTextBoxColumn clmnRefNo = new DataGridViewTextBoxColumn();
            clmnRefNo.Name = "RefNo";
            clmnRefNo.HeaderText = "Ref.#.";
            clmnRefNo.Width = 70;
            clmnRefNo.ReadOnly = true;
            dtbDetail.Columns.Add(clmnRefNo);

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
            clmnRate.DefaultCellStyle.Format = "N6";
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

         

            DataGridViewTextBoxColumn clmnSaleRateCRP = new DataGridViewTextBoxColumn();
            clmnSaleRateCRP.Name = "SaleRateCRP";
            clmnSaleRateCRP.HeaderText = "CRP Rate";
            clmnSaleRateCRP.DefaultCellStyle.Format = "N4";
            clmnSaleRateCRP.ValueType = typeof(System.Double);
            clmnSaleRateCRP.DefaultCellStyle.NullValue = "0";
            clmnSaleRateCRP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnSaleRateCRP.Width = 120;
            clmnSaleRateCRP.ReadOnly = true;
            dtbDetail.Columns.Add(clmnSaleRateCRP);


            DataGridViewTextBoxColumn clmnVNo = new DataGridViewTextBoxColumn();
            clmnVNo.Name = "VoucherNo";
            clmnVNo.HeaderText = "VoucherNo";
            clmnVNo.Width = 0;
            clmnVNo.Visible = false;
            dtbDetail.Columns.Add(clmnVNo);


            DataGridViewTextBoxColumn clmnSItemDiscount = new DataGridViewTextBoxColumn();
            clmnSItemDiscount.Name = "ItemDiscount";
            clmnSItemDiscount.HeaderText = "ItemDiscount";
            clmnSItemDiscount.Width = 0;
            clmnSItemDiscount.Visible = false;
            dtbDetail.Columns.Add(clmnSItemDiscount);


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

            DataGridViewTextBoxColumn clmnStockV = new DataGridViewTextBoxColumn();
            clmnStockV.Name = "StockV";
            clmnStockV.HeaderText = "StockV";
            clmnStockV.Width = 0;
            clmnStockV.Visible = false;
            dtbDetail.Columns.Add(clmnStockV);

        }
        
        private void CalculateTaxDiscount()
        {
            dotxtTaxamount.Value = 0;
            if (dotxtDiscount.Value <= 100)
            {
                dotxtDiscountAmount.Value = dotxtGrossAmount.Value * (dotxtDiscount.Value / 100);
                dotxtNetAmount.Value = dotxtGrossAmount.Value - dotxtDiscountAmount.Value;
            }
            if (dotxtTax.Value <= 100)
            {
                dotxtTaxamount.Value = (dotxtGrossAmount.Value - dotxtDiscount.Value) * (dotxtTax.Value / 100);
                dotxtNetAmount.Value = (dotxtGrossAmount.Value - dotxtDiscount.Value) - dotxtTaxamount.Value;
            }
        }

        private void CalculateCharges()
        {
            CalculateAmount();
            donumTotalCharges.Value =  donumTransportCharges.Value + donumOtherCharges.Value;
            
        }
        
        private void CalculateAmount()
        {
            dotxtGrossAmount.Value = 0;
           

            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (Convert.ToDecimal(dotxtGrossAmount.Value) == Convert.ToDecimal("0"))
                {

                    if (dtbDetail.Rows[i].Cells["Amount"].Value == null)
                    {
                        dtbDetail.Rows[i].Cells["Amount"].Value = "0";
                    }
                    dotxtGrossAmount.Value = Convert.ToDecimal(dtbDetail.Rows[i].Cells["Amount"].Value.ToString());

                }
                else
                {

                    if (dtbDetail.Rows[i].Cells["Amount"].Value == null)
                    {
                        dtbDetail.Rows[i].Cells["Amount"].Value = "0";
                    }
                    dotxtGrossAmount.Value =
                        Convert.ToDecimal(dotxtGrossAmount.Value) +
                        Convert.ToDecimal(dtbDetail.Rows[i].Cells["Amount"].Value);


                }
               
            }

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
                        dtbDetail.Rows[i].Cells["BranchCode"].Value = dr[i]["BranchCode"].ToString();
                        dtbDetail.Rows[i].Cells["BarCode"].Value = dr[i]["BarCode"].ToString();

                        dtbDetail.Rows[i].Cells["SaleRateCRP"].Value = dr[i]["SaleRateCRP"].ToString();
                        if (dr[i]["RefNo"].ToString() != "")
	                    {
                            dtbDetail.Columns["RefNo"].Visible = true;
                            dtbDetail.Rows[i].Cells["RefNo"].Value = dr[i]["RefNo"].ToString();
	                    }
                        else
                        {
                            dtbDetail.Columns["RefNo"].Visible = false;
                        }
                        dtbDetail.Rows[i].Cells["ItemDiscount"].Value = dr[i]["ItemDiscount"].ToString();
                        dtbDetail.Rows[i].Cells["Discount"].Value = dr[i]["Discount"].ToString();

                       
                    }
                    CalculateAmount();
                    CalculateCharges();
                    CalculateTaxDiscount();
                }
            }
        }

        void dtbMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        void dtbDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (General.strButtonState == "ADD" || strButtonState == "ADD" || General.strButtonState == "SAVE" || General.strButtonState == "EDIT")
            {
                
                if (e.KeyValue == 13)
                {
                    SendKeys.Send("{Right}");
                    if (dtbDetail.Columns.Count == dtbDetail.CurrentCell.ColumnIndex + 8)
                    {
                        if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["SNo"].Value != null)
                        {
                            dtbDetail.Rows.Add();
                            SendKeys.Send("{Home}");
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Quantity"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Rate"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Amount"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Discount"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["SaleRateCRP"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["ItemDiscount"].Value = 0;
                        }
                    }
                    if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Symbol"].Value == null || dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Symbol"].Value.ToString() == "")
                    {
                        if (strButtonState != "SAVE")
                        {
                            DialogResult dr =
                            MessageBox.Show("Are you sure to Save this Record", "Confirmation Save",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (Convert.ToString(dr) == "Yes")
                            {
                                SAVE();
                            }
                        }
                        else
                        {
                            DialogResult dr =
                            MessageBox.Show("Are you sure to Add another Record", "Confirmation Save",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (Convert.ToString(dr) == "Yes")
                            {
                                ADD();
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
                        frmListSearch childForm = new frmListSearch(dtb, "S", null);
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
                if (dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value != null || dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value != null)
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
                    dtbDetail.Rows[e.RowIndex].Cells["PerPcsRAte"].Value = "0";
                    dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value = "0";
                }

                if (dtbDetail.Columns["Quantity"].Index == e.ColumnIndex)
                {
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == true)
                    {
                        if (dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString() != "")
                        {
                            if (Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) > Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Stock"].Value))
                            {
                                MessageBox.Show("Stock is not in Hand", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = "0";
                                dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = "0";
                            }
                            else
                            {
                                dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = Math.Round(Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value), 0);
                                donumStock.Value = Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Stock"].Value) - Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value);
                            }
                        }
                        else
                        {
                            dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = "0";
                            donumStock.Value = Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Stock"].Value);
                        }
                        //if (Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) )
                        //{
                            
                        //}
                    }
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == false)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                    }
                    if (dtbDetail.Columns["Quantity"].Index == e.ColumnIndex)
                    {
                        if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == true)
                        {
                        }

                    }
                    CalculateAmount();
                }

                if (dtbDetail.Columns["Discount"].Index == e.ColumnIndex)
                {
                    if (dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value)  < 100)
                        {
                            if (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value) > Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["ItemDiscount"].Value))
                            {
                                MessageBox.Show("Discount Limit is cross add Company Refrence Bill #", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                string str = Microsoft.VisualBasic.Interaction.InputBox("Bill Ref #.", "Title", "", 0, 0);
                                if (str == "")
                                {
                                    dtbDetail.Columns["RefNo"].Visible = false;
                                    dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value = "0";


                                }
                                else
                                {
                                    dtbDetail.Columns["RefNo"].Visible = true;
                                    dtbDetail.Rows[e.RowIndex].Cells["RefNo"].Value = str;
                                    if (dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value.ToString() != "")
                                    {
                                        dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value) - (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value)) / 100;

                                    }
                                    else
                                    {
                                        dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value);
                                    }
                                }
                            }
                            else
                            {

                                if (dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value.ToString() != "")
                                {
                                    dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value) - (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value)) / 100;
                                    dtbDetail.Columns["RefNo"].Visible = false;
                                    dtbDetail.Rows[e.RowIndex].Cells["RefNo"].Value = "";
                                }
                                else
                                {
                                    dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value);
                                }
                                if (dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value != "")
                                {
                                    dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value) - (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value)) / 100;

                                }
                                else
                                {
                                    dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value);
                                }
                            }
                            dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = Math.Round(Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value), 0);
                        }
                        else
                        {
                            MessageBox.Show("Discount is not Equal or Greater then 100%", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dtbDetail.Rows[e.RowIndex].Cells["RefNo"].Value = "";
                            dtbDetail.Rows[e.RowIndex].Cells["Discount"].Value = "0";
                               
                        }
                      
                    }
                    else
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["SaleRateCRP"].Value);
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = Math.Round(Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value), 0);
                        dtbDetail.Columns["RefNo"].Visible = false;
                        dtbDetail.Rows[e.RowIndex].Cells["RefNo"].Value = "";

                    }
                }

              

                if (dtbDetail.Columns["Rate"].Index == e.ColumnIndex)
                {
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == false || dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString() == "")
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                    }
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == true)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = Math.Round(Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value), 0);
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
                }


            }
            catch (Exception EX)
            {

            }
        }
        
        void dtbDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataTable dtb = new DataTable();
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                if (e.Control is DataGridViewTextBoxEditingControl)
                {
                    DataGridViewTextBoxEditingControl te;
                    if (dtbDetail.Columns["Symbol"].Index == dtbDetail.CurrentCell.ColumnIndex)
                    {
                        te = new DataGridViewTextBoxEditingControl();
                        te.Clear();
                        te = (DataGridViewTextBoxEditingControl)e.Control;
                        te.AutoCompleteMode = AutoCompleteMode.Suggest;
                        te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        te.AutoCompleteCustomSource = acShortName;
                    }
                    
                    if (dtbDetail.Columns["ItemName"].Index == dtbDetail.CurrentCell.ColumnIndex)
                    {
                        te = new DataGridViewTextBoxEditingControl();
                        te.Clear();
                        te = (DataGridViewTextBoxEditingControl)e.Control;
                        te.AutoCompleteMode = AutoCompleteMode.Suggest;
                        te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        te.AutoCompleteCustomSource = acItemName;
                    }
                }
            }
        }
        
        void dtbDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //  dbllastvalue = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
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
   
            if (dtbDetail.Columns["Symbol"].Index == intColumn)
            {
                dtb = dsPopulateCombo.Tables[(int)DataPop.Item];

                DataRow[] dRow = dtb.Select("ShortName = '" + dtbDetail.Rows[intRow].Cells["Symbol"].Value + "'");
                if (dRow.Count() > 0)
                {
                    dtbDetail.Rows[intRow].Cells["BarCode"].Value = dRow[0]["BarCode"].ToString();
                    dtbDetail.Rows[intRow].Cells["ItemName"].Value = dRow[0]["ItemName"].ToString();
                    dtbDetail.Rows[intRow].Cells["ItemCode"].Value = dRow[0]["ItemCode"].ToString();
                    dtbDetail.Rows[intRow].Cells["ItemDiscount"].Value = dRow[0]["Favour"].ToString();
                    dtbDetail.Rows[intRow].Cells["Rate"].Value = dRow[0]["PerPcsRAte"].ToString();
                    dtbDetail.Rows[intRow].Cells["SaleRateCRP"].Value = dRow[0]["PerPcsRAte"].ToString();

                    DataTable dtbstock = cls.GetStockds(General.dtSystemDate, dtbDetail.Rows[intRow].Cells["ItemCode"].Value.ToString()).Tables[0];

                    if (dtbstock.Rows.Count > 0)
                    {
                        donumStock.Value = Convert.ToDecimal(dtbstock.Rows[0]["FCAmount"].ToString());
                        donumAvgRate.Value = Convert.ToDecimal(dtbstock.Rows[0]["AvgRate"].ToString());
                        dtbDetail.Rows[intRow].Cells["Stock"].Value = dtbstock.Rows[0]["FCAmount"].ToString();
                        if (dtbDetail.Rows.Count > 1)
                        {
                            for (int i = 0; i < dtbDetail.Rows.Count; i++)
                            {
                                if (dtbDetail.Rows[intRow].Cells["Symbol"].Value.ToString() == dtbDetail.Rows[i].Cells["Symbol"].Value.ToString())
                                {
                                    dtbDetail.Rows[intRow].Cells["Stock"].Value = Convert.ToDecimal(dtbDetail.Rows[intRow].Cells["Stock"].Value) - Convert.ToDecimal(dtbDetail.Rows[i].Cells["Quantity"].Value);
                                    donumStock.Value = Convert.ToDecimal(dtbDetail.Rows[intRow].Cells["Stock"].Value);
                                }
                            }
                        }
                        //if (dtbstock.Rows.Count > 1)
                        //{
                        //    dtbDetail.Rows[intRow].Cells["Stock"].Value = dtbstock.Rows[1]["FCAmount"].ToString();
                        //    donumStock.Value = Convert.ToDecimal(dtbstock.Rows[1]["FCAmount"].ToString());
                        //}
                    }
                    else
                    {
                        donumStock.Value = 0;
                        donumAvgRate.Value = 0;
                    }
                }
                else
                {
                    dtbDetail.Rows[intRow].Cells["ItemName"].Value = "";
                    dtbDetail.Rows[intRow].Cells["ItemCode"].Value = "";
                    dtbDetail.Rows[intRow].Cells["Symbol"].Value = "";
                    dtbDetail.Rows[intRow].Cells["Rate"].Value = "0";
                    dtbDetail.Rows[intRow].Cells["SaleRateCRP"].Value = "0";
                    dtbDetail.Rows[intRow].Cells["PerPcsRAte"].Value = "0";
                      dtbDetail.Rows[intRow].Cells["Stock"].Value = "0";
                    donumStock.Value = 0;
                    donumAvgRate.Value = 0;
                }
            }


            if (dtbDetail.Columns["ItemName"].Index == intColumn)
            {
                dtb = dsPopulateCombo.Tables[(int)DataPop.Item];

                if (dtbDetail.Rows[intRow].Cells["ItemName"].Value.ToString().Length >= 3)
                {
                    DataRow[] dr = dtb.Select("ItemName Like '" + dtbDetail.Rows[intRow].Cells["ItemName"].Value + "%'", "ItemName");
                    if (dr.Count() > 0)
                    {
                        if (dr.GetUpperBound(0) >= 0)
                        {
                            dtb.DefaultView.Sort = "ItemName";
                            dtbDetail.Rows[intRow].Cells["BarCode"].Value = dr[0]["BarCode"].ToString();
                            dtbDetail.Rows[intRow].Cells["ItemName"].Value = dr[0]["ItemName"].ToString();
                            dtbDetail.Rows[intRow].Cells["ItemCode"].Value = dr[0]["ItemCode"].ToString();
                            dtbDetail.Rows[intRow].Cells["Symbol"].Value = dr[0]["ShortName"].ToString();
                            dtbDetail.Rows[intRow].Cells["ItemDiscount"].Value = dr[0]["Favour"].ToString();

                            dtbDetail.Rows[intRow].Cells["Rate"].Value = dr[0]["PerPcsRAte"].ToString();

                            dtbDetail.Rows[intRow].Cells["SaleRateCRP"].Value = dr[0]["PerPcsRAte"].ToString();
                          
                            DataTable dtbstock = cls.GetStockds(General.dtSystemDate, dtbDetail.Rows[intRow].Cells["ItemCode"].Value.ToString()).Tables[0];

                            if (dtbstock.Rows.Count > 0)
                            {
                                donumStock.Value = Convert.ToDecimal(dtbstock.Rows[0]["FCAmount"].ToString());
                                donumAvgRate.Value = Convert.ToDecimal(dtbstock.Rows[0]["AvgRate"].ToString());
                                dtbDetail.Rows[intRow].Cells["Stock"].Value = dtbstock.Rows[0]["FCAmount"].ToString();
                                if (dtbDetail.Rows.Count > 1)
                                {
                                    for (int i = 0; i < dtbDetail.Rows.Count; i++)
                                    {
                                        if (dtbDetail.Rows[intRow].Cells["Symbol"].Value.ToString() == dtbDetail.Rows[i].Cells["Symbol"].Value.ToString())
                                        {
                                            dtbDetail.Rows[intRow].Cells["Stock"].Value = Convert.ToDecimal(dtbDetail.Rows[intRow].Cells["Stock"].Value) - Convert.ToDecimal(dtbDetail.Rows[i].Cells["Quantity"].Value);
                                            donumStock.Value = Convert.ToDecimal(dtbDetail.Rows[intRow].Cells["Stock"].Value);
                                        }
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        dtb.DefaultView.Sort = "";
                        dtbDetail.Rows[intRow].Cells["ItemName"].Value = "";
                        dtbDetail.Rows[intRow].Cells["ItemCode"].Value = "";
                        dtbDetail.Rows[intRow].Cells["Symbol"].Value = "";
                        dtbDetail.Rows[intRow].Cells["Rate"].Value = "0";
                        dtbDetail.Rows[intRow].Cells["Stock"].Value = "0";
                        dtbDetail.Rows[intRow].Cells["SaleRateCRP"].Value = "0";
                        dtbDetail.Rows[intRow].Cells["PerPcsRAte"].Value = "0";
                        donumStock.Value = 0;
                        donumAvgRate.Value = 0;
                    }
                }
            }

        }
        
        private void PopulateCombo()
        {
            cls = new General();

            string strQuery = "Select * from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Status = 'A' and isTransactional = 'True' Order by Title ;Select * from EX_SetupItems Where Locked = 'False' and Status = 'A' and BranchCode = '" + General.strBranchCode + "' Order by ItemName;Select * from EX_SetupSalesMen Where BranchCode = '" + General.strBranchCode + "' and Status = 'A'";
            dsPopulateCombo = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicbopaymentMode, dsPopulateCombo.Tables[(int)DataPop.Account], "Title", "AccountNo");
            cls.PopulateCombo(dicboSalesMen, dsPopulateCombo.Tables[(int)DataPop.SalesMen], "SalesMen", "Code");
            DataTable dtb = new DataTable();
            dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                acShortName.Add(dtb.Rows[i]["ShortName"].ToString());
                acItemName.Add(dtb.Rows[i]["ItemName"].ToString());

            }
        }
        
        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

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

        private void frmSales_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            General.strTableName[1] = "EX_SalesDetail";
            General.strTableName[0] = "EX_SalesMaster";
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
            dtbDetail.Columns["RefNo"].Visible = false;
            Mainfrm = (MainForm)this.ParentForm;
            dtDate.Value = General.dtSystemDate;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            ADD();
            txtBarCode.Focus();
        }

        private void GenerateVoucherNo()
        {
            string strTransNo = string.Format("{0:D5}", Convert.ToInt32(cls.GetTransNo(strTransType)));
            ditxtVoucherNo.Text = strTransType + "-" + strTransNo + "-" + General.strBranchCode;
            //ditxtInvoiceNo.Text = General.dtSystemDate.Year.ToString() + General.dtSystemDate.Month.ToString() + strTransNo;
        }
        
        #region IToolBar Members

        public bool ADD()
        {
            cls = new General();
            cls.ClearALL(PnlMain);
            cls.EnableDisble(PnlMain, true);


            dtbDetail.Rows.Clear();
            if (dtbDetail.Rows.Count == 0)
            {
                dtbDetail.Rows.Add();
            }
            ditxtVoucherNo.Enabled = false;
            strButtonState = "ADD";
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            dicbopaymentMode.SelectedValue = cls.strControlAccount("Cashinhand");
            dtbDetail.Columns["RefNo"].Visible = false;
            dotxtGrossAmount.Enabled = false;
            dotxtDiscountAmount.Enabled = false;
            dotxtTaxamount.Enabled = false;
            dotxtNetAmount.Enabled = false;
            donumTotalCharges.Enabled = false;
            dotxtCustomer.Focus();
            return true;
        }

        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();

            DialogResult dr =
  MessageBox.Show("are you sure to Save That Record", "Confirmation Save",
  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Convert.ToString(dr) == "Yes")
            {

                if (strButtonState == "ADD")
                {
                    GenerateVoucherNo();

                }
                if (strButtonState == "ADD" || strButtonState == "EDIT")
                {

                    if (ValidatingControls() == true)
                    {

                        strTransType = "SAL";

                        for (int i = 0; i < dtbDetail.Rows.Count; i++)
                        {
                            dtbDetail.Rows[i].Cells["VoucherNo"].Value = ditxtVoucherNo.Text;
                            dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                            dtbDetail.Rows[i].Cells["Sno"].Value = i;
                        }
                        strCondition = "Where VoucherNo = '" + ditxtVoucherNo.Text + "'";
                        ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "Posted=False;Process=Green;AccountNo=" + cls.strControlAccount("PurchaseSale") + ";BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + "");
                        dtbMaster.DataSource = ds.Tables[0];
                        cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
                        cls.EnableDisble(PnlMain, false);
                        strButtonState = "SAVE";
                        PRINT();
                        ADD();
                    }
                    else
                    {
                        MessageBox.Show(strError, "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }

            }
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            return true;
        }

        public bool EDIT()
        {
            ditxtVoucherNo.Enabled = false;
            ///ditxtInvoiceNo.Enabled = false;
            ///
            
            dotxtGrossAmount.Enabled = false;
            dotxtDiscountAmount.Enabled = false;
            dotxtTaxamount.Enabled = false;
            dotxtNetAmount.Enabled = false;
            donumTotalCharges.Enabled = false;
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


            strQuery = "Select * from EX_SalesMaster a " + General.strStatusCondition + "  and BranchCode = '" + General.strBranchCode + "'";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate + "'";
            }
            strQuery = strQuery + " ;Select a.RecNo,SNO,c.ItemCode,ItemName,BarCode,PurchaseRate,ShortName,Quantity,Rate,Amount,c.Discount,ItemDiscount,c.RefNo,c.SaleRateCRP,a.VoucherNo,a.BranchCode from EX_SalesDetail c Inner Join EX_SalesMaster a on a.VoucherNo = c.VoucherNo and a.RecNo = c.RecNo Inner Join EX_SetupItems b on c.ItemCode = b.ItemCode and b.Status = 'A' and c.BranchCode = b.BranchCode";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate + "'";
            }
            ds = objGetData.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtSearchDetail = ds.Tables[1];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
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
            //if (dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["Status"].Value.ToString() == "A")
            //{
            DialogResult dr =
     MessageBox.Show("are you sure to Print That Record", "Confirmation Print",
     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Convert.ToString(dr) == "Yes")
            {

                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                DataTable dtb = new DataTable();
                DataSet ds = new DataSet();
                string strQuery = " Select a.AccountNo,Title as CustomerName,a.TransDate,a.VoucherNo,e.SalesMen as Remarks,'Sale' as Transactiontype,'" + General.strCompanyName + "' as CompanyName,'" + General.strPhone + "' as PH ,'"+ General.strBranchName +"' as BranchName, ";
                strQuery = strQuery + " ItemName,case When IteminPackets != 1 then cast((b.Quantity)/IteminPackets as int) else 0 end as Pack,case When IteminPackets != 1 then ((((b.Quantity)/IteminPackets) - cast((b.Quantity)/IteminPackets as int))* IteminPackets) else b.Quantity end as Quantity,b.Quantity as TotalQty,b.Discount,Rate,Amount,'" + General.strCompanyName + "' as CompanyName ";
                strQuery = strQuery + " from EX_SalesMaster a  ";
                strQuery = strQuery + " inner Join EX_SalesDetail b on a.VoucherNo = b.VoucherNo and a.BranchCode = b.BranchCode  ";
                strQuery = strQuery + " and a.RecNo = b.RecNo  ";
                strQuery = strQuery + " Inner Join EX_SetupAccount d on a.PaymentMode = d.AccountNo and a.BranchCode = d.BranchCode and d.Status = 'A' ";
                strQuery = strQuery + " Inner Join EX_SetupItems c on c.ItemCode = b.Itemcode and c.Status = 'A' and a.BranchCode = c.BranchCode";
                strQuery = strQuery + " Inner Join EX_SetupSalesMen e on e.Code = a.SalesMen and e.Status = 'A' ";
                strQuery = strQuery + " Where a.VoucherNo = '" + ditxtVoucherNo.Text + "' and a.Status in ('A','U')";

                string strQuery2 = " Select a.AccountNo,Title as CustomerName,a.TransDate,a.VoucherNo,e.SalesMen as Remarks,'Delivery Order' as Transactiontype,'" + General.strCompanyName + "' as CompanyName,'" + General.strPhone + "' as PH  ,'" + General.strBranchName + "' as BranchName, ";
                strQuery2 = strQuery2 + " ItemName,case When IteminPackets != 1 then cast((b.Quantity)/IteminPackets as int) else 0 end as Pack, case When IteminPackets != 1 then ((((b.Quantity)/IteminPackets) - cast((b.Quantity)/IteminPackets as int))* IteminPackets) else b.Quantity end as Quantity,b.Quantity as TotalQty,b.Discount,Rate,Amount,'" + General.strCompanyName + "' as CompanyName ";
                strQuery2 = strQuery2 + " from EX_SalesMaster a  ";
                strQuery2 = strQuery2 + " inner Join EX_SalesDetail b on a.VoucherNo = b.VoucherNo and a.BranchCode = b.BranchCode  ";
                strQuery2 = strQuery2 + " and a.RecNo = b.RecNo  ";
                strQuery2 = strQuery2 + " Inner Join EX_SetupAccount d on a.PaymentMode = d.AccountNo and a.BranchCode = d.BranchCode and d.Status = 'A' ";
                strQuery2 = strQuery2 + " Inner Join EX_SetupItems c on c.ItemCode = b.Itemcode and c.Status = 'A' and a.BranchCode = c.BranchCode";
                strQuery2 = strQuery2 + " Inner Join EX_SetupSalesMen e on e.Code = a.SalesMen and e.Status = 'A' ";
                strQuery2 = strQuery2 + " Where a.VoucherNo = '" + ditxtVoucherNo.Text + "' and a.Status in ('A','U')";


                ds = objGetData.GetDataSet(strQuery+";"+strQuery2);
                dtb = ds.Tables[0];

                rptPrePrinted devrep = new rptPrePrinted();
                devrep.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
                devrep.DataSource = dtb;
               

                devrep.RequestParameters = false;
                devrep.CreateDocument();
                devrep.ShowPreview();

                 devrep = new rptPrePrinted();
                devrep.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
                devrep.DataSource = ds.Tables[1];


                devrep.RequestParameters = false;
                devrep.CreateDocument();
                devrep.ShowPreview();


                
                //devrep.ShowPreview();
            }
            //}
            //else
            //{
            //    MessageBox.Show("Authorize the Record first", "Error",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bolState = false;
            }
            else
            {
                bolState = true;
            }
            if (dtbDetail.Rows[0].Cells["ItemCode"].Value == null)
            {
                strError = strError + "\n" + "Item is not Selected on First Line";
                bolState = false;
            }

            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                //dtbDetail.Rows[i].Cells["StockV"].Value = "0";
                //dtbDetail.Rows[i].Cells["Stock"].Value = "0";

                if (dtbDetail.Rows[i].Cells["ItemCode"].Value != null)
                {
                    if (String.IsNullOrEmpty(dtbDetail.Rows[i].Cells["ItemCode"].Value.ToString()) == false)
                    {
                        //if (dicboTransaction.SelectedValue.ToString() == "2")
                        //{
                        //    if (Convert.ToDouble(dtbDetail.Rows[i].Cells["Quantity"].Value.ToString()) > Convert.ToDouble(dtbDetail.Rows[i].Cells["StockV"].Value.ToString()))
                        //    {
                        //        strError = strError + "\n" + "Quantity is not Available of " + dtbDetail.Rows[i].Cells["Symbol"].Value.ToString() + "";
                        //    }
                        //}
                        if (dtbDetail.Rows[i].Cells["Amount"].Value != null)
                        {
                            if (dtbDetail.Rows[i].Cells["Amount"].Value.ToString() == "0")
                            {
                                strError = strError + "\n" + "Amount Should not be 0 on line no " + i + "";
                                bolState = false;
                            }
                        }
                        else
                        {
                            strError = strError + "\n" + "Amount Should not be 0 on line no " + i + "";
                            bolState = false;
                        }

                    }
                }
            }
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (dtbDetail.Rows[i].Cells["ItemCode"].Value != null)
                {
                    if (String.IsNullOrEmpty(dtbDetail.Rows[i].Cells["ItemCode"].Value.ToString()))
                    {
                        strError = strError + "\n" + "Item Should not be Empty on line no " + i + "";
                        bolState = false;
                    }
                }
            }
            cls.StrMessage = strError;
            if (strError != "")
            {
                bolState = false;
            }
            else
            {
                bolState = true;
            }
            return bolState;
        }

        private void frmSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (strButtonState != "ADD" || strButtonState != "Edit")
            {
                if (e.KeyChar == (char)19)
                {
                    SAVE();
                }
                if (e.KeyChar == '')
                {
                    ADD();
                   dotxtCustomer.Focus();
                }
            }

        }

        private void frmSales_Activated(object sender, EventArgs e)
        {
            Mainfrm.EnableDisbale(strButtonState, true, "S");

        }

        private void dtbDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1) || (e.ColumnIndex == -1))
            {
                Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    e.CellBounds, Color.Orange, Color.NavajoWhite,
                    System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
                gradientBrush.Dispose();

                // paint rest of cell
                e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
                DataGridViewPaintParts.ContentForeground);
                e.Handled = true;
            }
        }

        private void dotxtDiscount_Validated(object sender, EventArgs e)
        {
            CalculateTaxDiscount();
        }

        private void dotxtTax_Validated(object sender, EventArgs e)
        {
            CalculateTaxDiscount();
        }

        private void donumTransportCharges_Validated(object sender, EventArgs e)
        {
            CalculateCharges();
        }

        private void donumOtherCharges_Validated(object sender, EventArgs e)
        {
            CalculateCharges();
        }

        private void dtbDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dotxtRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void cstTextBox1_Validated(object sender, EventArgs e)
        {
            if (txtBarCode.Text != "" && strButtonState == "ADD")
            {

                bool bol = false;
                DataTable dtb = new DataTable();
                dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
                int intRow = 0;
                if (dtbDetail.Rows.Count > 1)
                {
                    intRow = dtbDetail.Rows.Count - 1;
                }
                if (txtBarCode.Text != null)
                {
                    for (int i = 0; i < dtbDetail.Rows.Count; i++)
                    {
                        if (dtbDetail.Rows[i].Cells["BarCode"].Value != null)
                        {
                            if (txtBarCode.Text == dtbDetail.Rows[i].Cells["BarCode"].Value.ToString())
                            {
                                dtbDetail.Rows[i].Cells["Quantity"].Value = Convert.ToDouble(dtbDetail.Rows[i].Cells["Quantity"].Value) + 1;
                                dtbDetail.Rows[i].Cells["Amount"].Value = Math.Round(Convert.ToDouble(dtbDetail.Rows[i].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[i].Cells["Rate"].Value), 0);
                                if (dtbDetail.Rows[intRow].Cells["Stock"].Value != null)
                                {
                                    donumStock.Value = Convert.ToDecimal(dtbDetail.Rows[i].Cells["Stock"].Value) - Convert.ToDecimal(dtbDetail.Rows[i].Cells["Quantity"].Value);
                                }
                                txtBarCode.Focus();
                                txtBarCode.Text = "";
                                bol = true;
                                break;
                            }

                            else
                            {
                                bol = false;
                            }
                        }
                    }
                    if (bol == false)
                    {
                        string strBarCode = txtBarCode.Text;
                        DataRow[] dr = dtb.Select("BarCode = '" + strBarCode + "'");
                        if (dr.Count() > 0)
                        {
                            if (dr.GetUpperBound(0) >= 0)
                            {
                                dtb.DefaultView.Sort = "BarCode";
                                dtbDetail.Rows[intRow].Cells["BarCode"].Value = dr[0]["BarCode"].ToString();
                                dtbDetail.Rows[intRow].Cells["ItemName"].Value = dr[0]["ItemName"].ToString();
                                dtbDetail.Rows[intRow].Cells["ItemCode"].Value = dr[0]["ItemCode"].ToString();
                                dtbDetail.Rows[intRow].Cells["Symbol"].Value = dr[0]["ShortName"].ToString();
                                dtbDetail.Rows[intRow].Cells["ItemDiscount"].Value = dr[0]["Favour"].ToString();
                                dtbDetail.Rows[intRow].Cells["Quantity"].Value = "1";
                                dtbDetail.Rows[intRow].Cells["Rate"].Value = dr[0]["PerPcsRAte"].ToString();
                                dtbDetail.Rows[intRow].Cells["Amount"].Value = Math.Round(Convert.ToDouble(dtbDetail.Rows[intRow].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[intRow].Cells["Rate"].Value), 0);
                                if (dtbDetail.Rows[intRow].Cells["Stock"].Value != null)
                                {
                                    donumStock.Value = Convert.ToDecimal(dtbDetail.Rows[intRow].Cells["Stock"].Value) - Convert.ToDecimal(dtbDetail.Rows[intRow].Cells["Quantity"].Value);
                                }
                                dtbDetail.Rows[intRow].Cells["SaleRateCRP"].Value = dr[0]["SaleRateCRP"].ToString();
                                dtbDetail.Rows.Add();
                                txtBarCode.Focus();
                                txtBarCode.Text = "";
                                dtbDetail.Rows[intRow].Cells["BarCode"].Selected = false;
                                dtbDetail.Rows[intRow + 1].Cells["BarCode"].Selected = true;
                            }
                        }

                        else
                        {
                            MessageBox.Show("Invalid BarCode", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);

                            dtb.DefaultView.Sort = "";
                            dtbDetail.Rows[intRow].Cells["BarCode"].Value = "";
                            dtbDetail.Rows[intRow].Cells["ItemName"].Value = "";
                            dtbDetail.Rows[intRow].Cells["ItemCode"].Value = "";
                            dtbDetail.Rows[intRow].Cells["Symbol"].Value = "";
                            dtbDetail.Rows[intRow].Cells["Rate"].Value = "0";
                            dtbDetail.Rows[intRow].Cells["SaleRateCRP"].Value = "0";
                            donumStock.Value = 0;
                            donumAvgRate.Value = 0;
                            txtBarCode.Text = "";
                            txtBarCode.Focus();

                        }
                        CalculateAmount();
                    }
                }
            }
        }

        private void frmSales_Shown(object sender, EventArgs e)
        {

        }
        
    }

}
