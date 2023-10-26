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
    public partial class frmTransProcess : BaseForm,IToolBar
    {
        GetData.ServiceSoapClient objGetData;
        string strButtonState;
        public frmTransProcess()
        {
            InitializeComponent();
        }
        private bool IndexSales()
        {
            bool bolstate = false;
            string strQuery = " select 'CEX' as TType,VoucherNo from EX_TransactionsMaster ";
            strQuery = strQuery + " Where TransDate = '" + dttoDate.Value.ToString("dd/MMM/yyyy") + "' and BranchCode ='" + General.strBranchCode + "' ";
            strQuery = strQuery + " and TransType = 2 and Status = 'A';Select 'TT' as TType,Code from EX_TransTT Where TransDate = '" + dttoDate.Value.ToString("dd/MMM/yyyy") + "' and Status = 'A';Select Distinct a.VoucherNo,'JV' TType  from EX_JournalVoucherMaster a Inner Join EX_JournalVoucherDetail b on a.VoucherNo = b.VoucherNo and a.BranchCode = b.BranchCode and a.Status = 'A' Where ItemCode != '304' and Credit > 0 and TransDate = '" + dttoDate.Value.ToString("dd/MMM/yyyy") + "' and a.BranchCode ='" + General.strBranchCode + "' ";

            GetData.ServiceSoapClient objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataTable dtb = new DataTable();
            DataTable dtbTT = new DataTable();
            DataTable dtbJV = new DataTable();

            DataSet ds = objGetData.GetDataSet(strQuery);
            dtb = ds.Tables[0];
            dtbTT = ds.Tables[1];
            dtbJV = ds.Tables[2];
            progressBar1.Maximum = dtb.Rows.Count;
            progressBar1.Minimum = 0;
            label1.Text = "Sale Transactions Process " + dtb.Rows.Count;
            Application.DoEvents();

            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                strQuery = "Delete From EX_PrsTransactions Where VoucherNo = '" + dtb.Rows[i]["VoucherNo"].ToString() + "' and BranchCode = '" + General.strBranchCode + "'";
                objGetData.Dmlexecute(strQuery);

                strQuery = " Update EX_TransactionsMaster Set Status = 'U' ";
                strQuery = strQuery + " Where VoucherNo = '" + dtb.Rows[i]["VoucherNo"].ToString() + "' and BranchCode = '" + General.strBranchCode + "' and TransType = 2 ";
                objGetData.Dmlexecute(strQuery);

                strQuery = " Update EX_TransactionsMaster Set Status = 'A' ";
                strQuery = strQuery + " Where VoucherNo = '" + dtb.Rows[i]["VoucherNo"].ToString() + "' and BranchCode = '" + General.strBranchCode + "' and TransType = 2 ";
                objGetData.Dmlexecute(strQuery);

                progressBar1.Value = i;
            }

            progressBar1.Maximum = dtbTT.Rows.Count;
            progressBar1.Value = 0;
            label1.Text = "TT Transactions Process " + dtbTT.Rows.Count;
            Application.DoEvents();

            //for (int i = 0; i < dtbTT.Rows.Count; i++)
            //{
            //    strQuery = "Delete From EX_PrsTransactions Where VoucherNo = '" + dtbTT.Rows[i]["Code"].ToString() + "' and BranchCode = '1'";
            //    objGetData.Dmlexecute(strQuery);

            //    strQuery = " Update EX_TransTT Set Status = 'U' ";
            //    strQuery = strQuery + " Where Code = '" + dtbTT.Rows[i]["Code"].ToString() + "' ";
            //    objGetData.Dmlexecute(strQuery);

            //    strQuery = " Update EX_TransTT Set Status = 'A' ";
            //    strQuery = strQuery + " Where Code = '" + dtbTT.Rows[i]["Code"].ToString() + "'  ";
            //    objGetData.Dmlexecute(strQuery);

            //    progressBar1.Value = i;
            //}

            progressBar1.Maximum = dtbJV.Rows.Count;
            progressBar1.Value = 0;

            label1.Text = "JV Transactions Process " + dtbJV.Rows.Count;
            Application.DoEvents();

            for (int i = 0; i < dtbJV.Rows.Count; i++)
            {
                strQuery = "Delete From EX_PrsTransactions Where VoucherNo = '" + dtbJV.Rows[i]["VoucherNo"].ToString() + "' and BranchCode = '" + General.strBranchCode + "'";
                objGetData.Dmlexecute(strQuery);

                strQuery = " Update EX_JournalVoucherMaster Set Status = 'U' ";
                strQuery = strQuery + " Where VoucherNo = '" + dtbJV.Rows[i]["VoucherNo"].ToString() + "' and BranchCode = '" + General.strBranchCode + "' ";
                objGetData.Dmlexecute(strQuery);

                strQuery = " Update EX_JournalVoucherMaster Set Status = 'A' ";
                strQuery = strQuery + " Where VoucherNo = '" + dtbJV.Rows[i]["VoucherNo"].ToString() + "' and BranchCode = '" + General.strBranchCode + "' ";
                objGetData.Dmlexecute(strQuery);

                progressBar1.Value = i;
            }

            strQuery = "insert into EX_TranLog Select '" + General.strBranchCode + "','" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "','Admin','Z' ";
            objGetData.Dmlexecute(strQuery);
            bolstate = true;
            return bolstate;
        }
    
        private void btnGenerateProcess_Click(object sender, EventArgs e)
        {
            //=====================================DateRange================================
            //TimeSpan tsRange;
            //tsRange = Convert.ToDateTime(dtFromDate.Value) - Convert.ToDateTime(dttoDate.Value);
            //int days = Math.Abs(tsRange.Days);
          //=================================================================================
            General cls = new General();
            if (!cls.CheckMorri())
            {
                return;
            }
            if (!IndexSales())
            {
                MessageBox.Show("Day End not process");
                return;
            }
                label1.Text = "Checking UnAuthorize Record";
                Application.DoEvents();

        //    if (Checkstock() == true)
                objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
                string strQuery1 = " Select * from VU_UnAuthorizedRecord Where Status > 0 and BranchCode = '" + General.strBranchCode + "' and TransDate <= '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "';";
                string strQuery = " Select Title,Round(Sum(case When Flag = 'D' then Quantity else - Quantity end),0) as Quantity ";
                strQuery = strQuery + " from EX_PrsTransactions a ";
                strQuery = strQuery + " Inner Join EX_SetupAccount b on a.AccountNo = b.AccountNo and a.BranchCode = b.BranchCode and b.Status = 'A' ";
                strQuery = strQuery + " Where a.CurrencyCode != '304' and Title = 'FC IN HAND' and a.CurrencyCode != '' and a.Status = 'A'  ";
                strQuery = strQuery + " and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '"+ General.dtSystemDate.ToString("dd/MMM/yyyy") +"' ";
                strQuery = strQuery + " Group by Title ;Select * from EX_Revaluetion a Where a.Status = 'A' and BranchCode = '"+ General.strBranchCode +"' and TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
                string strError = "";
                DataSet ds = new DataSet();
                DataTable dtb = new DataTable();
                DataTable dtbRev = new DataTable();
                ds = objGetData.GetDataSet(strQuery1 + ";" + strQuery);
                dtb = ds.Tables[0];
                dtbRev = ds.Tables[2];
                if (dtb.Rows.Count != 0)
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        strError = strError + "\n UN-Authorized Records on ";
                        strError = strError  +  " " + dtb.Rows[i]["Form"] +" = "+ dtb.Rows[i]["Status"] +"";
                    }
                }
                label1.Text = "Checking Cash";
                Application.DoEvents();

                if (General.strBranchCode != "35")
                {
                    double cashinVault = 0;
                    double cashinHand = 0;
                    double TotalCash = 0;
                    strQuery = "Select Round(Sum(case When Flag = 'D' then Debit else - Credit end),2) as CashinHand from EX_PrsTransactions a";
                    strQuery = strQuery + " Where AccountNo in ((Select Cashinhand From EX_ControlAccounts Where BranchCode = a.BranchCode)) and BranchCode = '" + General.strBranchCode + "' and Status = 'A' and a.TransDate <= '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' Group by a.AccountNo";
                    strQuery1 = "Select Round(Sum(case When Flag = 'D' then Debit else - Credit end),2) as CashinHand from EX_PrsTransactions a";
                    strQuery1 = strQuery1 + " Where AccountNo in ((Select Cashinvault From EX_ControlAccounts Where BranchCode = a.BranchCode)) and BranchCode = '" + General.strBranchCode + "' and Status = 'A' and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' Group by a.AccountNo";

                    ds = objGetData.GetDataSet(strQuery + ";" + strQuery1);
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        cashinVault = Convert.ToDouble(ds.Tables[1].Rows[0]["CashinHand"].ToString());

                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cashinHand = Convert.ToDouble(ds.Tables[0].Rows[0]["CashinHand"].ToString());
                    }

                    TotalCash = cashinHand + cashinVault;


                    if (TotalCash < 0)
                    {
                        strError = strError + "\n your Cash is in negative kindly check your cash before closing";
                    }
                }
                if (strError != "")
                {
                    MessageBox.Show(strError, "UN-Authorized",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);                
                }
                else
                {
                    label1.Text = "Process Day End";
                    Application.DoEvents();

                    strQuery = "Exec SP_DayEnd '" + General.strBranchCode + "','" + dttoDate.Value.ToString("dd/MMM/yyyy") + "','" + General.strUserId + "'";
                    objGetData.Dmlexecute(strQuery);
                    MessageBox.Show("Executed Successfully", "Execute",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
        }

        private Boolean Checkstock()
        {
            string strMessage = "";
            General cls = new General();

            DataSet ds = cls.GetStockds(General.dtSystemDate,null);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["FCAmount"].ToString() != "0")
                {
                    if (strMessage == "")
                    {
                        strMessage = "Stock Should be 0 of Following Items \n";
                        strMessage = strMessage + ds.Tables[0].Rows[i]["ItemName"].ToString() + "   " + ds.Tables[0].Rows[i]["FCAmount"].ToString() + "\n";
                    }
                    else
                    {
                        strMessage = strMessage + ds.Tables[0].Rows[i]["ItemName"].ToString() + "   " + ds.Tables[0].Rows[i]["FCAmount"].ToString() + "\n";
                    }
                }
            }
            if (strMessage == "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(strMessage ,"",MessageBoxButtons.OK, MessageBoxIcon.Information);
                ;
                return false;
            }
        }

        #region IToolBar Members

        public bool ADD()
        {

            strButtonState = "ADD";
            return true;
        }

        public bool SAVE()
        {
            strButtonState = "SAVE";
            return true;
        }

        public bool EDIT()
        {
            strButtonState = "EDIT";
            return true;
        }

        public bool QUERY()
        {
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

        private void frmTransProcess_Load(object sender, EventArgs e)
        {
            dtbMaster.Visible = false;
           // dtFromDate.Value = General.dtSystemDate;
            dttoDate.Value = General.dtSystemDate;
            statusStrip1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
