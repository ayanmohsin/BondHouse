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
    public partial class frmInterBankTransactions : BaseForm,IToolBar
    {
        public frmInterBankTransactions()
        {
            InitializeComponent();
        }
        enum DataPop { PaymentMode, TransType, Account, Item, Customer,AccountDet,VT};
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataSet dsPopulateCombo;
        DataTable dtSearchMaster;
        DataTable dtSearchDetail;
        string strAccountNo = "";
        public string strButtonState = null;
        string strTransType = "IBT";
        public string strError = "";
        string strCondition;
        string strValue;
        MainForm Mainfrm;
        private void AddColumninDetailGrid()
        {

            DataGridViewTextBoxColumn clmnSno = new DataGridViewTextBoxColumn();
            clmnSno.Name = "Sno";
            clmnSno.HeaderText = "Sno";
            clmnSno.Width = 40;
            clmnSno.ReadOnly = true;
            clmnSno.Visible = false;
            dtbDetail.Columns.Add(clmnSno);

            DataGridViewTextBoxColumn clmnSettlemnet = new DataGridViewTextBoxColumn();
            clmnSettlemnet.Name = "AccountDet";
            clmnSettlemnet.HeaderText = "Settelment Account";
            clmnSettlemnet.Width = 195;
            dtbDetail.Columns.Add(clmnSettlemnet);

            DataGridViewTextBoxColumn clmnSettlemnetCode = new DataGridViewTextBoxColumn();
            clmnSettlemnetCode.Name = "SettleAccount";
            clmnSettlemnetCode.HeaderText = "Settelment Code";
            clmnSettlemnetCode.Visible = false;
            dtbDetail.Columns.Add(clmnSettlemnetCode);


            DataGridViewTextBoxColumn clmnSymbol = new DataGridViewTextBoxColumn();
            clmnSymbol.Name = "Symbol";
            clmnSymbol.HeaderText = "Symbol";
            clmnSymbol.Width = 70;
            clmnSymbol.ReadOnly = true;
            dtbDetail.Columns.Add(clmnSymbol);



            DataGridViewTextBoxColumn cboTitle = new DataGridViewTextBoxColumn();
            cboTitle.Name = "ItemName";
            cboTitle.HeaderText = "Name of Currency";
            cboTitle.Width = 200;
            cboTitle.Visible = false;
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
            clmnQty.Width = 100;
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
            //strValue = cls.strControlAccount("PurchaseSale");
            string strQuery = "Select * from EX_System Where Flag = 'M';Select * from EX_System Where Flag = 'T';Select * from EX_SetupAccount a Inner Join EX_SetupItems b on a.CurrencyCode = b.ItemCode and b.Status = 'A' Where a.BranchCode = '" + General.strBranchCode + "' and a.Status = 'A' and a.isTransactional = 'True' Order by Title;Select * from EX_SetupItems Where Locked = 'False' and Status = 'A';Select * from EX_SetupCustomer Where Status = 'A';Select * from EX_SetupAccount a Inner Join EX_SetupItems b on a.CurrencyCode = b.ItemCode and b.Status = 'A' Where a.BranchCode = '" + General.strBranchCode + "' and a.Status = 'A' and a.isTransactional = 'True' Order by Title;Select Code,Description from EX_System Where Flag = 'VT'";
            dsPopulateCombo = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicboCurrency, dsPopulateCombo.Tables[(int)DataPop.Item], "ShortName", "ItemCode");
            cls.PopulateCombo(dicboParty, dsPopulateCombo.Tables[(int)DataPop.Customer], "CustName", "CustCode");
            cls.PopulateCombo(dicboPaymentMode, dsPopulateCombo.Tables[(int)DataPop.Account], "Title", "AccountNo");
            cls.PopulateCombo(dicboTransType, dsPopulateCombo.Tables[(int)DataPop.TransType], "Description", "Code");
            cls.PopulateCombo(dicboVoucherType, dsPopulateCombo.Tables[(int)DataPop.VT], "Description", "Code");

        }
        private void GenerateVoucherNo()
        {
            string strTransNo = string.Format("{0:D5}", Convert.ToInt32(cls.GetTransNo(strTransType)));
            ditxtBillMemo.Text = General.dtSystemDate.Year.ToString() + General.dtSystemDate.Month.ToString() + strTransNo + General.strBranchCode;
            ditxtTransNo.Text = strTransType + "-" + strTransNo + "-" + General.strBranchCode; 
        }
        #region IToolBar Members

        public bool ADD()
        {
            cls = new General();
            dicboCurrency.SelectedIndex = 23;
            dicboParty.SelectedIndex = 0;
            dicboTransType.SelectedIndex = 0;
            dtbDetail.Rows.Clear();
            if (dtbDetail.Rows.Count == 0)
            {
                dtbDetail.Rows.Add();
                dtbDetail.Rows[0].Cells["Quantity"].Value = "0";
                dtbDetail.Rows[0].Cells["Rate"].Value = "0";
                dtbDetail.Rows[0].Cells["Amount"].Value = "0";
                dtbDetail.Rows[0].Cells["EquRate"].Value = "0";
                dtbDetail.Rows[0].Cells["EquAmount"].Value = "0";
            }
            ditxtBillMemo.Enabled = false;
            ditxtTransNo.Enabled = false;
            strButtonState = "ADD";
            dicboTransType.Focus();
            dicboCurrency.Enabled = false;
            dtDealDate.Enabled = true;
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
                        if (dtbDetail.Rows[i].Cells["AccountDet"].Value != null)
                        {
                            if (String.IsNullOrEmpty(dtbDetail.Rows[i].Cells["AccountDet"].Value.ToString()) == false)
                            {
                                dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                                dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                                dtbDetail.Rows[i].Cells["Sno"].Value = i;
                            }

                        }
                    }
                    //if (dicboTransType.SelectedValue.ToString() == "1")
                    //{
                    //    strTransType = "PUR";
                    //}
                    //else if (dicboTransType.SelectedValue.ToString() == "2")
                    //{
                    //    strTransType = "SAL";
                    //}

                    strCondition = "Where TransNo = '" + ditxtTransNo.Text + "'";
                    ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "Posted=False;Process=Green;BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + "");
                    dtbMaster.DataSource = null;
                    dtbMaster.DataSource = ds.Tables[0];
                    //        dtSearchDetail = ds.Tables[1];
                    cls.BindGridwithTextBox(PnlMain, dtbMaster, "",null);
                    cls.EnableDisble(PnlMain, false);
                    strButtonState = "SAVE";
                    dtDealDate.Enabled = false;

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

            ditxtBillMemo.Enabled = false;
            ditxtTransNo.Enabled = false;
            strButtonState = "EDIT";
            dicboCurrency.Enabled = false;
            dtDealDate.Enabled = true;
            return true;
        }

        public bool QUERY()
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            dtSearchDetail = new DataTable();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_TransInterBankTransactionMaster a " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "' AND Posted = 'false' ";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate + "'";
            }
            strQuery = strQuery + ";Select c.RecNo,SNO,c.ItemCode,ItemName,ShortName,Quantity,c.Rate,Amount,EquRate,EquAmount,c.TransNo,c.BranchCode,d.Title,d.AccountNo from EX_TransInterBankTransactionDetail c Inner Join EX_TransInterBankTransactionMaster a on a.TransNo = c.TransNo and a.RecNo = c.RecNo and a.BranchCode = c.BranchCode Inner Join EX_SetupItems b on c.ItemCode = b.ItemCode and b.Status = 'A' Inner Join EX_SetupAccount d on c.SettleAccount = d.AccountNo and d.Status = 'A'";
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
            cls.BindGridwithTextBox(PnlMain, dtbMaster, "",null);
            dtbMaster_SelectionChanged(dtbMaster, null);
            strButtonState = "QUERY";
            dtDealDate.Enabled = false;
            return true;
        }

        public bool UNDO()
        {
            strButtonState = "UNDO";
            dtbDetail.Rows.Clear();
            dtDealDate.Enabled = true;

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
                if (ditxtTransNo.Text != "")
                {
                    cls = new General();
                    cls.GenerateVoucher("IBT", ditxtTransNo.Text);
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
            if (!String.IsNullOrEmpty(cls.StrMessage))
            {
                strError = cls.StrMessage;
                bolState = false;
            }
            else
            {
                bolState = true;
            }
            if (dinumConversionRate.Value == 0)
            {
                strError = strError + "\n" + "Conversion Rate Should not be 0";
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
                        //if (dicboTransType.SelectedValue.ToString() == "2")
                        //{
                        //    DataSet ds = cls.GetStockds(General.dtSystemDate, dtbDetail.Rows[i].Cells["ItemCode"].Value.ToString());
                        //    if (Convert.ToDouble(dtbDetail.Rows[i].Cells["Quantity"].Value.ToString()) > Convert.ToDouble(ds.Tables[0].Rows[0]["FCAmount"].ToString()))
                        //    {
                        //        strError = strError + "\n" + "Quantity is not Available of " + ds.Tables[0].Rows[0]["ShortName"].ToString() + "";
                        //    }
                        //}
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
                if (dinumConversionRate.Value != 0)
                {
                        if (cls.IsNumeric(dtbDetail.Rows[i].Cells["Quantity"].Value.ToString()) == true && cls.IsNumeric(dtbDetail.Rows[i].Cells["Rate"].Value.ToString()) == true)
                        {
                            dtbDetail.Rows[i].Cells["Amount"].Value = Convert.ToDouble(dtbDetail.Rows[i].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[i].Cells["Rate"].Value);
                            dtbDetail.Rows[i].Cells["EquRate"].Value = (Convert.ToDouble(dtbDetail.Rows[i].Cells["Rate"].Value) * Convert.ToDouble(dinumConversionRate.Value));
                            dtbDetail.Rows[i].Cells["EquAmount"].Value = (Convert.ToDouble(dtbDetail.Rows[i].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[i].Cells["EQuRate"].Value));
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
            if (ditxtTransNo.Text != "" && strButtonState != "ADD" && dtSearchDetail != null && strButtonState != "EDIT")
            {

                dr = dtSearchDetail.Select("TransNo = '" + ditxtTransNo.Text + "' and RecNo = '" + dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["RecNo"].Value + "' ", "TransNo");
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
                    dtbDetail.Rows[i].Cells["AccountDet"].Value = dr[i]["Title"].ToString();
                    dtbDetail.Rows[i].Cells["SettleAccount"].Value = dr[i]["AccountNo"].ToString();
                }
                CalculateAmount();

            }
        }

        void dtbDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (General.strButtonState == "ADD" || strButtonState == "ADD" || General.strButtonState == "SAVE" || General.strButtonState == "EDIT")
            {
                if (e.KeyValue == 13)
                {
                    SendKeys.Send("{Right}");
                    if (dtbDetail.Columns.Count == dtbDetail.CurrentCell.ColumnIndex + 6)
                    {
                        if (dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex].Cells["SNo"].Value != null)
                        {
                            dtbDetail.Rows.Add();
                            SendKeys.Send("{Home}");
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Quantity"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Rate"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["Amount"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["EquRate"].Value = 0;
                            dtbDetail.Rows[dtbDetail.CurrentCell.RowIndex + 1].Cells["EquAmount"].Value = 0;

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
            DataTable dtb2 = new DataTable();
            cls = new General();
            dtb = dsPopulateCombo.Tables[(int)DataPop.Item];
            dtb2 = dsPopulateCombo.Tables[(int)DataPop.AccountDet];
            try
            {
                cls = new General();
                if (dtbDetail.Columns["AccountDet"].Index == e.ColumnIndex)
                {
                    FetchCurrencyGrid(e.RowIndex, e.ColumnIndex);
                }
                if (dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value != null)
                {
                //        if (String.IsNullOrEmpty(dtbDetail.Rows[e.RowIndex].Cells["Symbol"].Value.ToString()) == false)
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
                        dtbDetail.Rows[e.RowIndex].Cells["EquRate"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value) * Convert.ToDouble(dinumConversionRate.Value));
                        dtbDetail.Rows[e.RowIndex].Cells["EquAmount"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["EQuRate"].Value));
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
                        dtbDetail.Rows[e.RowIndex].Cells["EquRate"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Rate"].Value) * Convert.ToDouble(dinumConversionRate.Value));
                        dtbDetail.Rows[e.RowIndex].Cells["EquAmount"].Value = (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["EQuRate"].Value));
                    }
                    CalculateAmount();
                }

                //if (dtbDetail.Columns["Symbol"].Index == e.ColumnIndex)
                //{
                //    FetchCurrencyGrid(e.RowIndex, e.ColumnIndex);
                //}
                //if (dtbDetail.Columns["ItemName"].Index == e.ColumnIndex)
                //{
                //    FetchCurrencyGrid(e.RowIndex, e.ColumnIndex);
                //}

               
                }
            
            }
            catch (Exception ex)
            {

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
                        donumStock.Value = Convert.ToDecimal(dtbstock.Rows[0]["FCAmount"].ToString());
                        donumAverage.Value = Convert.ToDecimal(dtbstock.Rows[0]["AvgRate"].ToString());
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
                                donumStock.Value = Convert.ToDecimal(dtbstock.Rows[0]["FCAmount"].ToString());
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
            if (dtbDetail.Columns["AccountDet"].Index == intColumn)
            {
                dtb = dsPopulateCombo.Tables[(int)DataPop.AccountDet];
       
                if (dtbDetail.Rows[intRow].Cells["AccountDet"].Value.ToString().Length >= 3)
                {
                    DataRow[] dr = dtb.Select("Title Like '" + dtbDetail.Rows[intRow].Cells["AccountDet"].Value + "%'", "Title");
                    if (dr.Count() > 0)
                    {
                        if (dr.GetUpperBound(0) >= 0)
                        {
                            dtb.DefaultView.Sort = "Title";
                            dtbDetail.Rows[intRow].Cells["AccountDet"].Value = dr[0]["Title"].ToString();
                            dtbDetail.Rows[intRow].Cells["SettleAccount"].Value = dr[0]["AccountNo"].ToString();
                            DataTable dtb1 = dsPopulateCombo.Tables[(int)DataPop.Item];
                            DataRow[] dr1 = dtb1.Select("ItemCode = '" + dr[0]["CurrencyCode"].ToString() + "'", "ItemName");
                            dtbDetail.Rows[intRow].Cells["ItemName"].Value = dr1[0]["ItemName"].ToString();
                            dtbDetail.Rows[intRow].Cells["ItemCode"].Value = dr1[0]["ItemCode"].ToString();
                            dtbDetail.Rows[intRow].Cells["Symbol"].Value = dr1[0]["ShortName"].ToString();
                            dtbDetail.Rows[intRow].Cells["Rate"].Value = dr1[0]["MinimumRate"].ToString();
                            dtbDetail.Rows[intRow].Cells["Quantity"].Value = "0";
                            dtbDetail.Rows[intRow].Cells["EquRate"].Value = "0";
                            dtbDetail.Rows[intRow].Cells["EquAmount"].Value = "0";
                            dtbDetail.Rows[intRow].Cells["Amount"].Value = "0";
                            donumMax.Value = Convert.ToDecimal(dr1[0]["MaximumRate"].ToString());
                            donumMinRate.Value = Convert.ToDecimal(dr1[0]["MinimumRate"].ToString());
                            DataTable dtbstock = cls.GetStockds(General.dtSystemDate, dtbDetail.Rows[intRow].Cells["ItemCode"].Value.ToString()).Tables[0];

                            if (dtbstock.Rows.Count > 0)
                            {
                                donumStock.Value = Convert.ToDecimal(dtbstock.Rows[0]["FCAmount"].ToString());
                                donumAverage.Value = Convert.ToDecimal(dtbstock.Rows[0]["AvgRate"].ToString());
                           }
                            if (dr1[0]["ItemCode"].ToString() == "304")
                            {
                                dtbDetail.Columns["Rate"].ReadOnly = true;
                            }
                            else
                            {
                                dtbDetail.Columns["Rate"].ReadOnly = false;
                            }
                        }
                    }
                    else
                    {
                        dtb.DefaultView.Sort = "";
                        dtbDetail.Rows[intRow].Cells["AccountDet"].Value = "";
                        dtbDetail.Rows[intRow].Cells["SettleAccount"].Value = "";
                        dtbDetail.Rows[intRow].Cells["ItemName"].Value = "";
                        dtbDetail.Rows[intRow].Cells["ItemCode"].Value = "";
                        dtbDetail.Rows[intRow].Cells["Symbol"].Value = "";
                        dtbDetail.Rows[intRow].Cells["Rate"].Value = "0";

                    }
                }
            }

        }
        void dtbDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataTable dtb = new DataTable();
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridViewTextBoxEditingControl te;
                if (dtbDetail.CurrentCell.ColumnIndex == 3)
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
                else if (dtbDetail.CurrentCell.ColumnIndex == 4)
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
                else if (dtbDetail.CurrentCell.ColumnIndex == 1)
                {
                    te = new DataGridViewTextBoxEditingControl();
                    te.Clear();
                    te = (DataGridViewTextBoxEditingControl)e.Control;
                    te.AutoCompleteMode = AutoCompleteMode.Suggest;
                    te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    dtb = dsPopulateCombo.Tables[(int)DataPop.AccountDet];
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        te.AutoCompleteCustomSource.Add(dtb.Rows[i]["Title"].ToString());
                    }
                }

            }
        }
        void dtbDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (strButtonState == "EDIT")
            {
                FetchCurrencyGrid(dtbDetail.CurrentCell.RowIndex, dtbDetail.CurrentCell.ColumnIndex);
            }
        }
        private void CalculateAmount()
        {
            lblTotalAmount.Text = "0";
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (dtbDetail.Rows[i].Cells["Amount"].Value != null)
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
            lblTotalAmount.Text = string.Format("{0:0,0}", Convert.ToDouble(lblTotalAmount.Text));
            lblusdAmount.Text = string.Format("{0:0,0}", Convert.ToDouble(lblusdAmount.Text));

        }
        private void frmTransExport_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            General.strTableName[1] = "EX_TransInterBankTransactionDetail";
            General.strTableName[0] = "EX_TransInterBankTransactionMaster";
            General.strPKColumn = "TransNo";
            General.strAuthorizeTableName = General.strTableName[0];
            PopulateCombo();
            AddColumninDetailGrid();
            cls.EnableDisble(PnlMain, false);
            dtbDetail.CellEndEdit += new DataGridViewCellEventHandler(dtbDetail_CellEndEdit);
            dtbDetail.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dtbDetail_EditingControlShowing);
          
            dtbDetail.KeyDown += new KeyEventHandler(dtbDetail_KeyDown);
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            dtbDetail.SelectionChanged += new EventHandler(dtbDetail_SelectionChanged);
            //numEXRAtes.Value = Convert.ToDecimal(dsPopulateCombo.Tables[(int)DataPop.Item].Rows[0]["Description"].ToString());
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

        private void cmdCompleteSale_Click_1(object sender, EventArgs e)
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
        private void dicboPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void frmInterBankTransactions_Activated(object sender, EventArgs e)
        {
            Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }

        private void cstTextBox3_Validating(object sender, CancelEventArgs e)
        {
            dtbDetail.Focus();
            dtbDetail.Rows[0].Cells[0].Selected = false;
            dtbDetail.Rows[0].Cells[1].Selected = true;
        }

        private void dicboPaymentMode_Validated(object sender, EventArgs e)
        {
            DataRow[] dr = new DataRow[0];
            DataTable dtb = dsPopulateCombo.Tables[(int)DataPop.Account];
            dr = dtb.Select("AccountNo = '" + dicboPaymentMode.SelectedValue + "'", "AccountNo");
            dicboCurrency.SelectedValue = dr[0]["CurrencyCode"].ToString();
            dinumConversionRate.Value = Convert.ToDecimal(dr[0]["MinimumRate"].ToString());
            if (dr[0]["CurrencyCode"].ToString() == "304")
            {
                dinumConversionRate.Enabled = false;
            }
            else
            {
                dinumConversionRate.Enabled = true;
            }
    
        }

        private void dinumConversionRate_ValueChanged(object sender, EventArgs e)
        {
            if (dinumConversionRate.Value != 0)
            {
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    if (cls.IsNumeric(dtbDetail.Rows[i].Cells["Quantity"].Value.ToString()) == true && cls.IsNumeric(dtbDetail.Rows[i].Cells["Rate"].Value.ToString()) == true)
                    {
                        dtbDetail.Rows[i].Cells["Amount"].Value = Convert.ToDouble(dtbDetail.Rows[i].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[i].Cells["Rate"].Value);
                        dtbDetail.Rows[i].Cells["EquRate"].Value = (Convert.ToDouble(dtbDetail.Rows[i].Cells["Rate"].Value) * Convert.ToDouble(dinumConversionRate.Value));
                        dtbDetail.Rows[i].Cells["EquAmount"].Value = (Convert.ToDouble(dtbDetail.Rows[i].Cells["Quantity"].Value) * Convert.ToDouble(dtbDetail.Rows[i].Cells["EQuRate"].Value));
                    }
                }
                
            }
        }

        private void cstDateTimePicker1_Validated(object sender, EventArgs e)
        {
            if (dtDealDate.Value < General.dtSystemDate)
            {
                MessageBox.Show("Deal Date Should not be less then Current Date", "Deal Date",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtDealDate.Value = General.dtSystemDate;
                dtDealDate.Focus();
            }
        }

    }
}
