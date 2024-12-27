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
    public partial class frmSaleByCategory : Form
    {
        public frmSaleByCategory()
        {
            InitializeComponent();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
           
            string qry1 = @"select * from tblMain m
                            inner join tblDetails d on m.MainId = d.MainID
                            inner join products p on p.pID = d.proID
                            inner join category c on c.catId = p.CategoryID
                            where m.aDate between @sdate and @edate ";
            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@sdate", Convert.ToDateTime(sDate.Value).Date);
            cmd.Parameters.AddWithValue("@edate", Convert.ToDateTime(eDate.Value).Date);
            frmPrint frm = new frmPrint();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

            rptsalebycat cr = new rptsalebycat();

            cr.SetDataSource(dt);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show();
        }
    }
}
