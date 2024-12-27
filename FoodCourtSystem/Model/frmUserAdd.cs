using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodCourtSystem.Model
{
    public partial class frmUserAdd : Form
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
                {
                    e.Handled = true; // Cancel the key press event
                }

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true; // Cancel the key press event
                }
            
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

        private void frmUserAdd_Load(object sender, EventArgs e)
        {
            txtName.Focus();
            guna2ToggleSwitch1.Checked = true;
            txtPass.UseSystemPasswordChar = true;
            if(MainClass.ROLE != "Admin")
            {
                //btnSave.Visible = false;
                btnSave.Enabled = false;
                guna2CustomCheckBox1.Enabled = false;
                label7.Enabled = false;
            }
            else
            {   btnSave.Enabled = true;
                guna2CustomCheckBox1.Enabled = true;
                label7.Enabled = true;
            }
        }
        private static Regex gmailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@gmail.com$", RegexOptions.IgnoreCase);

        private void btnSave_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;

            if (!gmailRegex.IsMatch(email) && txtName.Text != string.Empty)
            {
                txtemail.Text = "";
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                guna2MessageDialog1.Show("Only Gmail addresses are allowed.", "Invalid Email");
            }
            else if (txtName.Text != string.Empty && txtPhone.Text != string.Empty && txtPass.Text != string.Empty &&txtusername.Text != string.Empty && txtemail.Text != string.Empty)
            {
               

                string qry = "";
                if (id == 0)
                {
                    qry = "insert into users values (@uName, @uPass,@Name, @phone, @role,@email,@status,@address)";
                }
                else
                {
                    qry = "update users Set username = @uName,upass = @uPass,uName = @Name,uphone = @phone,uRole = @role,uEmail = @email, Status = @status, Address = @address where userID = @id";
                }
                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@uPass", txtPass.Text);
                ht.Add("@uName", txtusername.Text);
                ht.Add("@Name", txtName.Text);
                ht.Add("@phone", txtPhone.Text);
                ht.Add("@role", cbRole.Text);
                ht.Add("@email", txtemail.Text);
                ht.Add("@status", lblstatus.Text);
                ht.Add("@address", txtAddress.Text);

                if (MainClass.SQl(qry, ht) > 0)
                {
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Saved Succesfully..!", "TFC");
                    id = 0;
                    txtName.Text = "";
                    txtPhone.Text = "";
                    txtPass.Text = "";
                    txtusername.Text = "";
                    cbRole.SelectedIndex = -1;
                    txtName.Focus();
                    Errorlabel.Text = "";
                    txtemail.Text = "";
                    txtAddress.Text = "";
                    guna2ToggleSwitch1.Checked = true;
                }
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("All Fields are required", "Error");
                Errorlabel.Text = "Name or Phone or role etc should not be empty..!!";
                

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            
          
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2ToggleSwitch1.Checked == true) 
            { lblstatus.Text = "Active"; }
            else
            { lblstatus.Text = "InActive"; }
        }
    }
}
