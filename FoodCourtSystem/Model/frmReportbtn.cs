using FoodCourtSystem.Reports;
using System;
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
    public partial class frmReportbtn : Form
    {
        public frmReportbtn()
        {
            InitializeComponent();
        }

        private void btnSaleCat_Click(object sender, EventArgs e)
        {
            frmSaleByCategory frm = new frmSaleByCategory();
            frm.ShowDialog();
        }

        private void btnsalebyproduct_Click(object sender, EventArgs e)
        {
            salesbyitems frm = new salesbyitems();
            frm.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
                string qry1 = @"select * from users";
                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
                frmPrint frm = new frmPrint();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                users cr = new users();

                cr.SetDataSource(dt);
                frm.crystalReportViewer1.ReportSource = cr;
                frm.crystalReportViewer1.Refresh();
                frm.Show();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string qry1 = @"select * from staff";
            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            frmPrint frm = new frmPrint();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

            Staff cr = new Staff();
            cr.SetDataSource(dt);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show();
        }
    }
}
