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

namespace FoodCourtSystem.View
{
    public partial class frmStaffView : Form
    {
        public frmStaffView()
        {
            InitializeComponent();
        }

        private void frmStaffView_Load(object sender, EventArgs e)
        {
            GetData();
            btnAll.Checked = true;
        }
        public void GetData()
        {
            string qry = "";
            if (rdinact.Checked)
            {
                qry = "Select staffID, sName, sPhone, sRole, Status From staff where Status = 'InActive' and sName like '%" + txtSearch.Text + "%'";
            }
            else if (rdact.Checked)
            {
                qry = "Select staffID, sName, sPhone, sRole, Status From staff where Status = 'Active' and sName like '%" + txtSearch.Text + "%'";

            }
            else
            {
                qry = "Select staffID, sName, sPhone, sRole, Status From staff where sName like '%" + txtSearch.Text + "%'";
            }

            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvRole);
            lb.Items.Add(dgvstat);
            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmStaffAdd());
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
                frmStaffAdd frm = new frmStaffAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                frm.cbRole.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value);
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
            //        string qry = "Delete from staff where staffID = " + id + " ";
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
