using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ExchangeCompanySoftware.Reports;

namespace ExchangeCompanySoftware
{
    public partial class frmTT : BaseForm,IToolBar
    {
        enum DataPop { Party,Item,Vendor };
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataTable dtSearchMaster;
        string strButtonState = null;
        string strTransType = "TTIS";
        public string strError = "";
        DataSet dsPopulateCombo;
        string strFormButton;
        string strCondition;
        MainForm Mainfrm;
        DataGridView grd1;
        public frmTT()
        {
            InitializeComponent();
        }

        #region IToolBar Members
        public bool HISTORY()
        {
            return true;
        }
            public bool ADD()
            {
                ditxtItemCode.Enabled = false;
                strButtonState = "ADD";
                strFormButton = General.strStateAddEDIT;
                cls.ClearALL(PnlMain);
                ditxtTTNO.Focus();
                rdoTT.Checked = false;
                rdoTT.Checked = true;
                dtDate.Value = General.dtSystemDate;
                return true;

            }

            public bool SAVE()
            {
                cls = new General();
                DataSet ds = new DataSet();
                strFormButton = General.strStateALL;
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                string strTT = "";
                DialogResult dr =
                  MessageBox.Show("are you sure to Save That Record", "Confirmation Save",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Convert.ToString(dr) == "Yes")
                {

                    if (strButtonState == "ADD")
                    {
                        ditxtItemCode.Text = cls.GetTransNo(strTransType);
                    }
                    Calculate();
                    if (ValidatingControls() == true)
                    {
                        if (rdoCash.Checked == true)
                        {
                            strTT = "C";
                        }
                        else if (rdoRMB.Checked == true)
                        {
                            strTT = "R";
                        }
                        else if (rdoTT.Checked == true)
                        {
                            strTT = "T";
                        }
                        strCondition = "Where Code = '" + ditxtItemCode.Text + "'";
                        ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "UserID=" + General.strUserId + ";TTTYPE=" + strTT + "");
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
                }
                Mainfrm.EnableDisbale(strButtonState, true, "S");
                return true;
            }
            public bool EDIT()
            {
                ditxtItemCode.Enabled = false;
                strFormButton = General.strStateAddEDIT;
                strButtonState = "EDIT";
                return true;
            }

            public bool QUERY()
            {
                strFormButton = General.strStateALL;
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                DataSet ds = new DataSet();
                dtSearchMaster = new DataTable();
                string strQuery;
                strQuery = "Select * from EX_TransTT " + General.strStatusCondition + "";
                if (General.strFormQueryCriteria != "")
                {
                    strQuery = strQuery + General.strFormQueryCriteria;
                }
                else
                {
                    strQuery = strQuery + " and TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
                }
             
                ds = objGetData.GetDataSet(strQuery);
                dtSearchMaster = ds.Tables[0];
                dtbMaster.DataSource = dtSearchMaster;
                cls.BindGridwithTextBox(PnlMain, dtbMaster,"",null);
                strButtonState = "QUERY";
                return true;
            }

            public bool UNDO()
            {
                strFormButton = General.strStateALL;
                strButtonState = "UNDO";
                rdoTT.Checked = false;
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
                strCondition = "Where Code = '" + ditxtItemCode.Text + "'";
                cls.DeleteRecord(General.strTableName, strCondition);
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
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                DataTable dtb = new DataTable();
                Button btn = new Button();
                btn.Text = "PRINT";
                btn.Dock = DockStyle.Bottom;
                btn.Height = 20;
                Form frm = new Form();
                grd1 = new DataGridView();
                grd1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grd1.ReadOnly = true;
                DataGridViewCheckBoxColumn chq = new DataGridViewCheckBoxColumn();
                chq.ReadOnly = false;
                chq.Name = "Select";
                chq.HeaderText = "Select";
                grd1.Columns.Add(chq);
                btn.Click += new EventHandler(btn_Click);
                frm.Controls.Add(grd1);
                frm.Controls.Add(btn);
                grd1.Dock = DockStyle.Fill;
                grd1.DataSource = dtbMaster.DataSource;
                grd1.CellDoubleClick += new DataGridViewCellEventHandler(grd_CellDoubleClick);
                
                grd1.Columns["Select"].ReadOnly = false;
                grd1.ReadOnly = false;
                frm.Width = 800;
                frm.ShowDialog();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Dispose();

                strButtonState = "PRINT";
               return true;
            }

