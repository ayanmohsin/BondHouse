using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExchangeCompanySoftware.Reports;

namespace ExchangeCompanySoftware
{
    public partial class frmBarCode : BaseForm,IToolBar
    {
        General cls;
        DataSet dsPopulateCombo;
        GetData.ServiceSoapClient objGetData;
        public frmBarCode()
        {
            InitializeComponent();
        }
        private void PopulateCombo()
        {
            cls = new General();
            string strQuery = "Select * from EX_SetupItems Where Locked = 'False' and Status = 'A';Select * from EX_SetupCategory";
            dsPopulateCombo = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);

            AutoCompleteStringCollection BarCode = new AutoCompleteStringCollection();
            AutoCompleteStringCollection ItemName = new AutoCompleteStringCollection();
            AutoCompleteStringCollection ShortName = new AutoCompleteStringCollection();;
            AutoCompleteStringCollection ItemCode = new AutoCompleteStringCollection();

            cls.PopulateCombo(docboCategory, dsPopulateCombo.Tables[1], "Category", "Code");
            foreach (DataRow row in dsPopulateCombo.Tables[0].Rows)
            {

                BarCode.Add(row["BarCode"].ToString());
                ItemName.Add(row["ItemName"].ToString());
                ShortName.Add(row["ShortName"].ToString());
                ItemCode.Add(row["ItemCode"].ToString());            
            }
            dotxtCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            dotxtCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            dotxtCode.AutoCompleteCustomSource = ItemCode;
            
            txtBarCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBarCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBarCode.AutoCompleteCustomSource = BarCode;
            
            dotxtItemNAme.AutoCompleteMode = AutoCompleteMode.Suggest;
            dotxtItemNAme.AutoCompleteSource = AutoCompleteSource.CustomSource;
            dotxtItemNAme.AutoCompleteCustomSource = ItemName;
            
            dotxtSName.AutoCompleteMode = AutoCompleteMode.Suggest;
            dotxtSName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            dotxtSName.AutoCompleteCustomSource = ShortName;

            ditxtBarCodeFrom.AutoCompleteMode = AutoCompleteMode.Suggest;
            ditxtBarCodeFrom.AutoCompleteSource = AutoCompleteSource.CustomSource;
            ditxtBarCodeFrom.AutoCompleteCustomSource = BarCode;

            ditxtBarCodeTo.AutoCompleteMode = AutoCompleteMode.Suggest;
            ditxtBarCodeTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            ditxtBarCodeTo.AutoCompleteCustomSource = BarCode;
            
        }
        private void CalculateAmount()
        {
            lblQty.Text = "0";


            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (Convert.ToDecimal(lblQty.Text) == Convert.ToDecimal("0"))
                {

                    if (dtbDetail.Rows[i].Cells["Quantity"].Value == null)
                    {
                        dtbDetail.Rows[i].Cells["Quantity"].Value = "0";
                    }
                    lblQty.Text = Convert.ToDecimal(dtbDetail.Rows[i].Cells["Quantity"].Value).ToString();

                }
                else
                {

                    if (dtbDetail.Rows[i].Cells["Quantity"].Value == null)
                    {
                        dtbDetail.Rows[i].Cells["Quantity"].Value = "0";
                    }
                    lblQty.Text = (Convert.ToDecimal(lblQty.Text) + Convert.ToDecimal(dtbDetail.Rows[i].Cells["Quantity"].Value)).ToString();

                }

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtb = new DataTable();
          
            dtb.Columns.Add("ItemCode");
            dtb.Columns.Add("SaleRateCRP");
            dtb.Columns.Add("ShortName");
            dtb.Columns.Add("CompanyName");
            int intRow = 0;
            
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                for (int ir = 0; ir < Convert.ToInt32(dtbDetail.Rows[i].Cells["Quantity"].Value); ir++)
                {
                    if (dtb.Rows.Count >= 1)
                    {
                        intRow = dtb.Rows.Count;
                    }
                    dtb.Rows.Add();
                    dtb.Rows[intRow]["ItemCode"] = dtbDetail.Rows[i].Cells["BarCode"].Value;
                    dtb.Rows[intRow]["ShortName"] = dtbDetail.Rows[i].Cells["Symbol"].Value;
                    dtb.Rows[intRow]["SaleRateCrp"] = dtbDetail.Rows[i].Cells["SaleRateCrp"].Value;
                    dtb.Rows[intRow]["CompanyName"] = General.strCompanyName;
                }
            }
            xrBarcode devrep = new xrBarcode();
            devrep.Margins = new System.Drawing.Printing.Margins(30, 30, 15, 29);
            devrep.PaperKind = System.Drawing.Printing.PaperKind.A4;

