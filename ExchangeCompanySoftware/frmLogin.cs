using Microsoft.Win32;
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
    public partial class frmLogin : Form
    {
        enum DataPop { Branch, User ,Session,eSystem};
       
        DataSet dsPopulateCombo;
        General cls;
        string dtSessionDateFrom;
        string dtSessionDateTo;
        string strCompany, strBranch, strBranchId, strBranchIdTO, strAddress, strPhone, strFax;
     
        public frmLogin()
        {
            InitializeComponent();


            string strEndPoint = "";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Endpoint");
            if (key != null)
            {
                object str = key.GetValue("EndPoint");
                if (str != null)
                {
                    if (str.ToString() != "")
                    {
                        strEndPoint = str.ToString();
                    }
                }
                Security sec = new Security();
                string strAddress = sec.Decrypt("Password*124", strEndPoint);
                General.gendPoint = strAddress;
            }
            else
            {
                frmApplication frm = new frmApplication();
                frm.ShowDialog();
            }
        }
        private void PopulateCombo()
        {
            string strQuery = "Select * from EX_Branch;Select * from EX_Login Where Locked = 'False' and Status = 'A';Select * from EX_Session;Select Description,Flag From EX_System";
            dsPopulateCombo = new DataSet();
            cls = new General();
           
            dsPopulateCombo =cls.GetDataSet(strQuery);
            if (dsPopulateCombo == null)
            {
                return;
            }
            cls.PopulateCombo(docboBranch, dsPopulateCombo.Tables[(int)DataPop.Branch], "BranchName", "BranchCode");
            DataRow[] dr = dsPopulateCombo.Tables[(int)DataPop.eSystem].Select("Flag = 'Z'");
            General.dblOverUS = Convert.ToDouble(dr[0]["Description"].ToString());
            dr = dsPopulateCombo.Tables[(int)DataPop.eSystem].Select("Flag = 'E'");
            General.dblExUSRate = Convert.ToDouble(dr[0]["Description"].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // docboUser.SelectedText = txtUserId.Text;

            if (txtUserId.Text != "")
            {
                General.strAddress = strAddress;
                General.strBranchCode = strBranchId;
                General.strBranchCodeTo = strBranchIdTO;
                General.strBranchName = strBranch;
                General.strPhone = strPhone;
                General.strFax = strFax;
                General.strCompanyName = strCompany;
                General.strUserId = txtUserId.Text;
                DataTable dtbUser = dsPopulateCombo.Tables[(int)DataPop.User];
                DataRow[] dr = dtbUser.Select("BranchCode = '" + docboBranch.SelectedValue + "' and UserId = '" + txtUserId.Text + "'");
                if (dr.Count() > 0)
                {
                    General.strBranchCodeTo = dr[0]["BranchCodeTo"].ToString();
                    General.strBranchCodeFrom = dr[0]["BranchCodeFrom"].ToString();

                    if (dr[0]["Password"].ToString() == dotxtPassword.Text)
                    {
                        string strQuery = "Select * from EX_LoginButton a Inner Join SM_OptionButtons b on a.ButtonId = b.OptionId ";
                        strQuery = strQuery + " Inner Join EX_LoginDetail c on a.MnuId = c.OptionId and a.UserId = c.UserId  and a.BranchCode = c.BranchCode";
                        strQuery = strQuery + " Where a.UserId = '" + General.strUserId + "' and a.BranchCode = '" + General.strBranchCode + "' ";
                        General.bolisMainUser = Convert.ToBoolean(dr[0]["isMain"].ToString());
                            General cls = new General();
                        General.dsRights =cls.GetDataSet(strQuery);

                        MainForm frm = new MainForm(dtSessionDateFrom, dtSessionDateTo, txtUserId.Text, strBranch);
                        frm.Show();
                        this.Hide();
                        frm.WindowState = FormWindowState.Maximized;

                    }
                    else
                    {
                        MessageBox.Show("InCorrect Password", "",
                               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                }
                else
                {
                        MessageBox.Show("Invalid User Id", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            else
            {
                MessageBox.Show("Enter User Id", "",
                       MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            
        }
    

        private void frmLogin_Load(object sender, EventArgs e)
        {
            WinApi.AnimateWindow(this.Handle, 800, 655360);
            cls = new General();
          //  if (cls.CheckLocalInterNet() == true && cls.Ping() == true)
            //{
                PopulateCombo();
                if (dsPopulateCombo == null)
                {
                lblError.Visible = true;
                    return;
                }
                txtUserId.Focus();
            //}
           // else
            //{
           //     Application.Exit();
            //}
        }

        private void docboBranch_Validated(object sender, EventArgs e)
        {
            if (dsPopulateCombo == null)
            {
                return;
            }


            DataTable dtbUser = dsPopulateCombo.Tables[(int)DataPop.User];
            DataRow[] dr = dtbUser.Select("BranchCode = '" + docboBranch.SelectedValue + "'");
            DataTable dtbUser2 = new DataTable();
            if (dr.Count() > 0)
            {
                for (int intCol = 0; intCol < 6; intCol++)
                {
                    dtbUser2.Columns.Add();
                    dtbUser2.Columns[intCol].ColumnName = dtbUser.Columns[intCol].ColumnName;
                    
                    for (int i = 0; i < dr.Count(); i++)
                    {
                        if (dr.Count() > dtbUser2.Rows.Count)
                        {
                            dtbUser2.Rows.Add();
                        }
                        dtbUser2.Rows[i][dtbUser2.Columns[intCol].ColumnName] = dr[i][dtbUser2.Columns[intCol].ColumnName].ToString();
                    }

                }
                DataTable dtbBranch = dsPopulateCombo.Tables[(int)DataPop.Branch];
                dr = dtbBranch.Select("BranchCode = '" + docboBranch.SelectedValue + "'");

                strBranch = dr[0]["BranchName"].ToString();
                strBranchId = dr[0]["BranchCode"].ToString();                
                strCompany = dr[0]["CompanyName"].ToString();
                strAddress = dr[0]["Address"].ToString();
                strFax = dr[0]["Fax"].ToString();
                strPhone = dr[0]["Phone"].ToString();

                General.dtSystemDate = Convert.ToDateTime(dr[0]["SystemDate"].ToString());
             //   cls.PopulateCombo(docboUser,dtbUser2, "UserId", "Password");

            }


            dtbUser = dsPopulateCombo.Tables[(int)DataPop.Session];
            dr = dtbUser.Select("BranchCode = '" + docboBranch.SelectedValue + "'");
            dtbUser2 = new DataTable();
            if (dr.Count() > 0)
            {
                for (int intCol = 0; intCol < 3; intCol++)
                {
                    dtbUser2.Columns.Add();
                    dtbUser2.Columns[intCol].ColumnName = dtbUser.Columns[intCol].ColumnName;

                    for (int i = 0; i < dr.Count(); i++)
                    {
                        if (dr.Count() > dtbUser2.Rows.Count)
                        {
                            dtbUser2.Rows.Add();
                        }
                        dtbUser2.Rows[i][dtbUser2.Columns[intCol].ColumnName] = dr[i][dtbUser2.Columns[intCol].ColumnName].ToString();
                    }

                }
            //    cls.PopulateCombo(docboSession, dtbUser2, "SessionName", "SessionId");
            }

        }

        private void dotxtPassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button2_Click(sender, e);
            }
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmApplication frm = new frmApplication();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr =
            MessageBox.Show("Are you sure to Clear Cache. ", "Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Convert.ToString(dr) == "Yes")
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Endpoint");
                key.SetValue("Endpoint", "");
                this.Close();
            }
        }

        private void docboSession_Validated(object sender, EventArgs e)
        {
            //DataTable dtbSession = dsPopulateCombo.Tables[(int)DataPop.Session];
            //DataRow[] dr = dtbSession.Select("SessionId = '"+ docboSession.SelectedValue +"'");
            //dtSessionDateFrom = dr[0]["SessionStart"].ToString();
            //dtSessionDateTo = dr[0]["SessionEnd"].ToString();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void docboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUserId_Validated(object sender, EventArgs e)
        {
        }

        private void txtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}