            void btn_Click(object sender, EventArgs e)
            {
                string strCriteria= null;
                for (int iRow = 0; iRow < grd1.Rows.Count; iRow++)
                {
                    if (Convert.ToBoolean(grd1.Rows[iRow].Cells["SELECT"].Value) == true)
                    {
                        if (strCriteria == null)
                        {
                            strCriteria = "'" + grd1.Rows[iRow].Cells["Code"].Value.ToString() + "'";
                        }
                        else
                        {
                            strCriteria = strCriteria + "," + "'" + grd1.Rows[iRow].Cells["Code"].Value.ToString() + "'";
                        }
                    }
                }
                string strQuery = " Select a.*,ItemName from EX_TransTT a Inner Join EX_SetupItems b on a.CurrencyCode = b.ItemCode and b.Status = 'A' ";
                strQuery = strQuery + " Where a.Code in (" + strCriteria + ") and a.Status in ('A') Order by TTNo";
                DataTable dtb = objGetData.GetDataSet(strQuery).Tables[0];

                rptTT devrep = new rptTT();
                devrep.Margins = new System.Drawing.Printing.Margins(5, 0, 5, 10);
                devrep.DataSource = dtb;



                devrep.RequestParameters = false;
                devrep.ShowPreview();
            }

        #endregion
       
