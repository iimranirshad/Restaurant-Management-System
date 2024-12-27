using System;
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
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }
        public string orderType = "";
        public int driverID = 0;
        public string cusName = "";
        public int mainID = 0;

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            if (orderType == "Take Away")
            {
                lblDriver.Visible = false;
                cbDriver.Visible = false;
                
            }
            if(orderType == "Din In")
            {
                lblDriver.Visible = false;
                cbDriver.Visible = false;
            }
            string qry = "select staffID 'id',sName 'name' from staff where sRole = 'Driver'";
            MainClass.CBFill(qry, cbDriver);

            if(mainID >0)
            {
                cbDriver.SelectedValue = driverID;

            }
        
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Name and Phone number should not be Empty", "Error");
            }
            
        }

        private void cbDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            driverID = Convert.ToInt32(cbDriver.SelectedValue);
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Ignore the input if it's not a letter.
                }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
           // Check if the pressed key is a digit and greater than zero.
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true; // Ignore the input.
                }
                
            

        }
    }
}
