using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using ExchangeCompanySoftware.GetData;

namespace ExchangeCompanySoftware
{
    public partial class frmCurrencyPosition : BaseForm, IToolBar
    {
       
        string strQuery;
        DataSet ds;
        DataTable dtb;
        PivotGridField fd5;
       
        public frmCurrencyPosition()
        {
            InitializeComponent();
        }

        #region IToolBar Members

        public bool ADD()
        {
           return true;
        }

        public bool SAVE()
        {
           return true;
        }

        public bool EDIT()
        {
           return true;
        }

        public bool QUERY()
        {
           return true;
        }

        public bool UNDO()
        {
           return true;
        }

        public bool EXIT()
        {
           return true;
        }

        public bool DELETE()
        {
           return true;
        }

        public bool NEXT()
        {
           return true;
        }

        public bool PREVIOUS()
        {
           return true;
        }

        public bool LAST()
        {
           return true;
        }

        public bool FIRST()
        {
           return true;
        }

        public bool AUTHORIZE()
        {
           return true;
        }

        public bool PRINT()
        {
           return true;
        }

        #endregion
        private void PopulateCurrencyPosition()
        {
            string strQuery2="";
            try
            {
                ds = new DataSet();
                //strQuery = " Select ";
                //strQuery = strQuery + " ItemCode,ItemName,ShortName,";
                //strQuery = strQuery + " Round(Sum(case When Flag = 'D' then Quantity else -Quantity end),4) as Quantity, ";
                //strQuery = strQuery + " Round(case When Sum(case When Flag = 'D' then Quantity else -Quantity end) > 0 then ";
                //strQuery = strQuery + " Sum(case When Flag = 'D' then Debit else -Credit end)/ ";
                //strQuery = strQuery + " Sum(case When Flag = 'D' then Quantity else -Quantity end) else 0 end,4) as AvgRate , ";
                //strQuery = strQuery + " Round(Sum(case When Flag = 'D' then Debit else -Credit end),0) as Amount ";
                //strQuery = strQuery + " from EX_PrsTransactions a Inner Join EX_SetupAccount b on a.AccountNo = b.AccountNo  ";
                //strQuery = strQuery + " and a.BRanchCode = b.BranchCode and b.Status = 'A' ";
                //strQuery = strQuery + " Inner Join EX_SetupItems c on a.CurrencyCode = c.ItemCode and c.Status = 'A' Where a.Status = 'A' ";
                string strBranch="";
                for (int i = 0; i < dtbBranch.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtbBranch.Rows[i].Cells[0].Value) == true)
                    {
                        //if (dtbBranch.Rows[i].Cells[2].Value.ToString() != "35")
                        //{
                            strBranch = strBranch + "'" + dtbBranch.Rows[i].Cells[2].Value + "',";
                        //}
                        //else
                        //{
                        //    // strQuery2 = " Select ";
                        //    //strQuery2 = strQuery2 + " a.AccountNo,Title,";
                        //    //strQuery2 = strQuery2 + " Round(Sum(case When Flag = 'D' then Quantity else -Quantity end),4) as Quantity, ";
                        //    //strQuery2 = strQuery2 + " Round(case When Sum(case When Flag = 'D' then Quantity else -Quantity end) > 0 then ";
                        //    //strQuery2 = strQuery2 + " Sum(case When Flag = 'D' then Debit else -Credit end)/ ";
                        //    //strQuery2 = strQuery2 + " Sum(case When Flag = 'D' then Quantity else -Quantity end) else 0 end,4) as AvgRate , ";
                        //    //strQuery2 = strQuery2 + " Round(Sum(case When Flag = 'D' then Debit else -Credit end),0) as Amount ";
                        //    //strQuery2 = strQuery2 + " from EX_PrsTransactions a Inner Join EX_SetupAccount b on a.AccountNo = b.AccountNo  ";
                        //    //strQuery2 = strQuery2 + " and a.BRanchCode = b.BranchCode and b.Status = 'A' ";
                        //    //strQuery2 = strQuery2 + " Inner Join EX_SetupItems c on a.CurrencyCode = c.ItemCode and c.Status = 'A' Where a.Status = 'A' ";
                        //    //strQuery2 = strQuery2 + " and a.BranchCode in ('35') and a.CurrencyCode != '304' and a.Transdate <= '" + dtSystemDate.Value + "' ";
                        //    //strQuery2 = strQuery2 + " Group by ";   
                        //    //strQuery2 = strQuery2 + " a.AccountNo,Title";
                        //    //strQuery2 = strQuery2 + " having Round(Sum(case When Flag = 'D' then Quantity else -Quantity end),4) != 0 and Round(Sum(case When Flag = 'D' then Debit else -Credit end),0) != 0 ";
                        //}
                    }
                }
                if (strBranch != "")
                {
                    strBranch = strBranch.Substring(0, strBranch.Length - 1);                    
                }
                //strQuery = strQuery + " and a.BranchCode in ("+ strBranch +") and a.CurrencyCode != '304' and a.Transdate <= '" + dtSystemDate.Value + "' ";
                //strQuery = strQuery + " Group by ";
                //strQuery = strQuery + " ItemName,ShortName,ItemCode";
                //strQuery = strQuery + " having Round(Sum(case When Flag = 'D' then Quantity else -Quantity end),4) != 0 and Round(Sum(case When Flag = 'D' then Debit else -Credit end),0) != 0 ";


