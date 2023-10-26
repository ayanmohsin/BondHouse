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
    public partial class frmAccountSetup : BaseForm,IToolBar
    {
        enum DataPop {Header,City,Nature,Currency,Branch,Account};
       
        General cls;
        DataTable dtSearchMaster;
        string strButtonState = null;
        string strTransType = "SAC";
        public string strError = "";
        DataSet dsPopulateCombo;
        int intLevel = 0;
        string strCondition;
        public enum BtnState
        {
            Add = 0,
            SAVE = 3,
            EDIT = 1,
            QUERY = 4,
            UNDO = 5,
            EXIT = 10,
            DELETE = 2,
            NEXT = 8,
            PREVIOUS = 7,
            LAST = 9,
            FIRST = 6,
            AUTHORIZE = 12,
            PRINT = 11,
        }
    
        public frmAccountSetup()
        {
            InitializeComponent();
        }

        private void PopulateCombo()
        {
            string strQuery = "Select AccountNo,Title,HeaderCode from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Status = 'A' and isTransactional = 'False';Select * from EX_System Where Flag = 'D';Select * from Ex_Nature;Select * from EX_SetupItems Where Status = 'A';Select BranchCode,BranchName From EX_Branch;Select AccountNo,Title from EX_SetupAccount Where BranchCode = '" + General.strBranchCode + "' and Status = 'A' ";
            dsPopulateCombo = new DataSet();
            cls = new General();
 
            dsPopulateCombo =cls.GetDataSet(strQuery);
            cls.PopulateCombo(docboHeader, dsPopulateCombo.Tables[(int)DataPop.Header], "title", "AccountNo");
            cls.PopulateCombo(docboCity, dsPopulateCombo.Tables[(int)DataPop.City], "Description", "Code");
            cls.PopulateCombo(docboNature, dsPopulateCombo.Tables[(int)DataPop.Nature], "Description", "Code");
            cls.PopulateCombo(dicboCurrency, dsPopulateCombo.Tables[(int)DataPop.Currency], "ShortName", "ItemCode");
            cls.PopulateCombo(docboBranch, dsPopulateCombo.Tables[(int)DataPop.Branch], "BranchName", "BranchCode");
            AutoCompleteStringCollection acCustomer = new AutoCompleteStringCollection();
            foreach (DataRow row in dsPopulateCombo.Tables[(int)DataPop.Account].Rows)
            {

                acCustomer.Add(row["Title"].ToString());
            }

            //ditxtTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //ditxtTitle.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //ditxtTitle.AutoCompleteCustomSource = acCustomer;

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
        private void frmAccountSetup_Load(object sender, EventArgs e)
        {
            General.strTableName[0]= "EX_SetupAccount";
            General.strPKColumn = "AccountNo";
            General.strAuthorizeTableName = General.strTableName[0];
            cls = new General();
            cls.EnableDisble(PnlMain, false);
            PopulateCombo();
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
            this.Tag = "S";
            dtDate.Value = General.dtSystemDate;

        }

        void dtbMaster_SelectionChanged(object sender, EventArgs e)
        {
            if (strButtonState != "ADD" || strButtonState != "EDIT")
            {
                if (dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["BankCash"].Value.ToString() == "B")
                {
                    rdoBank.Checked = true;
                }
                else if (dtbMaster.Rows[dtbMaster.CurrentCell.RowIndex].Cells["BankCash"].Value.ToString() == "C")
                {
                    rdoCash.Checked = true;
                }
                
            }
        }
        private void populateTreeView()
        {
                General cls = new General();
            DataSet ds = new DataSet();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_SetupAccount "+ General.strStatusCondition +" and BranchCode = '" + General.strBranchCode + "' and Status = 'A' order by HeaderCode,AccountNo";
            ds =cls.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            tvAccount.Nodes.Clear();
            LoadMenuTreeView(dtSearchMaster);
        }

        private TreeNode BuildNode(string Text)
        {
            return new TreeNode(Text);
        }
        
        public void FillChildren(TreeNode _Parent, string strAccount, DataTable dt)
        {
            intLevel++;
            DataView Data = new DataView(dt);
            Data.RowFilter = "HeaderCode = " + "'" + strAccount + " '";

            //// Define the image index in the lowest level  
            //if (Data.Count == 0)
            //{
            //    _Parent.ImageIndex = 2;
            //    _Parent.SelectedImageIndex = 2;
            //}

            foreach (System.Data.DataRowView foo in Data)
            {
                TreeNode t = BuildNode((string)foo["Title"]);
                t.Tag = intLevel;
                FillChildren(t, foo["AccountNo"].ToString(),dt);
                _Parent.Nodes.Add(t);
                System.Diagnostics.Trace.WriteLine("Added node at level " + intLevel.ToString());
            }
            intLevel--;
        }  

        private void LoadMenuTreeView(DataTable dt)
        {
            DataView Data = new DataView(dt);
            Data.RowFilter = "HeaderCode is null or Headercode = ''";
            foreach (System.Data.DataRowView foo in Data)
            {
                TreeNode t = BuildNode((string)foo["Title"]);
                t.Tag = 0;
                FillChildren(t, foo["AccountNo"].ToString(),dt);
                tvAccount.Nodes.Add(t);
            }

            //tvAccount.ImageList = this.imageList1;
        }  
        

        #region IToolBar Members
        public bool HISTORY()
        {
            return true;
        }
        public bool ADD()
        {
            ditxtAccountNo.Enabled = false;
            strButtonState = "ADD";
            docboHeader.Focus();
            dicboCurrency.SelectedValue = "304";
            return true;
        }

        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();
            string strBankCash;           
            if (strButtonState == "ADD")
            {
                int strTransNo = Convert.ToInt32(cls.GetTransNo(strTransType));
                if (docboHeader.SelectedItem != null)
                {


                    if (docboHeader.SelectedItem.ToString() != "")
                    {
                        string strQuery = "Select isnull(COUNT(AccountNo),0)+1 from EX_SetupAccount Where HeaderCode = '" + docboHeader.SelectedValue.ToString() + "'";
                        ds =cls.GetDataSet(strQuery);
                        string strTransNo1 = ds.Tables[0].Rows[0][0].ToString();
                        ditxtAccountNo.Text = docboHeader.SelectedValue.ToString() + "-" + strTransNo1 + "-" + string.Format("{0:D2}", strTransNo);
                    }
                    else
                    {
                        ditxtAccountNo.Text = string.Format("{0:D2}", strTransNo) + General.strBranchCode;
                    }
                }
                else
                {
                    ditxtAccountNo.Text = string.Format("{0:D2}", strTransNo) + General.strBranchCode;
                }
                ds = new DataSet();
            }
            if (ValidatingControls() == true)
            {
                if (rdoBank.Checked == true)
                {
                    strBankCash = "B";
                }
                else
                {
                    strBankCash = "C";
                }
                strCondition = "" + General.strStatusCondition + " and AccountNo = '" + ditxtAccountNo.Text + "' And BranchCode = '" + General.strBranchCode + "' ";
                ds = cls.SaveRecord(strButtonState, null, General.strTableName, PnlMain, strTransType, strCondition, "BankCash=" + strBankCash + ";BranchCode=" + General.strBranchCode + ";UserId=" + General.strUserId + "", true);
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster,"",null);
                cls.EnableDisble(PnlMain, false);
            }
                strButtonState = "SAVE";
            return true;
        }

        public bool EDIT()
        {
            ditxtAccountNo.Enabled = false;
            strButtonState = "EDIT";
            return true;
        }

        public bool QUERY()
        {
            populateTreeView();
            string strQuery = "Select * from EX_SetupAccount " + General.strStatusCondition + " and BranchCode = '" + General.strBranchCode + "' ";
            if (General.strFormQueryCriteria != "")
            {
                strQuery = strQuery + General.strFormQueryCriteria;
                strQuery = strQuery + " order by HeaderCode,AccountNo";
            }
            else
        	{
                strQuery = strQuery + " order by HeaderCode,AccountNo";
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
            DataSet ds = new DataSet();
            cls = new General();
            Boolean blnState =false;
            string strQuery = "Select * from EX_SetupAccount Where HeaderCode = '" + ditxtAccountNo.Text + "' and BranchCode = '" + General.strBranchCode + "';Select * from EX_ControlAccounts Where BranchCode = '" + General.strBranchCode + "';Select Distinct AccountNo From EX_PrsTransactions Where AccountNo = '" + ditxtAccountNo.Text + "' and BranchCode = '" + General.strBranchCode + "'";

            ds =cls.GetDataSet(strQuery);
            for (int i = 0; i < ds.Tables[1].Columns.Count ; i++)
            {
                if (ditxtAccountNo.Text.ToString() == ds.Tables[1].Rows[0][i].ToString())
                {
                    blnState = true;
                    MessageBox.Show("Control Account should not be Deleted", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                blnState = true;
                MessageBox.Show("Header Account should not be Deleted", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                blnState = true;
                MessageBox.Show("Account should not be Delete Kindly Locked the Account", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (blnState == false)
            {
                strCondition = "Where AccountNo = '" + ditxtAccountNo.Text + "' and BranchCode = '" + General.strBranchCode + "'";
                ds = cls.DeleteRecord(General.strTableName, strCondition);
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster, "",null);
                strButtonState = "DELETE";
                  
            }
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


        private void tvAccount_AfterSelect(object sender, TreeViewEventArgs e)
        {
            for (int i = 0; i < dtbMaster.Rows.Count; i++)
            {
                dtbMaster.Rows[i].Selected = false;
                if (dtbMaster.Rows[i].Cells["Title"].Value.ToString() == e.Node.Text.ToString())
                {
                    dtbMaster.CurrentCell = dtbMaster.Rows[i].Cells[0];
                }
            }   

        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAccountSetup_Deactivate(object sender, EventArgs e)
        {
            
        }

        private void frmAccountSetup_Activated(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true,"S");
        }
    }
}
