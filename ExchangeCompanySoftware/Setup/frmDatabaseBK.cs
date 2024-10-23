using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace ExchangeCompanySoftware
{
    public partial class frmDatabaseBK : ExchangeCompanySoftware.BaseForm
    {
        public frmDatabaseBK()
        {
            InitializeComponent();
        }

        private void btnDbBK_Click(object sender, EventArgs e)
        {
            General cls = new General();
            string strQuery = "Exec sp_DBBK ";
            cls.ExecuteDMLBK(strQuery);

            MessageBox.Show("Back up Successfully", "Execute",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
