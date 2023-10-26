﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExchangeCompanySoftware.Custom_Controls;
using System.Transactions;
using ExchangeCompanySoftware.Reports.Tickets;

namespace ExchangeCompanySoftware
{

    public partial class frmSalesReturnOLD : BaseForm,IToolBar 
    {
        enum DataPop {Trans,CustName,Account,Item,ExRate,MainTable};
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataSet dsPopulateCombo;
        DataTable dtSearchMaster;
        DataTable dtSearchDetail;
        string strAccountNo = "";
        public string strButtonState = null;
        string strTransType = "PUR";
        public string strError = "";
        string strCondition;
        string strValue;
        double dblQty = 0;
        double dbllastvalue;
        MainForm Mainfrm;
           
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

        public frmSalesReturnOLD()
        {
            InitializeComponent();
        }

        #region Comment
        //private void AddColumninDetailGrid()
        //{

        //    DataGridViewTextBoxColumn clmnSno = new DataGridViewTextBoxColumn();
        //    clmnSno.Name = "Sno";
        //    clmnSno.HeaderText = "Sno";
        //    clmnSno.Width = 40;
        //    clmnSno.ReadOnly = true;
        //    dtbDetail.Columns.Add(clmnSno);
            
        //    DataGridViewTextBoxColumn clmnSymbol = new DataGridViewTextBoxColumn();
        //    clmnSymbol.Name = "Symbol";
        //    clmnSymbol.HeaderText = "Symbol";
        //    clmnSymbol.Width = 70;
        //    dtbDetail.Columns.Add(clmnSymbol);



        //    DataGridViewTextBoxColumn cboTitle = new DataGridViewTextBoxColumn();
        //    cboTitle.Name = "ItemName";
        //    cboTitle.HeaderText = "Name of Currency";
        //    cboTitle.Width = 200;
        //    dtbDetail.Columns.Add(cboTitle);

        //    DataGridViewTextBoxColumn clmnitCode = new DataGridViewTextBoxColumn();
        //    clmnitCode.Name = "ItemCode";
        //    clmnitCode.HeaderText = "Code";
        //    clmnitCode.Width = 0;
        //    clmnitCode.Visible = false;
        //    dtbDetail.Columns.Add(clmnitCode);



            
        //    DataGridViewTextBoxColumn clmnQty = new DataGridViewTextBoxColumn();
        //    clmnQty.Name = "Quantity";
        //    clmnQty.HeaderText = "Quantity";
        //    clmnQty.DefaultCellStyle.Format = "N4";
        //    clmnQty.ValueType = typeof(System.Double);
        //    clmnQty.DefaultCellStyle.NullValue = "0";
        //    clmnQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    clmnQty.Width = 70;
        //    dtbDetail.Columns.Add(clmnQty);

        //    DataGridViewTextBoxColumn clmnRate = new DataGridViewTextBoxColumn();
        //    clmnRate.Name = "Rate";
        //    clmnRate.HeaderText = "Rate";
        //    clmnRate.DefaultCellStyle.Format = "N4";
        //    clmnRate.ValueType = typeof(System.Double);
        //    clmnRate.DefaultCellStyle.NullValue = "0";
        //    clmnRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    clmnRate.Width = 70;
        //    dtbDetail.Columns.Add(clmnRate);

        //    DataGridViewTextBoxColumn clmnAmount = new DataGridViewTextBoxColumn();
        //    clmnAmount.Name = "Amount";
        //    clmnAmount.HeaderText = "Amount";
        //    clmnAmount.DefaultCellStyle.Format = "N4";
        //    clmnAmount.ValueType = typeof(System.Double);
        //    clmnAmount.DefaultCellStyle.NullValue = "0";
        //    clmnAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    clmnAmount.Width = 100;
        //    clmnAmount.ReadOnly = true;
        //    dtbDetail.Columns.Add(clmnAmount);

        //    DataGridViewTextBoxColumn clmnEQU = new DataGridViewTextBoxColumn();
        //    clmnEQU.Name = "usEquilent";
        //    clmnEQU.HeaderText = "US$ Equilent Amount";
        //    clmnEQU.DefaultCellStyle.Format = "N4";
        //    clmnEQU.ValueType = typeof(System.Double);
        //    clmnEQU.DefaultCellStyle.NullValue = "0";
        //    clmnEQU.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    clmnEQU.Width = 120;
        //    clmnEQU.ReadOnly = true;
          
