using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExchangeCompanySoftware.GetData;
using System.Globalization;
using System.Drawing.Drawing2D;
using DevExpress.XtraBars;
using DevExpress.XtraPivotGrid;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace ExchangeCompanySoftware
{
    public partial class MainForm : Form
    {
        General cls;
        private int childFormNumber = 0;
       
        string strQuery;
        ToolStripMenuItem lMenuItem;
        DevExpress.XtraNavBar.NavBarItem lNavBarItem;
        TreeNode tNode;
        string mstrCaption;
        DataTable dtb;
        DataSet ds;
        int intLevel = 0;
        PivotGridField fd5;
        string strMenuId = "";
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
        private Image SetImageSize(Image thisImage, int Width, int Height)
        {
            Bitmap thisBitMap = new Bitmap(Width, Height);
            Graphics thisGraphic = Graphics.FromImage((Image)thisBitMap);
            thisGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            thisGraphic.DrawImage(thisImage, 0, 0, Width, Height);
            thisGraphic.Dispose();

            return (Image)thisBitMap;
        }
        private void addImagesonToolBtn()
        {
            Image img;
            int intWidth = 25;
            int intHeight = 25;
           
            Tool.Items[Convert.ToInt16(BtnState.Add)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.EDIT)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.DELETE)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.SAVE)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.UNDO)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.QUERY)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.FIRST)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.PREVIOUS)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.NEXT)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.LAST)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.EXIT)].ImageScaling = ToolStripItemImageScaling.None;
            Tool.Items[Convert.ToInt16(BtnState.PRINT)].ImageScaling = ToolStripItemImageScaling.None;
            img = Resource1.AddNew;
            Tool.Items[Convert.ToInt16(BtnState.Add)].Image = SetImageSize(img, intWidth, intHeight);
            img = Resource1.EdiNew;
            Tool.Items[Convert.ToInt16(BtnState.EDIT)].Image = SetImageSize(img, intWidth, intHeight);
            img = Resource1.delete;
            Tool.Items[Convert.ToInt16(BtnState.DELETE)].Image = SetImageSize(img, 50, intHeight);
            img = Resource1.save;
            Tool.Items[Convert.ToInt16(BtnState.SAVE)].Image = SetImageSize(img, intWidth, intHeight);
            img = Resource1.undo;
            Tool.Items[Convert.ToInt16(BtnState.UNDO)].Image = SetImageSize(img, intWidth, intHeight);
            img = Resource1.Query;
            Tool.Items[Convert.ToInt16(BtnState.QUERY)].Image = SetImageSize(img, intWidth, intHeight);
            img = Resource1.skip_backward;
            Tool.Items[Convert.ToInt16(BtnState.FIRST)].Image = SetImageSize(img, intWidth, intHeight);
            img = Resource1.rewind;
            Tool.Items[Convert.ToInt16(BtnState.PREVIOUS)].Image = SetImageSize(img, intWidth, intHeight);
            img = Resource1.fast_forward;
            Tool.Items[Convert.ToInt16(BtnState.NEXT)].Image = SetImageSize(img, intWidth, intHeight);
            img = Resource1.skip_forward;
            Tool.Items[Convert.ToInt16(BtnState.LAST)].Image = SetImageSize(img, intWidth, intHeight);
            img = Resource1.close ;
            Tool.Items[Convert.ToInt16(BtnState.EXIT)].Image = SetImageSize(img, intWidth, intHeight);
            img = Resource1.print;
            Tool.Items[Convert.ToInt16(BtnState.PRINT)].Image = SetImageSize(img, intWidth, intHeight);
            
        }
        private void GenerateButtons()
        {
            // <<<<<<<<<<<<<<<<<<  Add option Buttons (ADD EDIT DELTE)  >>>>>>>>>>>>>>>>>>>>>>>>>
            try
            {
                ds = new DataSet();
                strQuery = "Select * from SM_OptionButtons order by Priority";
                General cls = new General();
                ds =cls.GetDataSet(strQuery);
                dtb = ds.Tables[0];
                int l = dtb.Rows.Count;
                Tool.Items.Clear();
                for (int i = 0; i < l; i++)
                {
                    
                    ToolStripButton lButo = new ToolStripButton();
                    lButo.Text = dtb.Rows[i]["ButtonName"].ToString(); ;
                    lButo.Name = dtb.Rows[i]["ButtonName"].ToString(); ;
                    lButo.BackColor = Color.Black;
                    lButo.ForeColor = Color.Lime;
                    lButo.Tag = dtb.Rows[i]["OptionID"].ToString(); ;
                    Tool.Items.Add(lButo);
                    lButo.Visible = false;
                    lButo.TextImageRelation = TextImageRelation.ImageAboveText;
                    lButo.Click += new EventHandler(Tool_Click);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NAVMENU()
        {
            // <<<<<<<<<<<<<<<<<<  Add Menus >>>>>>>>>>>>>>>>>>>>>>>>>
            ds = new DataSet();
            strQuery = "Select * from SM_MenuOptions a inner Join EX_LoginDetail b on a.MnuId = b.OptionId Inner Join EX_Login c on b.UserId = c.UserId and b.BranchCode = c.BranchCode and b.RecNo = c.RecNo Where c.UserId = '" + General.strUserId + "' and b.BranchCode = '" + General.strBranchCode + "'  and c.Status = 'A'  order by Priority";

            cls = new General();
            ds =cls.GetDataSet(strQuery);
            dtb = ds.Tables[0];
            DataTable dtbTemp = dtb.Copy();
            DataRow[] ldatarows = dtb.Select("mnuHeader is null");
            int l = dtb.Rows.Count;
            NAVCONTROL.Items.Clear();
            TreeView tv = null;
            // <<<<<<<<<<<<<<<<<<  Add Sub Menus >>>>>>>>>>>>>>>>>>>>>>>>>
            foreach (DataRow ldatarow in ldatarows)
            {
                DevExpress.XtraNavBar.NavBarGroup nav = new DevExpress.XtraNavBar.NavBarGroup();
                DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
                tv = new TreeView();
                navBarGroupControlContainer1.Controls.Add(tv);
                nav.Name = ldatarow["mnuName"].ToString();
                nav.Caption = ldatarow["mnuCaption"].ToString();
                nav.Tag = ldatarow["FormName"].ToString();
                nav.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
                NAVCONTROL.Controls.Add(navBarGroupControlContainer1);
                nav.ControlContainer = navBarGroupControlContainer1;
                nav.GroupClientHeight = 300;
                string strImageResourse = "Resource1." + ldatarow["mnuCaption"].ToString();
                Stream imgStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(strImageResourse);
                if (imgStream != null)
                {
                    nav.SmallImage = new Bitmap(imgStream);
                }
                
                tv.Height = nav.GroupClientHeight;
                tv.Width = 200;
                tv.BackColor = Color.White;
                    tv.BorderStyle = BorderStyle.None;
                tv.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tv.ForeColor = Color.Black ;
                nav.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
                NAVCONTROL.Groups.Add(nav);
                // <<<<<<<<<<<<<<<<<<  Add Child Menus  >>>>>>>>>>>>>>>>>>>>>>>>>
                // AddChildNAvMenu(nav, dtbTemp, ldatarow["mnuid"].ToString());
                FillChildren(tv, ldatarow["mnuName"].ToString(), dtb);
            }

        }
        
        private void NAVMENUOLD()
        {
            // <<<<<<<<<<<<<<<<<<  Add Menus >>>>>>>>>>>>>>>>>>>>>>>>>
            ds = new DataSet();
            strQuery = "Select * from SM_MenuOptions a inner Join EX_LoginDetail b on a.MnuId = b.OptionId Inner Join EX_Login c on b.UserId = c.UserId and b.BranchCode = c.BranchCode and b.RecNo = c.RecNo Where c.UserId = '" + General.strUserId + "' and b.BranchCode = '" + General.strBranchCode + "'  and c.Status = 'A'  order by Priority";
            cls = new General();
            ds =cls.GetDataSet(strQuery);
            dtb = ds.Tables[0];
            DataTable dtbTemp = dtb.Copy();
            DataRow[] ldatarows = dtb.Select("mnuHeader is null");
            int l = dtb.Rows.Count;
            NAVCONTROL.Items.Clear();
            
            // <<<<<<<<<<<<<<<<<<  Add Sub Menus >>>>>>>>>>>>>>>>>>>>>>>>>
            foreach (DataRow ldatarow in ldatarows)
            {
                DevExpress.XtraNavBar.NavBarGroup nav = new DevExpress.XtraNavBar.NavBarGroup();
                nav.Name = ldatarow["mnuName"].ToString();
                nav.Caption = ldatarow["mnuCaption"].ToString();
                nav.Tag = ldatarow["FormName"].ToString();
                NAVCONTROL.Groups.Add(nav);
                // <<<<<<<<<<<<<<<<<<  Add Child Menus  >>>>>>>>>>>>>>>>>>>>>>>>>
                AddChildNAvMenu(nav, dtbTemp, ldatarow["mnuid"].ToString());
            }

        }

        private void AddChildNAvMenu(DevExpress.XtraNavBar.NavBarGroup pParenetMenu, DataTable psourceTable, string pHeadercode)
        {
            string strCriteria = "mnuHeader =  '" + pHeadercode + "'";
            DataRow[] ldatarows = psourceTable.Select(strCriteria);
            if (ldatarows.Length > 0)
            {
                foreach (DataRow ldatarow in ldatarows)
                {
                    DevExpress.XtraNavBar.NavBarItem navitem = new DevExpress.XtraNavBar.NavBarItem();
                    navitem.Name = ldatarow["mnuName"].ToString();
                    navitem.Caption = ldatarow["mnuCaption"].ToString();
                    navitem.Tag = ldatarow["FormName"].ToString();
                    pParenetMenu.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] 
                    { new DevExpress.XtraNavBar.NavBarItemLink(navitem)});
        //            AddChildNAvGROUP(navitem, psourceTable, ldatarow["mnuid"].ToString());
                    // <<<<<<<<<<<<<<<<<<  make a Form Event  >>>>>>>>>>>>>>>>>>>>>>>>>
                    navitem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navitem_LinkClicked);
///                    mnudeatil.Click += new EventHandler(mnuheader_Click);
                }
            }
        }

        public void FillChildren(object _Parent, string strAccount, DataTable dt)
        {
            string strCriteria = "mnuHeader =  '" + strAccount + "'";
            DataRow[] ldatarows = dt.Select(strCriteria);
            TreeView tv = null;
            TreeNode td = null;
            if (_Parent.GetType().Name.ToString() == "TreeView")
            {
                tv = (TreeView)_Parent;
                tv.NodeMouseClick += new TreeNodeMouseClickEventHandler(tv_NodeMouseClick);
            }
            else
            {
                td = (TreeNode)_Parent;
            }
            foreach (DataRow ldatarow in ldatarows)
            {
                TreeNode t = new TreeNode();
                t.Name = ldatarow["mnuName"].ToString();
                t.Text = ldatarow["mnuCaption"].ToString();
                t.Tag = ldatarow["FormName"].ToString();
                if (_Parent.GetType().Name.ToString() == "TreeView")
                {
                    tv.Nodes.Add(t);
                }
                else
                {
                    td.Nodes.Add(t);
                }
                FillChildren(t, ldatarow["mnuName"].ToString(), dt);

            }
        }

        void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Form frm = new Form();
            General.strReportCaption = e.Node.Text;
            strMenuId = e.Node.Name.ToString();
            if (e.Node.Tag.ToString() != "")
            {
                //if (lNavBarItem.Tag.ToString() != "frmReports")
                if (e.Node.Tag.ToString() != "frmReportQueryBuilder" && e.Node.Tag.ToString() != "frmSBP")
                {
                    frm = Returnforms(e.Node.Tag.ToString());
                    frm.MdiParent = this;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //frm.WindowState = FormWindowState.Maximized;

                    if (frm.Controls["PnlBase"] != null)
                    {
                        Label lblCaption = (Label)frm.Controls["PnlBase"].Controls["lblcaption"];

                        frm.Controls["PnlBase"].Width = frm.Width;
                    }
                    frm.Text = General.strReportCaption.ToUpper();
                    //                    frm.MaximizeBox = false;
                    frm.KeyPreview = true;
                    if (frm.Controls["PnlMain"] != null)
                    {
                        Panel pnlMain = (Panel)frm.Controls["PnlMain"];
                        //  pnlMain.Controls.Add(frm.Controls["txtBranchCode"]);
                        //pnlMain.Controls.Add(frm.Controls["dtTransDate"]);
                        //pnlMain.Controls.Add(frm.Controls["txtUserId"]);

                    }
                    DataTable dtb = new DataTable();
                    dtb = General.dsRights.Tables[0];
                    DataRow[] ldatarows = dtb.Select("MnuId = '" + strMenuId + "'");
                    foreach (DataRow ldatarow in ldatarows)
                    {
                        Tool.Items[ldatarow["ButtonName"].ToString()].Visible = true;
                    }
                    DataRow[] ldatarows2 = dtb.Select("MnuId = '" + strMenuId + "' and isAuth = 'True'");
                    if (ldatarows2.Count() > 0)
                    {
                        General.isAuthriozationRights = true;
                    }
                    else
                    {
                        General.isAuthriozationRights = false;
                    }
                    Tool.Items[Convert.ToInt16(BtnState.Add)].Enabled = true;
                    Tool.Items[Convert.ToInt16(BtnState.QUERY)].Enabled = true;
                }
                else
                {
                    if (e.Node.Tag.ToString() == "frmSBP")
                    {
                        frm = new frmSBP(e.Node.Name.ToString());
                    }
                    else
                    {
                        frm = new frmReportQueryBuilder(e.Node.Name.ToString());
                    }
                    frm.MdiParent = this;
                    frm.Text = General.strReportCaption;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                }
                Tool.Items[Convert.ToInt16(BtnState.EXIT)].Enabled = true;
                frm.TopMost = true;
                frm.BringToFront();
                frm.Show();
            }
        }
       
        
        void navitem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = new Form();
            lNavBarItem = (DevExpress.XtraNavBar.NavBarItem)sender;
            General.strReportCaption = lNavBarItem.Caption;
            strMenuId = lNavBarItem.Name.ToString();
            if (lNavBarItem.Tag.ToString() != "")
            {
                //if (lNavBarItem.Tag.ToString() != "frmReports")
                if (lNavBarItem.Tag.ToString() != "frmReportQueryBuilder" && lNavBarItem.Tag.ToString() != "frmSBP")
                {
                    frm = Returnforms(lNavBarItem.Tag.ToString());
                    frm.MdiParent = this;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //frm.WindowState = FormWindowState.Maximized;
                  
                    if (frm.Controls["PnlBase"] != null)
                    {
                        Label lblCaption = (Label)frm.Controls["PnlBase"].Controls["lblcaption"];
                      
                        frm.Controls["PnlBase"].Width = frm.Width;
                    }
                    frm.Text = General.strReportCaption.ToUpper();
//                    frm.MaximizeBox = false;
                    frm.KeyPreview = true;
                    if (frm.Controls["PnlMain"] != null)
                    {
                        Panel pnlMain = (Panel)frm.Controls["PnlMain"];
                        //  pnlMain.Controls.Add(frm.Controls["txtBranchCode"]);
                        //pnlMain.Controls.Add(frm.Controls["dtTransDate"]);
                        //pnlMain.Controls.Add(frm.Controls["txtUserId"]);

                    }
                    DataTable dtb = new DataTable();
                    dtb = General.dsRights.Tables[0];
                    DataRow[] ldatarows = dtb.Select("MnuId = '" + strMenuId + "'");
                    foreach (DataRow ldatarow in ldatarows)
                    {
                        Tool.Items[ldatarow["ButtonName"].ToString()].Visible = true;
                    }
                    DataRow[] ldatarows2 = dtb.Select("MnuId = '" + strMenuId + "' and isAuth = 'True'");
                    if (ldatarows2.Count() > 0)
                    {
                        General.isAuthriozationRights = true; 
                    }
                    else
                    {
                        General.isAuthriozationRights = false; 
                    }
                    Tool.Items[Convert.ToInt16(BtnState.Add)].Enabled = true;
                    Tool.Items[Convert.ToInt16(BtnState.QUERY)].Enabled = true;
                }
                else
                {
                    if (lNavBarItem.Tag.ToString() == "frmSBP")
                    {
                        frm = new frmSBP(lNavBarItem.Name.ToString());
                    }
                    else
                    {
                        frm = new frmReportQueryBuilder(lNavBarItem.Name.ToString());
                    }
                    frm.MdiParent = this;
                    frm.Text = General.strReportCaption;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                }
                Tool.Items[Convert.ToInt16(BtnState.EXIT)].Enabled = true;
                frm.TopMost = true;
                frm.BringToFront();
                frm.Show();
                
            }
        }

        private void PopulateMorri()
        { 
                strQuery = " Select Sum(Debit) as Debit,Sum(Credit) as Credit,Round(Sum(case When Flag = 'D' then Debit else -Credit end),0) as Amount ";
                strQuery = strQuery + " from EX_PrsTransactions a";
                strQuery = strQuery + " Where a.Status = 'A'   and a.BranchCode = '" + General.strBranchCode + "' and a.TransDate <= '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' ";
                strQuery = strQuery + " and AccountNo != ''";
                    General cls = new General();
                DataSet ds = new DataSet();
                ds =cls.GetDataSet(strQuery);
                object oAmount = ds.Tables[0].Rows[0]["Amount"];
                double dblAmount = 0;
                if (oAmount != null)
                {
                    if (oAmount.ToString() != "")
                    {
                        dblAmount = Convert.ToDouble(oAmount);
                    }
                }


                if (dblAmount != 0)
                {
                    label1.Text = "Capital not ok";
                    label1.ForeColor = Color.Red;
                }
                else
	            {
                    label1.Text = "Capital ok";
                    label1.ForeColor = Color.Green;
	            }
        }
        
        void Tool_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton lStripItem = (ToolStripButton)sender;
                IToolBar frmActiveform = null;
                General.strButtonState = sender.ToString();
                    if (this.ActiveMdiChild == null)
                    {
                        Application.Exit();
                        return;
                    }
                    if (this.ActiveMdiChild.Name != "frmReports" || this.ActiveMdiChild.Name != "frmSBP")
                    {
                        frmActiveform = (IToolBar)this.ActiveMdiChild;
                        BaseForm bs = (BaseForm)this.ActiveMdiChild;
                        bs.BaseButtonState = sender.ToString();
                        if (sender.ToString() == "EXIT")
                        {
                            foreach (ToolStripButton lstrip in Tool.Items)
                            {
                                lstrip.Visible = false;
                            }
                        }
                        if (sender.ToString() == "QUERY")
                        {
                            frmFormQueryBuilder frm = new frmFormQueryBuilder(bs.Name.ToString());
                            frm.ShowDialog();

                        }
                    }
                    else
                    {
                        this.ActiveMdiChild.Close();
                    }


                    if (frmActiveform != null)
                    {
                        DataSet ds = new DataSet();
                        DataTable dtb = new DataTable();
                        string strQuery = " Select * from EX_Revaluetion Where TransDate = '" + General.dtSystemDate.ToString("dd/MMM/yyyy") + "' and BranchCode = '" + General.strBranchCode + "' and Status = 'A'";
                            General cls = new General();
                        ds =cls.GetDataSet(strQuery);
                        dtb = ds.Tables[0];
                        if (dtb.Rows.Count == 0 || this.ActiveMdiChild.Name == "frmRevalution" || this.ActiveMdiChild.Name == "frmVaultINOUT")
                        {

                            EnableDisbale(sender.ToString(), true, "F");
                            frmActiveform.GetType().GetMethod(lStripItem.Text).Invoke(frmActiveform, null);
                        }
                        else
                        {
                            MessageBox.Show("After Revalution Entry is not Post must Delete the Revalution", "Revaluation",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
            }

        }

        public void EnableDisbale(string strButtonState, Boolean blnState,string strFS)
        {
            cls = new General();
            General.strButtonState = strButtonState;
            Panel pnlMain = null;
            DataGridView dtbMaster = null;
            if (this.ActiveMdiChild != null)
            {
                pnlMain = (Panel)this.ActiveMdiChild.Controls["PnlMain"];
                dtbMaster = (DataGridView)this.ActiveMdiChild.Controls["dtbMaster"];
            }
            for (int i = 0; i < Tool.Items.Count; i++)
            {
                Tool.Items[i].Enabled = blnState;
            }
            if (strButtonState == "NEXT" || strButtonState == "LAST" || strButtonState == "PREVIOUS" || strButtonState == "FIRST")
            {
                for (int i = 0; i < Tool.Items.Count; i++)
                {
                    Tool.Items[i].Enabled = true;
                }
            }
            if (strButtonState == "ADD")
            {
                Tool.Items[Convert.ToInt16(BtnState.Add)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.UNDO)].Enabled = true;
                Tool.Items[Convert.ToInt16(BtnState.SAVE)].Enabled = true;
                Tool.Items[Convert.ToInt16(BtnState.EDIT)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.DELETE)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.EXIT)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.FIRST)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.LAST)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.NEXT)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.PREVIOUS)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.QUERY)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.PRINT)].Enabled = false;

                if (strFS == "F")
                {
                    cls.ClearALL(pnlMain);                    
                }
             //   DateTimePicker dt = (DateTimePicker)pnlMain.Controls["dtTransDate"];
               // pnlMain.Controls["txtBranchCode"].Text = General.strBranchCode.ToString();
               // pnlMain.Controls["txtUserId"].Text = General.strUserId;
           //     dt.Text = General.dtSystemDate.ToString();
                cls.EnableDisble(pnlMain, true);
            }
            if (strButtonState == "EDIT")
            {
                Tool.Items[Convert.ToInt16(BtnState.Add)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.UNDO)].Enabled = true;
                Tool.Items[Convert.ToInt16(BtnState.SAVE)].Enabled = true;
                Tool.Items[Convert.ToInt16(BtnState.EDIT)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.DELETE)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.EXIT)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.FIRST)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.LAST)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.NEXT)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.PREVIOUS)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.QUERY)].Enabled = false;
                Tool.Items[Convert.ToInt16(BtnState.PRINT)].Enabled = false;

                cls.EnableDisble(pnlMain, true);
                dtbMaster.Enabled = false;
            }
            if (strButtonState == "UNDO")
            {
                onLoadButtonPostion();
                cls.EnableDisble(pnlMain, false);
                dtbMaster.Enabled = true;
            }
            if (strButtonState == "SAVE")
            {
                EnabledisableToolsButtonsonSave(true);
                dtbMaster.Enabled = true;

            }
            if (strButtonState == "QUERY")
            {
                EnabledisableToolsButtons(true);
            }
            if (strButtonState == "DELETE")
            {
                EnabledisableToolsButtons(true);
            }
            if (strButtonState == "NEXT")
            {
                dtbMaster.BindingContext[dtbMaster.DataSource].Position += 1;
            }
            if (strButtonState == "PREVIOUS")
            {
                dtbMaster.BindingContext[dtbMaster.DataSource].Position -= 1;
            }
            if (strButtonState == "LAST")
            {
                dtbMaster.BindingContext[dtbMaster.DataSource].Position = dtbMaster.Rows.Count;
            }
            if (strButtonState == "FIRST")
            {
                dtbMaster.BindingContext[dtbMaster.DataSource].Position = 0;
            }

            if (strButtonState == "EXIT")
            {
                Form frm = (Form)this.ActiveMdiChild;
                frm.Close();
                if (this.MdiChildren.Count() == 0)
                {
                    EnabledisableToolsButtons(false);
               }
                else
                {
                    onLoadButtonPostion();
                }
                
            }
            if (strButtonState == null)
            {
                onLoadButtonPostion();
            }
        }

        private Form Returnforms(string pstrFromname)
        { 
            String Fullname = "ExchangeCompanySoftware" + "." + pstrFromname;
            return (Form)Activator.CreateInstance(Type.GetType(Fullname, true, true));

            // }
              
        }
        
        public MainForm(string strFromDate, string strToDate,string strUserId,string strBranch)
        {
            InitializeComponent();
         
            //FromDate.Text = Convert.ToDateTime(strFromDate).ToString("dd/MMM/yyyy");
            //ToDate.Text = Convert.ToDateTime(strToDate).ToString("dd/MMM/yyyy");
            userId.Text = strUserId;
            Branch.Text = strBranch;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            Image img;
            int intWidth = 35;
            int intHeight = 35;
           
            cls = new General();
            PopulateMorri();
            GenerateButtons();
            NAVMENU();
            EnabledisableToolsButtons(false);
            CurrentDate.Text = General.dtSystemDate.ToString("dd/MMM/yyyy");
            this.Text = "RAYYAN";
            General.dtbControlAccount = dtbControlAccount();
            //addImagesonToolBtn();
            timer1.Enabled = true;
         
          }
        
        public DataTable dtbControlAccount()
        {
                General cls = new General();
            DataSet ds = new DataSet();
            string strQuery = "Select * from EX_ControlAccounts Where BranchCode = '"+ General.strBranchCode +"'";
            ds =cls.GetDataSet(strQuery);
            return ds.Tables[0];
        }
        public void EnabledisableToolsButtons(Boolean bolstate)
        {
            for (int i = 0; i < Tool.Items.Count; i++)
            {
                if (Tool.Items[i].Text == "SAVE" || Tool.Items[i].Text == "UNDO")
                {
                    Tool.Items[i].Enabled = false;

                }
                else
                {
                    Tool.Items[i].Enabled = bolstate;
                }
            }
            Tool.Items[Convert.ToInt16(BtnState.EXIT)].Enabled = true;

        }
        public void EnabledisableToolsButtonsonSave(Boolean bolstate)
        {
            for (int i = 0; i < Tool.Items.Count; i++)
            {
                 Tool.Items[i].Enabled = bolstate;
            }

        }
        void mnuheader_Click(object sender, EventArgs e)
        {
            
            Form frm = new Form();
            lMenuItem = (ToolStripMenuItem)sender;
            General.strReportCaption = lMenuItem.Text;
            if (lMenuItem.Tag.ToString() != "")
            {
                //if (lMenuItem.Tag.ToString() != "frmReports")
                if (lMenuItem.Tag.ToString() != "ReportQueryBuilder")
                {
                    frm = Returnforms(lMenuItem.Tag.ToString());
                    frm.MdiParent = this;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    
                    if (frm.Controls["PnlBase"] !=  null)
                    {
                        Label lblCaption = (Label)frm.Controls["PnlBase"].Controls["lblcaption"];
                        lblCaption.Text = General.strReportCaption.ToUpper();
                        frm.Controls["PnlBase"].Width = frm.Width;        
                    }
                    frm.MaximizeBox = false;
                    frm.KeyPreview = true;
                    frm.ControlBox = false;
                    if (frm.Controls["PnlMain"] != null)
                    {
                        Panel pnlMain = (Panel)frm.Controls["PnlMain"];
                      //  pnlMain.Controls.Add(frm.Controls["txtBranchCode"]);
                    //    pnlMain.Controls.Add(frm.Controls["dtTransDate"]);
                        //pnlMain.Controls.Add(frm.Controls["txtUserId"]);
                       
                    }
                    Tool.Items[Convert.ToInt16(BtnState.Add)].Enabled = true;
                    Tool.Items[Convert.ToInt16(BtnState.QUERY)].Enabled = true;
                    
                }
                else 
                {
                    frmReportQueryBuilder frmRep = new frmReportQueryBuilder(lMenuItem.Name.ToString());
                    frm = frmRep;
                    frm.MdiParent = this;
                    frm.Text = General.strReportCaption;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                }
                Tool.Items[Convert.ToInt16(BtnState.EXIT)].Enabled = true;
                frm.Show();
            }
        }
        private void onLoadButtonPostion()
        {
            Tool.Items[Convert.ToInt16(BtnState.Add)].Enabled = true;
            Tool.Items[Convert.ToInt16(BtnState.UNDO)].Enabled = false;
            Tool.Items[Convert.ToInt16(BtnState.SAVE)].Enabled = false;
            Tool.Items[Convert.ToInt16(BtnState.EDIT)].Enabled = false;
            Tool.Items[Convert.ToInt16(BtnState.DELETE)].Enabled = false;
            Tool.Items[Convert.ToInt16(BtnState.EXIT)].Enabled = true;
            Tool.Items[Convert.ToInt16(BtnState.FIRST)].Enabled = false;
            Tool.Items[Convert.ToInt16(BtnState.LAST)].Enabled = false;
            Tool.Items[Convert.ToInt16(BtnState.NEXT)].Enabled = false;
            Tool.Items[Convert.ToInt16(BtnState.PREVIOUS)].Enabled = false;
            Tool.Items[Convert.ToInt16(BtnState.QUERY)].Enabled = true;

        }
        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() > 0)
            {
                DataTable dtb = new DataTable();
                dtb = General.dsRights.Tables[0];
                DataRow[] ldatarows = dtb.Select("MnuId = '" + strMenuId + "'");
                foreach (DataRow ldatarow in ldatarows)
                {
                    Tool.Items[ldatarow["ButtonName"].ToString()].Visible = true;
                }
                DataRow[] ldatarows2 = dtb.Select("MnuId = '" + strMenuId + "' and isAuth = 'True'");
                if (ldatarows2.Count() > 0)
                {
                    General.isAuthriozationRights = true;
                }
                else
                {
                    General.isAuthriozationRights = false;
                }
            }
          
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void ShowForm(string FormName)
        {
            Form frm = Returnforms(FormName);
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.FormBorderStyle = FormBorderStyle.None;
            //frm.WindowState = FormWindowState.Maximized;

            if (frm.Controls["PnlBase"] != null)
            {
                Label lblCaption = (Label)frm.Controls["PnlBase"].Controls["lblcaption"];
                lblCaption.Text = "Trading Voucher";
                frm.Controls["PnlBase"].Width = frm.Width;
            }
            frm.MaximizeBox = false;
            frm.KeyPreview = true;
            frm.ControlBox = false;
            if (frm.Controls["PnlMain"] != null)
            {
                Panel pnlMain = (Panel)frm.Controls["PnlMain"];
                //  pnlMain.Controls.Add(frm.Controls["txtBranchCode"]);
              //  pnlMain.Controls.Add(frm.Controls["dtTransDate"]);
                //pnlMain.Controls.Add(frm.Controls["txtUserId"]);

            }
            Tool.Items[Convert.ToInt16(BtnState.Add)].Enabled = true;
            Tool.Items[Convert.ToInt16(BtnState.QUERY)].Enabled = true;
            frm.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (NAVCONTROL.Cursor.HotSpot.X != 5)
            {

                //NAVCONTROL.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
                //this.BackgroundImage = null;
                
                //this.BackgroundImage = Resource1.MDIFORM;
                //this.BackgroundImageLayout = ImageLayout.Stretch;
                //this.Refresh();
                //timer1.Enabled = false;     
            }
        }
        private void NAVCONTROL_NavPaneStateChanged(object sender, EventArgs e)
        {
            if (NAVCONTROL.OptionsNavPane.NavPaneState == DevExpress.XtraNavBar.NavPaneState.Expanded)
            {
//                timer1.Enabled = true;
                //this.BackgroundImage = null;
                //this.BackgroundImage = Resource1.MDIFORM;
                //this.BackgroundImageLayout = ImageLayout.Stretch;
                //this.Refresh();
            }
            else
            {
            //    timer1.Enabled = false;
           
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void passwordChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPasswordChange frm = new frmPasswordChange();
            frm.ShowDialog();
        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr =
           MessageBox.Show("Are you sure to Clear Cache. ", "Delete",
           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Convert.ToString(dr) == "Yes")
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Endpoint");
                key.SetValue("Endpoint", "");
                Application.Exit();
            }
        }
    }
}
