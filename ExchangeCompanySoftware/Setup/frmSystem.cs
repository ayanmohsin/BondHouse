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
    public partial class frmSystem : BaseForm,IToolBar
    {
       
        DataSet ds;
        public frmSystem()
        {
            InitializeComponent();
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

        private void frmSystem_Load(object sender, EventArgs e)
        {
                General cls = new General();
        
            ds = new DataSet();
            string strQuery = "Select Distinct Flag,Remarks From EX_System;Select * from EX_System";
            ds =cls.GetDataSet(strQuery);
            cls.PopulateCombo(cboType, ds.Tables[0], "Remarks", "Flag");
            dtbMaster.Visible = false;
            //dtDate.Value = General.dtSystemDate;

        }

        private void cmdFetch_Click(object sender, EventArgs e)
        {
                General cls = new General();
            string strQuery = "Select Code,Description,'' as [New Description] from EX_System Where Flag = '"+ cboType.SelectedValue +"'";
            ds =cls.GetDataSet(strQuery);
            dtbMaster1.DataSource = ds.Tables[0];

        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            General cls = new General();
            for (int i = 0; i < dtbMaster1.Rows.Count ; i++)
            {
                   if (String.IsNullOrEmpty(dtbMaster1.Rows[i].Cells[2].Value.ToString()) == false)
                    {
                        string strQuery = "Update EX_System Set Description = '" + dtbMaster1.Rows[i].Cells[2].Value.ToString() + "' Where Code = '" + dtbMaster1.Rows[i].Cells[0].Value.ToString() + "'";
                    cls.ExecuteDML(strQuery);
                }
                
            }
        }
    }
}
