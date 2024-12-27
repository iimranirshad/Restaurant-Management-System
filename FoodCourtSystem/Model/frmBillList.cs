
using FoodCourtSystem.Reports;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodCourtSystem.Model
{
    public partial class frmBillList : Form
    {
        public frmBillList()
        {
            InitializeComponent();
        }
        public int IDD = 0;
        public string qry = @"SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain
               WHERE status != 'Pending'";
        private void frmBillList_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            LoadData();
        }
        
        private void LoadData()
        {
            

            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvtable);
            lb.Items.Add(dgvWaiter);
            lb.Items.Add(dgvType);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvTotal);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count=count+1;
                row.Cells[0].Value = count;
            }
        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                
                if (guna2DataGridView1.CurrentRow.Cells["dgvStatus"].Value.ToString() == "Paid")
                {
                    guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                    guna2MessageDialog1.Show("The Bill is Already paid, can't checkout again..!","TFC");
                }
                else
                {
                    IDD = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    this.Close();
                }

                
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                IDD = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

                string qry1 = @"select * from tblMain m inner join 
                              tblDetails d on d.MainID = m.MainId
                                inner join products p on p.pID = d.proID
                                where m.MainId = " + IDD + "";
                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
                frmPrint frm = new frmPrint();
               
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                CrystalReport1 cr = new CrystalReport1();

                cr.SetDataSource(dt);
                frm.crystalReportViewer1.ReportSource = cr;
                frm.crystalReportViewer1.Refresh();
                frm.Show();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAll_CheckedChanged(object sender, EventArgs e)
        {
            qry = @"SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain
               WHERE status != 'Pending'";
            LoadData();
        }
        public void GetData()
        {
            qry = "SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain WHERE status != 'Pending' AND CustName LIKE '%" + txtSearch.Text + "%'";

            if (btnPaid.Checked) 
            {
                qry = "SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain WHERE status != 'Pending' AND status = 'Paid' AND CustName LIKE '%" + txtSearch.Text + "%'";
             }
            else if (btnComlt.Checked)
            {
                qry = "SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain WHERE status != 'Pending' AND status = 'Complete' AND CustName LIKE '%" + txtSearch.Text + "%'";
            }
            else if(radioButton1.Checked) 
            {
                qry = "SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain WHERE status != 'Pending' AND status != 'Paid' AND CustName LIKE '%" + txtSearch.Text + "%'";
            }
            else
            {
                qry = "SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain WHERE status != 'Pending' and CustName like '%" + txtSearch.Text + "%'";

            }
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvtable);
            lb.Items.Add(dgvWaiter);
            lb.Items.Add(dgvType);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvTotal);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            qry = @"SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain
               WHERE status != 'Pending' AND orderType = 'Delivery'";
            LoadData();
        }

        private void btnPaid_CheckedChanged(object sender, EventArgs e)
        {
            qry = @"SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain
               WHERE status = 'Paid'";
            LoadData();
        }

        private void btnComlt_CheckedChanged(object sender, EventArgs e)
        {
            qry = @"SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain
               WHERE status = 'Complete'";
            LoadData();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            qry = @"SELECT MainId, TableName, CustName, orderType, status, total FROM tblMain
               WHERE status != 'Pending' and status != 'Paid'";
            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
    }
    
}
