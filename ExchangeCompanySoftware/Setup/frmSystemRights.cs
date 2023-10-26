using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExchangeCompanySoftware.GetData;

namespace ExchangeCompanySoftware
{
    public partial class frmSystemRights : BaseForm,IToolBar
    {
        enum DataPop { Account };
       
        General cls;
        DataSet dsPopulateCombo;
        DataTable dtSearchMaster;
        DataTable dtSearchDetail;
        string strAccountNo = "";
        string strButtonState = null;
        string strTransType = "USER";
        public string strError = "";
        string strCondition;
        int intRows = 0;

        private void AddColumninDetailGrid()
        {
            DataGridViewCheckBoxColumn clmnitchk = new DataGridViewCheckBoxColumn();
            clmnitchk.Name = "Select";
            clmnitchk.HeaderText = "Select";
            clmnitchk.Width = 70;
            dtbDetail.Columns.Add(clmnitchk);

            
            DataGridViewTextBoxColumn cboTitle = new DataGridViewTextBoxColumn();
            cboTitle.Name = "MnuCaption";
            cboTitle.HeaderText = "Menu";
            cboTitle.Width = 200;
            dtbDetail.Columns.Add(cboTitle);

            DataGridViewTextBoxColumn clmnitCode = new DataGridViewTextBoxColumn();
            clmnitCode.Name = "OptionId";
            clmnitCode.HeaderText = "Menu Id";
            clmnitCode.Width = 0;
            dtbDetail.Columns.Add(clmnitCode);


            DataGridViewTextBoxColumn cboState = new DataGridViewTextBoxColumn();
            cboState.Name = "State";
            cboState.HeaderText = "";
            cboState.Width = 0;
            dtbDetail.Columns.Add(cboState);

            DataGridViewTextBoxColumn cboHeader = new DataGridViewTextBoxColumn();
            cboHeader.Name = "Header";
            cboHeader.HeaderText = "";
            cboHeader.Width = 20;
            dtbDetail.Columns.Add(cboHeader);


            DataGridViewTextBoxColumn clmnVNo = new DataGridViewTextBoxColumn();
            clmnVNo.Name = "UserId";
            clmnVNo.HeaderText = "";
            clmnVNo.Width = 0;
            dtbDetail.Columns.Add(clmnVNo);

            DataGridViewTextBoxColumn clmnbrCode = new DataGridViewTextBoxColumn();
            clmnbrCode.Name = "BranchCode";
            clmnbrCode.HeaderText = "";
            clmnVNo.Width = 0;
            dtbDetail.Columns.Add(clmnbrCode);

            DataGridViewCheckBoxColumn clmnitchkw = new DataGridViewCheckBoxColumn();
            clmnitchkw.Name = "Select";
            clmnitchkw.HeaderText = "Select";
            clmnitchkw.Width = 40;
            dtbButton.Columns.Add(clmnitchkw);


            DataGridViewTextBoxColumn cboTitlew = new DataGridViewTextBoxColumn();
            cboTitlew.Name = "ButtonCaption";
            cboTitlew.HeaderText = "Button";
            cboTitlew.Width = 100;
            dtbButton.Columns.Add(cboTitlew);



        }
        public frmSystemRights()
        {
            InitializeComponent();
        }
        public Boolean ValidatingControls()
        {
            Boolean bolState;
            strError = "";
            cls.Validate(PnlMain);
            if (dicboPassword.Text != dotxtConfirmPassword.Text)
            {
                cls.StrMessage = "The Password doesn't Match the Confirm Password";
            }
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
        private void frmSystemRights_Load(object sender, EventArgs e)
        {
            cls = new General();
            AddColumninDetailGrid();
            cls.EnableDisble(PnlMain, false);
            General.strTableName[0]= "EX_Login";
            General.strTableName[1]= "EX_LoginDetail";
            General.strPKColumn = "UserId";
            General.strAuthorizeTableName = General.strTableName[0];
            PopulateCombo();
            dtbMaster.SelectionChanged += new EventHandler(dtbMaster_SelectionChanged);
        }
        private void PopulateCombo()
        {
            string strQuery = "Select BranchCode,BranchName from EX_Branch";
            dsPopulateCombo = new DataSet();
            cls = new General();
             
            dsPopulateCombo =cls.GetDataSet(strQuery);
            cls.PopulateCombo(dicboBranch, dsPopulateCombo.Tables[0], "BranchName", "BranchCode");
        }
        private void GenerateMenus()
        {
            intRows = 0;
            // <<<<<<<<<<<<<<<<<<  Add Menus >>>>>>>>>>>>>>>>>>>>>>>>>
            DataSet ds = new DataSet();
            DataGridViewRow dtr = new DataGridViewRow();
            string strQuery = "Select * from SM_MenuOptions a order by Priority";
            General cls = new General();
            ds =cls.GetDataSet(strQuery);
            DataTable dtb = ds.Tables[0];
            DataTable dtbTemp = dtb.Copy();
            DataRow[] ldatarows = dtb.Select("mnuHeader is null");
            int l = dtb.Rows.Count;
            dtbDetail.Rows.Clear();
            // <<<<<<<<<<<<<<<<<<  Add Sub Menus >>>>>>>>>>>>>>>>>>>>>>>>>
            foreach (DataRow ldatarow in ldatarows)
            {
                    dtbDetail.Rows.Add();
                    dtbDetail.Rows[intRows].Cells["OptionId"].Value = ldatarow["MnuId"].ToString();
                    dtbDetail.Rows[intRows].Cells["Select"].Value = false;
                    dtbDetail.Rows[intRows].Cells["MnuCaption"].Value = ldatarow["mnuCaption"].ToString();
                    dtbDetail.Rows[intRows].Cells["State"].Value = ldatarow["Status"].ToString();
                    dtbDetail.Rows[intRows].Cells["Header"].Value = ldatarow["mnuHeader"].ToString();
                    dtbDetail.Rows[intRows].DefaultCellStyle.BackColor = Color.SteelBlue;
                   
                //     dtbDetail.Rows.Add(dtr);
                // <<<<<<<<<<<<<<<<<<  Add Child Menus  >>>>>>>>>>>>>>>>>>>>>>>>>
                    AddChildMenu(intRows, dtbTemp, ldatarow["mnuid"].ToString(), true);
                    intRows = intRows + 1;
                
            }

        }
        private void GenerateButton()
        {
            intRows = 0;
            // <<<<<<<<<<<<<<<<<<  Add Menus >>>>>>>>>>>>>>>>>>>>>>>>>
            DataSet ds = new DataSet();
            DataGridViewRow dtr = new DataGridViewRow();
            string strQuery = "Select * from SM_OptionButtons a";

            cls = new General();
            ds =cls.GetDataSet(strQuery);
            DataTable dtb = ds.Tables[0];
            DataTable dtbTemp = dtb.Copy();
            dtbButton.Rows.Clear();
            // <<<<<<<<<<<<<<<<<<  Add Sub Menus >>>>>>>>>>>>>>>>>>>>>>>>>
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                dtbButton.Rows.Add();
                dtbButton.Rows[i].Cells["ButtonCaption"].Value = dtb.Rows[i]["ButtonName"].ToString();
                dtbButton.Rows[i].Cells["Select"].Value = false;
            }
        }
   
