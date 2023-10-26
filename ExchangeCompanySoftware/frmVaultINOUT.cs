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
    public partial class frmVaultINOUT : BaseForm,IToolBar
    {
        enum DataPop { Trans, CustName, Account, Item, ExRate, MainTable };
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataTable dtSearchMaster;
        DataTable dtSearchDetail;
        public string strButtonState = null;
        string strTransType = "VINOUT";
        public string strError = "";
        string strCondition;
        AutoCompleteStringCollection namesCollection =
       new AutoCompleteStringCollection();
 
        public frmVaultINOUT()
        {
            InitializeComponent();
        }
        private void AddColumnToGrid()
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
            clmnRate.Visible = false;

            dtbDetail.Columns.Add(clmnRate);

            DataGridViewTextBoxColumn clmnAmount = new DataGridViewTextBoxColumn();
            clmnAmount.Name = "Amount";
            clmnAmount.HeaderText = "Amount";
            clmnAmount.DefaultCellStyle.Format = "N4";
            clmnAmount.ValueType = typeof(System.Double);
            clmnAmount.DefaultCellStyle.NullValue = "0";
            clmnAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnAmount.Width = 70;
            clmnAmount.Visible = false;
            dtbDetail.Columns.Add(clmnAmount);

            DataGridViewTextBoxColumn clmnTOV = new DataGridViewTextBoxColumn();
            clmnTOV.Name = "TransfertoVault";
            clmnTOV.HeaderText = "TransfertoVault";
            clmnTOV.DefaultCellStyle.Format = "N4";
            clmnTOV.ValueType = typeof(System.Double);
            clmnTOV.DefaultCellStyle.NullValue = "0";
            clmnTOV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnTOV.Width = 70;
            dtbDetail.Columns.Add(clmnTOV);

            DataGridViewTextBoxColumn clmnBal = new DataGridViewTextBoxColumn();
            clmnBal.Name = "Balance";
            clmnBal.HeaderText = "Balance";
            clmnBal.DefaultCellStyle.Format = "N4";
            clmnBal.ValueType = typeof(System.Double);
            clmnBal.DefaultCellStyle.NullValue = "0";
            clmnBal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clmnBal.Width = 70;
            dtbDetail.Columns.Add(clmnBal);

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

        private void frmVaultINOUT_Load(object sender, EventArgs e)
        {
            this.Tag = "T";
            cls = new General();
            General.strTableName[1] = "EX_VaultINOUTDetail";
            General.strTableName[0] = "EX_VaultINOUT";
            General.strPKColumn = "TransNo";
            General.strAuthorizeTableName = General.strTableName[0];
            grpVault.Enabled = false; 
            cls.EnableDisble(PnlMain, false);
            AddColumnToGrid();
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
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
            DataRow[] dr = new DataRow[0];
            if (ditxtTransNo.Text != "" && strButtonState != "ADD" && dtSearchDetail != null)
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
                    dtbDetail.Rows[i].Cells["TransfertoVault"].Value = Convert.ToDecimal(dr[i]["TransfertoVault"].ToString());
                    dtbDetail.Rows[i].Cells["Balance"].Value = Convert.ToDecimal(dr[i]["Balance"].ToString());
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = dr[i]["BranchCode"].ToString();
                }
                if (dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["VINOUT"].Value.ToString() == "IN")
                {
                    rdoIn.Checked = true;
                }
                else
                {
                    rdoOut.Checked = true;
                }
            }
   
        }

        #region IToolBar Members

        public bool ADD()
        {
           
            dtbDetail.Rows.Clear();
            if (dtbDetail.Rows.Count == 0)
            {
                dtbDetail.Rows.Add();
            }
            
           
                ditxtTransNo.Enabled = false;
                strButtonState = "ADD";
                grpVault.Enabled = true;
                ditxtRemarks.Focus();
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
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    dtbDetail.Rows[i].Cells["Sno"].Value = i;
                    dtbDetail.Rows[i].Cells["TransNo"].Value = ditxtTransNo.Text;
                    dtbDetail.Rows[i].Cells["BranchCode"].Value = General.strBranchCode;
                }
            }
            if (strButtonState == "ADD" || strButtonState == "EDIT")
            {
                if (ValidatingControls() == true)
                {
                    string strINOUT = "";
                    if (rdoIn.Checked == true)
                    {
                        strINOUT = "IN";
                    }
                    else if (rdoOut.Checked == true)
                    {
                        strINOUT = "OUT";
                    }
                    strCondition = "Where TransNo = '" + ditxtTransNo.Text + "'";
                    ds = cls.SaveRecord(strButtonState, dtbDetail, General.strTableName, PnlMain, strTransType, strCondition, "Posted=false;BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + ";VINOUT=" + strINOUT + "");
                    dtbMaster.DataSource = ds.Tables[0];
                    //dtSearchDetail = ds.Tables[1];
                    cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
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
            ditxtTransNo.Enabled = false;
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
            strQuery = "Select * from EX_VaultINOUT a " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "' AND Posted = 'false' ";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate + "'";
            }
            strQuery = strQuery +  " ;Select c.RecNo,SNO,c.ItemCode,ItemName,ShortName,Quantity,Rate,Amount,TransfertoVault,Balance,c.TransNo,c.BranchCode from EX_VaultINOUTDetail c Inner Join EX_VaultINOUT a on a.TransNo = c.TransNo and a.RecNo = c.RecNo Inner Join EX_SetupItems b on c.ItemCode = b.ItemCode and b.Status = 'A'";
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
            strButtonState = "QUERY";
            dtbMaster_SelectionChanged(dtbMaster, null);
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
     
            return true;
        }

        #endregion
        private void GenerateVoucherNo()
        {
            string strTransNo = string.Format("{0:D5}", Convert.ToInt32(cls.GetTransNo(strTransType)));
            ditxtTransNo.Text = strTransType + "-" + strTransNo + "-" + General.strBranchCode;
        }
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
       
            return bolState;
        }
        private void VaultINOUT(string strINOUT)
        {
            DataSet ds = new DataSet();
            DataTable dtb = new DataTable();
            string strQuery;
            string strQueryHand;
            if (strButtonState == "ADD" ||strButtonState == "EDIT")
            {
                if (strINOUT == "IN")
                {
                    strQueryHand = "Select Round(Sum(case When Flag = 'D' then Debit else - Credit end),0) as CashinHand from EX_PrsTransactions a";
                    strQueryHand = strQueryHand + " Where AccountNo in ((Select Cashinhand From EX_ControlAccounts Where BranchCode = a.BranchCode)) and BranchCode = '" + General.strBranchCode + "' and Status = 'A' and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + General.dtSystemDate + "' ";
                }
                else
                {
                    strQueryHand = "Select Round(Sum(case When Flag = 'D' then Debit else - Credit end),0) as CashinHand from EX_PrsTransactions a";
                    strQueryHand = strQueryHand + " Where AccountNo in ((Select Cashinvault From EX_ControlAccounts Where BranchCode = a.BranchCode)) and BranchCode = '" + General.strBranchCode + "' and Status = 'A' and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + General.dtSystemDate + "' ";
                }

               strQuery = "SELECT     b.ItemName, b.ShortName, b.ItemCode, c.Title, a.BranchCode, ROUND(Abs(SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE - Quantity END)), ";
               strQuery = strQuery + " 4) AS Quantity, ROUND(CASE WHEN SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE - Quantity END)  ";
               strQuery = strQuery + " > 0 THEN SUM(CASE WHEN Flag = 'D' THEN Debit ELSE - Credit END) / SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE - Quantity END) ELSE 0 END,  ";
               strQuery = strQuery + " 5) AS AvgRate, ROUND(Abs(SUM(CASE WHEN Flag = 'D' THEN Debit ELSE - Credit END)), 4) AS Amount, a.BranchCode AS Expr1 ";
               strQuery = strQuery + " FROM         dbo.EX_PrsTransactions AS a INNER JOIN ";
               strQuery = strQuery + " dbo.EX_SetupItems AS b ON a.CurrencyCode = b.ItemCode AND b.Status = 'A' INNER JOIN ";
               strQuery = strQuery + " dbo.EX_SetupAccount AS c ON a.AccountNo = c.AccountNo AND a.BranchCode = c.BranchCode AND c.Status = 'A' ";
               strQuery = strQuery + " WHERE     (a.CurrencyCode NOT IN ('304')) AND (a.Status = 'A') ";
               strQuery = strQuery + " and a.BranchCode = '"+ General.strBranchCode +"' and a.TransDate <= '"+ General.dtSystemDate +"'"; 

                if (strINOUT == "IN")
                {
                    strQuery = strQuery + " and a.AccountNo in (Select PurchaseSale From EX_ControlAccounts Where BranchCode = a.BranchCode)";
                    strQuery = strQuery + " GROUP BY b.ItemName, c.Title, b.ShortName, b.ItemCode,a.BranchCode ,a.AccountNo";
                    strQuery = strQuery + " having Round(SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE - Quantity END),4) != 0 ";
                }
                else
                {
                    strQuery = strQuery + "and a.AccountNo in (Select FCINVAULT From EX_ControlAccounts Where BranchCode = a.BranchCode) ";
                    strQuery = strQuery + " GROUP BY b.ItemName, c.Title, b.ShortName, b.ItemCode,a.BranchCode ";
                    strQuery = strQuery + " having Round(SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE - Quantity END),4) != 0 ";

                }
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                ds = objGetData.GetDataSet(strQuery + ";" + strQueryHand);
                dtb = ds.Tables[0];
                dtbDetail.Rows.Clear();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dtbDetail.Rows.Add();
                    dtbDetail.Rows[i].Cells["Symbol"].Value = dtb.Rows[i]["ShortName"];
                    dtbDetail.Rows[i].Cells["ItemName"].Value = dtb.Rows[i]["ItemName"];
                    dtbDetail.Rows[i].Cells["ItemCode"].Value = dtb.Rows[i]["ItemCode"];
                    dtbDetail.Rows[i].Cells["Quantity"].Value = dtb.Rows[i]["Quantity"];
                    dtbDetail.Rows[i].Cells["Rate"].Value = dtb.Rows[i]["AvgRate"];
                    dtbDetail.Rows[i].Cells["Amount"].Value = dtb.Rows[i]["Amount"];
                    dtbDetail.Rows[i].Cells["TransfertoVault"].Value = dtb.Rows[i]["Quantity"];

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["CashinHand"].ToString() != "")
                    {
                        if (Convert.ToDecimal(ds.Tables[1].Rows[0]["CashinHand"].ToString()) >= 0)
                        {
                            donumCashinHand.Value = Convert.ToDecimal(ds.Tables[1].Rows[0]["CashinHand"].ToString());
                        }
                        else
                        {
                            donumCashinHand.Value = 0;
                        }
                    }
                }
                
            }
        }
        private void rdoIn_CheckedChanged(object sender, EventArgs e)
        {
            if (strButtonState == "ADD" || strButtonState == "EDIT")
            {
                if (rdoIn.Checked == true)
                {
                    //DataSet ds = new DataSet();
                    //DataTable dtb = new DataTable();
                    //string strQuery = " Select * from EX_Revaluetion Where TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = '" + General.strBranchCode + "' and Status = 'A'";
                    //objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                    //ds = objGetData.GetDataSet(strQuery);
                    //dtb = ds.Tables[0];
                    //if (dtb.Rows.Count != 0)
                    //{
                        VaultINOUT("IN");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Kindly Enter the Spot Rates", "Revaluation",
                    //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    MainForm Mainfrm = (MainForm)this.ParentForm;
                    //    Mainfrm.EnableDisbale(strButtonState, true, "S");
                    //    cls.EnableDisble(PnlMain, false);
                    //}
                }
            }
        }

        private void dtbDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value.ToString() != "" && dtbDetail.Rows[e.RowIndex].Cells["TransfertoVault"].Value.ToString() != "")
            {
                if (Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) >= Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["TransfertoVault"].Value))
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Balance"].Value = Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["Quantity"].Value) - Convert.ToDouble(dtbDetail.Rows[e.RowIndex].Cells["TransfertoVault"].Value);
                }
                else
                {
                    dtbDetail.Rows[e.RowIndex].Cells["TransfertoVault"].Value = 0;
                    MessageBox.Show("InSufficent Quantity of " + dtbDetail.Rows[e.RowIndex].Cells["ItemName"].Value.ToString() + "On Counter");
                }
            }
           
        }

        private void rdoOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOut.Checked == true)
            {
                VaultINOUT("OUT");
            }
        }

        private void frmVaultINOUT_Activated(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }
    }

}
