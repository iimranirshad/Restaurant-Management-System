using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.VisualBasic.ApplicationServices;

namespace FoodCourtSystem.Model
{
    public partial class Frmforget : Form
    {
        public Frmforget()
        {
            InitializeComponent();
        }
        public static string OTPkey = "";
        public static string username;
        public static string phone;
        public static string USERNAME
        {
            get { return username; }
            private set { username = value; }
        }
        public static string PHONE
        {
            get { return phone; }
            private set { phone = value; }
        }
        public void Email(string toEmail)
        {
            string fromMail = "example@gmail.com";
            string fromPass = "secret-key";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Password Recovery";
            message.To.Add(new MailAddress(toEmail));
            string emailbody = "Please Enter OTP as soon as possible in order to recover the pasword \n Your OTP is : " + OTPkey;
            message.Body = emailbody;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPass),
                EnableSsl = true

            };
            smtpClient.Send(message);

        }

        private void Frmforget_Load(object sender, EventArgs e)
        {
            OTPkey = GenerateOTP();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != string.Empty || txtPhone.Text != string.Empty)
            {
                string UserEmail = "";
                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                using (SqlCommand command = new SqlCommand("select uEmail from users where username = @Uname or uphone = @phone", MainClass.con))
                {
                    command.Parameters.AddWithValue("@Uname", txtUsername.Text.ToString());
                    command.Parameters.AddWithValue("@phone", txtPhone.Text.ToString());
                    
                   
                    UserEmail = (string)command.ExecuteScalar();

                    if (UserEmail == "" || UserEmail == null || UserEmail == string.Empty)
                    {
                        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                        guna2MessageDialog1.Show("The Username or password is not found..!\nTry Again...!", "Password Recovery Service");
                        lblerror.Text = "userName or phone is not found..!";
                        txtUsername.Focus();
                    }
                    else
                    {
                        guna2MessageDialog1.Show("OTP has been send succesfully to email "+ UserEmail);
                        Email(UserEmail);
                        USERNAME = txtUsername.Text;
                        PHONE = txtPhone.Text;
                        FrmOTP.OTPkey = OTPkey;
                        this.Hide();

                        FrmOTP frm = new FrmOTP();
                        frm.lblEmail.Text = UserEmail;
                        frm.Show();
                    }


                }
            }else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Username or Phone is requited", "Password Recovery Service");
                txtUsername.Focus();
            }


        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Cancel the key press event
            }
        }

        private static Random random = new Random();

        private static string GenerateOTP()
        {
            const int otpLength = 6;
            const string characters = "0123456789";
            char[] otp = new char[otpLength];

            for (int i = 0; i < otpLength; i++)
            {
                otp[i] = characters[random.Next(characters.Length)];
            }

            return new string(otp);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginFRM frm = new LoginFRM();
            frm.Show();
        }
    }
   
}
