using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodCourtSystem.Model
{
    public partial class frmCheckout : Form
    {
        public frmCheckout()
        {
            InitializeComponent();
        }
        public double amt;

        private void txtReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
             // Check if the pressed key is a digit (0-9) or the backspace key
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    // Cancel the keypress event
                    e.Handled = true;
                }
        }
        public int MainID = 0;

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            double amt = 0;
            double receipt = 0;
            double change = 0;

            
            if(txtReceived.Text == "" ||  Convert.ToDouble(txtBillAmount.Text) <= Convert.ToDouble(txtReceived.Text))
            {
                txtReceived.ForeColor = Color.Green;
            }
            else
            {
                txtReceived.ForeColor = Color.Red;
            }
            double.TryParse(txtBillAmount.Text, out amt);
            double.TryParse(txtReceived.Text, out receipt);
            change = receipt-amt;
            txtChange.Text = change.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            string status;
            using (SqlCommand command = new SqlCommand("select status from tblMain where MainID = @id", MainClass.con))
            {
                command.Parameters.AddWithValue("@id", MainID);

                status = (string)command.ExecuteScalar();
               
            }
            if(status !="Paid")
            { 
            double actual, recived;
                if (txtReceived.Text != string.Empty)
                {
                    actual = Convert.ToDouble(txtBillAmount.Text);
                    recived = Convert.ToDouble(txtReceived.Text);
                    if (actual <= recived)
                    {
                        string qry = @"update tblMain set total = @total, received =@rec, change = @change,
                          status = 'Paid' where MainID = @id";
                        Hashtable ht = new Hashtable();
                        ht.Add("@id", MainID);
                        ht.Add("@total", txtBillAmount.Text);
                        ht.Add("@rec", txtReceived.Text);
                        ht.Add("@change", txtChange.Text);

                        if (MainClass.SQl(qry, ht) > 0)
                        {
                            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                            guna2MessageDialog1.Show("Payment Added Successfully", "TFC");
                            this.Close();
                        }
                    }
                    else
                    {
                        errlbl.Visible = true;
                        errlbl.Text = "Price must be equal to total bill...!";
                        txtChange.Clear();
                    }
                }
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show("The Current Bill is Already Paid", "TFC");
            }
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {
            txtBillAmount.Text = amt.ToString();
            txtReceived.Focus();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
