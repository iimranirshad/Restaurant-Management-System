using CrystalDecisions.Web;
using FoodCourtSystem.Model;
using FoodCourtSystem.Reports;
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
    public partial class frmKitchenView : Form
    {
        public frmKitchenView()
        {
            InitializeComponent();
            
            
        }
        int tag = 0;
        private void frmKitchenView_Load(object sender, EventArgs e)
        {
            
            GetOrders();
        }
        private void GetOrders()
        {
            flowLayoutPanel1.Controls.Clear();
            string qry1 = @"select * from tblMain where status = 'Pending'";
            SqlCommand cmd = new SqlCommand(qry1,MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            
            if (dt.Rows.Count <= 0)
            {
                FlowLayoutPanel p3 = new FlowLayoutPanel();
                p3 = new FlowLayoutPanel();
                p3.AutoSize = true;
                p3.Width = 100;
                p3.Height = 100;
                p3.BorderStyle = BorderStyle.FixedSingle;
                p3.FlowDirection = FlowDirection.LeftToRight;
                p3.Margin = new Padding(450,250,350,350);
                Label lb15 = new Label();
                lb15.ForeColor = Color.DarkRed;
                lb15.Margin = new Padding(10, 5, 3, 10);
                lb15.AutoSize = true;
                lb15.Visible = true;
                lb15.TextAlign = ContentAlignment.BottomCenter;
                lb15.Text = "Nothing left in Kitchen..!";
                p3.Controls.Add(lb15);
                flowLayoutPanel1.Controls.Add(p3);


                return;

            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    FlowLayoutPanel p1;
                    p1 = new FlowLayoutPanel();
                    p1.AutoSize = true;
                    p1.Width = 230;
                    p1.Height = 350;
                    p1.FlowDirection = FlowDirection.TopDown;
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Margin = new Padding(10, 10, 10, 10);


                    FlowLayoutPanel p2 = new FlowLayoutPanel();
                    p2.BackColor = Color.FromArgb(50, 55, 89);
                    p2.AutoSize = true;
                    p2.Width = 230;
                    p2.Height = 225;
                    p2.FlowDirection = FlowDirection.TopDown;
                    p2.Margin = new Padding(0, 0, 0, 0);

                    Label lb1 = new Label();
                    lb1.ForeColor = Color.White;
                    lb1.Margin = new Padding(10, 10, 3, 0);
                    lb1.AutoSize = true;

                    Label lb2 = new Label();
                    lb2.ForeColor = Color.White;
                    lb2.Margin = new Padding(10, 5, 3, 0);
                    lb2.AutoSize = true;

                    Label lb3 = new Label();
                    lb3.Margin = new Padding(10, 5, 3, 0);
                    lb3.AutoSize = true;
                    lb3.ForeColor = Color.White;

                    Label lb4 = new Label();
                    lb4.ForeColor = Color.White;
                    lb4.Margin = new Padding(10, 5, 3, 0);
                    lb4.AutoSize = true;

                    Label lb11 = new Label();
                    lb11.ForeColor = Color.White;
                    lb11.Margin = new Padding(10, 5, 3, 10);
                    lb11.AutoSize = true;


                    lb1.Text = "Table : " + dt.Rows[i]["TableName"].ToString();
                    lb2.Text = "Waiter Name : " + dt.Rows[i]["WiaterName"].ToString();
                    lb3.Text = "Order Time : " + dt.Rows[i]["aTime"].ToString();
                    lb4.Text = "Order type : " + dt.Rows[i]["orderType"].ToString();
                    lb11.Text = "Customer Name : " + dt.Rows[i]["CustName"].ToString();
                    

                    p2.Controls.Add(lb1);
                    p2.Controls.Add(lb2);
                    p2.Controls.Add(lb3);
                    p2.Controls.Add(lb4);
                    p2.Controls.Add(lb11);

                    p1.Controls.Add(p2);

                    int mid = 0;
                    mid = Convert.ToInt32(dt.Rows[i]["MainId"].ToString());
                    string qry2 = @"select * from tblMain m 
                        inner join tblDetails d on m.MainId = d.MainID
                        inner join products p on p.pID = d.proID
                        where m.MainId = " + mid + " ";

                    SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(dt2);


                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        Label lb5 = new Label();
                        lb5.ForeColor = Color.Black;
                        lb5.Margin = new Padding(10, 5, 3, 0);
                        lb5.AutoSize = true;

                        int no = j + 1;
                        lb5.Text = "" + no + " " + dt2.Rows[j]["pName"].ToString() + " " + dt2.Rows[j]["qty"].ToString();
                        lb5.Visible = true;
                        p1.Controls.Add(lb5);
                    }
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.AutoRoundedCorners = true;
                    b.Size = new Size(100, 35);
                    b.FillColor = Color.FromArgb(241, 85, 126);
                    b.Margin = new Padding(30, 5, 3, 10);
                    b.Text = "Complete";
                    b.Tag = dt.Rows[i]["MainID"].ToString();
                    b.Click += new EventHandler(b_click);
                    p1.Controls.Add(b);
                    //Guna.UI2.WinForms.Guna2Button b1 = new Guna.UI2.WinForms.Guna2Button();
                    //b1.AutoRoundedCorners = true;
                    //b1.Size = new Size(100, 35);
                    //b1.FillColor = Color.FromArgb(241, 85, 126);
                    //b1.Margin = new Padding(30, 5, 3, 10);
                    //b1.Text = "Print";
                    //tag = Convert.ToInt32(dt.Rows[i]["MainID"].ToString());   //storing the id
                    //b1.Click += new EventHandler(b_click1);
                    //p1.Controls.Add(b1);

                    flowLayoutPanel1.Controls.Add(p1);

                }
            }
            
           


        }

        //private void b_click1(object sender, EventArgs e)
        //{
            
        //    string qry2 = @"select * from tblMain m inner join 
        //                      tblDetails d on d.MainID = m.MainId
        //                        inner join products p on p.pID = d.proID
        //                        where m.MainId = @mid ";
        //    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
        //    SqlCommand cmd = new SqlCommand(qry2, MainClass.con);
        //    cmd.Parameters.AddWithValue("@mid", tag);
        //    frmPrint frm = new frmPrint();

        //    DataTable dt = new DataTable();

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);

        //    KOT cr = new KOT();

        //    cr.SetDataSource(dt);
        //    frm.crystalReportViewer1.ReportSource = cr;
        //    frm.crystalReportViewer1.Refresh();
        //    frm.Show();
        //}

        private void b_click(object sender, EventArgs e)
        {
           int id = Convert.ToInt32((sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString());

            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

            if(guna2MessageDialog1.Show("Are you sure to Complete Order..?")==DialogResult.Yes)
            {
                string qry = @"update tblMain set status = 'Complete' where MainId = @ID";
                Hashtable ht = new Hashtable();
                ht.Add("@ID", id);

                if(MainClass.SQl(qry,ht)>0)
                {
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Saved Successfully");

                }
                GetOrders();
            }
        }
    }
}