        //    dtbDetail.Columns.Add(clmnEQU);

        //    DataGridViewTextBoxColumn clmnVNo = new DataGridViewTextBoxColumn();
        //    clmnVNo.Name = "VoucherNo";
        //    clmnVNo.HeaderText = "VoucherNo";
        //    clmnVNo.Width = 0;
        //    clmnVNo.Visible = false;
        //    dtbDetail.Columns.Add(clmnVNo);

        //    DataGridViewTextBoxColumn clmnBranch = new DataGridViewTextBoxColumn();
        //    clmnBranch.Name = "BranchCode";
        //    clmnBranch.HeaderText = "BranchCode";
        //    clmnBranch.Width = 0;
        //    clmnBranch.Visible = false;
        //    dtbDetail.Columns.Add(clmnBranch);

        //}
        //void dtbMaster_SelectionChanged(object sender, EventArgs e)
        //{
        //    DataRow[] dr = new DataRow[0];
        //    if (ditxtVoucherNo.Text != "" && strButtonState != "ADD")
        //    {
        //        dr = dtSearchDetail.Select("VoucherNo = '" + ditxtVoucherNo.Text + "' and RecNo = '" + dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["RecNo"].Value + "' ", "VoucherNo");
        //        dtbDetail.Rows.Clear();
        //        for (int i = 0; i < dr.Count(); i++)
        //        {
        //            dtbDetail.Rows.Add();
        //            dtbDetail.Rows[i].Cells["Sno"].Value = dr[i]["Sno"].ToString();
        //            dtbDetail.Rows[i].Cells["ItemCode"].Value = dr[i]["ItemCode"].ToString();
        //            dtbDetail.Rows[i].Cells["ItemName"].Value = dr[i]["ItemName"].ToString();
        //            dtbDetail.Rows[i].Cells["Symbol"].Value = dr[i]["ShortName"].ToString();
        //            dtbDetail.Rows[i].Cells["Quantity"].Value = dr[i]["Quantity"].ToString();
        //            dtbDetail.Rows[i].Cells["Rate"].Value = dr[i]["Rate"].ToString();
        //            dtbDetail.Rows[i].Cells["Amount"].Value = dr[i]["Amount"].ToString();
        //            dtbDetail.Rows[i].Cells["VoucherNo"].Value = dr[i]["VoucherNo"].ToString();
        //            dtbDetail.Rows[i].Cells["usEquilent"].Value = Convert.ToDecimal(dr[i]["Amount"].ToString()) / numEXRAtes.Value;
        //            dtbDetail.Rows[i].Cells["BranchCode"].Value = dr[i]["BranchCode"].ToString();
        //        }
        //        CalculateAmount();

        //    }
        //}
        //void dtbMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //void dtbDetail_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (General.strButtonState == "ADD" || General.strButtonState == "SAVE" || General.strButtonState == "EDIT")
        //    {

        //        if (e.KeyValue == 40)
        //        {
        //            if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["SNo"].Value != null)
        //            {
        //                for (int i = 0; i < dtbDetail.Rows.Count; i++)
        //                {
        //                    if (dtbDetail.Rows[i].Cells["Sno"].Value == null)
        //                    {
        //                        dtbDetail.Rows.RemoveAt(i);
        //                    }
        //                }
        //                dtbDetail.Rows.Add();
        //            }
        //        }


        //        if (e.KeyValue == 113)
        //        {

        //            if (dtbDetail.Columns[dtbDetail.CurrentCell.ColumnIndex].Name == "Symbol")
        //            {
        //                DataTable dtb = new DataTable();
        //                dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
        //                frmListSearch childForm = new frmListSearch(dtb, "S", null);
        //                childForm.ShowDialog();
        //                if (frmListSearch.strArg != null)
        //                {
        //                    dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["ItemCode"].Value = frmListSearch.strArg[0];
        //                    dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["itemName"].Value = frmListSearch.strArg[1];
        //                    dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["Symbol"].Value = frmListSearch.strArg[2];
        //                }
        //            }
        //        }
        //    }
        //}
        //void dtbDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataTable dtb = new DataTable();
        //    cls = new General();
        //    dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
        //    try
        //    {
        //        cls = new General();
        //        if (dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value != null)
        //        {
        //            dtbDetail.Rows[e.RowIndex].Cells["Sno"].Value = e.RowIndex + 1;
        //        }
        //        else
        //        {
        //            dtbDetail.Rows[e.RowIndex].Cells["Sno"].Value = "";
        //            dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = "0";
        //            dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = "0";
        //            dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = "0";
        //            dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value = "";
        //            dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value = "";
        //            dtbDetail.Rows[e.RowIndex].Cells["VoucherNo"].Value = "";

