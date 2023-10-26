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
    public partial class frmBulkinTransit : BaseForm,IToolBar
    {
        enum DataPop { PaymentMode, TransType, Account, Item, Customer};
       
        General cls;
        DataSet dsPopulateCombo;
        DataTable dtSearchMaster;
        DataTable dtSearchDetail;
        string strAccountNo = "";
        public string strButtonState = null;
        string strTransType = "BSP";
        public string strError = "";
        string strCondition;
        string strValue;
        public frmBulkinTransit()
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
            clmnAmount.DefaultCellStyle.Format = "N4";
            clmnAmount.ValueType = typeof(System.Double);
            clmnAmount.DefaultCellStyle.NullValue = "0";
            clmnAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnAmount.Width = 100;
            clmnAmount.ReadOnly = true;
            dtbDetail.Columns.Add(clmnAmount);

            DataGridViewTextBoxColumn clmnEQU = new DataGridViewTextBoxColumn();
            clmnEQU.Name = "EquRate";
            clmnEQU.HeaderText = "Equilent Rate";
            clmnEQU.DefaultCellStyle.Format = "N4";
            clmnEQU.ValueType = typeof(System.Double);
            clmnEQU.DefaultCellStyle.NullValue = "0";
            clmnEQU.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnEQU.Width = 120;
            clmnEQU.ReadOnly = true;
            dtbDetail.Columns.Add(clmnEQU);

            DataGridViewTextBoxColumn clmnEQUAm = new DataGridViewTextBoxColumn();
            clmnEQUAm.Name = "EquAmount";
            clmnEQUAm.HeaderText = "Equilent Amount";
            clmnEQUAm.DefaultCellStyle.Format = "N4";
            clmnEQUAm.ValueType = typeof(System.Double);
            clmnEQUAm.DefaultCellStyle.NullValue = "0";
            clmnEQUAm.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnEQUAm.Width = 120;
            clmnEQUAm.ReadOnly = true;
            dtbDetail.Columns.Add(clmnEQUAm);
            
            
            DataGridViewTextBoxColumn clmnVNo = new DataGridViewTextBoxColumn();
            clmnVNo.Name = "TransNo";
            clmnVNo.HeaderText = "TransNo";
            clmnVNo.Width = 0;
            clmnVNo.Visible = false;
            dtbDetail.Columns.Add(clmnVNo);

            DataGridViewTextBoxColumn clmnBranch = new DataGridViewTextBoxColumn();
            clmnBranch.Name = "BranchCode";
            clmnBranch.HeaderText = "BranchCode";
            clmnBranch.Width = 0;
            clmnBranch.Visible = false;
            dtbDetail.Columns.Add(clmnBranch);

        }
        private void PopulateCombo()
        {
            cls = new General();
            strValue = cls.strControlAccount("PurchaseSale");
            string strQuery = "Select * from EX_System Where Flag = 'M';Select * from EX_System Where Flag = 'T';Select * from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and AccountNo = '" + strValue + "' and Status = 'A';Select * from EX_SetupItems Where Locked = 'False' and Status = 'A';Select * from EX_SetupCustomer Where isBranch = 'true' and Status = 'A'";
            dsPopulateCombo = new DataSet();
              
            dsPopulateCombo = cls.GetDataSet(strQuery);
            cls.PopulateCombo(dicboCurrency, dsPopulateCombo.Tables[(int)DataPop.Item], "ItemName", "ItemCode");
            cls.PopulateCombo(dicboParty, dsPopulateCombo.Tables[(int)DataPop.Customer], "CustName", "CustCode");
            cls.PopulateCombo(dicboPaymentMode, dsPopulateCombo.Tables[(int)DataPop.PaymentMode], "description", "Code");
            cls.PopulateCombo(dicboTransType, dsPopulateCombo.Tables[(int)DataPop.TransType], "Description", "Code");
        }
        private void GenerateVoucherNo()
        {
            string strTransNo = string.Format("{0:D5}", Convert.ToInt32(cls.GetTransNo(strTransType)));
            ditxtBillMemo.Text = strTransType + "-" + strTransNo + "-" + General.strBranchCode;
            ditxtTransNo.Text = General.dtSystemDate.Year.ToString() + General.dtSystemDate.Month.ToString() + strTransNo;
        }
        #region IToolBar Members

        public bool ADD()
        {
            cls = new General();
            dicboCurrency.SelectedIndex = 23;
            dicboParty.SelectedIndex = 0;
            dicboPaymentMode.SelectedIndex = 1;
            dicboTransType.SelectedIndex = 0;
            dtbDetail.Rows.Clear();
            if (dtbDetail.Rows.Count == 0)
            {
                dtbDetail.Rows.Add();
            }
            ditxtBillMemo.Enabled = false;
            ditxtTransNo.Enabled = false;
            strButtonState = "ADD";
            dicboTransType.Focus();
            
            return true;
        }

        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();
            if (strButtonState == "ADD")
            {
                GenerateVoucherNo();
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    if (dtbDetail.Rows[i].Cells["Amount"].Value  != null)
                    {
                        if (String.IsNullOrEmpty(dtbDetail.Rows[i].Cells["Amount"].Value.ToString()) == false)
                        {
                            dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                            dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                        }
                        
                    }
                }
            }
            if (strButtonState == "ADD" || strButtonState == "EDIT")
            {
                if (ValidatingControls() == true)
                {
                    if (dicboTransType.SelectedValue == "1")
                    {
                        strTransType = "PUR";
                    }
                    else if (dicboTransType.SelectedValue == "2")
                    {
                        strTransType = "SAL";
                    }
                    strCondition = "Where TransNo = '" + ditxtTransNo.Text + "'";
                    ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "Posted=False;Process=Green;AccountNo=" + strValue + ";BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + "");
                    dtbMaster.DataSource = null;
                    dtbMaster.DataSource = ds.Tables[0];
            //        dtSearchDetail = ds.Tables[1];
                    cls.BindGridwithTextBox(PnlMain, dtbMaster, "",null);
                    cls.EnableDisble(PnlMain, false);
                    strButtonState = "SAVE";
                }
                else
                {
                    MessageBox.Show(strError, "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            return true;
        }

        public bool EDIT()
        {

            ditxtBillMemo.Enabled = false;
            ditxtTransNo.Enabled = false;
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
            strQuery = "Select * from EX_TransBulkSalePurinTransitMaster " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "' AND Posted = 'false';Select a.RecNo,SNO,a.ItemCode,ItemName,ShortName,Quantity,a.Rate,Amount,EquRate,EquAmount,a.TransNo,a.BranchCode from EX_TransBulkSalePurinTransitDetail a Inner Join EX_TransBulkSalePurinTransitMaster c on a.TransNo = c.TransNo and a.RecNo = c.RecNo and a.BranchCode = c.BranchCode Inner Join EX_SetupItems b on a.ItemCode = b.ItemCode and b.Status = 'A'";
            ds =cls.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtSearchDetail = ds.Tables[1];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster, "",null);
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
            strCondition = "Where TransNo= '" + ditxtTransNo.Text + "'";
            cls.DeleteRecord(General.strTableName, strCondition);
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
                General cls = new General();
            DataTable dtb = new DataTable();
            string strQuery = "Select a.VoucherNo,a.TransDate,CustomerName,Address,CNICNO,d.Description as TransactionType,Tokenno,c.Description as CustomerType ";
            strQuery = strQuery + ",ItemName,ShortName,b.Quantity,b.Rate,b.Amount";
            strQuery = strQuery + ",'" + General.strCompanyName + "' as CompanyName,'" + General.strBranchName + "' as BranchName,(Select Address From EX_Branch Where BranchCode = '" + General.strBranchCode + "') as BranchAddress";
            strQuery = strQuery + ",(Select Phone From EX_Branch Where BranchCode = '" + General.strBranchCode + "') as BranchPhone";
            strQuery = strQuery + ",(Select Fax From EX_Branch Where BranchCode = '" + General.strBranchCode + "') as BranchFax";
            strQuery = strQuery + " from EX_TransactionsMaster a";
            strQuery = strQuery + " Inner Join EX_TransactionsDetail b on a.VoucherNo = b.VoucherNo";
            strQuery = strQuery + " Inner Join EX_System c on a.CustomerType = c.Code";
            strQuery = strQuery + " Inner Join EX_System d on a.TransType = d.Code";
            strQuery = strQuery + " Inner Join EX_SetupItems e on b.ItemCode = e.ItemCode and e.Status = 'A'";
            strQuery = strQuery + " Where a.VoucherNo = '" + ditxtTransNo.Text + "'";
            dtb =cls.GetDataSet(strQuery).Tables[0];
            //frmReportViewer frmrpt = new frmReportViewer(dtb, "rptDealTicket");
            //frmrpt.Show();


            return true;
        }
        public bool HISTORY()
        {
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
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (dtbDetail.Rows[i].Cells["ItemCode"].Value != null)
                {
                    if (String.IsNullOrEmpty(dtbDetail.Rows[i].Cells["ItemCode"].Value.ToString()) == false)
                    {
                        if (dicboTransType.SelectedValue.ToString() == "2")
                        {
                            DataSet ds = cls.GetStockds(General.dtSystemDate, dtbDetail.Rows[i].Cells["ItemCode"].Value.ToString());
                            if (Convert.ToDouble(dtbDetail.Rows[i].Cells["Quantity"].Value.ToString()) > Convert.ToDouble(ds.Tables[0].Rows[0]["FCAmount"].ToString()))
                            {
                                strError = strError + "\n" + "Quantity is not Available of " + ds.Tables[0].Rows[0]["ShortName"].ToString() + "";
                            }
                        }
                        if (dtbDetail.Rows[i].Cells["Amount"].Value.ToString() == "0" || dtbDetail.Rows[i].Cells["Amount"].Value == null)
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
            //if (Convert.ToDouble(lblusdAmount.Text) >= General.dblOverUS)
            //{
            //    if (String.IsNullOrEmpty(dotxtCnicNo.Text))
            //    {
            //        strError = strError + "\n" + "CNICNO or Passport No is Requird";
            //        bolState = false;
            //    }
            //}

            return bolState;
        }
        void dtbMaster_SelectionChanged(object sender, EventArgs e)
        {

            DataRow[] dr = new DataRow[0];
            if (ditxtTransNo.Text != "" && strButtonState != "ADD")
            {

                dr = dtSearchDetail.Select("TransNo = '" + ditxtTransNo.Text + "' and RecNo = '"+ dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["RecNo"].Value +"' ", "TransNo");
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
                    dtbDetail.Rows[i].Cells["TransNo"].Value = dr[i]["TransNo"].ToString();
                    dtbDetail.Rows[i].Cells["EquRate"].Value = Convert.ToDecimal(dr[i]["EquRate"].ToString());
                    dtbDetail.Rows[i].Cells["EquAmount"].Value = Convert.ToDecimal(dr[i]["EquAmount"].ToString()); 
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = dr[i]["BranchCode"].ToString();
                }
                CalculateAmount();

            }
        }
    
        void dtbDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (General.strButtonState == "ADD" || General.strButtonState == "SAVE" || General.strButtonState == "EDIT")
            {

                if (e.KeyValue == 40)
                {
                    if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["SNo"].Value != null)
                    {
                        for (int i = 0; i < dtbDetail.Rows.Count; i++)
                        {
                            if (dtbDetail.Rows[i].Cells["Sno"].Value == null)
                            {
                                dtbDetail.Rows.RemoveAt(i);
                            }
                        }
                        dtbDetail.Rows.Add();
                    }
                }


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
            DataTable dtb = new DataTable();
            cls = new General();
            dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
            try
            {
                cls = new General();

                if (String.IsNullOrEmpty(dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value.ToString()) == false)
                {
                    DataRow[] dRow = dtb.Select("ShortName = '" + dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value + "'");
                    if (dRow.Count() > 0)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value = dRow[0]["ItemName"].ToString();
                        dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value = dRow[0]["ItemCode"].ToString();
                        donumMax.Value = Convert.ToDecimal(dRow[0]["MaximumRate"].ToString());
                        donumMinRate.Value = Convert.ToDecimal(dRow[0]["MinimumRate"].ToString());
                        DataTable dtbstock = cls.GetStockds(General.dtSystemDate, dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString()).Tables[0];

                        if (dtbstock.Rows.Count > 0)
                        {
                            donumStock.Value = Convert.ToDecimal(dtbstock.Rows[0]["FCAmount"].ToString());
                            donumAverage.Value = Convert.ToDecimal(dtbstock.Rows[0]["AvgRate"].ToString());
                        }
                    }
                    else
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value = "";
                        dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value = "";
                        dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value = "";
                        donumMax.Value = 0;
                        donumMinRate.Value = 0;
                    }
                }

                
                
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
                    //if (dicboTransType.SelectedValue.ToString() == "2")
                    //{
                    //    if (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) > Convert.ToDouble(donumStock.Value))
                    //    {
                    //        MessageBox.Show("Stock is not available of this Currency");
                    //        dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
                    //        dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Selected = true;
                    //    }

                    //}
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == false)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                    }
                    if (cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) == true && cls.IsNumeric(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value.ToString()) == true)
                    {
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value);
                        dtbDetail.Rows[e.RowIndex].Cells["EquAmount"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dinumConversionRate.Value));
                        dtbDetail.Rows[e.RowIndex].Cells["EquRate"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["usEquilentAmount"].Value) / Convert.ToDouble(Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value)));
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
                        dtbDetail.Rows[e.RowIndex].Cells["Amount"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value);
                        dtbDetail.Rows[e.RowIndex].Cells["EquRate"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value) * Convert.ToDouble(Convert.ToDouble(dinumConversionRate.Value)));
                        dtbDetail.Rows[e.RowIndex].Cells["EquAmount"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["EquRate"].Value));
                    }
                    CalculateAmount();
                }


                if (dtbDetail.Columns["ItemName"].Index == e.ColumnIndex)
                {

                    if (dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value.ToString().Length >= 3)
                    {
                        DataRow[] dr = dtb.Select("ItemName Like '" + dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value + "%'", "ItemName");
                        if (dr.Count() > 0)
                        {
                            if (dr.GetUpperBound(0) >= 0)
                            {
                                dtb.DefaultView.Sort = "ItemName";
                                dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value = dr[0]["ItemName"].ToString();
                                dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value = dr[0]["ItemCode"].ToString();
                                dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value = dr[0]["ShortName"].ToString();
                            }
                        }
                        else
                        {
                            dtb.DefaultView.Sort = "";
                            dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value = "";
                            dtbDetail.Rows[e.RowIndex].Cells["ItemCode"].Value = "";
                            dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value = "";

                        }
                    }
                }
                dtbDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                dtbDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Selected = true;

            }
            catch (Exception ex)
            {

            }
        }
 
        
        private void CalculateAmount()
        {
            lblTotalAmount.Text = "0";
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (dtbDetail.Rows[i].Cells["Amount"].Value != null )
                {
                    if (Convert.ToDouble(lblTotalAmount.Text) == Convert.ToDouble("0"))
                    {
                        lblTotalAmount.Text = dtbDetail.Rows[i].Cells["Amount"].Value.ToString();
                        lblusdAmount.Text = dtbDetail.Rows[i].Cells["EQUAMount"].Value.ToString();
                    }
                    else
                    {
                        lblTotalAmount.Text =
                            (Convert.ToDouble(lblTotalAmount.Text) +
                            Convert.ToDouble(dtbDetail.Rows[i].Cells["Amount"].Value)).ToString();
                        lblusdAmount.Text =
                                                (Convert.ToDouble(lblusdAmount.Text) +
                                                Convert.ToDouble(dtbDetail.Rows[i].Cells["EquAmount"].Value)).ToString();

                    }
                    
                }
            }
            decimal d = Math.Round(Convert.ToDecimal(lblusdAmount.Text.ToString()), 4);
            lblusdAmount.Text = d.ToString();
        }
       
        private void frmBulkinTransit_Load(object sender, EventArgs e)
        {
            cls = new General();
            General.strTableName[1]= "EX_TransBulkSalePurinTransitDetail";
            General.strTableName[0]= "EX_TransBulkSalePurinTransitMaster";
            General.strPKColumn = "TransNo";
            General.strAuthorizeTableName = General.strTableName[0];
            PopulateCombo();
            AddColumninDetailGrid();
            cls.EnableDisble(PnlMain, false);
            dtbDetail.CellEndEdit += new DataGridViewCellEventHandler(dtbDetail_CellEndEdit);
            dtbDetail.KeyDown += new KeyEventHandler(dtbDetail_KeyDown);
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            //numEXRAtes.Value = Convert.ToDecimal(dsPopulateCombo.Tables[(int)DataPop.Item].Rows[0]["Description"].ToString());

           
        }

        private void cmdCompleteSale_Click(object sender, EventArgs e)
        {
            if (!dtbDetail.Rows[0].IsNewRow)
            {
                dtbDetail.Rows.RemoveAt(0);
            }
            //cls = new General();
            //DataTable dtb = new DataTable();
            //dtb = cls.GetStockds(General.dtSystemDate, null).Tables[0];
            //for (int i = 0; i < dtb.Rows.Count; i++)
            //{
            //    dtbDetail.Rows.Add();
            //    dtbDetail.Rows[i].Cells["Sno"].Value = i;
            //    dtbDetail.Rows[i].Cells["ItemCode"].Value = dtb.Rows[i]["ItemCode"].ToString();
            //    dtbDetail.Rows[i].Cells["Symbol"].Value = dtb.Rows[i]["ShortName"].ToString();
            //    dtbDetail.Rows[i].Cells["ItemName"].Value = dtb.Rows[i]["ItemName"].ToString();
            //    dtbDetail.Rows[i].Cells["Quantity"].Value = dtb.Rows[i]["FCAmount"].ToString();
            //    dtbDetail.Rows[i].Cells["Rate"].Value = 0;
            //    dtbDetail.Rows[i].Cells["Amount"].Value = 0;
         
            //}
        }
   
   
    }
}
