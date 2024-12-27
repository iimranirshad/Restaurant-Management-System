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
    public partial class frmStaffAdd : Form
    {
        public frmStaffAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void frmStaffAdd_Load(object sender, EventArgs e)
        {
            guna2ToggleSwitch1.Checked = true;
            if (guna2ToggleSwitch1.Checked == false)
            {
                lblstatus.Text = "InActive";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty && txtPhone.Text != string.Empty && cbRole.SelectedIndex>=0)
            {


                string qry = "";
                if (id == 0)
                {
                    qry = "insert into staff values (@Name, @phone, @role, @status, @address)";
                }
                else
                {
                    qry = "update staff Set sName = @Name,sphone = @phone,srole = @role, Status = @status, Address = @address where staffID = @id";
                }
                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@Name", txtName.Text);
                ht.Add("@phone", txtPhone.Text);
                ht.Add("@role", cbRole.Text);
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
                    cbRole.SelectedIndex = -1;
                    txtName.Focus();
                    Errorlabel.Text = "";
                    txtAddress.Text = "";
                    guna2ToggleSwitch1.Checked = false;
                }
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("All Fields are required", "Error");
                Errorlabel.Text = "Name or Phone or role should not be empty..!!";
                if(txtName.Text=="")
                    txtName.Focus();
                else if(txtPhone.Text=="")
                    txtPhone.Focus();
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Cancel the key press event
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked == true)
            {
                lblstatus.Text = "Active";
            }
            else
            {
                lblstatus.Text = "InActive";
            }
        }
    }
}
