using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FoodCourtSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void extbtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Exit Applicaton", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
                return;
        }

        private void lgnbtn_Click(object sender, EventArgs e)
        {
           if( MainClass.IsValidUser(txtUser.Text,txtPass.Text) == false)
            {
                MessageBox.Show("Invalid username or password!", "ACCESS DENITED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Welcome " + MainClass.USER + " ! ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmMain frm = new frmMain();
                frm.Show();
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUser.Clear();
            checkBox1 .Checked = false;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
