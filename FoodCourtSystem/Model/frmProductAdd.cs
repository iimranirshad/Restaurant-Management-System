using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodCourtSystem.Model
{
    public partial class frmProductAdd : Form
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public int cID = 0;
        string filePath ;
        Byte[] imageByteArray;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName ;
                txtImage.Image = new Bitmap(filePath);
            }
        }


        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            string qry = "select catId 'id', catName 'name' from category";
            MainClass.CBFill(qry, cbCat);
            guna2ToggleSwitch1.Checked = true;
            if (guna2ToggleSwitch1.Checked == false)
            {
                lblstatus.Text = "InActive";
            }
            //for update
            if(cID>0)
            {
                cbCat.SelectedValue = cID;
            }

            if (id>0)
            {
                ForUpdateLoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty && txtPrice.Text != string.Empty && cbCat.SelectedIndex >= 0)
            {


                string qry = "";
                if (id == 0)
                {
                    qry = "insert into products values (@Name, @price, @cat, @img, @status)";
                }
                else
                {
                    qry = "update products Set pName = @Name,pPrice = @price,CategoryID = @cat,pImage = @img, Status = @status where pID = @id";
                }
                //for image
                Image temp = new Bitmap(txtImage.Image);
                MemoryStream ms = new MemoryStream();
                temp.Save(ms,System.Drawing.Imaging.ImageFormat.Png);
                imageByteArray = ms.ToArray();

                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@Name", txtName.Text);
                ht.Add("@price", txtPrice.Text);
                ht.Add("@cat", Convert.ToInt32(cbCat.SelectedValue));
                ht.Add("@img", imageByteArray);
                ht.Add("@status",lblstatus.Text);


                if (MainClass.SQl(qry, ht) > 0)
                {
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Saved Succesfully..!", "Product Added");
                    id = 0;
                    cID = 0;
                    txtName.Text = "";
                    txtPrice.Text = "";
                    cbCat.SelectedIndex = 0;
                    cbCat.SelectedIndex = -1;
                    txtImage.Image = FoodCourtSystem.Properties.Resources.shopping_mall_48px1;
                    txtName.Focus();
                    Errorlabel.Text = "";
                }
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("All Fields are required", "Error");
                Errorlabel.Text = "Name or price or Category should not be empty..!!";
                if (txtName.Text == "")
                    txtName.Focus();
                else if (txtPrice.Text == "")
                    txtPrice.Focus();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ForUpdateLoadData()
        {
            string qry = "select * from products where pID = " + id + " ";
            SqlCommand cmd = new SqlCommand(qry,MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["pName"].ToString();
                txtPrice.Text = dt.Rows[0]["pPrice"].ToString();

                Byte[] imageArray = (byte[])(dt.Rows[0]["pImage"]);
                byte[] imageByteArray = imageArray;
                txtImage.Image = Image.FromStream(new  MemoryStream(imageArray));

            }

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Cancel the keypress event
                e.Handled = true;
            }
        }

        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2ToggleSwitch1.Checked == true) {
                lblstatus.Text = "Active";
            }
            else
            {
                lblstatus.Text = "InActive";
            }
        }
    }
}
