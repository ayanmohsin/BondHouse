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
    public partial class frmPasswordChange : Form
    {
        public frmPasswordChange()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string strError = "";
            string strQuery = " Select * from EX_Login Where Locked = 'False' and Status = 'A' and Password = '"+ txtOPassword.Text +"' and UserId = '"+ General.strUserId +"' ";
            DataSet ds = new DataSet();
                General cls = new General();
            ds =cls.GetDataSet(strQuery);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (txtNPassword.Text == txtCPassword.Text )
                {
                   
                    strQuery = "Update EX_Login set Password = '"+ txtCPassword.Text  +"' Where UserId = '"+ General.strUserId +"'";
                    cls.ExecuteDML(strQuery);
                    strError = "Password Update";
                }
                else
                {
                    strError = "Password not match";
                }
            }
            else
            {
                strError = "Incorrect Old Password";
            }
            MessageBox.Show(strError);
        }

        private void frmPasswordChange_Load(object sender, EventArgs e)
        {
            lblUser.Text = General.strUserId;
        }
    }
}