        //        }


        //        if (dtbDetail.Columns["Quantity"].Index == e.ColumnIndex)
        //        {
        //            if (dicboTransaction.SelectedValue.ToString() == "2")
        //            {
        //                if (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) > Convert.ToDouble(donumStock.Value))
        //                {
        //                    MessageBox.Show("Stock is not available of this Currency");
        //                    dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
        //                    dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Selected = true;
        //                }

        //            }
        //            if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == false)
        //            {
        //                dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
        //                dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = 0;
        //            }
        //            if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == true && cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == true)
        //            {
        //                dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value);
        //                dtbDetail.Rows[e.RowIndex].Cells["usEquilent"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value) / Convert.ToDouble(numEXRAtes.Value));
        //            }
        //            CalculateAmount();
        //        }

        //        if (dtbDetail.Columns["Rate"].Index == e.ColumnIndex)
        //        {
        //            if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == false || dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString() == "")
        //            {
        //                dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
        //                dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = 0;
        //            }
        //            if (Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value) < Convert.ToDecimal(donumMinRate.Value))
        //            {

        //                dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
        //                MessageBox.Show("Rate Should not be Minimum from Defined Rate", "",
        //                MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            if (Convert.ToDecimal(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value) > Convert.ToDecimal(donumMax.Value))
        //            {
        //                dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
        //                MessageBox.Show("Rate Should not be Maximum from Defined Rate", "",
        //                MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == true)
        //            {
        //                dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value);
        //                dtbDetail.Rows[e.RowIndex].Cells["usEquilent"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value) / Convert.ToDouble(numEXRAtes.Value));
        //            }
        //            CalculateAmount();
        //        }

        //        if (dtbDetail.Columns["Symbol"].Index == e.ColumnIndex)
        //        {
        //            DataRow[] dRow = dtb.Select("ShortName = '" + dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value + "'");
        //            if (dRow.Count() > 0)
        //            {
        //                dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value = dRow[0]["ItemName"].ToString();
        //                dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value = dRow[0]["ItemCode"].ToString();
        //                donumMax.Value = Convert.ToDecimal(dRow[0]["MaximumRate"].ToString());
        //                donumMinRate.Value = Convert.ToDecimal(dRow[0]["MinimumRate"].ToString());
        //                DataTable dtbstock = cls.GetStockds(General.dtSystemDate, dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString()).Tables[0];

        //                if (dtbstock.Rows.Count > 0)
        //                {
        //                    donumStock.Value = Convert.ToDecimal(dtbstock.Rows[0]["FCAmount"].ToString());
        //                    donumAverage.Value = Convert.ToDecimal(dtbstock.Rows[0]["AvgRate"].ToString());
        //                }
        //            }
        //            else
        //            {
        //                dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value = "";
        //                dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value = "";
        //                dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value = "";
        //                donumMax.Value = 0;
        //                donumMinRate.Value = 0;
        //            }
        //        }

        //        if (dtbDetail.Columns["ItemName"].Index == e.ColumnIndex)
        //        {

        //            if (dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value.ToString().Length >= 3)
        //            {
        //                DataRow[] dr = dtb.Select("ItemName Like '" + dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value + "%'", "ItemName");
        //                if (dr.Count() > 0)
        //                {
        //                    if (dr.GetUpperBound(0) >= 0)
        //                    {
        //                        dtb.DefaultView.Sort = "ItemName";
        //                        dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value = dr[0]["ItemName"].ToString();
        //                        dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value = dr[0]["ItemCode"].ToString();
        //                        dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value = dr[0]["ShortName"].ToString();
        //                    }
        //                }
        //                else
        //                {
        //                    dtb.DefaultView.Sort = "";
        //                    dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value = "";
        //                    dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value = "";
        //                    dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value = "";

        //                }
        //            }
        //        }
        //        dtbDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
        //        dtbDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Selected = true;

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        #endregion
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
            cboTitle.ReadOnly = true;
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

