using FoodCourtSystem.Model;
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

namespace FoodCourtSystem.View
{
    public partial class frmProductView : Form
    {
        public frmProductView()
        {
            InitializeComponent();
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            btnAll.Checked = true;
            GetData();
        }
        public void GetData()
        {
            string qry = "";
            if(rdinact.Checked)
            {
                qry = "select pID,pName,pPrice,CategoryID,c.catName,Status from products p inner join category c on c.catId = p.CategoryID where Status = 'InActive' and pName like '%" + txtSearch.Text + "%'";
            }else if (rdact.Checked)
            {
                qry = "select pID,pName,pPrice,CategoryID,c.catName,Status from products p inner join category c on c.catId = p.CategoryID where Status = 'Active' and pName like '%" + txtSearch.Text + "%'";
            }
            else{
                qry = "select pID,pName,pPrice,CategoryID,c.catName,Status from products p inner join category c on c.catId = p.CategoryID where pName like '%" + txtSearch.Text + "%'";
            }
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPrice);
            lb.Items.Add(dgvcatID);
            lb.Items.Add(dgvcat);
            lb.Items.Add(dgvstatus);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            MainClass.BlurBackground(new frmProductAdd());
            GetData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmProductAdd frm = new frmProductAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.cID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvcatID"].Value);
                
                MainClass.BlurBackground(frm);
                GetData();
            }
            //if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            //{
            //    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            //    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            //    if (guna2MessageDialog1.Show("Are you sure to delete?") == DialogResult.Yes)
            //    {
            //        int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
            //        string qry = "Delete from products where pID = " + id + " ";
            //        Hashtable ht = new Hashtable();
            //        MainClass.SQl(qry, ht);

            //        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            //        guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            //        guna2MessageDialog1.Show("Deleted Succesfully..!");
            //        GetData();
            //    }
            //}
        }

        private void btnAll_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void rdact_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void rdinact_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