                General cls = new General();

                //if (strQuery2 != "")
                //{
                //    if (strBranch == "")
                //    {
                //        ds = objGetData.GetDataSet(strQuery2);
                //    }
                //    else
                //    {
                //        ds = objGetData.GetDataSet(strQuery + ";" + strQuery2);
                //    }

                //}
                //else
                //{
                strBranch = General.strBranchCode;
                DateTime dt = Convert.ToDateTime(dtSystemDate.Value);
                strQuery2 = " Select ";
                strQuery2 = strQuery2 + " b.Title,ItemName,BranchName,";
                strQuery2 = strQuery2 + " Round(Sum(case When Flag = 'D' then Quantity else -Quantity end),4) as Quantity, ";
                strQuery2 = strQuery2 + " Round(case When Sum(case When Flag = 'D' then Quantity else -Quantity end) <> 0 then ";
                strQuery2 = strQuery2 + " Sum(case When Flag = 'D' then Debit else -Credit end)/ ";
                strQuery2 = strQuery2 + " Sum(case When Flag = 'D' then Quantity else -Quantity end) else 0 end,4) as AvgRate , ";
                strQuery2 = strQuery2 + " Round(Sum(case When Flag = 'D' then Debit else -Credit end),0) as Amount ";
                strQuery2 = strQuery2 + " from EX_PrsTransactions a Inner Join EX_SetupAccount b on a.AccountNo = b.AccountNo  ";
                strQuery2 = strQuery2 + " and a.BRanchCode = b.BranchCode and b.Status = 'A' ";
                strQuery2 = strQuery2 + " Inner Join EX_SetupItems c on a.CurrencyCode = c.ItemCode and c.Status = 'A' ";
                strQuery2 = strQuery2 + " Inner Join EX_Branch d on a.BranchCode = d.BranchCode ";
                strQuery2 = strQuery2 + " Where a.Status = 'A' ";
                strQuery2 = strQuery2 + " and a.BranchCode in (" + strBranch + ") and a.CurrencyCode != '304' and a.Transdate <= '" + dt.ToString("dd-MMM-yyyy") + "' ";
                strQuery2 = strQuery2 + " Group by ";
                strQuery2 = strQuery2 + " ItemName,b.Title,BranchName";
                strQuery2 = strQuery2 + " having Round(Sum(case When Flag = 'D' then Quantity else -Quantity end),4) != 0 and Round(Sum(case When Flag = 'D' then Debit else -Credit end),0) != 0 ";
                ds = cls.GetDataSet(strQuery2);
                //}
                
                DataTable dtb = ds.Tables[0];
                pivotGridControl1.DataSource = dtb;
                //dtbCurrency.Rows.Clear();

