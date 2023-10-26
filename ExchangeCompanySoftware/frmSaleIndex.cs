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
    public partial class frmSaleIndex : Form
    {
        public frmSaleIndex()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            General cls = new General();
            string strQuery = "Exec sp_IndexSale " + General.strBranchCode + ",'" + dtSystemDate.Value.ToString("dd/MMM/yyyy") + "'";
            cls.ExecuteDML(strQuery);
            MessageBox.Show("Updated");
        }

        private void frmSaleIndex_Load(object sender, EventArgs e)
        {
            dtSystemDate.Value = General.dtSystemDate;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
