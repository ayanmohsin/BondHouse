using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Drawing.Drawing2D;
using DevExpress.XtraPrinting;
using System.IO;
using System.Diagnostics;


namespace ExchangeCompanySoftware
{
    public partial class frmReportQueryBuilder : BaseForm,IToolBar 
    {
        string strOrderby;
        string strQuery;
        public string strError = ""; 
        XtraReport devrep;
        DataTable dtb;
        enum Grid { not, Query, Caption, Criteria, btn, Man, DataType, Operator, Order };
        string strDefaultColumn = "";
        string strSupressDefaultColumn = "";
        int intSupressChk;
        private string objectname1 = String.Empty;
       
        DataTable dtvalid;
        DataTable dtbAllQuery;
        int intTotalLength = 0;
        string strTotalLocation;
        private void AddGroup()
        {

            
        }
        public frmReportQueryBuilder(string objectname)
        {
            InitializeComponent();
            objectname1 = objectname;

        }
        private void AddColumn()
        {
            DataGridViewTextBoxColumn clmnQuery = new DataGridViewTextBoxColumn();
            clmnQuery.Name = "Query";
            clmnQuery.HeaderText = "Query";
            clmnQuery.Width = 40;
            clmnQuery.Visible = false;
            clmnQuery.ReadOnly = true;
            dtbDetail.Columns.Add(clmnQuery);

            //DataGridViewTextBoxColumn clmnCaption = new DataGridViewTextBoxColumn();
            //clmnCaption.Name = "Caption";
            //clmnCaption.HeaderText = "Caption";
            //clmnCaption.Width = 100;
            //clmnCaption.ReadOnly = true;
            //dtbDetail.Columns.Add(clmnCaption);


            DataGridViewTextBoxColumn clmnCriteria = new DataGridViewTextBoxColumn();
            clmnCriteria.Name = "Criteria";
            clmnCriteria.HeaderText = "Criteria";
            clmnCriteria.Width = 150;
            dtbDetail.Columns.Add(clmnCriteria);

            DataGridViewButtonColumn clmnbtn = new DataGridViewButtonColumn();
            clmnbtn.Name = "Click";
            clmnbtn.HeaderText = "Click";
            clmnbtn.Width = 60;
            dtbDetail.Columns.Add(clmnbtn);
            
            DataGridViewTextBoxColumn clmnMan = new DataGridViewTextBoxColumn();
            clmnMan.Name = "Man";
            clmnMan.HeaderText = "Man";
            clmnMan.Width = 40;
            clmnMan.Visible = false;
            clmnMan.ReadOnly = true;
           
            dtbDetail.Columns.Add(clmnMan);

            DataGridViewTextBoxColumn clmnDataType = new DataGridViewTextBoxColumn();
            clmnDataType.Name = "DataType";
            clmnDataType.HeaderText = "DataType";
            clmnDataType.Width = 40;
            clmnDataType.ReadOnly = true;
            clmnDataType.Visible = false;
            dtbDetail.Columns.Add(clmnDataType);

            DataGridViewTextBoxColumn clmnnot = new DataGridViewTextBoxColumn();
            clmnnot.Name = "not";
            clmnnot.HeaderText = "not";
            clmnnot.Width = 40;
            clmnnot.ReadOnly = true;
            clmnnot.Visible = false;
            dtbDetail.Columns.Add(clmnnot);

            DataGridViewTextBoxColumn clmnHG = new DataGridViewTextBoxColumn();
            clmnHG.Name = "HeaderGroup";
            clmnHG.HeaderText = "HeaderGroup";
            clmnHG.Width = 40;
            clmnHG.ReadOnly = true;
            clmnHG.Visible = false;
            dtbDetail.Columns.Add(clmnHG);

            DataGridViewTextBoxColumn clmnGroup = new DataGridViewTextBoxColumn();
            clmnGroup.Name = "Group";
            clmnGroup.HeaderText = "Grouping on";
            clmnGroup.Width = 120;
            clmnGroup.ReadOnly = true;
            dtbGroup.Columns.Add(clmnGroup);

            DataGridViewCheckBoxColumn chkGroup = new DataGridViewCheckBoxColumn();
            chkGroup.Name = "GroupChk";
            chkGroup.HeaderText = "Y/N";
            chkGroup.Width = 50;
            dtbGroup.Columns.Add(chkGroup);


            DataGridViewTextBoxColumn chkSelectionGroup = new DataGridViewTextBoxColumn();
            chkSelectionGroup.Name = "SelectionColumn";
            chkSelectionGroup.HeaderText = "Y/N";
            chkSelectionGroup.Width = 50;
            chkSelectionGroup.Visible = false;
            dtbGroup.Columns.Add(chkSelectionGroup);

            DataGridViewTextBoxColumn clmnfldSizeGroup = new DataGridViewTextBoxColumn();
            clmnfldSizeGroup.Name = "FieldSize";
            clmnfldSizeGroup.HeaderText = "Y/N";
            clmnfldSizeGroup.Width = 50;
            clmnfldSizeGroup.Visible = false;
            dtbGroup.Columns.Add(clmnfldSizeGroup);

            DataGridViewTextBoxColumn clmnOrder = new DataGridViewTextBoxColumn();
            clmnOrder.Name = "Order";
            clmnOrder.HeaderText = "Ordering on";
            clmnOrder.Width = 120;
            clmnOrder.ReadOnly = true;
            dtbOrder.Columns.Add(clmnOrder);

            DataGridViewCheckBoxColumn chkGroupOrder = new DataGridViewCheckBoxColumn();
            chkGroupOrder.Name = "OrderChk";
            chkGroupOrder.HeaderText = "Y/N";
            chkGroupOrder.Width = 50;
            dtbOrder.Columns.Add(chkGroupOrder);

            DataGridViewTextBoxColumn clmnMan213 = new DataGridViewTextBoxColumn();
            clmnMan213.Name = "SelectionColumn";
            clmnMan213.HeaderText = "Man";
            clmnMan213.Width = 40;
            clmnMan213.Visible = false;
            clmnMan213.ReadOnly = true;
            dtbOrder.Columns.Add(clmnMan213);


            DataGridViewTextBoxColumn clmnSupree = new DataGridViewTextBoxColumn();
            clmnSupree.Name = "Supress";
            clmnSupree.HeaderText = "Supressing on";
            clmnSupree.Width = 120;
            clmnSupree.ReadOnly = true;
            dtbSupress.Columns.Add(clmnSupree);

            DataGridViewCheckBoxColumn chkSupress = new DataGridViewCheckBoxColumn();
            chkSupress.Name = "SupressChk";
            chkSupress.HeaderText = "Y/N";
            chkSupress.Width = 50;
            dtbSupress.Columns.Add(chkSupress);

            DataGridViewTextBoxColumn chkSelection = new DataGridViewTextBoxColumn();
            chkSelection.Name = "SelectionColumn";
            chkSelection.HeaderText = "Y/N";
            chkSelection.Visible = false;
            dtbSupress.Columns.Add(chkSelection);

            DataGridViewTextBoxColumn clmnfldSize = new DataGridViewTextBoxColumn();
            clmnfldSize.Name = "FieldSize";
            clmnfldSize.HeaderText = "Y/N";
            clmnfldSize.Width = 50;
            clmnfldSize.Visible = false;
            dtbSupress.Columns.Add(clmnfldSize);

            DataGridViewTextBoxColumn clmnFor = new DataGridViewTextBoxColumn();
            clmnFor.Name = "Format";
            clmnFor.HeaderText = "Y/N";
            clmnFor.Width = 50;
            clmnFor.Visible = false;
            dtbSupress.Columns.Add(clmnFor);


            DataGridViewTextBoxColumn clmnDT = new DataGridViewTextBoxColumn();
            clmnDT.Name = "DataType";
            clmnDT.HeaderText = "Y/N";
            clmnDT.Width = 50;
            clmnDT.Visible = false;
            dtbSupress.Columns.Add(clmnDT);


            DataGridViewCheckBoxColumn chkSupressSUm = new DataGridViewCheckBoxColumn();
            chkSupressSUm.Name = "SumChk";
            chkSupressSUm.HeaderText = "Y/N";
            chkSupressSUm.Width = 50;
            dtbSummerized.Columns.Add(chkSupressSUm);

            DataGridViewTextBoxColumn clmnfldTextAli = new DataGridViewTextBoxColumn();
            clmnfldTextAli.Name = "TextAllign";
            clmnfldTextAli.HeaderText = "Y/N";
            clmnfldTextAli.Width = 50;
            clmnfldTextAli.Visible = false;
            dtbSupress.Columns.Add(clmnfldTextAli);

            DataGridViewTextBoxColumn clmnfldHG = new DataGridViewTextBoxColumn();
            clmnfldHG.Name = "HeaderGroup";
            clmnfldHG.HeaderText = "HeaderGroup";
            clmnfldHG.Width = 50;
            clmnfldHG.Visible = false;
            dtbSupress.Columns.Add(clmnfldHG);

            DataGridViewTextBoxColumn clmnfldRT = new DataGridViewTextBoxColumn();
            clmnfldRT.Name = "ReportTotal";
            clmnfldRT.HeaderText = "ReportTotal";
            clmnfldRT.Width = 50;
            clmnfldRT.Visible = false;
            dtbSupress.Columns.Add(clmnfldRT);

            DataGridViewTextBoxColumn clmnfldPT = new DataGridViewTextBoxColumn();
            clmnfldPT.Name = "PageTotal";
            clmnfldPT.HeaderText = "PageTotal";
            clmnfldPT.Width = 50;
            clmnfldPT.Visible = false;
            dtbSupress.Columns.Add(clmnfldPT);

            DataGridViewTextBoxColumn clmnfldGT = new DataGridViewTextBoxColumn();
            clmnfldGT.Name = "GroupTotal";
            clmnfldGT.HeaderText = "GroupTotal";
            clmnfldGT.Width = 50;
            clmnfldGT.Visible = false;
            dtbSupress.Columns.Add(clmnfldGT);


            DataGridViewTextBoxColumn clmnSum = new DataGridViewTextBoxColumn();
            clmnSum.Name = "ColumnSum";
            clmnSum.HeaderText = "Summerized";
            clmnSum.Width = 70;
            clmnSum.ReadOnly = true;
            dtbSummerized.Columns.Add(clmnSum);

            DataGridViewTextBoxColumn chkSelectionSum = new DataGridViewTextBoxColumn();
            chkSelectionSum.Name = "SelectionColumn";
            chkSelectionSum.HeaderText = "Y/N";
            chkSelectionSum.Width = 50;
            chkSelectionSum.Visible = false;
            dtbSummerized.Columns.Add(chkSelectionSum);

            DataGridViewCheckBoxColumn chkGroupLevel = new DataGridViewCheckBoxColumn();
            chkGroupLevel.Name = "SumGroupLevel";
            chkGroupLevel.HeaderText = "OnGroup";
            chkGroupLevel.Width = 50;
            dtbSummerized.Columns.Add(chkGroupLevel);

            DataGridViewCheckBoxColumn chkPageLevel = new DataGridViewCheckBoxColumn();
            chkPageLevel.Name = "SumPageLevel";
            chkPageLevel.HeaderText = "OnPage";
            chkPageLevel.Width = 50;
            dtbSummerized.Columns.Add(chkPageLevel);

            DataGridViewCheckBoxColumn chkReportLevel = new DataGridViewCheckBoxColumn();
            chkReportLevel.Name = "SumReportLevel";
            chkReportLevel.HeaderText = "OnReport";
            chkReportLevel.Width = 50;
            dtbSummerized.Columns.Add(chkReportLevel);
        }
        private void populateAllQueryField()
        {
            devrep = new XtraReport();
            General cls = new General();
            dtb = new DataTable();
            strQuery = "Select * from AllqueryField Where ObjectName = '" + objectname1 + "' ORDER BY Priority,HeaderGroup;Select * from EX_System Where Flag = 'O';Select * from EX_System Where Flag = 'OP';Select * from AllQuery Where  ObjectName = '" + objectname1 + "'";
            DataSet ds = cls.GetDataSet(strQuery);
            dtb = ds.Tables[0];
            dtbAllQuery = ds.Tables[3];
            chkLandscape.Checked = Convert.ToBoolean(dtbAllQuery.Rows[0]["isLandScape"].ToString());
                
            int intDefault = 0;
            DataGridViewComboBoxColumn clmnCaption = new DataGridViewComboBoxColumn();
            clmnCaption.Name = "ComboCaption";
            clmnCaption.HeaderText = "Caption";
            clmnCaption.Width = 100;
            dtvalid = dtb.Clone();
            dtvalid.Rows.Clear();
            DataRow[] drr = dtb.Select("isDisplay = 'True'");
            foreach (DataRow dr in drr)
            {    
                dtvalid.ImportRow(dr);
            }
            clmnCaption.DataSource = dtvalid;
            clmnCaption.DisplayMember = "FieldCaption";
            clmnCaption.ValueMember = "SelectionColumn";
           //clmnCaption.DefaultCellStyle.NullValue = "Select Data";
            dtbDetail.Columns.Add(clmnCaption);
            dtbDetail.Columns["ComboCaption"].DisplayIndex = 1;
            int l = dtvalid.Rows.Count;

            for (int i = 0; i < l; i++)
            {
                int n = dtbDetail.Rows.Add();
                dtbDetail.Rows[n].Cells["Not"].Value = dtvalid.Rows[i][2].ToString();
                if (dtvalid.Rows[i][4].ToString().Contains("strBranch") == true)
                {
                    dtvalid.Rows[i][4] = dtvalid.Rows[i][4].ToString().Replace("strBranch", General.strBranchCodeFrom.ToString());
                }
                dtbDetail.Rows[n].Cells["Query"].Value = dtvalid.Rows[i][4].ToString();
                dtbDetail.Rows[n].Cells["ComboCaption"].Value = dtvalid.Rows[i][3].ToString();
                dtbDetail.Rows[n].Cells["ComboCaption"].Value = dtvalid.Rows[i]["SelectionColumn"].ToString();
                dtbDetail.Rows[n].Cells["Man"].Value = dtvalid.Rows[i][5].ToString();
                dtbDetail.Rows[n].Cells["DataType"].Value = dtvalid.Rows[i][6].ToString();
                object oColumn = dtvalid.Rows[i]["SelectionColumn"];
                string sColumn = "";
                if (oColumn != null)
                {
                    if (oColumn.ToString() != "")
                    {
                        sColumn = oColumn.ToString();
                    }
                }
                if (sColumn == "DateFrom" || sColumn == "DateTo" || sColumn == "Dateason")
                {
                    dtbDetail.Rows[i].Cells["Criteria"].Value = General.dtSystemDate.ToString("dd-MMM-yyyy");
                }
                else
                {
                    dtbDetail.Rows[i].Cells["Criteria"].Value = "";
                }
                dtbDetail.Rows[i].Cells["HeaderGroup"].Value = dtvalid.Rows[i]["HeaderGroup"].ToString();  
            }
            for (int r = 0; r < dtb.Rows.Count ; r++)
            {
                if (Convert.ToBoolean(dtb.Rows[r]["isDefault"].ToString()) == true)
                {
                    if (strDefaultColumn == "")
                    {
                        strDefaultColumn = dtb.Rows[r]["FieldCaption"].ToString() + "=" + dtb.Rows[r]["SelectionColumn"].ToString() + "=" + dtb.Rows[r]["FieldSize"].ToString() + "=" + dtb.Rows[r]["TextAllign"].ToString() + "=" + dtb.Rows[r]["Format"].ToString() + "=" + dtb.Rows[r]["DataType"].ToString() + "=" + dtb.Rows[r]["HeaderGroup"].ToString() + "=" + dtb.Rows[r]["ReportTotal"].ToString() + "=" + dtb.Rows[r]["PageTotal"].ToString() + "=" + dtb.Rows[r]["GroupTotal"].ToString();
                    }
                    else
                    {
                        strDefaultColumn = strDefaultColumn + ";" + dtb.Rows[r]["FieldCaption"].ToString() + "=" + dtb.Rows[r]["SelectionColumn"].ToString() + "=" + dtb.Rows[r]["FieldSize"].ToString() + "=" + dtb.Rows[r]["TextAllign"].ToString() + "=" + dtb.Rows[r]["Format"].ToString() + "=" + dtb.Rows[r]["DataType"].ToString() + "=" + dtb.Rows[r]["HeaderGroup"].ToString() + "=" + dtb.Rows[r]["ReportTotal"].ToString() + "=" + dtb.Rows[r]["PageTotal"].ToString() + "=" + dtb.Rows[r]["GroupTotal"].ToString();
                    }
                }          
            }
            
            DataRow[] ldatarows = dtb.Select("isGroup = true");
            dtbGroup.Rows.Clear();
            int iRow = 0;
            foreach (DataRow ldatarow in ldatarows)
            {
                dtbGroup.Rows.Add();
                dtbGroup.Rows[iRow].Cells["Group"].Value = ldatarow["FieldCaption"].ToString();
                dtbGroup.Rows[iRow].Cells["GroupChk"].Value = ldatarow["DefaultGroup"].ToString(); 
                dtbGroup.Rows[iRow].Cells["SelectionColumn"].Value = ldatarow["SelectionColumn"].ToString();
                dtbGroup.Rows[iRow].Cells["FieldSize"].Value = ldatarow["FieldSize"].ToString();
                iRow = iRow + 1;
            }
            iRow = 0;
            DataRow[] ldatarows4 = dtb.Select("isSumrized = true", "Priority");
            dtbSummerized.Rows.Clear();
            foreach (DataRow ldatarow4 in ldatarows4)
            {
                dtbSummerized.Rows.Add();
                dtbSummerized.Rows[iRow].Cells["ColumnSum"].Value = ldatarow4["FieldCaption"].ToString();
                
                dtbSummerized.Rows[iRow].Cells["SumGroupLevel"].Value = ldatarow4["GroupTotal"].ToString();
                dtbSummerized.Rows[iRow].Cells["SumPageLevel"].Value = ldatarow4["PageTotal"].ToString();
                dtbSummerized.Rows[iRow].Cells["SumReportLevel"].Value = ldatarow4["ReportTotal"].ToString();
                if (Convert.ToBoolean(ldatarow4["ReportTotal"].ToString()) == true ||Convert.ToBoolean(ldatarow4["PageTotal"].ToString()) == true || Convert.ToBoolean(ldatarow4["GroupTotal"].ToString()) == true )
                {
                    dtbSummerized.Rows[iRow].Cells["SumChk"].Value = true;
                }
                else
                {
                    dtbSummerized.Rows[iRow].Cells["SumChk"].Value = false;
                }
                dtbSummerized.Rows[iRow].Cells["SelectionColumn"].Value = ldatarow4["SelectionColumn"].ToString();
                
                iRow = iRow + 1;
            }
            iRow = 0;
            DataRow[] ldatarows1 = dtb.Select("isSort = true");
            dtbOrder.Rows.Clear();
            foreach (DataRow ldatarow1 in ldatarows1)
            {
                dtbOrder.Rows.Add();
                dtbOrder.Rows[iRow].Cells["Order"].Value = ldatarow1["FieldCaption"].ToString();
                dtbOrder.Rows[iRow].Cells["SelectionColumn"].Value = ldatarow1["SelectionColumn"].ToString();
                iRow = iRow + 1;
            }
            DataRow[] ldatarows2 = dtb.Select("isSupress = true");
            dtbSupress.Rows.Clear();

            
            iRow = 0;
            foreach (DataRow ldatarow2 in ldatarows2)
            {
                dtbSupress.Rows.Add();
                dtbSupress.Rows[iRow].Cells["Supress"].Value = ldatarow2["FieldCaption"].ToString();
                dtbSupress.Rows[iRow].Cells["SupressChk"].Value = false;
                dtbSupress.Rows[iRow].Cells["SelectionColumn"].Value = ldatarow2["SelectionColumn"].ToString();
                dtbSupress.Rows[iRow].Cells["FieldSize"].Value = ldatarow2["FieldSize"].ToString();
                dtbSupress.Rows[iRow].Cells["TextAllign"].Value = ldatarow2["TextAllign"].ToString();
                dtbSupress.Rows[iRow].Cells["Format"].Value = ldatarow2["Format"].ToString();
                dtbSupress.Rows[iRow].Cells["DataType"].Value = ldatarow2["DataType"].ToString();
                dtbSupress.Rows[iRow].Cells["HeaderGroup"].Value = ldatarow2["HeaderGroup"].ToString();
                dtbSupress.Rows[iRow].Cells["GroupTotal"].Value = ldatarow2["GroupTotal"].ToString();
                dtbSupress.Rows[iRow].Cells["ReportTotal"].Value = ldatarow2["ReportTotal"].ToString();
                dtbSupress.Rows[iRow].Cells["PageTotal"].Value = ldatarow2["PageTotal"].ToString();
                iRow = iRow + 1;
            }

            dtb = new DataTable();
            dtb =cls.GetDataSet(strQuery).Tables[1];
            string[] words = dtb.Rows[0][1].ToString().Split(';');
            dtb = new DataTable();
            dtb.Columns.Add();
            dtb.Columns[0].ColumnName = "Operator";
            for (int i = 0; i < words.Count(); i++)
            {
                dtb.Rows.Add();
                dtb.Rows[i]["Operator"] = words[i];
            }
            DataGridViewComboBoxColumn cboTitle = new DataGridViewComboBoxColumn();
            cboTitle.Name = "Operator";
            cboTitle.HeaderText = "Operator";
            cboTitle.Width = 50;
            cboTitle.DataSource = dtb;
            cboTitle.DisplayMember = "Operator";
            cboTitle.ValueMember = "Operator";
            dtbDetail.Columns.Add(cboTitle);
            dtbDetail.Columns["Operator"].DisplayIndex = 2;
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                dtbDetail.Rows[i].Cells["Operator"].Value = "=";
            }

