﻿using FoodCourtSystem.Model;
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
using System.Xml.Serialization;

namespace FoodCourtSystem.View
{
    public partial class formCategoryView : SampleView
    {
        public formCategoryView()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            string qry = "Select * From category where catName like '%"+txtSearch.Text+"%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            //frmCategoryAdd frm = new frmCategoryAdd();
            //frm.ShowDialog();
            MainClass.BlurBackground(new frmCategoryAdd());
            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void formCategoryView_Load(object sender, EventArgs e)
        {
            GetData();
        }
        

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if(guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmCategoryAdd frm = new frmCategoryAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                MainClass.BlurBackground(frm);
                GetData();
            }
            if(guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Are you sure to delete?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from category where catId = " + id + " ";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Deleted Succesfully..!");
                    GetData();
                }
            }
        }
    }
}
