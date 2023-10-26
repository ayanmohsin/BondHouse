using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeCompanySoftware
{
    public class EndPoint
    {
        public string Address { get; set; }
        public string CompanyCode { get; set; }
        public string Database { get; set; }
    }
    public partial class frmApplication : Form
    {
        public frmApplication()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Endpoint");
                key.SetValue("EndPoint", textBox1.Text);
                key.Close();
                Security sec = new Security();
                string strAddress = sec.Decrypt("Password*124",textBox1.Text);
                General.gendPoint = strAddress;
                MessageBox.Show("Address Updated Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void frmApplication_Load(object sender, EventArgs e)
        {
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
                textBox1.Text = strEndPoint;
            }
        }
    }
}