                //for (int i = 0; i < dtb.Rows.Count; i++)
                //{
                //    dtbCurrency.Rows.Add();
                //    dtbCurrency.Rows[i].Cells["Currency"].Value = dtb.Rows[i][1].ToString();
                //    dtbCurrency.Rows[i].Cells["Quantity"].Value = string.Format("{0:0,0.0000}", Convert.ToDouble(dtb.Rows[i]["Quantity"].ToString()));
                //    dtbCurrency.Rows[i].Cells["Rate"].Value = string.Format("{0:0,0.0000}", Convert.ToDouble(dtb.Rows[i]["AvgRate"].ToString()));
                //    dtbCurrency.Rows[i].Cells["Amount"].Value = string.Format("{0:0,0.0000}", Convert.ToDouble(dtb.Rows[i]["Amount"].ToString()));
                //}
                //if (ds.Tables.Count > 1)
                //{
                //    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                //    {
                //        dtbCurrency.Rows.Add();
                //        dtbCurrency.Rows[dtbCurrency.Rows.Count - 1].Cells["Currency"].Value = ds.Tables[1].Rows[i][1].ToString();
                //        dtbCurrency.Rows[dtbCurrency.Rows.Count - 1].Cells["Quantity"].Value = string.Format("{0:0,0.0000}", Convert.ToDouble(dtb.Rows[i]["Quantity"].ToString()));
                //        dtbCurrency.Rows[dtbCurrency.Rows.Count - 1].Cells["Rate"].Value = string.Format("{0:0,0.0000}", Convert.ToDouble(dtb.Rows[i]["AvgRate"].ToString()));
                //        dtbCurrency.Rows[dtbCurrency.Rows.Count - 1].Cells["Amount"].Value = string.Format("{0:0,0.0000}", Convert.ToDouble(dtb.Rows[i]["Amount"].ToString()));
                //    }
                //}

             

                strQuery = "Select Round(Sum(case When Flag = 'D' then Debit else - Credit end),2) as CashinHand from EX_PrsTransactions a";
                strQuery = strQuery + " Where AccountNo in ((Select Cashinhand From EX_ControlAccounts Where BranchCode = a.BranchCode)) and BranchCode in (" + strBranch + ") and Status = 'A' and a.TransDate <= '" + dt.ToString("dd/MMM/yyyy") + "'";
                string strQuery1 = "Select Round(Sum(case When Flag = 'D' then Debit else - Credit end),2) as CashinHand from EX_PrsTransactions a";
                strQuery1 = strQuery1 + " Where AccountNo in ((Select Cashinvault From EX_ControlAccounts Where BranchCode = a.BranchCode)) and BranchCode in (" + strBranch + ") and Status = 'A' and BranchCode in (" + strBranch + ") and a.TransDate <= '" + dt.ToString("dd/MMM/yyyy") + "' ";

                ds = cls.GetDataSet(strQuery + ";" + strQuery1);
               
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblCashinHand.Text = ds.Tables[0].Rows[0]["CashinHand"].ToString();
                }
                lblCashinHand.Text = string.Format("{0:0,0}", Convert.ToDouble(lblCashinHand.Text));

