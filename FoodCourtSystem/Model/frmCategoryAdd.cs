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
    public partial class frmCategoryAdd : Form
    {
        public frmCategoryAdd()
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
            try
            {
                if (txtName.Text != string.Empty)
                {


                    string qry = "";
                    if (id == 0)
                    {
                        qry = "insert into category values (@Name)";
                    }
                    else
                    {
                        qry = "update category Set catName = @Name where catId = @id";
                    }
                    Hashtable ht = new Hashtable();
                    ht.Add("@id", id);
                    ht.Add("@Name", txtName.Text);

                    if (MainClass.SQl(qry, ht) > 0)
                    {
                        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        guna2MessageDialog1.Show("Saved Succesfully..!", "Category");
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
                    guna2MessageDialog1.Show("Category name should not be empty", "Error");
                    Errorlabel.Text = "Category must have a name eg Burger";
                    txtName.Focus();
                }
            }
            catch (Exception ex)
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show(ex.Message, "Error");
            }
        }
    }
}
