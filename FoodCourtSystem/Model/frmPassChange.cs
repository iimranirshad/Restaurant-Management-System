using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodCourtSystem.Model
{
    public partial class frmPassChange : Form
    {
        public frmPassChange()
        {
            InitializeComponent();

        }

        private void frmPassChange_Load(object sender, EventArgs e)
        {
            txtPass.Text = FrmOTP.PASS;
            newPass.Focus();
            txtPass.UseSystemPasswordChar = true;
            newPass.UseSystemPasswordChar = true;
            vnewPass.UseSystemPasswordChar = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked == true)
            {
                guna2CustomCheckBox1.Checked = false;
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                guna2CustomCheckBox1.Checked = true;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked == true)
                txtPass.UseSystemPasswordChar = false;
            else
                txtPass.UseSystemPasswordChar = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox2.Checked == true)
            {
                guna2CustomCheckBox2.Checked = false;
                newPass.UseSystemPasswordChar = true;
            }
            else
            {
                guna2CustomCheckBox2.Checked = true;
                newPass.UseSystemPasswordChar = false;
            }
        }

        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox2.Checked == true)
                newPass.UseSystemPasswordChar = false;
            else
                newPass.UseSystemPasswordChar = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox3.Checked == true)
            {
                guna2CustomCheckBox3.Checked = false;
                vnewPass.UseSystemPasswordChar = true;
            }
            else
            {
                guna2CustomCheckBox3.Checked = true;
                vnewPass.UseSystemPasswordChar = false;
            }
        }

        private void guna2CustomCheckBox3_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox3.Checked == true)
                vnewPass.UseSystemPasswordChar = false;
            else
                vnewPass.UseSystemPasswordChar = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (newPass.Text == vnewPass.Text)
            {
                string user = Frmforget.USERNAME;
                string upass = FrmOTP.PASS;
                string qry = @"update users Set upass = @uPass where upass = @pass and username = @uname";
                Hashtable ht = new Hashtable();
                ht.Add("@uPass", vnewPass.Text);
                ht.Add("@pass", upass);
                ht.Add("@uname", user);
                if (MainClass.SQl(qry, ht) > 0)
                {
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Saved Succesfully..!", "Pasword Service");
                    LoginFRM frm = new LoginFRM();
                    frm.Show();
                    frm.Show();
                }
                else
                {
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                    guna2MessageDialog1.Show("New Pass and Verify pass should be Same", "Pasword Service");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginFRM frm = new LoginFRM();
            frm.Show();
        }

        private void newPass_TextChanged(object sender, EventArgs e)
        {
            newPass.Focus();
        }
    }
}