            DataGridViewTextBoxColumn clmnGrossRate = new DataGridViewTextBoxColumn();
            clmnGrossRate.Name = "GrossRate";
            clmnGrossRate.HeaderText = "Rate Ex %";
            clmnGrossRate.DefaultCellStyle.Format = "N4";
            clmnGrossRate.ValueType = typeof(System.Double);
            clmnGrossRate.DefaultCellStyle.NullValue = "0";
            clmnGrossRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnGrossRate.Width = 120;
            clmnGrossRate.ReadOnly = true;
            dtbDetail.Columns.Add(clmnGrossRate);

            DataGridViewTextBoxColumn clmnGrossRateexp = new DataGridViewTextBoxColumn();
            clmnGrossRateexp.Name = "GrossRateExp";
            clmnGrossRateexp.HeaderText = "Rate + Expense";
            clmnGrossRateexp.DefaultCellStyle.Format = "N4";
            clmnGrossRateexp.ValueType = typeof(System.Double);
            clmnGrossRateexp.DefaultCellStyle.NullValue = "0";
            clmnGrossRateexp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnGrossRateexp.Width = 120;
            clmnGrossRateexp.ReadOnly = true;
            dtbDetail.Columns.Add(clmnGrossRateexp);

            //DataGridViewTextBoxColumn clmnNetRate = new DataGridViewTextBoxColumn();
            //clmnNetRate.Name = "NetRateExp";
            //clmnNetRate.HeaderText = "Rate - Expense";
            //clmnNetRate.DefaultCellStyle.Format = "N4";
            //clmnNetRate.ValueType = typeof(System.Double);
            //clmnNetRate.DefaultCellStyle.NullValue = "0";
            //clmnNetRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //clmnNetRate.Width = 120;
            //clmnNetRate.ReadOnly = true;
            //dtbDetail.Columns.Add(clmnNetRate);


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

            DataGridViewTextBoxColumn clmnStockV = new DataGridViewTextBoxColumn();
            clmnStockV.Name = "StockV";
            clmnStockV.HeaderText = "StockV";
            clmnStockV.Width = 0;
            clmnStockV.Visible = false;
            dtbDetail.Columns.Add(clmnStockV);

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

                        dtbDetail.Rows[i].Cells["GrossRate"].Value = dr[i]["PurchaseRate"].ToString();

                        
                    }
                    CalculateAmount();
                 
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
                    if (dtbDetail.Columns.Count == dtbDetail.CurrentCell.ColumnIndex + 5)
                    {
                        if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["SNo"].Value != null)
                        {
                            dtbDetail.Rows.Add();
                            SendKeys.Send("{Home}");
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Quantity"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Rate"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Amount"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["GrossRate"].Value = 0;


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

                if (dtbDetail.Columns["Quantity"].Index == e.ColumnIndex)
                {
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == true)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value =  Math.Round(Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value),0);
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

        

