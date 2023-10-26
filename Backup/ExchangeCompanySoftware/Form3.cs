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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            WinApi.AnimateWindow(this.Handle, 800, 655360);
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            lblCaption.Text = "Checking Connection";
            progressBar1.Value = 20;
            GetData.ServiceSoapClient objGetData;
            DataSet ds = new DataSet();
            string strQuery = "Select * from EX_System";
            ds = new DataSet(strQuery);
            timer1.Interval = 1000;
            timer1.Enabled = true;
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCaption.Text = "Loading Personal Setting";
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 20;        
            }
            else
            {
                timer1.Enabled = false;
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        
        }

    }
}
