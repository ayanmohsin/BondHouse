using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ExchangeCompanySoftware
{
    public partial class frmTT : BaseForm,IToolBar
    {
        enum DataPop { Party,Item,Vendor };
        GetData.ServiceSoapClient objGetData;
        General cls;
        DataTable dtSearchMaster;
        string strButtonState = null;
        string strTransType = "TT";
        public string strError = "";
        DataSet dsPopulateCombo;
        string strFormButton;
        string strCondition;
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
                ditxtTTNO.Focus();
                PopulateCombo();
                rdoTT.Checked = true;
                return true;

            }
     
            public bool SAVE()
            {
                cls = new General();
                DataSet ds = new DataSet();
                strFormButton = General.strStateALL;
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                string strTT="";
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
                    ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "UserID=" + General.strUserId + ";TTTYPE="+ strTT +"");
                    dtbMaster.DataSource = ds.Tables[0];
                    cls.BindGridwithTextBox(PnlMain, dtbMaster,"",null);
                    strButtonState = "SAVE";
                    cls.EnableDisble(PnlMain, false);
                    return true;
                }
                else
                {
                    MessageBox.Show(strError, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    General.strButtonState = strButtonState;
                    return false;
                }
        
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
                strButtonState = "PRINT";
               return true;
            }

        #endregion

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
            string strQuery = "Select * from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Status = 'A' and isTransactional = 'true';Select * from EX_SetupItems Where Status = 'A' and isMain = 'True' ;Select * from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Status = 'A' and isTransactional = 'true'";
            dsPopulateCombo = new DataSet();
            cls = new General();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
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
            dtDate.Value = General.dtSystemDate;
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
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
            Calculate();
        }

        private void dinumQty_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void dinumRate_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void donumCharges_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }



        private void Calculate()
        {
            double dblconRate = 0;
            double dbldhsCharges = 0;
            string strUnit = "";
            if (rdoCash.Checked == true)
            {
                dinumDhsAmount.Value = dinumQty.Value;
                dinumDhsRate.Value = dinumRate.Value;
                dinumAmount.Value = dinumDhsAmount.Value * dinumDhsRate.Value;
            }
            else
            {
                if (dicboCurrency.SelectedValue != null)
                {
                    DataRow[] dr = DataRow[] dicboCurrency.SelectedValue;
                    if (dicboCurrency.SelectedValue.ToString() == "2")
                    {
                        dblconRate = 3.674;
                        dbldhsCharges = 35;
                    }
                    else
                    {
                        dblconRate = 3.6742;
                        dbldhsCharges = 40;
                    }
                    dinumAmount.Value = (dinumQty.Value * dinumRate.Value) + donumCharges.Value;

                    if (strUnit == "N")
                    {
                        if (rdoTT.Checked == true)
                        {
                            if (dinumAmount.Value > 0)
                            {
                                dinumDhsAmount.Value = Convert.ToDecimal((dinumQty.Value * Convert.ToDecimal(dblconRate)) + Convert.ToDecimal(dbldhsCharges));
                                dinumDhsRate.Value = Convert.ToDecimal(dinumAmount.Value / Convert.ToDecimal(dinumDhsAmount.Value));
                            }
                        }
                        else if (rdoRMB.Checked == true)
                        {
                            if (dinumAmount.Value > 0)
                            {
                                dinumDhsAmount.Value = Convert.ToDecimal((dinumQty.Value * Convert.ToDecimal(donumBookingRate.Value)));
                                dinumDhsRate.Value = Convert.ToDecimal(dinumAmount.Value / Convert.ToDecimal(dinumDhsAmount.Value));
                            }
                        }
                    }
                    else if (strUnit == "D")
                    {
                        if (donumBookingRate.Value > 0)
                        {
                            dinumDhsAmount.Value = Convert.ToDecimal(((dinumQty.Value / donumBookingRate.Value) * Convert.ToDecimal(dblconRate)) + Convert.ToDecimal(dbldhsCharges));
                            dinumDhsRate.Value = Convert.ToDecimal(dinumAmount.Value / dinumDhsAmount.Value);
                        }
                        else
                        {
                            MessageBox.Show("ENTER BOOKING RATE");
                            donumBookingRate.Focus();
                        }
                    }
                    else if (strUnit == "M")
                    {
                        if (donumBookingRate.Value > 0)
                        {
                            dinumDhsAmount.Value = Convert.ToDecimal(((dinumQty.Value * donumBookingRate.Value) * Convert.ToDecimal(dblconRate)) + Convert.ToDecimal(dbldhsCharges));
                            dinumDhsRate.Value = Convert.ToDecimal(dinumAmount.Value / dinumDhsAmount.Value);
                        }
                        else
                        {
                            MessageBox.Show("ENTER BOOKING RATE");
                            donumBookingRate.Focus();
                        }
                    }
                }
            }
        }


        private void RadioChecked()
        {

            if (rdoCash.Checked == true)
            {
                donumBookingRate.Enabled = false;
                donumCharges.Enabled = false;
                donumCharges.Value = 0;
                donumBookingRate.Value = 0;
                Calculate();
            }
            else if (rdoTT.Checked == true)
            {
                donumBookingRate.Enabled = true;
                donumCharges.Enabled = true;
                Calculate();
            }
            else if (rdoRMB.Checked == true)
            {
                donumBookingRate.Enabled = true;
                donumCharges.Enabled = false;
                Calculate();
            }
        
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

    
      
    }
}
