using CrystalDecisions.ReportAppServer.DataDefModel;
using FoodCourtSystem.Model;
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

namespace FoodCourtSystem.View
{
    public partial class frmUserView : Form
    {
        public frmUserView()
        {
            InitializeComponent();
        }

        private void frmUserView_Load(object sender, EventArgs e)
        {
            btnAll.Checked = true;
            GetData();
        }
        public void GetData()
        {
            string qry = "";
            if (rdact.Checked)
            {
                qry = "Select userID,uName,uphone,uRole,Status From users where Status != 'InActive' and uName like '%" + txtSearch.Text + "%'  ";
            }
            else if (rdinact.Checked)
            {
                qry = "Select userID,uName,uphone,uRole,Status From users where Status != 'Active' and uName like '%" + txtSearch.Text + "%'  ";
            }
            else
            {
                qry = "Select userID,uName,uphone,uRole,Status From users where uName like '%" + txtSearch.Text + "%'  ";
            }

            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvRole);
            lb.Items.Add(dgvstat);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmUserAdd frm = new frmUserAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                frm.cbRole.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value);

                // Assuming you have a reference to the current DataGridView named "dataGridView"
                int rowIndex = guna2DataGridView1.CurrentCell.RowIndex;
                string uID = guna2DataGridView1.Rows[rowIndex].Cells["dgvid"].Value.ToString();
                if(MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                // Assuming you have a database connection object named "connection"
                using (SqlCommand command = new SqlCommand("SELECT username FROM users WHERE userID = @uID", MainClass.con))
                {
                    command.Parameters.AddWithValue("@uID", uID);
                   
                    string username = (string)command.ExecuteScalar();
                    frm.txtusername.Text = username;
                    
                }
                using (SqlCommand command = new SqlCommand("SELECT upass FROM users WHERE userID = @uID", MainClass.con))
                {
                    command.Parameters.AddWithValue("@uID", uID);

                    string userPass = (string)command.ExecuteScalar();
                    frm.txtPass.Text = userPass;

                }
                using (SqlCommand command = new SqlCommand("SELECT uEmail FROM users WHERE userID = @uID", MainClass.con))
                {
                    command.Parameters.AddWithValue("@uID", uID);

                    string email = (string)command.ExecuteScalar();
                    frm.txtemail.Text = email;

                }
                using (SqlCommand command = new SqlCommand("SELECT Address FROM users WHERE userID = @uID", MainClass.con))
                {
                    command.Parameters.AddWithValue("@uID", uID);

                    string Address = (string)command.ExecuteScalar();
                    frm.txtAddress.Text = Address;

                }
                using (SqlCommand command = new SqlCommand("SELECT Status FROM users WHERE userID = @uID", MainClass.con))
                {
                    command.Parameters.AddWithValue("@uID", uID);

                    string Status = (string)command.ExecuteScalar();
                    frm.lblstatus.Text = Status;

                }

                MainClass.con.Close();
                MainClass.BlurBackground(frm);
                GetData();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (MainClass.ROLE == "Admin")
                {
                    try
                    {
                        if (guna2MessageDialog1.Show("Are you sure to delete?") == DialogResult.Yes)
                        {
                            int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                            string qry = "Delete from users where userID = " + id + " AND uRole != 'Admin'";
                            Hashtable ht = new Hashtable();
                            string role = "";
                            MainClass.SQl(qry, ht);
                            if(MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                            using (SqlCommand command = new SqlCommand("SELECT uRole FROM users WHERE userID = "+id+" ", MainClass.con))
                            {
                                role= (string)command.ExecuteScalar();
                                
                            }
                            if (role != "Admin")
                            {
                                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                                guna2MessageDialog1.Show("Deleted Succesfully..!");
                                GetData();
                            }
                            else
                            {
                                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                                guna2MessageDialog1.Show("Could not delete","TFC");
                                GetData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                        guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        guna2MessageDialog1.Show("Could not delete" + ex.Message);
                    }
                }
                else
                {
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("You don't have permissons to delete users");
                }
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmUserAdd());
            GetData();
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
