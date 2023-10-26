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
            GetData.ServiceSoapClient objGetData;
            General cls;
            DataSet dsPopulateCombo;
            DataTable dtSearchMaster;
            public string strButtonState = null;
            string strTransType = "GLT";
            string strError;
            public string[] strTableName = new string[3];
            string strCondition;
        #endregion
    
        public frmTransPaymentRec()
        {
            InitializeComponent();
        }

        private Boolean ValidatingControls()
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
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_TransactionPaymentRecipt Where BranchCode = '" + General.strBranchCode + "' AND Posted = 'false' order by VoucherNo";
            ds = objGetData.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
        }

        #region IToolBar Members

        public bool ADD()
        {
            ditxtVoucherNo.Enabled = false;
            strButtonState = "ADD";
            return true;
        }
    
        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();
            

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
                strCondition = "Where VoucherNo = '" + ditxtVoucherNo.Text + "' and BranchCode='"+ General.strBranchCode +"'";
                ds = cls.SaveRecord(strButtonState, null, strTableName, PnlMain, strTransType, strCondition, "Posted=False;BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + "");
                 dtbMaster.DataSource = ds.Tables[0];
                 cls.BindGridwithTextBox(PnlMain, dtbMaster,"",null);
                 cls.EnableDisble(PnlMain, false);
            }
            strButtonState = "SAVE";
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
            populateMaster();
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
            strCondition = "Where VoucherNo = '" + ditxtVoucherNo.Text + "' and BranchCode = '" + General.strBranchCode + "'";
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            objGetData.DeleteRecord(strTableName,strCondition);

            MessageBox.Show("Record Succesfully Delete", "Deleted",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            string strQuery = "Select * from EX_SetupAccount Where isTransactional = 'True' and Locked = 'False' and BranchCode = '" + General.strBranchCode + "' and Status = 'A';Select * from EX_System Where Flag = 'A'";
            dsPopulateCombo = new DataSet();
            cls = new General();
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            dsPopulateCombo = objGetData.GetDataSet(strQuery);
            cls.PopulateCombo(dicboAccount, dsPopulateCombo.Tables[(int)DataPop.Account], "Title", "AccountNo");
            cls.PopulateCombo(dicboTransactionType, dsPopulateCombo.Tables[(int)DataPop.TransType], "Description", "Code");
       }

        private void frmTransPaymentRec_Load(object sender, EventArgs e)
        {
            
            strTableName[0] = "EX_TransactionPaymentRecipt";
            General.strAuthorizeTableName = strTableName[0];
            PopulateCombo();
            cls.EnableDisble(PnlMain, false);
        }

        private void frmTransPaymentRec_Activated(object sender, EventArgs e)
        {
          
        }
    }
}