        private void AddChildMenu(int intProw,DataTable psourceTable, string pHeadercode,Boolean pbol)
        {
            int irow = 1;
            string strCriteria = "mnuHeader =  '" + pHeadercode + "'";
            DataRow[] ldatarows = psourceTable.Select(strCriteria);
            if (ldatarows.Length > 0)
            {
                
                //if (pbol == false)
                //{
                //    intRows = intRows + 1;
                //}
                foreach (DataRow ldatarow in ldatarows)
                {
                    intRows = intRows + 1;
                    dtbDetail.Rows.Add();
                    dtbDetail.Rows[intRows].Cells["OptionId"].Value = ldatarow["MnuId"].ToString();
                    dtbDetail.Rows[intRows].Cells["MnuCaption"].Value = ldatarow["mnuCaption"].ToString();
                    dtbDetail.Rows[intRows].Cells["State"].Value = ldatarow["Status"].ToString();
                    dtbDetail.Rows[intRows].Cells["Header"].Value = ldatarow["mnuHeader"].ToString();
                    dtbDetail.Rows[intRows].Cells["Select"].Value = false;

                    //                dtbDetail.Rows.Add(dtr);
                    // <<<<<<<<<<<<<<<<<<  Add Child Menus  >>>>>>>>>>>>>>>>>>>>>>>>>
                    if (pbol == false)
                    {
                        dtbDetail.Rows[intRows].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        dtbDetail.Rows[intRows].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }

                    AddChildMenu(intRows, psourceTable, ldatarow["mnuid"].ToString(), false);
                    //irow = irow + 1;
                    //if (irow <= ldatarows.Length)
                    //{
                    //    intRows = intRows + 1;
                        
                    //}
                    // <<<<<<<<<<<<<<<<<<  make a Form Event  >>>>>>>>>>>>>>>>>>>>>>>>>
                 
                }
            }
        }
        #region IToolBar Members

