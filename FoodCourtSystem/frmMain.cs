using FoodCourtSystem.Model;
using FoodCourtSystem.Reports;
using FoodCourtSystem.View;
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

namespace FoodCourtSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        static frmMain _obj;
        public static frmMain Instance
        {
            get { if (_obj == null) { _obj = new frmMain(); } return _obj; }
        }

        public void AddControls(Form f)
        {
            Centerpanel.Controls.Clear();

            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            Centerpanel.Controls.Add(f);
            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            if (guna2MessageDialog1.Show("Do you really want to exit?", "Confirm") == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
            
        }

        

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
            lblRole.Text = MainClass.ROLE;
            _obj = this;
            AddControls(new frmHome());
            btnHome.Checked = true;
            if(MainClass.ROLE == "Admin" || MainClass.ROLE == "Manager")
            {
                btnSetting.Enabled = true;
                btnSetting.Visible = true;
            }
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new frmHome());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (MainClass.ROLE == "Admin" || MainClass.ROLE == "Manager")
            {
                AddControls(new formCategoryView());
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Access to the requested resource is not authorized!","TFC");
                btnHome.Checked = true;
            }
            
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            if (MainClass.ROLE == "Admin" || MainClass.ROLE == "Manager")
            {
                AddControls(new frmTableView());
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Access to the requested resource is not authorized!", "TFC");
                btnHome.Checked = true;
            };
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            if (MainClass.ROLE == "Admin" || MainClass.ROLE == "Manager")
            {
                AddControls(new frmStaffView());
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Access to the requested resource is not authorized!", "TFC");
                btnHome.Checked = true;
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (MainClass.ROLE == "Admin" || MainClass.ROLE == "Manager")
            {
                AddControls(new frmProductView());
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Access to the requested resource is not authorized!", "TFC");
                btnHome.Checked = true;
            }
            
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            frmPOS frm = new frmPOS();
            frm.Show();
            
        }

        private void btnKitchen_Click(object sender, EventArgs e)
        {
            AddControls(new frmKitchenView());
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            string qry1 = @"select * from products";
            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            frmPrint frm = new frmPrint();
            MainClass.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            guna2MessageDialog1.Show("Please Wait!!\n Menu list is loading...!", "TFC");
            rptMenu cr = new rptMenu();
            cr.SetDataSource(dt);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show();

           
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmsetting frm = new frmsetting();
            frm.Show(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginFRM frm = new LoginFRM();
            frm.Show();
        }
    }
}