              //  CalculateAmount();
              //  DrawPivotTable();
            }
            catch (Exception ex)
            {
            }
        }
        private void DrawPivotTable()
        {
            string strQuery2 = " Select ";
            strQuery2 = strQuery2 + " b.Title,ItemName,";
            strQuery2 = strQuery2 + " Round(Sum(case When Flag = 'D' then Quantity else -Quantity end),4) as Quantity, ";
            strQuery2 = strQuery2 + " Round(case When Sum(case When Flag = 'D' then Quantity else -Quantity end) <> 0 then ";
            strQuery2 = strQuery2 + " Sum(case When Flag = 'D' then Debit else -Credit end)/ ";
            strQuery2 = strQuery2 + " Sum(case When Flag = 'D' then Quantity else -Quantity end) else 0 end,4) as AvgRate , ";
            strQuery2 = strQuery2 + " Round(Sum(case When Flag = 'D' then Debit else -Credit end),0) as Amount ";
            strQuery2 = strQuery2 + " from EX_PrsTransactions a Inner Join EX_SetupAccount b on a.AccountNo = b.AccountNo  ";
            strQuery2 = strQuery2 + " and a.BRanchCode = b.BranchCode and b.Status = 'A' ";
            strQuery2 = strQuery2 + " Inner Join EX_SetupItems c on a.CurrencyCode = c.ItemCode and c.Status = 'A' Where a.Status = 'A' ";
            strQuery2 = strQuery2 + " and a.BranchCode in ('"+ General.strBranchCodeFrom +"') and a.CurrencyCode != '304' and a.Transdate <= '" + dtSystemDate.Value.ToString("dd/MMM/yyyy") + "' ";
            strQuery2 = strQuery2 + " Group by ";
            strQuery2 = strQuery2 + " ItemName,b.Title";
            strQuery2 = strQuery2 + " having Round(Sum(case When Flag = 'D' then Quantity else -Quantity end),4) != 0 and Round(Sum(case When Flag = 'D' then Debit else -Credit end),0) != 0 ";
            General cls = new General();
            ds = cls.GetDataSet(strQuery2);

            //pivotGridControl1.Fields.Clear();
            //if (pivotGridControl1 == null) return;

            //fd5 = new PivotGridField();
            //fd5.FieldName = "Amount";
            //fd5.Caption = "Amount";
            //fd5.SortOrder = PivotSortOrder.Ascending;
            //fd5.SetAreaPosition(PivotArea.DataArea, 2);
            //fd5.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            //fd5.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            //fd5.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum;
            //fd5.Width = 100;
            //pivotGridControl1.Fields.Add(fd5);

            //PivotGridField fd8 = new PivotGridField();
            //fd8.FieldName = "AvgRate";
            //fd8.Caption = "Rate";
            //fd8.SortOrder = PivotSortOrder.Ascending;
            //fd8.SetAreaPosition(PivotArea.DataArea, 1);
            //fd8.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            //fd8.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            //fd8.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average;
            //fd8.Width = 70;
            //pivotGridControl1.Fields.Add(fd8);


           
            //PivotGridField fd = new PivotGridField();
            //fd.FieldName = "Quantity";
            //fd.Caption = "Quantity";
            //fd.SortOrder = PivotSortOrder.Ascending;
            //fd.SetAreaPosition(PivotArea.DataArea, 0);
            //fd.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            //fd.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            //fd.Width = 70;
            //pivotGridControl1.Fields.Add(fd);


            //PivotGridField fd1 = new PivotGridField();
            //fd1.FieldName = "Title";
            //fd1.Caption = "Account";
            //fd1.SortOrder = PivotSortOrder.Ascending;
            //fd1.SetAreaPosition(PivotArea.ColumnArea, 0);
            //fd1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            //fd1.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            //fd1.Width = 120;
            //pivotGridControl1.Fields.Add(fd1);

            //PivotGridField fd4 = new PivotGridField();
            //fd4.FieldName = "ItemName";
            //fd4.Caption = "Currency Name";
            //fd4.SortOrder = PivotSortOrder.Ascending;
            //fd4.SetAreaPosition(PivotArea.RowArea, 0);
            //fd4.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            //fd4.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            //fd4.Width = 100;
            //pivotGridControl1.Fields.Add(fd4);
            //pivotGridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            pivotGridControl1.DataSource = ds.Tables[0];
        }
        private void frmCurrencyPosition_Load(object sender, EventArgs e)
        {
            dtbMaster.Visible = false;
            statusStrip1.Visible = false;
            dtSystemDate.Value = General.dtSystemDate;
            General cls = new General();
            ds = new DataSet();
            strQuery = " Select * from EX_Branch";
         
            ds =cls.GetDataSet(strQuery);
            DataTable dtb = ds.Tables[0];
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                dtbBranch.Rows.Add();
                dtbBranch.Rows[i].Cells[0].Value = "False";
                dtbBranch.Rows[i].Cells[1].Value = dtb.Rows[i]["BranchName"];
                dtbBranch.Rows[i].Cells[2].Value = dtb.Rows[i]["BranchCode"];
            }
            dtbBranch.Visible = false;
            if (General.strBranchCode == "35")
            {
                dtbBranch.Visible = true;
            }
            for (int i = 0; i < dtbBranch.Rows.Count; i++)
            {
                if (dtbBranch.Rows[i].Cells[2].Value.ToString() == General.strBranchCode.ToString())
                {
                    dtbBranch.Rows[i].Cells[0].Value = "true";
                }
            }
            PopulateCurrencyPosition();
            //Timer tm = new Timer();
            //tm.Interval = 9000;
            //tm.Enabled = true;
            //tm.Tick += new EventHandler(tm_Tick);
        }

        void tm_Tick(object sender, EventArgs e)
        {
            //PopulateCurrencyPosition();
        }

        private void pivotGridControl1_CustomSummary(object sender, PivotGridCustomSummaryEventArgs e)
        {
          
        }

        private void dtSystemDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateCurrencyPosition();
        }

        private void dtbCurrency_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex != -1))
            {
                // fill gradient background
                Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                e.CellBounds, Color.LightGray, Color.White,
                System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
                gradientBrush.Dispose();

                // paint rest of cell
                e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
                DataGridViewPaintParts.ContentForeground);
                e.Handled = true;
            }
            else
            {
                Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                e.CellBounds, Color.Orange, Color.Yellow,
                System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
                gradientBrush.Dispose();

                // paint rest of cell
                e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
                DataGridViewPaintParts.ContentForeground);
                e.Handled = true;

            }
        }
        //private void CalculateAmount()
        //{
        //    lblTotalAmount.Text = "0";
        //    for (int i = 0; i <  dtbCurrency.Rows.Count; i++)
        //    {
        //        if (Convert.ToDouble(lblTotalAmount.Text) == Convert.ToDouble("0"))
        //        {
        //            lblTotalAmount.Text = dtbCurrency.Rows[i].Cells["Amount"].Value.ToString();
        //        }
        //        else
        //        {
        //            lblTotalAmount.Text =
        //                (Convert.ToDouble(lblTotalAmount.Text) +
        //                Convert.ToDouble(dtbCurrency.Rows[i].Cells["Amount"].Value)).ToString();
        //        }
        //    }

        //    decimal d = Math.Round(Convert.ToDecimal(lblTotalAmount.Text.ToString()), 0);
        //    lblTotalAmount.Text = d.ToString();
        //    lblTotalAmount.Text = string.Format("{0:0,0}", Convert.ToDouble(lblTotalAmount.Text));

        //}
  
        private void dtbBranch_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtbBranch.IsCurrentCellDirty)
            {
                dtbBranch.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtbBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateCurrencyPosition();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pivotGridControl1.OptionsPrint.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            pivotGridControl1.OptionsPrint.PageSettings.Landscape = true;
            pivotGridControl1.OptionsPrint.PageSettings.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            pivotGridControl1.ShowPrintPreview();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string sD1 = dtSystemDate.Value.ToString("dd-MMM-yyyy");
            string sD2 = General.dtSystemDate.ToString("dd-MMM-yyyy");


            if (sD1 == sD2)
            {
                General cls = new General();
                string strQuery = "Exec sp_IndexSale " + General.strBranchCode + ",'" + dtSystemDate.Value.ToString("dd/MMM/yyyy") + "'";
                cls.ExecuteDML(strQuery);

            }
            PopulateCurrencyPosition();
        }

        private void pivotGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void pivotGridControl1_FieldAreaChanged(object sender, PivotFieldEventArgs e)
        {

        }

        private void pivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
        {
            
        }

        private void pivotGridControl1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pivotGridControl1_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void pivotGridControl1_CustomDrawCell(object sender, PivotCustomDrawCellEventArgs e)
        {
            if (e.DataField.FieldName == "Quantity"  && (decimal)e.GetFieldValue(e.DataField) < 0)
            {
                e.Appearance.DrawBackground(e.GraphicsCache, e.Bounds);
                e.Appearance.DrawString(e.GraphicsCache, e.DisplayText, e.Bounds, e.Appearance.Font, Brushes.Red,
                e.Appearance.GetStringFormat());
                e.Handled = true;
            }
            if (e.DataField.FieldName == "Amount" && (decimal)e.GetFieldValue(e.DataField) < 0)
            {
                e.Appearance.DrawBackground(e.GraphicsCache, e.Bounds);
                e.Appearance.DrawString(e.GraphicsCache, e.DisplayText, e.Bounds, e.Appearance.Font, Brushes.Red,
                e.Appearance.GetStringFormat());
                e.Handled = true;
            }

        }
    }
}
