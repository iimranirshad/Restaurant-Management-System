using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodCourtSystem.Model
{
    public partial class FrmOTP : Form
    {
        public FrmOTP()
        {
            InitializeComponent();
        }
        public static string OTPkey = "";
        private void FrmOTP_Load(object sender, EventArgs e)
        {
            txtotp.Focus();
        }
        
        private void txtotp_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void txtotp_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Cancel the key press event
            }
            
        }
        private static string Password = "";
        public static string PASS
        {
            get { return Password; }
            set { Password = value; }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtotp.Text == OTPkey)
            {
                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                using (SqlCommand command = new SqlCommand("select upass from users where uEmail = @email", MainClass.con))
                {
                    command.Parameters.AddWithValue("@email", lblEmail.Text.ToString());

                    Password = (string)command.ExecuteScalar();
                }
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if(guna2MessageDialog1.Show("Your Password is '" +  Password + " \n Do You Change the Pasword","Recovery Service") == DialogResult.Yes)
                {
                    this.Hide();
                    frmPassChange frm = new frmPassChange();
                    frm.Show();
                    
                }
                else
                {
                    this.Hide();
                    LoginFRM frm = new LoginFRM();
                    frm.Show();
                }
                
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show("OTP is not matched with latest otp..!\nPlease re-enter OTP","Recovery Service");
                txtotp.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginFRM frm = new LoginFRM();
            frm.Show();
        }
    }
}
