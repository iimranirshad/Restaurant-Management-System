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
    public partial class frmTableAdd : Form
    {
        public frmTableAdd()
        {
            InitializeComponent();
        }
        public int id = 0;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {


                string qry = "";
                if (id == 0)
                {
                    qry = "insert into tables values (@Name)";
                }
                else
                {
                    qry = "update tables Set tname = @Name where tid = @id";
                }
                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@Name", txtName.Text);

                if (MainClass.SQl(qry, ht) > 0)
                {
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Saved Succesfully..!", "Table");
                    id = 0;
                    txtName.Text = "";
                    txtName.Focus();
                    Errorlabel.Text = "";
                }
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Table name should not be empty", "Error");
                Errorlabel.Text = "Table must have a name eg Table 1..";
                txtName.Focus();
            }
        }
    }
}
