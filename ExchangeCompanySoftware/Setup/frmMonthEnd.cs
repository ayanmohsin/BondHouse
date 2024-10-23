using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static DevExpress.Xpo.Helpers.CommandChannelHelper;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace ExchangeCompanySoftware
{
    public partial class frmMonthEnd : BaseForm, IToolBar
    {
        public frmMonthEnd()
        {
            InitializeComponent();
        }

        public bool ADD()
        {
            throw new NotImplementedException();
        }

        public bool AUTHORIZE()
        {
            throw new NotImplementedException();
        }

        public bool DELETE()
        {
            throw new NotImplementedException();
        }

        public bool EDIT()
        {
            throw new NotImplementedException();
        }

        public bool EXIT()
        {
            throw new NotImplementedException();
        }

        public bool FIRST()
        {
            throw new NotImplementedException();
        }

        public bool LAST()
        {
            throw new NotImplementedException();
        }

        public bool NEXT()
        {
            throw new NotImplementedException();
        }

        public bool PREVIOUS()
        {
            throw new NotImplementedException();
        }

        public bool PRINT()
        {
            throw new NotImplementedException();
        }

        public bool QUERY()
        {
            throw new NotImplementedException();
        }

        public bool SAVE()
        {
            throw new NotImplementedException();
        }

        public bool UNDO()
        {
            throw new NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerateProcess_Click(object sender, EventArgs e)
        {
            General cls = new General();
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to proceed?",
                                                   "Confirmation",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                     string strQuery = "Exec sp_MonthEnd '" + dttoDate.Value.ToString("dd/MMM/yyyy") + "','" + General.strBranchCode + "','" + ditxtRemarks.Text + " Closing for the Month "+ dttoDate.Value.ToString("yyyy-MMM") + "'";
                     cls.ExecuteDML(strQuery);

                    MessageBox.Show("Month End Executed Successfully", "Execute",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    // Code to execute if user clicked No
                    MessageBox.Show("You clicked No!");
                }

                
            }
            catch (Exception ex)
            {
              
                throw;
            }
        }
    }
}
