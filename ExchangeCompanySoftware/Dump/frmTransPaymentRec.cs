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
    public partial class frmTransPaymentRec : BaseForm,IToolBar
    {
        #region Declaration
            enum DataPop { Account, TransType};
           
            General cls;
            DataSet dsPopulateCombo;
            DataTable dtSearchMaster;
            public string strButtonState = null;
            string strTransType = "GLT";
            public string strError = "";
            string strCondition;
            MainForm Mainfrm;
        #endregion
    
        public frmTransPaymentRec()
        {
            InitializeComponent();
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
   
        private void populateMaster()
        {
                General cls = new General();
            DataSet ds = new DataSet();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_TransactionPaymentRecipt " + General.strStatusCondition + " and  BranchCode = '" + General.strBranchCode + "' And TransDate = '"+ General.dtSystemDate.ToString("dd/MMM/yyyy") +"' AND Posted = 'false' order by VoucherNo";
            ds =cls.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
        }

        #region IToolBar Members

        public bool ADD()
        {
            ditxtVoucherNo.Enabled = false;
            dicboTransactionType.SelectedIndex = 1;
            dicboTransactionType.SelectedIndex = 0;
            strButtonState = "ADD";
            dtDate.Value = General.dtSystemDate;
            cls.ClearALL(PnlMain);
            PopulateCombo();
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
                                  int strTransNo = Convert.ToInt32(cls.GetTransNo(strTransType));
                                  ditxtVoucherNo.Text = string.Format("{0:D5}", strTransNo);
                                  if (dicboTransactionType.Text == "Payment")
                                  {
                                      ditxtVoucherNo.Text = "PAY-" + ditxtVoucherNo.Text + "-" + General.strBranchCode;
                                  }
                                  else if (dicboTransactionType.Text == "Recipt")
                                  {
                                      ditxtVoucherNo.Text = "REC-" + ditxtVoucherNo.Text + "-" + General.strBranchCode;
                                  }
                              }
                              if (ValidatingControls() == true)
                              {


                                   strCondition = "Where VoucherNo = '" + ditxtVoucherNo.Text + "' and BranchCode='" + General.strBranchCode + "'";
                                  ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "Posted=False;BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + "");
                                  string strQuery = "Update " + General.strTableName[0] + " Set " + " Status = 'A' " + strCondition;
                    cls.ExecuteDML(strQuery);

                    ds.Tables[0].Rows[0]["Status"] = "A";
                                  dtbMaster.DataSource = ds.Tables[0];
                                  cls.BindGridwithTextBox(PnlMain, dtbMaster, "", null);
                                  cls.EnableDisble(PnlMain, false);
                                  strButtonState = "SAVE";
                                  this.Focus();
                              }
                          }
            Mainfrm.EnableDisbale(strButtonState, true, "S");
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
            string strQuery = "Select * from EX_TransactionPaymentRecipt a " + General.strStatusCondition + " ";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
            }
            else
            {
                strQuery = strQuery + " and a.TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            }
            DataSet ds =cls.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster,"",null);
            strButtonState = "QUERY";
            return true;
        }

        public bool UNDO()
        {
            strButtonState = "UNDO";
            return true;
        }

        public bool EXIT()
        {
            strButtonState = "EXIT";
            return true;
        }

        public bool DELETE()
        {
            //ExchangeCompanySoftware.GetData.ServiceSoapClient objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            //objGetData.Endpoint.Address = new System.ServiceModel.EndpointAddress(General.gendPoint);
            //strCondition = "Where VoucherNo = '" + ditxtVoucherNo.Text + "' and BranchCode = '" + General.strBranchCode + "'";
            //    General cls = new General();
            //objGetData.DeleteRecord(General.strTableName,strCondition, General.gUserId, General.gPassword);

            //MessageBox.Show("Record Succesfully Delete", "Deleted",
            //MessageBoxButtons.OK, MessageBoxIcon.Information);

            //strButtonState = "DELETE";
            //return true;
            cls = new General();
            strCondition = "Where VoucherNo = '" + ditxtVoucherNo.Text + "' And BranchCode = '" + General.strBranchCode + "'";
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
            strButtonState = "NEXT";
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
            strButtonState = "PRINT";
            return true;
        }

        #endregion

        private void PopulateCombo()
        {
           
            cls.PopulateCombo(dicboAccount, dsPopulateCombo.Tables[(int)DataPop.Account], "Title", "AccountNo");
            cls.PopulateCombo(dicboTransactionType, dsPopulateCombo.Tables[(int)DataPop.TransType], "Description", "Code");
       }

        private void frmTransPaymentRec_Load(object sender, EventArgs e)
        {
            
            General.strTableName[0]= "EX_TransactionPaymentRecipt";
            General.strPKColumn = "VoucherNo";
            General.strAuthorizeTableName = General.strTableName[0];
            string strQuery = "Select AccountNo,Title from EX_SetupAccount Where isTransactional = 'True' and Locked = 'False' and BranchCode = '" + General.strBranchCode + "' and Status = 'A' and CurrencyCode = '304';Select * from EX_System Where Flag = 'A' ";
            dsPopulateCombo = new DataSet();
            cls = new General();
          
            dsPopulateCombo =cls.GetDataSet(strQuery);
            PopulateCombo();
            dtDate.Value = General.dtSystemDate;
            Mainfrm = (MainForm)this.ParentForm;
            cls.EnableDisble(PnlMain, false);
        }

        private void frmTransPaymentRec_Activated(object sender, EventArgs e)
        {
          
        }

        private void frmTransPaymentRec_KeyPress(object sender, KeyPressEventArgs e)
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
                    dicboTransactionType.Focus();
                }
            }
        }

        private void docboNarration_Validated(object sender, EventArgs e)
        {
           
        }
        private void dicboTransactionType_Validated(object sender, EventArgs e)
        {

            if (dicboTransactionType.SelectedValue.ToString() == "26")
            {
                PnlMain.BackColor = Color.Teal;
            }
            else if (dicboTransactionType.SelectedValue.ToString() == "27")
            {
                PnlMain.BackColor = Color.Salmon ;
            }
        }

        private void dicboTransactionType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dicboTransactionType.SelectedValue.ToString() == "26")
            {
                PnlMain.BackColor = Color.Teal;
            }
            else if (dicboTransactionType.SelectedValue.ToString() == "27")
            {
                PnlMain.BackColor = Color.Salmon;
            }
        }

        private void dicboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dicboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
                  }

        private void dicboAccount_Validated(object sender, EventArgs e)
        {
            if (dicboAccount.SelectedValue != null)
            {

                string strQuery = " Select AccountNo,Title,Debit,";
                strQuery = strQuery + " Credit,Round(Amount,0) as Balance from (";
                strQuery = strQuery + " Select a.AccountNo,Title,Sum(Debit) as Debit,Sum(Credit) as Credit,Sum(case When Flag = 'D' then Debit else -Credit end) as Amount ,";
                strQuery = strQuery + " case When c.CurrencyCode != (Select Description From EX_System Where Flag = 'BC') then ";
                strQuery = strQuery + " SUM(CASE WHEN Flag = 'D' THEN Quantity ELSE -Quantity END) else 0 end  AS Quantity ";
                strQuery = strQuery + " from EX_PrsTransactions a";
                strQuery = strQuery + " Left Outer Join EX_SetupAccount c on a.AccountNo = c.AccountNo and c.Status = 'A'and a.BranchCode= c.BranchCode Where A.Status = 'A' and NatureCode ='6'  and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + dtDate.Value.ToString("dd/MMM/yyyy") + "'";
                strQuery = strQuery + " and TransType not in (Select TransType from EX_Closing Where '" + dtDate.Value.ToString("dd/MMM/yyyy") + "' <= ClosedDate) and a.AccountNo = '"+ dicboAccount.SelectedValue.ToString() +"'";
                strQuery = strQuery + " Group by Title,a.AccountNo,c.CurrencyCode)qry ";


                DataSet ds = new DataSet();
                ds =cls.GetDataSet(strQuery);
                DataRow[] dRow = ds.Tables[0].Select("AccountNo = '" + dicboAccount.SelectedValue.ToString() + "'");
                if (dRow.Count() > 0)
                {
                    decimal decBalance = Convert.ToDecimal(dRow[0]["Balance"].ToString());
                    if (decBalance < 0)
                    {
                        donumBalance.Value = -decBalance;
                        donumBalance.ForeColor = Color.Blue;
                    }
                    else
                    {
                        donumBalance.Value = decBalance;
                        donumBalance.ForeColor = Color.Red;

                    }

                }
                else
                {
                    donumBalance.Value = 0;
                    donumBalance.ForeColor = Color.Black;
                }
            }
            else
            {
                donumBalance.Value = 0;
                donumBalance.ForeColor = Color.Black;
                MessageBox.Show("Select Accounts Proper");
                dicboAccount.Focus();
            }
        }
    }
}
