using FluentEmail.Core;
using FoodCourtSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodCourtSystem
{
    public partial class LoginFRM : Form
    {
        public LoginFRM()
        {
            InitializeComponent();
        }

        private void LoginFRM_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
           
            
        }


        private void extbtn_Click(object sender, EventArgs e)
        {
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OKCancel;
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            if (guna2MessageDialog1.Show("Exit Applicaton", "Confirm") == DialogResult.OK)
            {
                Application.Exit();
            }
            else
                return;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUser.Clear();
            guna2CustomCheckBox1.Checked = false;
            
        }

        private void lgnbtn_Click(object sender, EventArgs e)
        {
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            if (MainClass.IsValidUser(txtUser.Text, txtPass.Text) == false)
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Invalid username or password!", "ACCESS DENITED");
                return;
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                guna2MessageDialog1.Show("Welcome " + MainClass.USER + " ! \n" + "You Logged in as " + MainClass.ROLE + "!", "ACCESS GRANTED");
                this.Hide();
                frmMain frm = new frmMain();
                frm.AddControls(new frmHome());
                frm.Show();
            }
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked == true)
                txtPass.UseSystemPasswordChar = false;
            else
                txtPass.UseSystemPasswordChar = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if(guna2CustomCheckBox1.Checked == true)
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

       

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frmforget frm = new Frmforget();
            frm.Show();
        }
    }
}
