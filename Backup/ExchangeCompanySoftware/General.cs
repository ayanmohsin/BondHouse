using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExchangeCompanySoftware.Custom_Controls;
using System.Data;
using System.Net;
using ExchangeCompanySoftware.Reports;
namespace ExchangeCompanySoftware
{
    class General
    {
        GetData.ServiceSoapClient objGetData;
        public static DateTime dtSystemDate = DateTime.Now;
        public static string strPKColumn;
        public static string strFormQueryCriteria = "";
        public static DataSet dsSubReport;
        public static string strStatusCondition = "Where Status in ('U','A','X')";
        public static string strHeadOfficeCode = "35";
        public static string[] strTableName = new string[3];
        public static string strButtonState;
        public static DataSet dsRights;
        public static Boolean isAuthriozationRights;
        public string StrMessage;
        public static double dblExUSRate;
        public static double dblOverUS;
        public static string strUserId ;
        public static Boolean bolNoEDITDelete =false;
        public static string strBranchCode ;
        public static string strBranchCodeTo;
        public static string strBranchCodeFrom;
        public static string strAuthorizeTableName;
        public static string strBranchName ;
        public static string strCompanyName;
        public static string strPhone;
        public static string strFax ;
        public static string strAddress ;
        public static string strReportCaption;
        public static string SessionDateFrom;
        public static string SessionDateTo;
        public static string strFormButtonState;
        public static string strStateAddEDIT = "SAVE~UNDO";
        public static string strStateALL = "ALL";
        public static string strAccountCurrencyCash;
        public static string strAccountCashinHandPK;
        public static double strPortFolioAmount;
        public static DataTable dtbControlAccount;
        public static string strBranchCriteria;
        public static Boolean bolisMainUser;
        BaseForm fs = new BaseForm();

        public string strControlAccount(string strColumnName)
        {
            return General.dtbControlAccount.Rows[0][strColumnName].ToString();
        }
        public bool CheckMorri()
        {
            string strQuery = " Select Sum(Debit) as Debit,Sum(Credit) as Credit,Round(Sum(case When Flag = 'D' then Debit else -Credit end),0) as Amount ";
            strQuery = strQuery + " from EX_PrsTransactions a";
            strQuery = strQuery + " Where a.Status = 'A'   and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and AccountNo != ''";
            GetData.ServiceSoapClient objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            ds = objGetData.GetDataSet(strQuery);
            string strMorri = ds.Tables[0].Rows[0]["Amount"].ToString();
            if (strMorri == "0")
            {
                
                return true;
            }
            else
            {
                MessageBox.Show("Kindly check Morri out from  (" + strMorri + ")");
                return false;
            }
        }
        public DataSet GetStockds(DateTime dtason,string strItemCode)
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();



            string strQuery = " Select a.AccountNo,b.ItemCode,b.ItemName,b.ShortName ";
            strQuery = strQuery + " ,Sum(case When Flag = 'D' then Quantity else -Quantity end) as FCAmount, ";
            strQuery = strQuery + " case When (Sum(case When Flag = 'D' then Quantity else -Quantity end)) > 0 then  ";
            strQuery = strQuery + " Sum(case When Flag = 'D' then Debit else -Credit end)/ ";
            strQuery = strQuery + " Sum(case When Flag = 'D' then Quantity else -Quantity end) else 0 end as AvgRate, ";
            strQuery = strQuery + " Sum(case When Flag = 'D' then Debit else -Credit end) as Amount ";
            strQuery = strQuery + " from EX_PrsTransactions a ";
            strQuery = strQuery + " Inner Join EX_SetupItems b on a.CurrencyCode = b.ItemCode and b.Status = 'A' ";
            strQuery = strQuery + " Inner Join EX_setupAccount c on a.AccountNo = c.AccountNo and a.BranchCode = c.BranchCode and c.Status = 'A' ";
            strQuery = strQuery + " Where a.Status = 'A' and a.AccountNo in  ";
            strQuery = strQuery + " ((Select FCinVault from EX_ControlAccounts Where BranchCode = a.BranchCode)  ";
            strQuery = strQuery + " ,(Select PurchaseSale from EX_ControlAccounts Where BranchCode = a.BranchCode)) and a.BranchCode = '" + strBranchCode + "'   and a.TransDate <= '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "'";
            if (strItemCode != null)
            {
                strQuery = strQuery + " and b.ItemCode = '" + strItemCode + "'";
            }
            strQuery = strQuery + " Group by a.AccountNo,b.ItemCode,b.ItemName,b.ShortName ";