                if (dtbDetail.Columns["Rate"].Index == e.ColumnIndex)
                {
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == false || dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString() == "")
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value = 0;
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                    }
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == true)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value =  Math.Round(Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value),0);
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
            dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
            
            if (dtbDetail.Columns["Symbol"].Index == intColumn)
            {
                DataRow[] dRow = dtb.Select("ShortName = '" + dtbDetail.Rows[intRow].Cells["Symbol"].Value + "'");
                if (dRow.Count() > 0)
                {
                    dtbDetail.Rows[intRow].Cells["ItemName"].Value = dRow[0]["ItemName"].ToString();
                    dtbDetail.Rows[intRow].Cells["ItemCode"].Value = dRow[0]["ItemCode"].ToString();
               
                }
                else
                {
                    dtbDetail.Rows[intRow].Cells["ItemName"].Value = "";
                    dtbDetail.Rows[intRow].Cells["ItemCode"].Value = "";
                    dtbDetail.Rows[intRow].Cells["Symbol"].Value = "";
                    dtbDetail.Rows[intRow].Cells["Rate"].Value = "0";
                    dtbDetail.Rows[intRow].Cells["GrossRate"].Value = "0";
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
                          

                        }
                    }
                    else
                    {
                        dtb.DefaultView.Sort = "";
                        dtbDetail.Rows[intRow].Cells["ItemName"].Value = "";
                        dtbDetail.Rows[intRow].Cells["ItemCode"].Value = "";
                        dtbDetail.Rows[intRow].Cells["Symbol"].Value = "";
                        dtbDetail.Rows[intRow].Cells["Rate"].Value = "0";
                        dtbDetail.Rows[intRow].Cells["GrossRate"].Value = "0";

                    }
                }
            }

        }        
        private void PopulateCombo()
        {
            cls = new General();

            string strQuery = "Select * from EX_System Where Flag = 'T';Select * from EX_System Where Flag = 'C' and Code not in ('303','31');Select * from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Status = 'A' and isTransactional = 'True' ;Select * from EX_SetupItems Where Locked = 'False' and Status = 'A';Select * from EX_System Where Flag = 'E'";
            dsPopulateCombo = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicbopaymentMode, dsPopulateCombo.Tables[(int)DataPop.Account], "Title", "AccountNo");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            General.strTableName[1]= "EX_PurchaseDetail";
            General.strTableName[0]= "EX_PurchaseMaster";
            General.strPKColumn = "VoucherNo";
            General.strAuthorizeTableName = General.strTableName[0];
            PopulateCombo();
            AddColumninDetailGrid();
            cls.EnableDisble(PnlMain, false);
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            dtbMaster.CellValueChanged += new DataGridViewCellEventHandler(dtbMaster_CellValueChanged);
            dtbMaster.CellContentClick += new DataGridViewCellEventHandler(dtbMaster_CellContentClick);

            dtbDetail.SelectionChanged +=new EventHandler(dtbDetail_SelectionChanged);
            dtbDetail.EditingControlShowing +=new DataGridViewEditingControlShowingEventHandler(dtbDetail_EditingControlShowing);
            dtbDetail.CellBeginEdit+=new DataGridViewCellCancelEventHandler(dtbDetail_CellBeginEdit);
            dtbDetail.CellEndEdit += new DataGridViewCellEventHandler(dtbDetail_CellEndEdit);
            dtbDetail.KeyDown += new KeyEventHandler(dtbDetail_KeyDown);

         
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
            //ditxtInvoiceNo.Enabled = false;
            strButtonState = "ADD";
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            dicbopaymentMode.SelectedValue = cls.strControlAccount("Cashinhand");
            dotxtGrossAmount.Enabled = false;
           dotxtNetAmount.Enabled = false;
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
                                 
                                       strTransType = "PUR";
                                 
                                   for (int i = 0; i < dtbDetail.Rows.Count; i++)
                                   {
                                       dtbDetail.Rows[i].Cells["VoucherNo"].Value = ditxtVoucherNo.Text;
                                       dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                                       dtbDetail.Rows[i].Cells["Sno"].Value = i;
                                   }
                                   strCondition = "Where VoucherNo = '" + ditxtVoucherNo.Text + "'";
                                   ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "Posted=False;Process=Green;AccountNo=" + cls.strControlAccount("PurchaseSale") + ";BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + "");
                                   dtbMaster.DataSource = ds.Tables[0];
                                   //dtSearchDetail = ds.Tables[1];
                                   cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
                                   cls.EnableDisble(PnlMain, false);
                                   strButtonState = "SAVE";
                                  
                                   PRINT();
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
           dotxtNetAmount.Enabled = false;
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

          
           strQuery = "Select * from EX_PurchaseMaster a " + General.strStatusCondition + "  and BranchCode = '" + General.strBranchCode + "'";
           if (General.strFormQueryCriteria != "")
           {
               strQuery = strQuery +  General.strFormQueryCriteria;
           }
           else
           {
               strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate + "'";
           }
           strQuery = strQuery + " ;Select a.RecNo,SNO,c.ItemCode,ItemName,PurchaseRate,ShortName,Quantity,Rate,Amount,a.VoucherNo,a.BranchCode from EX_PurchaseDetail c Inner Join EX_PurchaseMaster a on a.VoucherNo = c.VoucherNo and a.RecNo = c.RecNo Inner Join EX_SetupItems b on c.ItemCode = b.ItemCode and b.Status = 'A'";
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
                //if (dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["Status"].Value.ToString() == "A")
                //{
                    DialogResult dr =
             MessageBox.Show("are you sure to Print That Record", "Confirmation Print",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             
                    if (Convert.ToString(dr) == "Yes")
                    {

                        objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                        DataTable dtb = new DataTable();
                        string strQuery = " Select a.VoucherNo,a.TransDate,CustomerName,Address,CnicNo,TokenNo,";
                        strQuery = strQuery + " e.ItemName,e.ShortName,b.Quantity,b.Rate,b.Amount,c.Description as TransactionType,";
                        strQuery = strQuery + " d.Description as CustomerType from EX_PurchaseMaster a Inner Join EX_PurchaseDetail b on a.VoucherNo = b.VoucherNo ";
                        strQuery = strQuery + " and a.BranchCode = b.BranchCode and a.RecNo = b.RecNo";
                        strQuery = strQuery + " Inner Join EX_System c on c.Code = a.TransType ";
                        strQuery = strQuery + " Inner Join EX_System d on d.Code = a.CustomerType";
                        strQuery = strQuery + " Inner Join EX_SetupItems e on b.Itemcode = e.ItemCode and e.Status = 'A'";
                        strQuery = strQuery + " Where a.VoucherNo = '" + ditxtVoucherNo.Text + "' and a.Status in ('A','U')";
                        dtb = objGetData.GetDataSet(strQuery).Tables[0];

                        //rptDealTicket devrep = new rptDealTicket(General.strAddress);
                        rptPrePrinted devrep = new rptPrePrinted();
                        devrep.Margins = new System.Drawing.Printing.Margins(40, 0, 130, 10);
                        //devrep.Margins = new System.Drawing.Printing.Margins(30, 0, 120, 0);
                        devrep.DataSource = dtb;
                        //devrep.Parameters["UserId"].Value = General.strUserId;
                        //devrep.Parameters["ReportName"].Value = General.strReportCaption;
                        //devrep.Parameters["CompanyName"].Value = General.strCompanyName;
                        //devrep.Parameters["BranchName"].Value = General.strBranchName;
                        //devrep.Parameters["Criteria"].Value = "";
                                            
                        devrep.RequestParameters = false;
                        devrep.CreateDocument();
                        devrep.Print();
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
                bolState= false;
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
          
            for (int i = 0; i < dtbDetail.Rows.Count ; i++)
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
        private void cstTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void cboTransaction_Validated(object sender, EventArgs e)
        {

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
                    dotxtGrossAmount.Value = Convert.ToDecimal( dtbDetail.Rows[i].Cells["Amount"].Value.ToString());
              
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
        private void chkAccount_CheckedChanged(object sender, EventArgs e)
        {
        
        }
        private void dotxtCnicNo_Validating(object sender, CancelEventArgs e)
        {
            dtbDetail.Focus();
            dtbDetail.Rows[0].Cells[0].Selected = false;
            dtbDetail.Rows[0].Cells[1].Selected = true;
        }
        private void dicboCustomerType_Validated(object sender, EventArgs e)
        {
          
        }
        private void docboCustName_Validated(object sender, EventArgs e)
        {
           
        }
        private void dotxtCnicNo_Validated_1(object sender, EventArgs e)
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
        private void dicboCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmdCompleteSale_Click(object sender, EventArgs e)
        {
            //cls = new General();
            //DataTable dtb = new DataTable();
            //dtb = cls.GetStockds(General.dtSystemDate, null).Tables[0];
            //for (int i = 0; i < dtb.Rows.Count; i++)
            //{
            //    dtbDetail.Rows[i].Cells["ItemCode"].Value = dtb.Rows[i]["ItemCode"].ToString();
            //    dtbDetail.Rows[i].Cells["Symbol"].Value = dtb.Rows[i]["ShortName"].ToString();
            //    dtbDetail.Rows[i].Cells["ItemName"].Value = dtb.Rows[i]["ItemName"].ToString();
            //    dtbDetail.Rows[i].Cells["Quantity"].Value = dtb.Rows[i]["FCAmount"].ToString();
            //    dtbDetail.Rows[i].Cells["Rate"].Value = 0;
            //    dtbDetail.Rows[i].Cells["Amount"].Value = 0;
            //    dtbDetail.Rows.Add();

            //}
        }
        private void frmTradingVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '')
            {
                ADD();
            }
        }

        private void frmTradingVoucher_Activated(object sender, EventArgs e)
        {
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }

        private void dotxtCnicNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void ditxtVoucherNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dotxtAddress_Validating(object sender, CancelEventArgs e)
        {
           
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

        private void dtbDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void donumCustomClearing_ValueChanged(object sender, EventArgs e)
        {

        }

        private void donumCustomClearing_Validated(object sender, EventArgs e)
        {
       }

        private void donumLabourCharges_Validated(object sender, EventArgs e)
        {
        }

        private void donumTransportCharges_Validated(object sender, EventArgs e)
        {
        }

        private void donumOtherCharges_Validated(object sender, EventArgs e)
        {
        }

  
        private void dotxtDiscount_Validated(object sender, EventArgs e)
        {
        }

        private void dotxtTax_Validated(object sender, EventArgs e)
        {
        }

        private void dotxtNetAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    
    }
}
