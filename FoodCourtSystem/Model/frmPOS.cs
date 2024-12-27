using FoodCourtSystem.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FoodCourtSystem.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();

        }

        public int MainID = 0;
        public int driverID = 0;
        public string OrderType = "";
        public string customerName = "";
        public string customerPhone = "";
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();

            Productpanel.Controls.Clear();
            LoadProducts();

        }


        private void AddCategory()
        {
            string qry = "Select * from Category";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CategoryPanel.Controls.Clear();
            Guna.UI2.WinForms.Guna2Button b2 = new Guna.UI2.WinForms.Guna2Button();
            b2.FillColor = Color.FromArgb(50, 55, 89);
            b2.Size = new Size(134, 45);
            b2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            b2.Text = "All Categories";
            b2.CheckedState.FillColor = Color.FromArgb(241, 85, 126);
            b2.Click += new EventHandler(b_click);
            CategoryPanel.Controls.Add(b2);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(50, 55, 89);
                    b.Size = new Size(134, 45);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();
                    b.CheckedState.FillColor = Color.FromArgb(241, 85, 126);

                    //event for click
                    b.Click += new EventHandler(b_click);
                    CategoryPanel.Controls.Add(b);

                }
            }
        }

        private void b_click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            if (b.Text == "All Categories")
            {
                txtSearch.Text = "1";
                txtSearch.Text = "";
                return;
            }

            foreach (var item in Productpanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PCategory.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }

        private void AddItems(string id, string proID, string name, string cat, string price, Image pimage)
        {
            var w = new ucProduct()
            {
                PName = name,
                PPrice = price,
                PCategory = cat,
                PImage = pimage,
                id = Convert.ToInt32(proID)
            };
            Productpanel.Controls.Add(w);
            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;

                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {
                    //condition for avoid duplication in table and add 1 automatically in qty
                    if (Convert.ToInt32(item.Cells["dgvproID"].Value) == wdg.id)
                    {
                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) *
                                                        double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        GetTotal();
                        return;

                    }

                }
                //thsi will add new product
                guna2DataGridView1.Rows.Add(new object[] { 0, 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                GetTotal();
            };
        }

        //getting product from database
        private void LoadProducts()
        {
            string qry = "select * from products inner join category on catId = CategoryID where Status != 'InActive'";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);


            foreach (DataRow item in dt.Rows)
            {
                Byte[] imagearray = (byte[])item["pImage"];
                byte[] imagebytearray = imagearray;

                AddItems("0", item["pId"].ToString(), item["pName"].ToString(), item["catName"].ToString(),
                    item["pPrice"].ToString(), Image.FromStream(new MemoryStream(imagearray)));

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in Productpanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }
        private void GetTotal()
        {
            double total = 0;
            lblTotal.Text = "";
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                total += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }
            lblTotal.Text = total.ToString("N2");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            guna2DataGridView1.Rows.Clear();
            MainID = 0;
            lblTotal.Text = "0.00";

        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Delivery";

            frmAddCustomer frm = new frmAddCustomer();
            frm.mainID = MainID;
            frm.orderType = OrderType;
            MainClass.BlurBackground(frm);

            if (frm.txtName.Text != "")
            {
                driverID = frm.driverID;
                lblDriverName.Text = "Customer Name: " + frm.txtName.Text + " Phone: " + frm.txtPhone.Text + "Driver: " + frm.cbDriver.Text;
                lblDriverName.Visible = true;
                customerName = frm.txtName.Text;
                customerPhone = frm.txtPhone.Text;
            }
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Take Away";

            frmAddCustomer frm = new frmAddCustomer();
            frm.mainID = MainID;
            frm.orderType = OrderType;
            MainClass.BlurBackground(frm);

            if (frm.txtName.Text != "")
            {
                driverID = frm.driverID;
                lblDriverName.Text = "Customer Name: " + frm.txtName.Text + " Phone: " + frm.txtPhone.Text;
                lblDriverName.Visible = true;
                customerName = frm.txtName.Text;
                customerPhone = frm.txtPhone.Text;
            }
        }

        private void btnDin_Click(object sender, EventArgs e)
        {
            OrderType = "Din In";
            lblDriverName.Visible = false;
            frmTableSelect frm = new frmTableSelect();
            MainClass.BlurBackground(frm);
            if (frm.TableName != "")
            {
                lblTable.Text = frm.TableName;
                lblTable.Visible = true;

            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible = false;
            }
            frmWaiterSelect frm1 = new frmWaiterSelect();
            if (frm.waitershow)
            {

                MainClass.BlurBackground(frm1);
                if (frm1.WaiterName != "")
                {
                    lblWaiter.Text = frm1.WaiterName;
                    lblWaiter.Visible = true;

                }
                else
                {
                    lblWaiter.Text = "";
                    lblWaiter.Visible = false;
                }
            }
            else
            {
                btnDin.Checked = false;
            }
            if (frm1.customerShow)
            {
                frmAddCustomer frm2 = new frmAddCustomer();
                frm2.mainID = MainID;
                frm2.orderType = OrderType;
                MainClass.BlurBackground(frm2);

                if (frm2.txtName.Text != "")
                {
                    driverID = frm2.driverID;
                    lblDriverName.Text = "Customer Name: " + frm2.txtName.Text + " Phone: " + frm2.txtPhone.Text;
                    lblDriverName.Visible = true;
                    customerName = frm2.txtName.Text;
                    customerPhone = frm2.txtPhone.Text;
                }
            }
            else
            {
                btnDin.Checked = false;
            }


        }


        private void btnKot_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.RowCount > 0)
            {
                string qry1 = ""; //for main table
                string qry2 = ""; //for detail table

                int detailID = 0;

                if (MainID == 0)
                {
                    qry1 = @"insert into tblMain values(@aDate,@aTime,@TableName ,@WiaterName, 
                        @status, @orderType ,@total,@received,@change,@driverID,@CustName,@CustPhone);
                        Select SCOPE_IDENTITY()";
                    //the second part of query will get recent add ids

                }
                else
                {
                    qry1 = @"update tblMain  set status = @status, orderType = @orderType,total = @total,
                        received = @received,change = @change where MainId = @ID";

                }



                SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
                cmd.Parameters.AddWithValue("@aDate", Convert.ToDateTime(DateTime.Now.Date));
                cmd.Parameters.AddWithValue("@ID", MainID);
                cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
                cmd.Parameters.AddWithValue("@TableName", lblTable.Text);
                cmd.Parameters.AddWithValue("@WiaterName", lblWaiter.Text);
                cmd.Parameters.AddWithValue("@status", "Pending");
                cmd.Parameters.AddWithValue("@orderType", OrderType);
                cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));
                cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
                cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));
                cmd.Parameters.AddWithValue("@driverID", driverID);
                cmd.Parameters.AddWithValue("@CustName", customerName);
                cmd.Parameters.AddWithValue("@CustPhone", customerPhone);

                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
                {
                    detailID = Convert.ToInt32(guna2DataGridView1.Rows[i].Cells["dgvid"].Value);
                    if (detailID == 0)
                    {
                        qry2 = @" Insert into tblDetails values (@MainId,@proID,@qty,@price,@amount)";
                    }
                    else
                    {
                        qry2 = @" Update tblDetails set proID = @proID, qty = @qty, price = @price,amount = @amount
                                where detailID = @ID";
                    }
                    SqlCommand cmd1 = new SqlCommand(qry2, MainClass.con);
                    cmd1.Parameters.AddWithValue("@MainId", MainID);
                    cmd1.Parameters.AddWithValue("@ID", detailID);
                    cmd1.Parameters.AddWithValue("@proID", Convert.ToInt32(guna2DataGridView1.Rows[i].Cells["dgvproID"].Value));
                    cmd1.Parameters.AddWithValue("@qty", Convert.ToInt32(guna2DataGridView1.Rows[i].Cells["dgvQty"].Value));
                    cmd1.Parameters.AddWithValue("@price", Convert.ToDouble(guna2DataGridView1.Rows[i].Cells["dgvPrice"].Value));
                    cmd1.Parameters.AddWithValue("@amount", Convert.ToDouble(guna2DataGridView1.Rows[i].Cells["dgvAmount"].Value));
                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    cmd1.ExecuteNonQuery();
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }


                }
                MainID = 0;
                detailID = 0;
                guna2MessageDialog1.Show("Saved Successfully..!", "Order");

                guna2DataGridView1.Rows.Clear();

                lblTable.Text = "";
                lblWaiter.Text = "";
                lblTable.Visible = false;
                lblWaiter.Visible = false;
                lblTotal.Text = "0.00";
                lblDriverName.Text = "";
                btnTake.Checked = false;
                btnDelivery.Checked = false;
                btnDin.Checked = false;
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Counld not place a empty order", "TFC");
            }
            //foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            //{

            //    detailID = Convert.ToInt32(row.Cells["dgvid"].Value);

            //    if(detailID == 0)
            //    {
            //        qry2 = @" Insert into tblDetails values (@MainId,@proID,@qty,@price,@amount)";
            //    }
            //    else
            //    {
            //        qry2 = @" Update tblDetails set proID = @proID, qty = @qty, price = @price,amount = @amount
            //                    where detailID = @ID";
            //    }

            //    SqlCommand cmd1 = new SqlCommand(qry2, MainClass.con);
            //    cmd1.Parameters.AddWithValue("@ID", detailID);
            //    cmd1.Parameters.AddWithValue("@MainID", MainID);
            //    cmd1.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvproID"].Value));
            //    cmd1.Parameters.AddWithValue("@qty",Convert.ToInt32(row.Cells["dgvQty"].Value));
            //    cmd1.Parameters.AddWithValue("@price", Convert.ToDouble(row.Cells["dgvPrice"].Value));
            //    cmd1.Parameters.AddWithValue("@amount",Convert.ToDouble(row.Cells["dgvAmount"].Value));

            //    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            //    cmd1.ExecuteNonQuery();
            //    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
            //    MainID = 0;
            //    detailID = 0;
            //    guna2MessageDialog1.Show("Saved Successfully..!", "Order");

            //    guna2DataGridView1.Rows.Clear();

            //    lblTable.Text = "";
            //    lblWaiter.Text = "";
            //    lblTable.Visible = false;
            //    lblWaiter.Visible = false;
            //    lblTotal.Text = "0.00";

            //}


        }
        public int id = 0;
        public bool billclick = false;

        private void btnBill_Click(object sender, EventArgs e)
        {
            billclick = true;
            frmBillList frm = new frmBillList();
            MainClass.BlurBackground(frm);

            if (frm.IDD > 0)
            {
                id = frm.IDD;
                MainID = frm.IDD;
                LoadEnteries();
            }

        }

        private void LoadEnteries()
        {
            string qry = @"select * from tblMain m 
                inner join tblDetails d on m.MainId = d.MainID
                inner join products p on p.pID = d.proID
                where m.MainId = " + id + "";

            SqlCommand cmd2 = new SqlCommand(qry, MainClass.con);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            if (dt2.Rows.Count <= 0)
            {
                btnDin.Checked = false;
                lblTable.Visible = false;
                lblWaiter.Visible = false;
                guna2MessageDialog1.Show("Could Place an Empty Order");
                return;
            }
            else if (dt2.Rows[0]["orderType"].ToString() == "Delivery")
            {
                btnDelivery.Checked = true;
                lblWaiter.Visible = false;
                lblTable.Visible = false;
            }
            else if (dt2.Rows[0]["orderType"].ToString() == "Take away")
            {
                btnTake.Checked = true;
                lblWaiter.Visible = false;
                lblTable.Visible = false;
            }
            else if (dt2.Rows[0]["orderType"].ToString() == "Din In")
            {
                btnDin.Checked = true;
                lblTable.Visible = true;
                lblWaiter.Visible = true;
            }
            else
            {
                btnDin.Checked = false;
                btnDelivery.Checked = false;
                btnTake.Checked = false;
                lblWaiter.Visible = false;
                lblTable.Visible = false;

            }
            guna2DataGridView1.Rows.Clear();

            foreach (DataRow item in dt2.Rows)
            {
                lblTable.Text = item["TableName"].ToString();
                lblWaiter.Text = item["WiaterName"].ToString();

                string detailid = item["DetailID"].ToString();
                string proname = item["pName"].ToString();
                string proid = item["proID"].ToString();
                string qty = item["qty"].ToString();
                string price = item["price"].ToString();
                string amount = item["amount"].ToString();

                object[] obj = { 0, detailid, proid, proname, qty, price, amount };
                guna2DataGridView1.Rows.Add(obj);
            }
            GetTotal();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {

            if (guna2DataGridView1.Rows.Count > 0 && billclick == true)
            {
                frmCheckout frm = new frmCheckout();
                frm.MainID = id;
                frm.amt = Convert.ToDouble(lblTotal.Text);
                MainClass.BlurBackground(frm);

                MainID = 0;
                guna2DataGridView1.Rows.Clear();
                lblTable.Text = "";
                lblWaiter.Text = "";
                lblTable.Visible = false;
                lblWaiter.Visible = false;
                lblTotal.Text = "00";
            }
            else
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Check out only works when you click on bill List", "Check Out");
                billclick = false;
                return;
            }
        }


        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            string qry1 = ""; //for main table
            string qry2 = ""; //for detail table

            int detailID = 0;
            if (OrderType == "")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Please select Order Type", "TFC");
                return;
            }
            if (MainID == 0)
            {
                qry1 = @"insert into tblMain values(@aDate,@aTime,@TableName ,@WiaterName, 
                        @status, @orderType ,@total,@received,@change,@driverID,@CustName,@CustPhone);
                        Select SCOPE_IDENTITY()";
                //the second part of query will get recent add ids

            }
            else
            {
                qry1 = @"update tblMain  set status = @status, orderType = @orderType,total = @total,
                        received = @received,change = @change where MainId = @ID";

            }



            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@aDate", Convert.ToDateTime(DateTime.Now.Date));
            cmd.Parameters.AddWithValue("@ID", MainID);
            cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@TableName", lblTable.Text);
            cmd.Parameters.AddWithValue("@WiaterName", lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status", "Hold");
            cmd.Parameters.AddWithValue("@orderType", OrderType);
            cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@driverID", driverID);
            cmd.Parameters.AddWithValue("@CustName", customerName);
            cmd.Parameters.AddWithValue("@CustPhone", customerPhone);

            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

            for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                detailID = Convert.ToInt32(guna2DataGridView1.Rows[i].Cells["dgvid"].Value);
                if (detailID == 0)
                {
                    qry2 = @" Insert into tblDetails values (@MainId,@proID,@qty,@price,@amount)";
                }
                else
                {
                    qry2 = @" Update tblDetails set proID = @proID, qty = @qty, price = @price,amount = @amount
                                where detailID = @ID";
                }
                SqlCommand cmd1 = new SqlCommand(qry2, MainClass.con);
                cmd1.Parameters.AddWithValue("@MainId", MainID);
                cmd1.Parameters.AddWithValue("@ID", detailID);
                cmd1.Parameters.AddWithValue("@proID", Convert.ToInt32(guna2DataGridView1.Rows[i].Cells["dgvproID"].Value));
                cmd1.Parameters.AddWithValue("@qty", Convert.ToInt32(guna2DataGridView1.Rows[i].Cells["dgvQty"].Value));
                cmd1.Parameters.AddWithValue("@price", Convert.ToDouble(guna2DataGridView1.Rows[i].Cells["dgvPrice"].Value));
                cmd1.Parameters.AddWithValue("@amount", Convert.ToDouble(guna2DataGridView1.Rows[i].Cells["dgvAmount"].Value));
                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                cmd1.ExecuteNonQuery();
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }


            }
            MainID = 0;
            detailID = 0;
            guna2MessageDialog1.Show("Saved Successfully..!", "Order");

            guna2DataGridView1.Rows.Clear();

            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            lblTotal.Text = "0.00";
            lblDriverName.Text = "";
            btnTake.Checked = false;
            btnDelivery.Checked = false;
            btnDin.Checked = false;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvmin")
            {
                int currentValue = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvQty"].Value);
                int amount = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvAmount"].Value);
                if (currentValue > 1)
                { 
                    guna2DataGridView1.CurrentRow.Cells["dgvQty"].Value = currentValue - 1; 

                }
                guna2DataGridView1.CurrentRow.Cells["dgvAmount"].Value = int.Parse(guna2DataGridView1.CurrentRow.Cells["dgvQty"].Value.ToString()) * int.Parse(guna2DataGridView1.CurrentRow.Cells["dgvPrice"].Value.ToString());
            }
            if(guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                guna2DataGridView1.Rows.Remove(guna2DataGridView1.CurrentRow);
            }
            

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvadd")
            {
                int currentValue = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvQty"].Value);
                int amount = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvAmount"].Value);
                if (currentValue >= 1)
                {
                    guna2DataGridView1.CurrentRow.Cells["dgvQty"].Value = currentValue + 1;

                }
                guna2DataGridView1.CurrentRow.Cells["dgvAmount"].Value = int.Parse(guna2DataGridView1.CurrentRow.Cells["dgvQty"].Value.ToString()) * int.Parse(guna2DataGridView1.CurrentRow.Cells["dgvPrice"].Value.ToString());
            }
            GetTotal();
        }
          
    }
}