            ds = objGetData.GetDataSet(strQuery);
            return ds;
        }
        public void GenerateVoucher(string strTransType,string strVoucherNo)
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataTable dtb = new DataTable();
            string strQuery;
              
                    strQuery = " select a.TransDate,VoucherNo,a.AccountNo";
                    strQuery = strQuery + ",Title,ShortName,a.Quantity,a.Rate,a.Debit,a.Credit,a.UserId,Remarks ";
                    strQuery = strQuery + " from EX_PrsTransactions a ";
                    strQuery = strQuery + " Inner Join EX_SetupAccount b on a.AccountNo = b.AccountNo  ";
                    strQuery = strQuery + " and a.BranchCode = b.branchCode and b.Status = 'A' ";
                    strQuery = strQuery + " Inner Join EX_SetupItems c on a.CurrencyCode = c.ItemCode ";
                    strQuery = strQuery + " and c.Status = 'A' ";
                    strQuery = strQuery + " Where TransType = '" + strTransType + "' ";
                    strQuery = strQuery + " and VoucherNo = '" + strVoucherNo + "'  ";
                    strQuery = strQuery + " and a.BranchCode = '" + General.strBranchCode + "' ";
                    strQuery = strQuery + " Order by c.ItemName";

                    rptVouchers devrep = new rptVouchers();
                    dtb = objGetData.GetDataSet(strQuery).Tables[0];
                    devrep.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
                    devrep.DataSource = dtb;
                    devrep.Parameters["UserId"].Value = General.strUserId;
                    devrep.Parameters["ReportName"].Value = General.strReportCaption + " Voucher";
                    devrep.Parameters["CompanyName"].Value = General.strCompanyName;
                    devrep.Parameters["BranchName"].Value = General.strBranchName;
                    devrep.Parameters["Criteria"].Value = "";
                    devrep.RequestParameters = false;
                    devrep.CreateDocument();
                    devrep.ShowPreview();

                
    



        }
        public DataSet DeleteRecord(string[] strTableName,string strCondition)
        { 
            DataSet dsMain = new DataSet();
          DialogResult dr =
                      MessageBox.Show("are you sure to delete Record", "Confirmation Delete",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
          if (Convert.ToString(dr) == "Yes")
          {
              objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
              dsMain = objGetData.DeleteRecord(strTableName, strCondition);
              MessageBox.Show("Record Succesfully Delete", "Deleted",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          return dsMain;
        }
        public void BindGridwithTextBox(Panel pnl, DataGridView dtb,string strBranchCode,string[] strDataItem)
        {
            Control.ControlCollection controls = pnl.Controls;
            int intChek = 0;
            foreach (Control ctrl in controls)
            {
                if (ctrl.GetType() == typeof(cstTextBox))
                {
                    if (strBranchCode != ctrl.Tag)
                    {
                        if (ctrl.Tag != null)
                        {
                            ctrl.DataBindings.Clear();
                            ctrl.DataBindings.Add("Text", dtb.DataSource, ctrl.Tag.ToString());
                        }                        
                    }
                }
                else if (ctrl.GetType() == typeof(cstOptionalTextBox))
                {
                    if (strBranchCode != ctrl.Tag)
                    {

                        if (ctrl.Tag != null)
                        {
                            ctrl.DataBindings.Clear();
                            ctrl.DataBindings.Add("Text", dtb.DataSource, ctrl.Tag.ToString());
                        }
                    }
                }

                else if (ctrl.GetType() == typeof(cstNumericupDown))
                {
                    if (strBranchCode != ctrl.Tag)
                    {

                        if (ctrl.Tag != null)
                        {
                            ctrl.DataBindings.Clear();
                            ctrl.DataBindings.Add("Value", dtb.DataSource, ctrl.Tag.ToString());
                        }
                    }
                }

                else if (ctrl.GetType() == typeof(cstComboBox))
	            {
                    
                    if (strBranchCode != ctrl.Tag)
                    {

                        if (ctrl.Tag != null)
                        {
                            if (strDataItem != null)
                            {
                                if (intChek <= strDataItem.Count())
                                {
                                    for (int i = intChek; i < strDataItem.Count(); i++)
                                    {
                                        if (ctrl.Tag.ToString() == strDataItem[i].ToString())
                                        {
                                            intChek = intChek + 1;
                                            ctrl.DataBindings.Clear();
                                            ctrl.DataBindings.Add("Text", dtb.DataSource, ctrl.Tag.ToString());
                                            break;
                                        }
                                        else
                                        {
                                            ctrl.DataBindings.Clear();
                                            ctrl.DataBindings.Add("SelectedValue", dtb.DataSource, ctrl.Tag.ToString());
                                            break;
                                        }
                                    }  
                                }
   
                            }
                            else
                            {
                                ctrl.DataBindings.Clear();
                                ctrl.DataBindings.Add("SelectedValue", dtb.DataSource, ctrl.Tag.ToString());
                            }
                        }
                    }
	            }
                else if (ctrl.GetType() == typeof(cstCheckBox))
                {
                    if (strBranchCode != ctrl.Tag)
                    {

                        if (ctrl.Tag != null)
                        {

                            ctrl.DataBindings.Clear();
                            ctrl.DataBindings.Add("Checked", dtb.DataSource, ctrl.Tag.ToString());
                        }
                    }
                }
                else if (ctrl.GetType() == typeof(cstDateTimePicker))
                {
                    if (strBranchCode != ctrl.Tag)
                    {

                        if (ctrl.Tag != null)
                        {

                            ctrl.DataBindings.Clear();
                            ctrl.DataBindings.Add("Value", dtb.DataSource, ctrl.Tag.ToString());
                        }
                    }
                }

            }
        }
        public void PopulateCombo(cstComboBox cbo, DataTable dtb, string strDisplayName, string strCode)
        {
            cbo.DataSource = dtb;
            cbo.DisplayMember = strDisplayName;
            cbo.ValueMember = strCode;
        }
        public bool IsNumeric(string numberString)
        {
            char[] ca = numberString.ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                if (ca[i] > 57 || ca[i] < 48 && ca[i] < 46)
                    return false;
            }
            return true;
        }
        
        public DataSet CreateMasterDataDataSet(Panel pnlMain, DataGridView grdDetail, string strOtherRecord)
        {
            DataSet dsSave = new DataSet();
            DataTable dtb = new DataTable();
            string strdsTableMaster = "Master";
            int intChk = 0;
            fs = new BaseForm();
            Control.ControlCollection controls = pnlMain.Controls;
            
            //if (pnlMain.Controls["dtTransDate"] == null)
            //{
            //    pnlMain.Controls.Add(fs.Controls["dtTransDate"]);
            //}
  
            dsSave.Tables.Add(strdsTableMaster);
            dsSave.Tables[strdsTableMaster].Columns.Add("RecNo");
            dsSave.Tables[strdsTableMaster].Columns.Add("AuserId");
            dsSave.Tables[strdsTableMaster].Columns.Add("ADate");
            dsSave.Tables[strdsTableMaster].Columns.Add("DuserId");
            dsSave.Tables[strdsTableMaster].Columns.Add("DDate");
            dsSave.Tables[strdsTableMaster].Columns.Add("Status");
            if (strOtherRecord != null)
            {
                string[] strColumn = new string[10];
                string[] arr = strOtherRecord.Split(';'); // split the string's spaces
                for (int i = 0; i < arr.Count(); i++)
                {
                    if (dsSave.Tables[strdsTableMaster].Rows.Count == 0)
                    {
                        dsSave.Tables[strdsTableMaster].Rows.Add();
                    }
                    string[] arrColumn = arr[i].Split('=');
                    dsSave.Tables[strdsTableMaster].Columns.Add(arrColumn[0]);
                    dsSave.Tables[strdsTableMaster].Rows[intChk][arrColumn[0]] = arrColumn[1];
                }
            }

            foreach (Control ctrl in controls)
            {

                if (ctrl.Tag != null && ctrl.Tag.ToString() != "")
                {
                    if (dsSave.Tables[0].Columns.Contains(ctrl.Tag.ToString()) == false)
                    {
                        intChk = 0;
                        if (dsSave.Tables[strdsTableMaster].Rows.Count == 0)
                        {
                            dsSave.Tables[strdsTableMaster].Rows.Add();
                        }
                        dsSave.Tables[strdsTableMaster].Rows[intChk]["RecNo"] = "1";
                        dsSave.Tables[strdsTableMaster].Rows[intChk]["AUserId"] = "";
                        dsSave.Tables[strdsTableMaster].Rows[intChk]["ADate"] = "";
                        dsSave.Tables[strdsTableMaster].Rows[intChk]["DUserId"] = "";
                        dsSave.Tables[strdsTableMaster].Rows[intChk]["DDate"] = "";
                        dsSave.Tables[strdsTableMaster].Rows[intChk]["Status"] = "U";
                        if (ctrl.GetType() == typeof(cstTextBox) || ctrl.GetType() == typeof(cstNumericupDown) || ctrl.GetType() == typeof(cstOptionalTextBox) || ctrl.GetType() == typeof(cstDateTimePicker))
                        {
                            dsSave.Tables[strdsTableMaster].Columns.Add(ctrl.Tag.ToString());
                            dsSave.Tables[strdsTableMaster].Rows[intChk][ctrl.Tag.ToString()] = ctrl.Text;
                        }
                        else if (ctrl.GetType() == typeof(cstComboBox))
                        {
                            cstComboBox ctrlCombo = (cstComboBox)ctrl;
                            dsSave.Tables[strdsTableMaster].Columns.Add(ctrl.Tag.ToString());
                            dsSave.Tables[strdsTableMaster].Rows[intChk][ctrl.Tag.ToString()] = ctrlCombo.SelectedValue;
                        }
                        else if (ctrl.GetType() == typeof(cstCheckBox))
                        {
                            if (ctrl.Tag != null)
                            {
                                cstCheckBox ctrlCombo = (cstCheckBox)ctrl;
                                dsSave.Tables[strdsTableMaster].Columns.Add(ctrl.Tag.ToString());
                                dsSave.Tables[strdsTableMaster].Rows[intChk][ctrl.Tag.ToString()] = ctrlCombo.Checked;

                            }
                        }

                    }
                }
            }
           
            if (grdDetail != null)
            {
                
                if (grdDetail.Rows.Count > 0)
                {
                    string strdsTableDetail = "Detail";
                        
                    for (int intCol = 0; intCol < grdDetail.Columns.Count; intCol++)
                    {
                     
                        dtb.Columns.Add(grdDetail.Columns[intCol].Name);
                        for (int intRows = 0; intRows < grdDetail.Rows.Count; intRows++)
                        {
                            if (grdDetail.Rows[intRows].Cells["Sno"].Value != null)
                            {
                                if (dtb.Rows.Count < grdDetail.Rows.Count)
                                {
                                    if (dtb.Rows.Count == intRows)
                                    {
                                        dtb.Rows.Add();         
                                    }
                                }
                                dtb.Rows[intRows][intCol] = grdDetail.Rows[intRows].Cells[intCol].Value;
                            }
                        }
                    }
                    if (dtb.Columns.Contains("RECNO") == false)
                    {
                        dtb.Columns.Add("RecNo");
                    }
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        dtb.Rows[i]["RecNo"] = "1";
                    }

                    dsSave.Tables.Add(dtb);
                    dsSave.Tables[1].TableName = strdsTableDetail;
                }       
            }
            return dsSave;
        }
        public void ClearALL(Panel pnl)
        {
            Control.ControlCollection controls = pnl.Controls;
            foreach (Control ctrl in controls)
            {

                if (ctrl.GetType() == typeof(cstTextBox) || ctrl.GetType() == typeof(cstNumericupDown) || ctrl.GetType() == typeof(cstOptionalTextBox) || ctrl.GetType() == typeof(cstComboBox))
                {
                    if (ctrl.GetType() == typeof(cstNumericupDown))
                    {
                        ctrl.Text = "0";
                    }
                    else
                    { ctrl.Text = ""; }

                }
            }

        }
        public void EnableDisble(Panel pnl, Boolean blnState)
        {
            Control.ControlCollection controls = pnl.Controls;
            foreach (Control ctrl in controls)
            {
                if (ctrl.GetType() == typeof(RadioButton) || ctrl.GetType() == typeof(cstCheckBox) || ctrl.GetType() == typeof(cstOptionalTextBox) || ctrl.GetType() == typeof(DataGridView) || ctrl.GetType() == typeof(Button) || ctrl.GetType() == typeof(cstTextBox) || ctrl.GetType() == typeof(cstNumericupDown) || ctrl.GetType() == typeof(cstComboBox) || ctrl.GetType() == typeof(Button))
                {
                    ctrl.Enabled = blnState;

                }
            }

        }
        public string GetTransNo(string strTransType)
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            string strQuery = "Select Transactionno = Transactionno + 1 From EX_TransNo Where TransactionType = '" + strTransType + "' and '" + dtSystemDate + "' between DateFrom and DateTo"; 
            ds = objGetData.GetDataSet(strQuery);
            string strTransNo = ds.Tables[0].Rows[0][0].ToString();
            return strTransNo;
        }
        public void UpdateTransNo(string strTransType)
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            string strQuery = "Update EX_TransNo Set Transacationno = Transactionno + 1 Where TransactionType = '" + strTransType + "' and '" + dtSystemDate + "' between DateFrom and DateTo";
            objGetData.Dmlexecute(strQuery);
        }
        public void Validate(Panel pnl)
        {
            StrMessage = null;
            Control.ControlCollection controls = pnl.Controls;
            foreach (Control ctrl in controls)
            {
                if (ctrl.Name.Substring(0, 2) == "di")
                {
                    if (ctrl.GetType() == typeof(cstTextBox))
                    {
                        if (ctrl.Text == string.Empty)
                        {
                            StrMessage = StrMessage + ctrl.Name.Replace("ditxt", "") + "\n";
                        }
                    }
                    else if (ctrl.GetType() == typeof(cstComboBox))
                    {
                        if (ctrl.Text == string.Empty)
                        {
                            StrMessage = StrMessage + ctrl.Name.Replace("dicbo", "") + "\n";
                        }

                    }
                    else if (ctrl.GetType() == typeof(cstNumericupDown))
                    {
                        double dbl = Convert.ToDouble(ctrl.Text);
                        if (dbl == 0)
                        {
                            StrMessage = StrMessage + ctrl.Name.Replace("dinum", "") + "\n";
                        }

                    }
                }
            }
            if (StrMessage != null)
            {
                StrMessage = "must be enter" + "\n" + StrMessage;
            }

        }
        public DataSet SaveRecord(string strButtonState,DataGridView grdDetail,string[] strTableName, Panel PnlMain, string strTransType, string strCondition,string strOtherRecord)
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            DataSet ds = new DataSet();
            DataSet dsMain = new DataSet();
            ds = CreateMasterDataDataSet(PnlMain, grdDetail,strOtherRecord);
            if (strButtonState == "ADD")
            {
                dsMain = objGetData.InsertMasterRecord(ds, strTransType, strTableName,strCondition);
            }
            else if (strButtonState == "EDIT")
            {
                dsMain = objGetData.UpdateMasterRecord(ds, strTableName, strCondition);
            }
            MessageBox.Show("Record Succesfully Saved", "Saved",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return dsMain;
        }
        public bool CheckLocalInterNet()
        {

            try
            {
                System.Net.Dns.GetHostByName("www.google.com");
                return true;
            }
            catch
            {
                MessageBox.Show("Check Your Internet Connection", "",
                     MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false; // host not reachable. 
            }
        }

        public bool Ping()
        {
            objGetData = new ExchangeCompanySoftware.GetData.ServiceSoapClient();
            string url1 = objGetData.Endpoint.ListenUri.ToString();
            WebRequest r = WebRequest.Create(url1);
            try
            {
                r.GetResponse();
                return true;
            }
            catch
            {
                MessageBox.Show("Server is not Responding contact From Head Office", "",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

        }

  
    }
}