        public bool ADD()
        {
            dtbDetail.Rows.Clear();
            GenerateMenus();
            strButtonState = "ADD";
            return true;
        }

        public bool SAVE()
        {
            cls = new General();
            DataSet ds = new DataSet();
            DataTable dtb = new DataTable();
            int intRows = 0;
            if (strButtonState == "ADD")
            {
            }
            for (int i = 0; i < dtbDetail.Columns.Count; i++)
            {
                dtb.Columns.Add(dtbDetail.Columns[i].Name);
            }            
            dtb.Columns.Add("Sno");
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtbDetail.Rows[i].Cells["Select"].Value.ToString()) == true)
                {
                    dtb.Rows.Add();
                    dtb.Rows[intRows]["Select"] = dtbDetail.Rows[i].Cells["Select"].Value;
                    dtb.Rows[intRows]["OptionId"] = dtbDetail.Rows[i].Cells["OptionId"].Value;
                    dtb.Rows[intRows]["MnuCaption"] = dtbDetail.Rows[i].Cells["MnuCaption"].Value;
                    dtb.Rows[intRows]["State"] = dtbDetail.Rows[i].Cells["State"].Value;
                    dtb.Rows[intRows]["Header"] = dtbDetail.Rows[i].Cells["Header"].Value;
                    dtb.Rows[intRows]["UserId"] = ditxtUser.Text;
                    dtb.Rows[intRows]["BranchCode"] = dicboBranch.SelectedValue;
                    dtb.Rows[intRows]["Sno"] = intRows;
                    intRows = intRows + 1;
                }
            }
            if (dtbdetail1.Columns.Count > 0)
            {
                dtbdetail1.Columns.RemoveAt(0);                
            }
            dtbdetail1.DataSource = dtb;
            
            if (ValidatingControls() == true)
            {

                strCondition = "Where UserId = '" + ditxtUser.Text + "' and BranchCode = '"+ dicboBranch.SelectedValue +"'";
                ds = cls.SaveRecord(strButtonState, dtbdetail1, General.strTableName, PnlMain, strTransType, strCondition, "BranchCodeFrom=" + dicboBranch.SelectedValue + ";BranchCodeTo=" + dicboBranch.SelectedValue + "");
                cls.EnableDisble(PnlMain, false);
                dtSearchDetail = ds.Tables[1];
                dtbMaster.DataSource = ds.Tables[0];
                cls.BindGridwithTextBox(PnlMain, dtbMaster, "",null);
                strButtonState = "SAVE";
            }
            else
            {
                MessageBox.Show(strError, "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public bool EDIT()
        {

            dtbDetail.Columns["Select"].ReadOnly = false;

            ditxtUser.Enabled = false;
            strButtonState = "EDIT";
            return true;
        }

        public bool QUERY()
        {
                General cls = new General();
            DataSet ds = new DataSet();
            dtSearchDetail = new DataTable();
            dtSearchMaster = new DataTable();
            string strQuery;
            strQuery = "Select * from EX_Login " + General.strStatusCondition + ";Select Sno,Userid,BranchCode,OptionId from EX_LoginDetail a Inner Join SM_MenuOptions b on a.OptionId = b.MnuId";
            ds =cls.GetDataSet(strQuery);
            dtSearchMaster = ds.Tables[0];
            dtSearchDetail = ds.Tables[1];
            dtbMaster.DataSource = dtSearchMaster;
            cls.BindGridwithTextBox(PnlMain, dtbMaster, "",null);
            dtbMaster_SelectionChanged(dtbMaster, null);
            strButtonState = "QUERY";
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
            cls = new General();
            strCondition = "Where UserId = '" + ditxtUser.Text + "' And BranchCode = '" + General.strBranchCode + "'";
            cls.DeleteRecord(General.strTableName, strCondition);
            strButtonState = "DELETE";
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
        private void dtbDetail_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            GenerateButton();


        }
        void dtbMaster_SelectionChanged(object sender, EventArgs e)
        {
                if (ditxtUser.Text != "" && strButtonState != "ADD")
                {

                    DataRow[] dr = new DataRow[0];
                    DataGridViewTextBoxColumn dtc = new DataGridViewTextBoxColumn();
                    dtc.Name = "OptionId";
                    if (dtbDetail.Rows.Count == 0)
                    {
                        dtbDetail.Rows.Clear();
                        GenerateMenus();

                    }
                    for (int i = 0; i < dtbDetail.Rows.Count; i++)
                    {
                        dtbDetail.Rows[i].Cells["Select"].Value = false;
                    }
                    dr = dtSearchDetail.Select("UserId = '" + ditxtUser.Text + "' and BranchCode = '" + dicboBranch.SelectedValue + "'", "UserId");
                    if (dtbdetail1.Rows.Count > 0)
                    {
                        dtbdetail1.DataSource = null;
                    }
                    if (dtbdetail1.Columns.Count > 0)
                    {
                        dtbdetail1.Columns.RemoveAt(0);
                    }
                    dtbdetail1.Columns.Add(dtc);
                    for (int i = 0; i < dr.Count(); i++)
                    {
                        dtbdetail1.Rows.Add();
                        dtbdetail1.Rows[i].Cells["OptionId"].Value = dr[i]["OptionId"].ToString();
                        for (int j = 0; j < dtbDetail.Rows.Count; j++)
                        {

                            if (dr[i]["OptionId"].ToString() == dtbDetail.Rows[j].Cells["OptionId"].Value.ToString())
                            {

                                dtbDetail.Rows[j].Cells["Select"].Value = true;
                            }
                        }
                    }
                }

            }

        private void cstCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                dtbDetail.Rows[i].Cells["Select"].Value = chkSelectAll.Checked;
            }
        }

        private void dtbDetail_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtbButton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string strButtonRights = "";
            for (int i = 0; i < dtbButton.Rows.Count ; i++)
            {
                if (Convert.ToBoolean(dtbButton.Rows[i].Cells["Select"].Value) == true)
                {
                    strButtonRights = strButtonRights + "" + dtbButton.Rows[i].Cells["ButtonCaption"].Value + ";";
                }
            }
        }

        private void frmSystemRights_Activated(object sender, EventArgs e)
        {
            MainForm Mainfrm = (MainForm)this.ParentForm;
            Mainfrm.EnableDisbale(strButtonState, true, "S");
            
        }
        }
  
}

