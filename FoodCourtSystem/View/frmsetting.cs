using FoodCourtSystem.Model;
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

namespace FoodCourtSystem.View
{
    public partial class frmsetting : Form
    {
        public frmsetting()
        {
            InitializeComponent();
        }
        public void AddControls(Form f)
        {
            Centerpanel.Controls.Clear();

            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            Centerpanel.Controls.Add(f);
            f.Show();
        }

        

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new frmUserView());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            AddControls(new frmReportbtn());
        }

        private void frmsetting_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
            lblRole.Text = MainClass.ROLE;
        }
    }
}