            dtb = new DataTable();
            dtb =cls.GetDataSet(strQuery).Tables[2];
            words = dtb.Rows[0][1].ToString().Split(';');
            dtb = new DataTable();
            dtb.Columns.Add();
            dtb.Columns[0].ColumnName = "Operator";
            for (int i = 0; i < words.Count(); i++)
            {
                dtb.Rows.Add();
                dtb.Rows[i]["Operator"] = words[i];
            }
            DataGridViewComboBoxColumn cboTitle1 = new DataGridViewComboBoxColumn();
            cboTitle1.Name = "Operator";
            cboTitle1.HeaderText = "Operator";
            cboTitle1.Width = 65;
            cboTitle1.DataSource = dtb;
            cboTitle1.DisplayMember = "Operator";
            cboTitle1.ValueMember = "Operator";
            dtbSummerized.Columns.Add(cboTitle1);
            dtbSummerized.Columns["Operator"].DisplayIndex = 2;
            for (int i = 0; i < dtbSummerized.Rows.Count; i++)
            {
                dtbSummerized.Rows[i].Cells["Operator"].Value = "SUM";
            }
        }
        private Boolean CheckMandatory()
        {
            Boolean blnState = true;
            strError = "";
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtbDetail.Rows[i].Cells["MAN"].Value) == true)
                {
                    if (dtbDetail.Rows[i].Cells["Criteria"].Value == "")
                    {
                        blnState =  false;
                        if (strError == "")
                        {
                            strError = "must be Enter " + dtbDetail.Rows[i].Cells["ComboCaption"].Value + "";
                        }
                        else
                        {
                            strError = strError + "\n" + "must be Enter " + dtbDetail.Rows[i].Cells["ComboCaption"].Value + "";
                        }
                    }
                    else
                    {
                        blnState =  true;
                    }
                }
                
            }
            return blnState;
        }
        public void WhereClause(string strq)
        {
            string strqry;
            strqry = strQuery;
            Boolean bolstate;
            if (strqry.Contains("qryBranchFrom") == true || strqry.Contains("qryBranchTo") == true)
            {
                strqry = strqry.Replace("qryBranchFrom", General.strBranchCodeFrom.ToString());
                strqry = strqry.Replace("qryBranchTo", General.strBranchCodeTo.ToString());
            }
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                if (dtbDetail.Rows[i].Cells["Criteria"].Value != "" && dtbDetail.Rows[i].Cells["Criteria"].Value != null)
                {

                    if (strqry.Contains("DateFrom") == true || strqry.Contains("Dateason") == true || strqry.Contains("DateTo") == true || strqry.Contains("qryStringValue") == true || strqry.Contains("qryBranchFrom") == true || strqry.Contains("qryBranchTo") == true)
                    {
                        if (dtbDetail.Rows[i].Cells["Not"].Value.ToString() == "Dateason")
                        {
                            strqry = strqry.Replace("Dateason", Convert.ToDateTime(dtbDetail.Rows[i].Cells["Criteria"].Value.ToString().Replace("'","")).ToString("dd-MMM-yyyy"));
                        }
                        else if (dtbDetail.Rows[i].Cells["Not"].Value.ToString() == "DateFrom")
                        {
                            strqry = strqry.Replace("DateFrom", Convert.ToDateTime(dtbDetail.Rows[i].Cells["Criteria"].Value.ToString().Replace("'", "")).ToString("dd-MMM-yyyy"));
                            strqry = strqry.Replace("DateTo", Convert.ToDateTime(dtbDetail.Rows[i + 1].Cells["Criteria"].Value.ToString().Replace("'", "")).ToString("dd-MMM-yyyy"));
                        }
                        else if (dtbDetail.Rows[i].Cells["Not"].Value.ToString() == "qryStringValue")
                        {
                            strqry = strqry.Replace("qryStringValue", dtbDetail.Rows[i].Cells["Criteria"].Value.ToString());
                        }
                        else if (dtbDetail.Rows[i].Cells["Not"].Value.ToString() == "qryBranchFrom")
                        {
                            strqry = strqry.Replace("qryBranchFrom", General.strBranchCode.ToString());
                        }
                        else if (dtbDetail.Rows[i].Cells["Not"].Value.ToString() == "qryBranchTo")
                        {
                            strqry = strqry.Replace("qryBranchTo", General.strBranchCodeTo.ToString());
                        }
                    }

                    if (dtbDetail.Rows[i].Cells["Not"].Value.ToString() != "Dateason".ToString() && dtbDetail.Rows[i].Cells["Not"].Value.ToString() != "DateFrom".ToString() && dtbDetail.Rows[i].Cells["Not"].Value.ToString() != "DateTo".ToString() && dtbDetail.Rows[i].Cells["Not"].Value.ToString() != "qryStringValue".ToString())
                    {
                        strqry = strqry + " and " + dtbDetail.Rows[i].Cells["Not"].Value + " " + dtbDetail.Rows[i].Cells["Operator"].Value + "  (" + dtbDetail.Rows[i].Cells["Criteria"].Value + ")";
                    }
                }
                strQuery = strqry;
            }

        }
        public string OrderbyClause(string strQuery)
        {
            string strOrderbyClause = null;
            if (strOrderby != null)
            {
                strOrderbyClause = "Order by " + strOrderby;
            }
            for (int i = 0; i < dtbOrder.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtbOrder.Rows[i].Cells["OrderChk"].Value) == true)
                {
                    if (strOrderbyClause == null) 
                    {
                        strOrderbyClause = "Order by " + dtbOrder.Rows[i].Cells["SelectionColumn"].Value + "";
                    }
                    else
                    {
                        strOrderbyClause = strOrderbyClause + "," + dtbOrder.Rows[i].Cells["SelectionColumn"].Value + "";
                    }
                }
            }
            return strQuery = strQuery + "  " + strOrderbyClause;
        }
        private void cmdGenerate_Click(object sender, EventArgs e)
        {

            if (CheckMandatory() == true)
            {
                CreateReportDoucument();
                devrep.ShowPreview();
            }
            else
            {
              MessageBox.Show(strError, "ERROR",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateReportDoucument()
        {
            int intLenR = 1;
            int intLenG = 1;
            int intLenP = 1;

            XRLabel labelSumGroup;
            DevExpress.XtraReports.UI.XRSummary xrSummary1;
            PageFooterBand pfB = new PageFooterBand(); ;
            ReportFooterBand rfB = new ReportFooterBand();
            XRLabel labelCaption;
            XRLabel labelCaptionMain = new XRLabel();

            int strLenG = 25;
            int strLenP = 25;
            int strLenR = 25;
            
             intTotalLength = 0;
                string strReport;
                    General cls = new General();
                strReport = dtbAllQuery.Rows[0]["ReportName"].ToString();
                string strReportName = "ExchangeCompanySoftware" + "." + "Reports." + strReport;
                devrep = (XtraReport)Activator.CreateInstance(Type.GetType(strReportName, true, true));
                    
                strQuery = dtbAllQuery.Rows[0][1].ToString();
                WhereClause(strQuery);
                strQuery = OrderbyClause(strQuery);
                dtb =cls.GetDataSet(strQuery).Tables[0];
                devrep.Margins = new System.Drawing.Printing.Margins(20, 20, 10, 20);
             
                devrep.DataSource = dtb;
                devrep.DataMember = dtb.TableName;
                if (strReport == "rptDynamic")
                {

                    for (int i = 0; i < dtbSupress.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dtbSupress.Rows[i].Cells["SupressChk"].Value.ToString()) == true)
                        {
                            if (strSupressDefaultColumn == "")
                            {
                                strSupressDefaultColumn = dtbSupress.Rows[i].Cells["Supress"].Value + "=" + dtbSupress.Rows[i].Cells["SelectionColumn"].Value + "=" + dtbSupress.Rows[i].Cells["FieldSize"].Value + "=" + dtbSupress.Rows[i].Cells["TextAllign"].Value + "=" + dtbSupress.Rows[i].Cells["Format"].Value + "=" + dtbSupress.Rows[i].Cells["DataType"].Value + "=" + dtbSupress.Rows[i].Cells["HeaderGroup"].Value + "=" + dtbSupress.Rows[i].Cells["ReportTotal"].Value + "=" + dtbSupress.Rows[i].Cells["PageTotal"].Value + "=" + dtbSupress.Rows[i].Cells["GroupTotal"].Value;
                            }
                            else
                            {
                                strSupressDefaultColumn = strSupressDefaultColumn + ";" + dtbSupress.Rows[i].Cells["Supress"].Value + "=" + dtbSupress.Rows[i].Cells["SelectionColumn"].Value + "=" + dtbSupress.Rows[i].Cells["FieldSize"].Value + "=" + dtbSupress.Rows[i].Cells["TextAllign"].Value + "=" + dtbSupress.Rows[i].Cells["Format"].Value + "=" + dtbSupress.Rows[i].Cells["DataType"].Value + "=" + dtbSupress.Rows[i].Cells["HeaderGroup"].Value + "=" + dtbSupress.Rows[i].Cells["ReportTotal"].Value + "=" + dtbSupress.Rows[i].Cells["PageTotal"].Value + "=" + dtbSupress.Rows[i].Cells["GroupTotal"].Value;
                            }
                        }
                    }
                    if (strSupressDefaultColumn != "")
                    {
                        strDefaultColumn = strSupressDefaultColumn;
                    }
                    AddReportColumn(strDefaultColumn);
                    strSupressDefaultColumn = "";
                }
                for (int ig = 0; ig < dtbGroup.Rows.Count; ig++)
                {
                    if (Convert.ToBoolean(dtbGroup.Rows[ig].Cells["GroupChk"].Value.ToString()) == true)
                    {
                        GroupHeaderBand ghBand = new GroupHeaderBand();
                        ghBand.Name = ig.ToString();
                        devrep.Bands.Add(ghBand);
                        string[] strCheck = dtbGroup.Rows[ig].Cells["SelectionColumn"].Value.ToString().Split('.');
                        GroupField groupField;
                        if (strCheck.Count() >= 2)
                        {
                            
                            groupField = new GroupField(strCheck[1]);
                        }
                        else
                        {
                            groupField = new GroupField(strCheck[0]);
                        }
                        
                        ghBand.GroupFields.Add(groupField);

                        ghBand.Height = 1;
                        XRLabel labelGroup = new XRLabel();
                        labelGroup.Width = 400;
                        labelGroup.Borders = BorderSide.Bottom;
                        labelGroup.BorderWidth = 6; 
                        labelGroup.BackColor = Color.Gray;
                        labelGroup.ForeColor = Color.White;
                        if (strCheck.Count() >= 2)
                        {
                            labelGroup.DataBindings.Add("Text", devrep.DataSource, strCheck[1]);
                        }
                        else
                        {
                            labelGroup.DataBindings.Add("Text", devrep.DataSource, strCheck[0]);
                        }
                        labelGroup.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        ghBand.Controls.Add(labelGroup);
                        #region Group Total
                        GroupFooterBand gfB = new GroupFooterBand();
                        gfB.Height = 150;
                        devrep.Bands.Add(gfB);
                        for (int i = 0; i < dtbSummerized.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dtbSummerized.Rows[i].Cells["SumChk"].Value.ToString()) == true)
                            {
                                if (Convert.ToBoolean(dtbSummerized.Rows[i].Cells["SumGroupLevel"].Value.ToString()) == true)
                                {
                                    labelSumGroup = new XRLabel();
                                    labelCaption = new XRLabel();
                                    xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
                                    xrSummary1.FormatString = "{0:#,0.00;(#,#);-}";
                                    xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
                                    if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "SUM")
                                    {
                                        xrSummary1.Func = SummaryFunc.Sum;
                                    }
                                    else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "COUNT")
                                    {
                                        xrSummary1.Func = SummaryFunc.Count;
                                    }
                                    else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "MIN")
                                    {
                                        xrSummary1.Func = SummaryFunc.Min;
                                    }
                                    else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "MAX")
                                    {
                                        xrSummary1.Func = SummaryFunc.Max;
                                    }
                                    else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "AVG")
                                    {
                                        xrSummary1.Func = SummaryFunc.Avg;
                                    }
                                    //labelCaptionMain.Location = new Point(intTotalLength - 353, 0);
                                    //labelCaptionMain.Width = 300;
                                    //labelCaptionMain.BackColor = Color.Navy;
                                    //labelCaptionMain.ForeColor = Color.White;
                                    //labelCaptionMain.Borders = BorderSide.All;
                                    //labelCaptionMain.BorderWidth = 3;
                                    //labelCaptionMain.Text = "Group Total";
                                    //labelCaptionMain.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                    //labelCaptionMain.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                                    //labelCaptionMain.Location = new Point(intTotalLength - 353, 0);
                                    //labelCaptionMain.Width = 300;
                                    //labelCaptionMain.BackColor = Color.Navy;
                                    //labelCaptionMain.ForeColor = Color.White;
                                    //labelCaptionMain.Borders = BorderSide.All;
                                    //labelCaptionMain.BorderWidth = 3;
                                    //gfB.Controls.Add(labelCaptionMain);

                                    labelCaption.Text = "Group Total";
                                    labelCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                    labelCaption.TextAlignment = TextAlignment.MiddleCenter;
                                    labelCaption.Borders = BorderSide.All;
                                    labelCaption.Location = new Point(0, 0);
                                    labelCaption.BorderWidth = 1;
                                    labelCaption.Width = 100;
                                    gfB.Controls.Add(labelCaption);

                                    labelSumGroup.DataBindings.Add("Text", devrep.DataSource, dtbSummerized.Rows[i].Cells["SelectionColumn"].Value.ToString());
                                    labelSumGroup.Summary = xrSummary1;
                                    string[] strSplit = strTotalLocation.Split(';');
                                    if (strSplit.Count() != intLenG)
                                    {
                                        string[] strLocation = strSplit[intLenG].Split('=');
                                        int intL = Convert.ToInt32(strLocation[0]);
                                        int intW = Convert.ToInt32(strLocation[1]);

                                        labelSumGroup.Location = new Point(intL, 10);
                                        labelSumGroup.TextAlignment = TextAlignment.MiddleRight;
                                        labelSumGroup.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                        labelSumGroup.Width = intW;
                                        labelSumGroup.TextAlignment = TextAlignment.MiddleCenter;
                                        labelSumGroup.Borders = BorderSide.All;

                                        labelSumGroup.BorderWidth = 1;
                                        gfB.Height = 5;
                                        gfB.Controls.Add(labelSumGroup);
                                        intLenG = intLenG + 1;
                                        // strLenG = strLenG + 25;
                                    }
                                }
                               
                            }
                           
                        #endregion
                   
                    }
                        intLenG = 1;
                }
            
                        Band pfB1 = devrep.Bands["PageFooter"];
                        if (pfB1 == null)
                        {
                            devrep.Bands.Add(pfB);
                        }
                        else
                        {
                            pfB = (PageFooterBand)pfB1;
                        }
                        Band rfB1 = devrep.Bands["ReportFooter"];
                        if (rfB1 == null)
                        {
                           
                            devrep.Bands.Add(rfB);
                        }
                        else
                        {
                            rfB = (ReportFooterBand)rfB1;
                        }
                        for (int i = 0; i < dtbSummerized.Rows.Count; i++)
                        {
                        #region ReportSum
                        if (Convert.ToBoolean(dtbSummerized.Rows[i].Cells["SumReportLevel"].Value.ToString()) == true)
                        {

                            labelSumGroup = new XRLabel();
                            labelCaption = new XRLabel();
                            xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
                            xrSummary1.FormatString = "{0:#,0.00;(#,#);-}";
                            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
                            if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "SUM")
                            {
                                xrSummary1.Func = SummaryFunc.Sum;
                            }
                            else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "COUNT")
                            {
                                xrSummary1.Func = SummaryFunc.Count;
                            }
                            else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "MIN")
                            {
                                xrSummary1.Func = SummaryFunc.Min;
                            }
                            else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "MAX")
                            {
                                xrSummary1.Func = SummaryFunc.Max;
                            }
                            else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "AVG")
                            {
                                xrSummary1.Func = SummaryFunc.Avg;
                            }

                            //labelCaptionMain.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            //labelCaptionMain.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            //labelCaptionMain.Location = new Point(intTotalLength - 353, 0);
                            //labelCaptionMain.Width = 300;
                            //labelCaptionMain.BackColor = Color.Orange;
                            //labelCaptionMain.ForeColor = Color.White;
                            //labelCaptionMain.Borders = BorderSide.All;
                            //labelCaptionMain.BorderWidth = 3;
                            //labelCaptionMain.Text = "Report Total";
                            //labelCaptionMain.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            //rfB.Controls.Add(labelCaptionMain);

                            labelCaption.Text = "Report Total";
                            labelCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            labelCaption.TextAlignment = TextAlignment.MiddleCenter;
                            labelCaption.Borders = BorderSide.All;
                            labelCaption.Location = new Point(0, 0);
                            labelCaption.BorderWidth = 1;
                            labelCaption.Width = 100;
                            rfB.Controls.Add(labelCaption);
                            //rfB.Controls.Add(labelCaption);

                            labelSumGroup.DataBindings.Add("Text", devrep.DataSource, dtbSummerized.Rows[i].Cells["SelectionColumn"].Value.ToString());
                               string[] strSplit = strTotalLocation.Split(';');
                               if (strSplit.Count() != intLenR)
                               {
                                   string[] strLocation = strSplit[intLenR].Split('=');
                                   int intL = Convert.ToInt32(strLocation[0]);
                                   int intW = Convert.ToInt32(strLocation[1]);

                                   labelSumGroup.Location = new Point(intL, 10);
                                   labelSumGroup.TextAlignment = TextAlignment.MiddleRight;
                                   labelSumGroup.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                   labelSumGroup.Width = intW;
                                   labelSumGroup.Borders = BorderSide.All;
                                   labelSumGroup.BorderWidth = 1;
                                   labelSumGroup.Summary = xrSummary1;
                                   labelSumGroup.TextAlignment = TextAlignment.MiddleCenter;
                                   rfB.Controls.Add(labelSumGroup);
                                   strLenR = strLenR + 25;
                                   intLenR = intLenR + 1;
                                   intTotalLength = intTotalLength + labelCaptionMain.Width;
                               }
                            }
                        
                        #endregion
                        #region PageTotal
                        if (Convert.ToBoolean(dtbSummerized.Rows[i].Cells["SumPageLevel"].Value.ToString()) == true)
                        {
                            labelSumGroup = new XRLabel();
                            labelCaption = new XRLabel();
                            xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
                            xrSummary1.FormatString = "{0:#,0.00;(#,#);-}";
                            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
                            if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "SUM")
                            {
                                xrSummary1.Func = SummaryFunc.Sum;
                            }
                            else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "COUNT")
                            {
                                xrSummary1.Func = SummaryFunc.Count;
                            }
                            else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "MIN")
                            {
                                xrSummary1.Func = SummaryFunc.Min;
                            }
                            else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "MAX")
                            {
                                xrSummary1.Func = SummaryFunc.Max;
                            }
                            else if (dtbSummerized.Rows[i].Cells["Operator"].Value.ToString() == "AVG")
                            {
                                xrSummary1.Func = SummaryFunc.Avg;
                            }
                            //labelCaptionMain.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            //labelCaptionMain.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            //labelCaptionMain.Location = new Point(intTotalLength - 353, 0);
                            //labelCaptionMain.Width = 300;
                            //labelCaptionMain.BackColor = Color.Yellow;
                            //labelCaptionMain.ForeColor = Color.Black;
                            //labelCaptionMain.Borders = BorderSide.All;
                            //labelCaptionMain.BorderWidth = 3;
                            //labelCaptionMain.Text = "Page Total";
                            //labelCaptionMain.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            //pfB.Controls.Add(labelCaptionMain);


                            labelCaption.Text = "Page Total";
                            labelCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            labelCaption.TextAlignment = TextAlignment.MiddleCenter;
                            labelCaption.Borders = BorderSide.All;
                            labelCaption.Location = new Point(0, 0);
                            labelCaption.BorderWidth = 1;
                            labelCaption.Width = 100;
                            pfB.Controls.Add(labelCaption);

                            labelSumGroup.DataBindings.Add("Text", devrep.DataSource, dtbSummerized.Rows[i].Cells["SelectionColumn"].Value.ToString());
                            string[] strSplit = strTotalLocation.Split(';');
                            if (strSplit.Count() != intLenP)
                            {
                                string[] strLocation = strSplit[intLenP].Split('=');
                                int intL = Convert.ToInt32(strLocation[0]);
                                int intW = Convert.ToInt32(strLocation[1]);

                                labelSumGroup.Location = new Point(intL, 10);
                                labelSumGroup.TextAlignment = TextAlignment.MiddleRight;
                                labelSumGroup.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                labelSumGroup.Width = intW;
                                labelSumGroup.Borders = BorderSide.Bottom;
                                labelSumGroup.BorderWidth = 1;
                                labelSumGroup.Summary = xrSummary1;
                                labelSumGroup.TextAlignment = TextAlignment.MiddleCenter;
                                pfB.Controls.Add(labelSumGroup);
                                strLenP = strLenP + 25;
                                intLenP = intLenP + 1;
                            }
                        }
                        #endregion
                    }
                }
                devrep.Parameters["UserId"].Value = General.strUserId;
                devrep.Parameters["ReportName"].Value = General.strReportCaption;
                devrep.Parameters["CompanyName"].Value = General.strCompanyName;
                devrep.Parameters["BranchName"].Value = General.strBranchName;
                string strCriteria = "";
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    if (String.IsNullOrEmpty(dtbDetail.Rows[i].Cells["Criteria"].Value.ToString()) == false)
                    {
                        strCriteria = strCriteria + ";" + dtbDetail.Rows[i].Cells["ComboCaption"].Value.ToString() + "=" + dtbDetail.Rows[i].Cells["Criteria"].Value.ToString();
                    }
                }
                devrep.Parameters["Criteria"].Value = strCriteria;
                devrep.RequestParameters = false;
                XRPageInfo pgInfo = new XRPageInfo();
                pgInfo.Font =  new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                pfB.Controls.Add(pgInfo);
                devrep.CreateDocument();         
        }

        void labelSumGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (((XRLabel)sender).Text != "")
            {
                double dt = new double();
                dt = Math.Round(Convert.ToDouble(((XRLabel)sender).Text.ToString()), 0);
                ((XRLabel)sender).Text = String.Format("{0:0,0}", dt);

            }
        }


        private void AddReportColumn(string strColumns)
        {
            strTotalLocation = "";
            PageHeaderBand PhBand = new PageHeaderBand();
            XRPageInfo pginfo = new XRPageInfo();

            Band detBand = devrep.Bands["Detail"];
            int strLen = 0;
            int strHGLEN = 0;
            int strHGwidth = 0;
            dtb = new DataTable();
            PhBand.Height = 10;

            devrep.Bands.Add(PhBand);
            detBand.Height = 1;
            devrep.Bands.Add(detBand);

            string[] strAddColums = strColumns.Split(';');
            string strHGLabel = "";

            for (int i = 0; i < strAddColums.Count(); i++)
            {
                string[] strSplit = strAddColums[i].Split('=');
                XRPageBreak xrPageBreak0 = new XRPageBreak();
              
                XRLabel Lbl = new XRLabel();
            
                Lbl.Text = strSplit[0];
                Lbl.Width = strSplit[0].Length;
                Lbl.Borders = DevExpress.XtraPrinting.BorderSide.All;
                Lbl.BorderColor = Color.White;
                Lbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Lbl.Location = new Point(strLen, 23);
                
                Lbl.Width = Convert.ToInt32(strSplit[2]);
                Lbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                
                xrPageBreak0.Location = new Point(50, 150);
                
                //Running Total
                //xrtcDec.DataBindings.Add("Text", DataSource, "ContactItem.ClaimTotalsReportClientsTable.Dec");
                //xrtcDec.Summary = new XRSummary(SummaryRunning.Group);
                
              
                //xrSummary1.FormatString = "{0:#.00}";
                //xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
                //this.xrLabel1.Summary = xrSummary1;
                Lbl.BackColor = Color.LightGray;
                Lbl.ForeColor = Color.Black;
            
               
                PhBand.Controls.Add(Lbl);

               
                XRLabel detLbl = new XRLabel();
                detLbl.Text = strAddColums[i];
                detLbl.Location = new Point(strLen, 0);
                //detLbl.AutoWidth = true;
                detLbl.Width = Convert.ToInt32(strSplit[2]);
                detLbl.DataBindings.Add("Text", devrep.DataSource, strSplit[1]);
                if (strSplit[3].ToString() == "R")
                {
                    detLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                }
                else if (strSplit[3].ToString() == "C")
                {
                    detLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                }
                else if (strSplit[3].ToString() == "L")
                {
                    detLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                }
               if (strSplit[5].ToString() ==  "D")
                {
                    detLbl.BeforePrint += new System.Drawing.Printing.PrintEventHandler(detLbl_BeforePrint);
                }
                if (strSplit[4].ToString() == "n0")
                {
                    detLbl.BeforePrint +=new System.Drawing.Printing.PrintEventHandler(detRound0);
                }
                if (strSplit[4].ToString() == "n4")
                {
                    detLbl.BeforePrint += new System.Drawing.Printing.PrintEventHandler(detRound4);
                }
                if (strSplit[4].ToString() == "n2")
                {
                    detLbl.BeforePrint += new System.Drawing.Printing.PrintEventHandler(detRound2);
                }
                detBand.Height = 10;
                detLbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
                detBand.Controls.Add(detLbl);
                XRLabel HGLbl = null;
                if (strSplit[6] != "")
                {
                  
                    if (strHGLabel != strSplit[6])
                    {
                        XRLabel HGLbl1 = null;

                        if (strHGLabel != "")
                        {
                            HGLbl1 = (XRLabel)PhBand.Controls[strHGLabel];
                        }
                        strHGLabel = strSplit[6];
                        HGLbl = new XRLabel();
                        HGLbl.Borders = DevExpress.XtraPrinting.BorderSide.All;
                        HGLbl.BorderWidth = 1;
                        HGLbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        HGLbl.TextAlignment = TextAlignment.MiddleCenter;
                        HGLbl.Location = new Point(strLen, 0);
                        HGLbl.Text = strHGLabel;
                        HGLbl.Name = strHGLabel;
                        if (HGLbl1 == null)
                        {
                            strHGwidth = strHGwidth + Lbl.Width;
                        }
                        else
                        {
                            strHGwidth = (strHGwidth + Lbl.Width) - HGLbl1.Width;
                        }
                    }
                    else
                    {
                        XRLabel HGLbl1 = (XRLabel)PhBand.Controls[strHGLabel];
                        HGLbl = HGLbl1;
                        strHGwidth = strHGwidth + Lbl.Width;
                    }
                    PhBand.Controls.Add(HGLbl);
                }
                strLen = strLen + Convert.ToInt32(strSplit[2]);
                intTotalLength = intTotalLength + Lbl.Width;
                if (strSplit[6] != "")
                {
                    HGLbl.Width = strHGwidth;
                }
                if (strSplit[5] == "N")
                {
                    if (strSplit[7] == "True")
                    {
                        strTotalLocation = strTotalLocation + ";" + detLbl.Location.X.ToString() + "=" + strSplit[2];
                    }
                }
            }

         
            DevExpress.XtraPrinting.Preview.PrintPreviewFormEx form = new DevExpress.XtraPrinting.Preview.PrintPreviewFormEx();
            form.PrintingSystem = devrep.PrintingSystem;
            try
            {
                form.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Scale, new object[] { 1 });
            }
            catch (Exception)
            {
                form.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Scale, new object[] { 1 });
            }
            devrep.Landscape = chkLandscape.Checked;
            if (chkLines.Checked == true)
            {
                XRLine Line = new DevExpress.XtraReports.UI.XRLine();
                Line.Location = new System.Drawing.Point(0, 25);
                Line.Size = new System.Drawing.Size(intTotalLength, 0);
                detBand.Controls.Add(Line);
            }
       

        }
        void detRound0(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (((XRLabel)sender).Text != "")
            {
                double dt = new double();
                dt = Math.Round(Convert.ToDouble(((XRLabel)sender).Text.ToString()), 0);
               // ((XRLabel)sender).Text = String.Format("{{0:#,0;(#,#);-}", dt); 
                ((XRLabel)sender).Text = String.Format("{0:#,0;(#,#);-}", dt); 
                
            }
        }
        void detRound4(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (((XRLabel)sender).Text != "")
            {
                double dt = new double();
                dt = Math.Round(Convert.ToDouble(((XRLabel)sender).Text.ToString()), 4);
                ((XRLabel)sender).Text = String.Format("{0:#,0.0000;(#,#);-}", dt); 
            }

        }
        void detRound2(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (((XRLabel)sender).Text != "")
            {
                double dt = new double();
                dt = Math.Round(Convert.ToDouble(((XRLabel)sender).Text.ToString()), 2);
                ((XRLabel)sender).Text = String.Format("{0:#,0.00;(#,#);-}", dt); 
            }

        }

        void detLbl_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (((XRLabel)sender).Text != "")
            {
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(((XRLabel)sender).Text.ToString());
                ((XRLabel)sender).Text = dt.ToString("dd-MMM-yyyy");

            }

        }



        //for (int i = 0; i < grdFetch.Rows.Count; i++)
        //{
        //            XRPageBreak xrPageBreak0 = new XRPageBreak();
        //            XRLabel Lbl = new XRLabel();
        //            Lbl.Text = grdFetch.Rows[i].Cells["ColumnName"].Value.ToString();
        //            Lbl.Width = grdFetch.Rows[i].Cells["ColumnName"].Value.ToString().Length;
        //            Lbl.Borders = DevExpress.XtraPrinting.BorderSide.All;
        //            Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //            Lbl.Location = new Point(strLen, 0);

        //            xrPageBreak0.Location = new Point(50, 150);

        //            PhBand.Controls.Add(Lbl);
        //            XRLabel detLbl = new XRLabel();
        //            detLbl.Text = grdFetch.Rows[i].Cells["ColumnName"].Value.ToString();
        //            detLbl.Location = new Point(strLen, 0);
        //            detLbl.AutoWidth = true;
        //            detLbl.DataBindings.Add("Text", devrep.DataSource, grdFetch.Rows[i].Cells["ColumnName"].Value.ToString());
        //            detBand.Controls.Add(detLbl);
        //            strLen = strLen + 100;
        //        }
        //    }
        //}
        //intNoofRecord = dtb.Rows.Count;
        //Lblcount.Location = new Point(strLen, 0);

        private void frmReports_Load(object sender, EventArgs e)
        {
            AddColumn();
            populateAllQueryField();
            dtbDetail.CellContentClick += new DataGridViewCellEventHandler(dtbDetail_CellContentClick);
            dtbMaster.Visible = false;
            txtStatus.Visible = false;
            statusStrip1.Visible = false;
        }
        private void dtbDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if (e.ColumnIndex == dtbDetail.Columns["Click"].Index)
                {
                        General cls = new General();
                    string strqry = dtbDetail.Rows[e.RowIndex].Cells["Query"].Value.ToString();
                    dtb = new DataTable();
                    dtb = cls.GetDataSet(strqry).Tables[0];
                    frmListSearch childForm = new frmListSearch(dtb, dtbDetail.Rows[e.RowIndex].Cells["DataType"].Value.ToString(), dtbDetail.Rows[e.RowIndex].Cells["Operator"].Value.ToString());
                    childForm.ShowDialog();
                    dtbDetail.Rows[e.RowIndex].Cells["Criteria"].Value = frmListSearch.strArg[0];
                }
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddSummery()
        {
            
            //ReportFooterBand rptFB = new ReportFooterBand();
            //try
            //{
            //    XRLabel thisLabel = (XRLabel)sender;
            //    System.Data.DataTable table = ((System.Data.DataSet)thisLabel.Report.DataSource).Tables[thisLabel.Report.DataMember];

            //    object question = this.GetCurrentColumnValue("Question");
            //    object sumQuestion = table.Compute("Count(Question)", string.Format("Question = '{0}' ", question));

            //    object answer = this.GetCurrentColumnValue("Answer");
            //    object sumAnswer = table.Compute("Count(Answer)", string.Format("Answer = '{0}' AND Question='{1}' ", answer, question));
            //    e.Result = string.Format("total answers for question : {0}  this answer count: {1}", sumQuestion, sumAnswer);  // do your math here
            //    e.Handled = true;
            //}
            //catch (Exception ex)
            //{
            //    e.Result = "ERROR";
            //    e.Handled = true;
            //}

        }
        #region IToolBar Members

        public bool ADD()
        {
           return true;
        }

        public bool SAVE()
        {
           return true;
        }

        public bool EDIT()
        {
           return true;
        }

        public bool QUERY()
        {
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
        private void dtbSupress_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }
        private void dtbSupress_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
       
        }
        private void dtbDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if ((e.RowIndex != -1) && e.ColumnIndex != 3)
            //{
            //    // fill gradient background
            //    Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
            //    e.CellBounds, Color.LightGray, Color.White,
            //    System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            //    e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
            //    gradientBrush.Dispose();

            //    // paint rest of cell
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
            //    DataGridViewPaintParts.ContentForeground);
            //    e.Handled = true;
            //}
            //else if ((e.RowIndex == -1))
            //{
            //    Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
            //    e.CellBounds, Color.Orange, Color.NavajoWhite,
            //    System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            //    e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
            //    gradientBrush.Dispose();

            //    // paint rest of cell
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
            //    DataGridViewPaintParts.ContentForeground);
            //    e.Handled = true;

            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CreateReportDoucument();
            devrep.Print();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtbDetail.Rows.Count; i++)
            {
                dtbDetail.Rows[i].Cells["Criteria"].Value = "";
            }
            for (int i = 0; i < dtbGroup.Rows.Count; i++)
            {
                dtbGroup.Rows[i].Cells["GroupChk"].Value = false;
            }
            for (int i = 0; i < dtbOrder.Rows.Count; i++)
            {
                dtbOrder.Rows[i].Cells["OrderChk"].Value = false;
            }
            for (int i = 0; i < dtbSummerized.Rows.Count; i++)
            {
                dtbSummerized.Rows[i].Cells["SumChk"].Value = false;
                dtbSummerized.Rows[i].Cells["SumGroupLevel"].Value = false;
                dtbSummerized.Rows[i].Cells["SumPageLevel"].Value = false;
                dtbSummerized.Rows[i].Cells["SumReportLevel"].Value = false;
            }
            for (int i = 0; i < dtbSupress.Rows.Count; i++)
            {
                dtbSupress.Rows[i].Cells["SupressChk"].Value = false;
            }
        }

        private void dtbDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtbDetail.Columns[e.ColumnIndex].Name == "ComboCaption")
            {
                DataRow[] drr = dtvalid.Select("ObjectName = '" + objectname1 + "' and SelectionColumn = '"+ dtbDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value +"'");
                foreach (DataRow ldatarow in drr)
                {
                    dtbDetail.Rows[e.RowIndex].Cells["Not"].Value = ldatarow[2].ToString();
                    if (ldatarow[4].ToString().Contains("strBranch") == true)
                    {
                        ldatarow[4] = ldatarow[4].ToString().Replace("strBranch", General.strBranchCodeFrom.ToString());
                    }
                    dtbDetail.Rows[e.RowIndex].Cells["Query"].Value = ldatarow[4].ToString();
                    dtbDetail.Rows[e.RowIndex].Cells["Man"].Value = ldatarow[5].ToString();
                    dtbDetail.Rows[e.RowIndex].Cells["DataType"].Value = ldatarow[6].ToString();
                    dtbDetail.Rows[e.RowIndex].Cells["Criteria"].Value = "";
                }

            }
        }

        private void dtbSummerized_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    //dtbMaster.Rows[0].Cells[1].Selected = true;
            //    SendKeys.Send("{Right}");
            //    //  dtbMaster.Rows[e.RowIndex].Cells[0].Value = false;
            //}

        }

        private void dtbSummerized_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    dtbSummerized.Rows[e.RowIndex].Cells["SumPageLevel"].Value = dtbSummerized.Rows[e.RowIndex].Cells["SumChk"].Value;
            //    dtbSummerized.Rows[e.RowIndex].Cells["SumGroupLevel"].Value = dtbSummerized.Rows[e.RowIndex].Cells["SumChk"].Value;
            //    dtbSummerized.Rows[e.RowIndex].Cells["SumReportLevel"].Value = dtbSummerized.Rows[e.RowIndex].Cells["SumChk"].Value;
            //}

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (CheckMandatory() == true)
            {
                CreateReportDoucument();
                string strPath= "c:\\"+DateTime.Now.ToString("ddMMyyyhhmmss")+".pdf";
                devrep.ExportToPdf(strPath);
                //FileStream fl = new FileStream(strPath, FileMode.Open);
                Process.Start(strPath);
            }
            else
            {
                MessageBox.Show(strError, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckMandatory() == true)
            {
                CreateReportDoucument();
                string strPath = "c:\\" + DateTime.Now.ToString("ddMMyyyhhmmss") + ".csv";
                devrep.ExportToCsv(strPath);
                //FileStream fl = new FileStream(strPath, FileMode.Open);
                Process.Start(strPath);
            }
            else
            {
                MessageBox.Show(strError, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