        void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex != -1)
                {
                    if (grd1.Rows[e.RowIndex].Cells["Code"].Value != null)
                    {
                        //string strQuery = " Select Title,ShortName,VoucherNo,Quantity,Rate,Debit,Credit,Remarks from EX_PrsTransactions a";
                        //strQuery = strQuery + " Inner Join EX_SetupAccount c on a.AccountNo = c.AccountNo and c.Status = 'A' and a.BranchCode= c.BranchCode";
                        //strQuery = strQuery + " Inner Join EX_SetupItems d on a.CurrencyCode = d.ItemCode and d.Status = 'A' ";
                        //strQuery = strQuery + " Where a.VoucherNo = '" + grd.Rows[e.RowIndex].Cells["VoucherNo"].Value + "' and a.Status = 'A' and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + dtTransDate.Value + "'";

                        //GetData.ServiceSoapClient objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                        //DataSet ds = new DataSet();
                        //ds = objGetData.GetDataSet(strQuery);
                    }

                }

            }

        private void CalculateOLD()
            {
                decimal dblConRate = donumBookingRate.Value;
                decimal dblQty = dinumQty.Value;
                decimal dblRate = dinumRate.Value;
                decimal dblCharges = donumCharges.Value;
                decimal dblAmount = (dinumQty.Value * dinumRate.Value) + dblCharges;
                decimal dblDhsAmount = dinumQty.Value * donumBookingRate.Value;
                decimal dblDhsRate = 0;    
                if (dblDhsAmount != 0)
                {
                    dblDhsRate = dblAmount / dblDhsAmount;
                }
            
                dinumAmount.Value = dblAmount;
                dinumDhsAmount.Value = dblDhsAmount;
                dinumDhsRate.Value = dblDhsRate;
            
            }

        private void PopulateCombo()
        {
            cls = new General();
          
            cls.PopulateCombo(dicboParty, dsPopulateCombo.Tables[(int)DataPop.Party], "title", "AccountNo");
            cls.PopulateCombo(dicboVendor, dsPopulateCombo.Tables[(int)DataPop.Vendor], "Title", "AccountNo");
            cls.PopulateCombo(dicboCurrency, dsPopulateCombo.Tables[(int)DataPop.Item], "ItemName", "ItemCode");
        }

        public Boolean ValidatingControls()
            {
                Boolean bolState;

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
                if (dicboParty.SelectedValue == null)
                {
                    MessageBox.Show("Party Account Not Selected Properly");
                    bolState = false;
                }
                else
                {
                    bolState = true;
                }
                if (dicboParty.SelectedValue == null)
                {
                    MessageBox.Show("Vendor Account Not Selected Properly");
                    bolState = false;
                }
                else
                {
                    bolState = true;
                }

                return bolState;
            }

        private void frmSetupItem_Load(object sender, EventArgs e)
        {
            General.strTableName[0]= "EX_TransTT";
            General.strPKColumn = "Code";
            General.strAuthorizeTableName = General.strTableName[0];
            this.Tag = "S";
            cls = new General();
            cls.EnableDisble(PnlMain, false);
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            string strQuery = "Select AccountNo,Title from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Locked = 'false'  and Status = 'A' and isTransactional = 'true' and NatureCode = '6';Select ItemCode,ItemName,Unit from EX_SetupItems Where Status = 'A' and isMain = 'True' ;Select AccountNo,Title from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Locked = 'false'  and Status = 'A' and isTransactional = 'true' and CurrencyCode !='304'";
         
            dsPopulateCombo = new DataSet();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
         
            PopulateCombo();
            Mainfrm = (MainForm)this.ParentForm;
            dtDate.Value = General.dtSystemDate;
        }

        void dtbMaster_SelectionChanged(object sender, EventArgs e)
        {

            //if (dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["Pic"].Value != null)
            //{

            //    if (!File.Exists(pictureBox1.Tag.ToString()))
            //    {
            //        Image image = pictureBox1.Image;
            //        image.Save(pictureBox1.Tag.ToString(), ImageFormat.Jpeg);
            //    }
            //    else
            //    {
            //        string delStr = pictureBox1.Tag.ToString();
            //        pictureBox1.Image.Dispose();
            //        File.Delete(delStr);
            //        Image image = pictureBox1.Image;
            //        image.Save(delStr, ImageFormat.Jpeg);
            //        pictureBox1.Image = Image.FromFile(delStr);
            //    }

            //}
        }

        private void frmPurpose_Activated(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }

        private void dinumQty_Validated(object sender, EventArgs e)
        {
            Calculate();
        }

        private void dinumRate_Validated(object sender, EventArgs e)
        {
            Calculate();

        }

        private void donumCharges_Validated(object sender, EventArgs e)
        {
            Calculate();
        }

        private void donumBookingRate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dinumQty_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dinumRate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void donumCharges_ValueChanged(object sender, EventArgs e)
        {
        }



        private void Calculate()
        {
            decimal dblconRate = 0;
            decimal dbldhsCharges = 0;
            decimal dblBookingRate = 0;
            string strUnit = "";
            dblconRate = donumConRate.Value;
            dbldhsCharges = donumDhsCharges.Value;
            dblBookingRate = donumBookingRate.Value;
            dinumAmount.Value = (dinumQty.Value * dinumRate.Value) + donumCharges.Value;
            if (rdoCash.Checked == true)
            {
                dinumDhsAmount.Value = dinumQty.Value + Convert.ToDecimal(dbldhsCharges);
            }
            else
            {
                if (dicboCurrency.SelectedValue != null)
                {
                    if (dicboCurrency.SelectedValue.ToString() != "")
                    {
                        DataRow[] dr = new DataRow[0];
                        dr = dsPopulateCombo.Tables[(int)DataPop.Item].Select("ItemCode = '" + dicboCurrency.SelectedValue + "' ");
                        strUnit = dr[0]["Unit"].ToString();

                        if (strUnit == "N")
                        {
                            if (rdoTT.Checked == true)
                            {
                                if (dinumAmount.Value > 0)
                                {
                                    dinumDhsAmount.Value = Math.Round(Convert.ToDecimal((dinumQty.Value * Convert.ToDecimal(dblconRate)) + Convert.ToDecimal(dbldhsCharges)),0);
                                
                                }
                            }
                            else if (rdoRMB.Checked == true)
                            {
                                if (dinumAmount.Value > 0)
                                {
                                    if (dblBookingRate > 0)
                                    {
                                        dinumDhsAmount.Value = Math.Round(Convert.ToDecimal((dinumQty.Value * Convert.ToDecimal(dblBookingRate))) + Convert.ToDecimal(dbldhsCharges), 0);
                                    }
                                }
                            }

                        }
                        else if (strUnit == "D")
                        {
                            if (dblBookingRate > 0)
                            {
                                    dinumDhsAmount.Value = Math.Round(Convert.ToDecimal(((dinumQty.Value / dblBookingRate) * Convert.ToDecimal(dblconRate)) + Convert.ToDecimal(dbldhsCharges)), 0);
                            }
                        }
                        else if (strUnit == "M")
                        {
                            if (dblconRate > 0)
                            {
                                if (dblBookingRate > 0)
                                {
                                    if (dinumQty.Value != 0)
                                    {
                                        dinumDhsAmount.Value = Math.Round(Convert.ToDecimal(((dinumQty.Value * dblBookingRate) * Convert.ToDecimal(dblconRate)) + Convert.ToDecimal(dbldhsCharges)), 0);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (dinumDhsAmount.Value > 0)
            {
                dinumDhsRate.Value = Math.Round(Convert.ToDecimal(dinumAmount.Value / Convert.ToDecimal(dinumDhsAmount.Value)), 4); ;
            }
        }


        private void RadioChecked()
        {

            if (rdoCash.Checked == true)
            {
             
                donumCharges.Value = 0;
                donumBookingRate.Value = 0;
                donumDhsCharges.Value = 0;
            }
            else if (rdoTT.Checked == true)
            {
                donumBookingRate.Enabled = true;
                donumCharges.Enabled = true;
                donumDhsCharges.Enabled = true;
                donumDhsCharges.Value = 30;
                if (donumCharges.Value == 0)
                {
                    donumCharges.Value = 1000;
                }
            }
            else if (rdoRMB.Checked == true)
            {
                donumCharges.Value = 0;
                donumBookingRate.Value = 0;
                donumDhsCharges.Value = 0;
            }
            Calculate();
        }

        private void rdoTT_CheckedChanged(object sender, EventArgs e)
        {
            RadioChecked();
        }

        private void rdoRMB_CheckedChanged(object sender, EventArgs e)
        {
            RadioChecked();
        }

        private void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            RadioChecked();
        }

        private void donumBookingRate_Validated(object sender, EventArgs e)
        {
            Calculate();


        }

   
   
        private void dicboVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

   
        private void frmTT_KeyPress(object sender, KeyPressEventArgs e)
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
                    Mainfrm.EnableDisbale(strButtonState, true, "S");
                    ditxtTTNO.Focus();
                }
            }

        }

        private void cstTextBox2_Validated(object sender, EventArgs e)
        {
            //if (strButtonState != "SAVE")
            //{
            //    DialogResult dr =
            //    MessageBox.Show("Are you sure to Save this Record", "Confirmation Save",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (Convert.ToString(dr) == "Yes")
            //    {
            //        SAVE();
            //    }
            //}
        }

        private void dicboParty_Validated(object sender, EventArgs e)
        {
            if (dicboParty.SelectedValue != null)
            {

                string strQuery = " Select AccountNo,Title,Debit,";
                strQuery = strQuery + " Credit,Round(Amount,0) as Balance from (";
                strQuery = strQuery + " Select a.AccountNo,Title,Sum(Debit) as Debit,Sum(Credit) as Credit,Sum(case When Flag = 'D' then Debit else -Credit end) as Amount ,";
                strQuery = strQuery + " case When c.CurrencyCode != (Select Description From EX_System Where Flag = 'BC') then ";
                strQuery = strQuery + " SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE -Quantity END) else 0 end  AS Quantity ";
                strQuery = strQuery + " from EX_PrsTransactions a";
                strQuery = strQuery + " Left Outer Join EX_SetupAccount c on a.AccountNo = c.AccountNo and c.Status = 'A'and a.BranchCode= c.BranchCode Where A.Status = 'A' and NatureCode ='6'  and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + dtDate.Value.ToString("dd/MMM/yyyy") + "'";
                strQuery = strQuery + " and TransType not in (Select TransType from EX_Closing Where '" + dtDate.Value.ToString("dd/MMM/yyyy") + "' <= ClosedDate) and a.AccountNo = '" + dicboParty.SelectedValue.ToString() + "'";
                strQuery = strQuery + " Group by Title,a.AccountNo,c.CurrencyCode)qry ";

                DataSet ds = new DataSet();
                ds = objGetData.GetDataSet(strQuery);
                DataRow[] dRow = ds.Tables[0].Select("AccountNo = '" + dicboParty.SelectedValue.ToString() + "'");


                if (dRow.Count() > 0)
                {
                    decimal decBalance = Convert.ToDecimal(dRow[0]["Balance"].ToString());
                    if (decBalance < 0)
                    {
                        donumBalanceDr.Value = -decBalance;
                        donumBalanceDr.ForeColor = Color.Blue;
                    }
                    else
                    {
                        donumBalanceDr.Value = decBalance;
                        donumBalanceDr.ForeColor = Color.Red;

                    }

                }
                else
                {
                    donumBalanceDr.Value = 0;
                    donumBalanceDr.ForeColor = Color.Black;
                }
            }
            else
            {
                donumBalanceDr.Value = 0;
                donumBalanceDr.ForeColor = Color.Black;
                MessageBox.Show("Select Accounts Proper");
                dicboParty.Focus();
            }
        }

        private void dicboParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (strButtonState == "QUERY")
            {
                if (dicboParty.SelectedValue != null)
                {
                    string strQuery = " Select AccountNo,Title,Debit,";
                    strQuery = strQuery + " Credit,Round(Amount,0) as Balance from (";
                    strQuery = strQuery + " Select a.AccountNo,Title,Sum(Debit) as Debit,Sum(Credit) as Credit,Sum(case When Flag = 'D' then Debit else -Credit end) as Amount ,";
                    strQuery = strQuery + " case When c.CurrencyCode != (Select Description From EX_System Where Flag = 'BC') then ";
                    strQuery = strQuery + " SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE -Quantity END) else 0 end  AS Quantity ";
                    strQuery = strQuery + " from EX_PrsTransactions a";
                    strQuery = strQuery + " Left Outer Join EX_SetupAccount c on a.AccountNo = c.AccountNo and c.Status = 'A'and a.BranchCode= c.BranchCode Where A.Status = 'A' and NatureCode ='6'  and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + dtDate.Value.ToString("dd/MMM/yyyy") + "'";
                    strQuery = strQuery + " and TransType not in (Select TransType from EX_Closing Where '" + dtDate.Value.ToString("dd/MMM/yyyy") + "' <= ClosedDate) and a.AccountNo = '" + dicboParty.SelectedValue.ToString() + "'";
                    strQuery = strQuery + " Group by Title,a.AccountNo,c.CurrencyCode)qry ";

                    DataSet ds = new DataSet();
                    ds = objGetData.GetDataSet(strQuery);
                    DataRow[] dRow = ds.Tables[0].Select("AccountNo = '" + dicboParty.SelectedValue.ToString() + "'");


                    if (dRow.Count() > 0)
                    {
                        decimal decBalance = Convert.ToDecimal(dRow[0]["Balance"].ToString());
                        if (decBalance < 0)
                        {
                            donumBalanceDr.Value = -decBalance;
                            donumBalanceDr.ForeColor = Color.Blue;
                        }
                        else
                        {
                            donumBalanceDr.Value = decBalance;
                            donumBalanceDr.ForeColor = Color.Red;

                        }

                    }
                    else
                    {
                        donumBalanceDr.Value = 0;
                        donumBalanceDr.ForeColor = Color.Black;
                    }
                }
                else
                {
                    donumBalanceDr.Value = 0;
                    donumBalanceDr.ForeColor = Color.Black;
                    MessageBox.Show("Select Accounts Proper");
                    dicboParty.Focus();
                }
                
            }
        }

        private void donumConRate_Validated(object sender, EventArgs e)
        {
            Calculate();

        }

        private void ditxtAttan_TextChanged(object sender, EventArgs e)
        {

        }

        private void donumDhsCharges_Validated(object sender, EventArgs e)
        {
            Calculate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dotxtFetch.Text != "")
            {
                string strQuery = "Select * from EX_TransTT Where Code = '" + dotxtFetch.Text + "' ";
                DataSet ds = objGetData.GetDataSet(strQuery);
                DataTable dtb = ds.Tables[0];
                dtbMaster.DataSource = dtb;
                cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
                ditxtItemCode.Text = "";
            }
        }

    
      
    }
}