            devrep.DataSource = dtb;
            devrep.RequestParameters = false;
            devrep.CreateDocument();
            devrep.PrintingSystem.Document.AutoFitToPagesWidth = 1;
            devrep.ShowPreview();
        }

        #region IToolBar Members

        public bool ADD()
        {
            throw new NotImplementedException();
        }

        public bool SAVE()
        {
            throw new NotImplementedException();
        }

        public bool EDIT()
        {
            throw new NotImplementedException();
        }

        public bool QUERY()
        {
            throw new NotImplementedException();
        }

        public bool UNDO()
        {
            throw new NotImplementedException();
        }

        public bool EXIT()
        {
            throw new NotImplementedException();
        }

        public bool DELETE()
        {
            throw new NotImplementedException();
        }

        public bool NEXT()
        {
            throw new NotImplementedException();
        }

        public bool PREVIOUS()
        {
            throw new NotImplementedException();
        }

        public bool LAST()
        {
            throw new NotImplementedException();
        }

        public bool FIRST()
        {
            throw new NotImplementedException();
        }

        public bool AUTHORIZE()
        {
            throw new NotImplementedException();
        }

        public bool PRINT()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void cstTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void frmBarCode_Load(object sender, EventArgs e)
        {
            AddColumninDetailGrid();
            PopulateCombo();
            dtbMaster.Visible = false;
            txtStatus.Visible = false;
        }

        private void txtBarCode_Validating(object sender, CancelEventArgs e)
        {
           

        }

        private void AddColumninDetailGrid()
        {
            DataGridViewTextBoxColumn clmnBarCode = new DataGridViewTextBoxColumn();
            clmnBarCode.Name = "BarCode";
            clmnBarCode.HeaderText = "BarCode";
            clmnBarCode.Width = 70;
            dtbDetail.Columns.Add(clmnBarCode);


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

            DataGridViewTextBoxColumn clmnitSale = new DataGridViewTextBoxColumn();
            clmnitSale.Name = "SaleRateCRP";
            clmnitSale.HeaderText = "SaleRate";
            clmnitSale.Width = 0;
            clmnitSale.Visible = false;
            dtbDetail.Columns.Add(clmnitSale);

        }
        
        private void txtBarCode_Validated(object sender, EventArgs e)
        {
            DataTable dtb = new DataTable();
            dtb = dsPopulateCombo.Tables[0];

            if (txtBarCode.Text != "")
            {
                DataRow[] dRow = dtb.Select("Barcode= '" + txtBarCode.Text + "'");
                if (dRow.Count() > 0)
                {
                    dotxtItemNAme.Text = dRow[0]["ItemName"].ToString();
                    dotxtCode.Text = dRow[0]["ItemCode"].ToString();
                    dotxtSName.Text = dRow[0]["ShortName"].ToString();
                    txtSaleRate.Text = dRow[0]["SaleRateCRP"].ToString();

                    dotxtQty.Focus();
                }
                else
                {
                    dotxtItemNAme.Text = "";
                    dotxtCode.Text = "";
                    dotxtSName.Text = "";
                    txtBarCode.Text = "";
                    txtSaleRate.Text = "";
                }
            }

        }

        private void btnAddToGrid_Click(object sender, EventArgs e)
        {
            int intRows=0;
            dtbDetail.Rows.Add();
            if (dtbDetail.Rows.Count > 1)
            {
                intRows = dtbDetail.Rows.Count - 1;
            }
            dtbDetail.Rows[intRows].Cells["BarCode"].Value = txtBarCode.Text;
            dtbDetail.Rows[intRows].Cells["ItemCode"].Value = dotxtCode.Text;
            dtbDetail.Rows[intRows].Cells["Symbol"].Value = dotxtSName.Text;
            dtbDetail.Rows[intRows].Cells["itemName"].Value = dotxtItemNAme.Text;
            dtbDetail.Rows[intRows].Cells["Quantity"].Value = dotxtQty.Text;
            dtbDetail.Rows[intRows].Cells["SaleRateCRP"].Value = txtSaleRate.Text;

            CalculateAmount();
        }

        private void btnRange_Click(object sender, EventArgs e)
        {
            DataTable dtb = new DataTable();
            dtb = dsPopulateCombo.Tables[0];
            string strQuery = "Barcode >= '" + ditxtBarCodeFrom.Text + "' and Barcode <= '" + ditxtBarCodeTo.Text + "'";
            DataRow[] dRow = dtb.Select(strQuery);

            int intRows = 0;
                for (int i = 0; i < dRow.Count(); i++)
                {
                    dtbDetail.Rows.Add();
                    dtbDetail.Rows[intRows].Cells["BarCode"].Value = dRow[i]["Barcode"].ToString();
                    dtbDetail.Rows[intRows].Cells["ItemName"].Value = dRow[i]["ItemName"].ToString();
                    dtbDetail.Rows[intRows].Cells["ItemCode"].Value = dRow[i]["ItemCode"].ToString();
                    dtbDetail.Rows[intRows].Cells["Symbol"].Value = dRow[i]["ShortName"].ToString();
                    dtbDetail.Rows[intRows].Cells["Quantity"].Value = "1";
                    dtbDetail.Rows[intRows].Cells["SaleRateCrp"].Value = dRow[i]["SaleRateCrp"].ToString();
                
                    intRows = intRows + 1;    

                }
                CalculateAmount();
            

        }

        private void dotxtItemNAme_Validated(object sender, EventArgs e)
        {
            DataTable dtb = new DataTable();
            dtb = dsPopulateCombo.Tables[0];

            if (txtBarCode.Text != "")
            {
                DataRow[] dRow = dtb.Select("ItemName= '" + dotxtItemNAme.Text + "'");
                if (dRow.Count() > 0)
                {
                    txtBarCode.Text = dRow[0]["BarCode"].ToString();
                    dotxtCode.Text = dRow[0]["ItemCode"].ToString();
                    dotxtSName.Text = dRow[0]["ShortName"].ToString();
                    txtSaleRate.Text = dRow[0]["SaleRateCRP"].ToString();
                    dotxtQty.Focus();
                }
                else
                {
                    dotxtItemNAme.Text = "";
                    dotxtCode.Text = "";
                    dotxtSName.Text = "";
                    txtBarCode.Text = "";
                    txtSaleRate.Text = "";
                }
            }
            CalculateAmount();

        }

        private void dotxtSName_Validated(object sender, EventArgs e)
        {
            DataTable dtb = new DataTable();
            dtb = dsPopulateCombo.Tables[0];

            if (txtBarCode.Text != "")
            {
                DataRow[] dRow = dtb.Select("ShortName= '" + dotxtSName.Text + "'");
                if (dRow.Count() > 0)
                {
                    txtBarCode.Text = dRow[0]["BarCode"].ToString();
                    dotxtCode.Text = dRow[0]["ItemCode"].ToString();
                    dotxtItemNAme.Text = dRow[0]["ItemName"].ToString();
                    txtSaleRate.Text = dRow[0]["SaleRateCRP"].ToString();

                    dotxtQty.Focus();
                }
                else
                {
                    dotxtItemNAme.Text = "";
                    dotxtCode.Text = "";
                    dotxtSName.Text = "";
                    txtBarCode.Text = "";
                    txtSaleRate.Text = "";
                }
            }
            CalculateAmount();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dtb = new DataTable();
            dtb = dsPopulateCombo.Tables[0];
            string strQuery = "CategoryCode = '" + docboCategory.SelectedValue + "' ";
            DataRow[] dRow = dtb.Select(strQuery);

            int intRows = 0;
            for (int i = 0; i < dRow.Count(); i++)
            {
                dtbDetail.Rows.Add();
                dtbDetail.Rows[intRows].Cells["BarCode"].Value = dRow[i]["Barcode"].ToString();
                dtbDetail.Rows[intRows].Cells["ItemName"].Value = dRow[i]["ItemName"].ToString();
                dtbDetail.Rows[intRows].Cells["ItemCode"].Value = dRow[i]["ItemCode"].ToString();
                dtbDetail.Rows[intRows].Cells["Symbol"].Value = dRow[i]["ShortName"].ToString();
                dtbDetail.Rows[intRows].Cells["SaleRateCRP"].Value = dRow[i]["SaleRateCRP"].ToString();
                dtbDetail.Rows[intRows].Cells["Quantity"].Value = "1";
                intRows = intRows + 1;
            }
            CalculateAmount();
        }

        private void dtbDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtbDetail.Columns["Quantity"].Index == e.ColumnIndex)
            {
                            CalculateAmount();
            }
        }
    }
}
