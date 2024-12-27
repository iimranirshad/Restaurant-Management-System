namespace FoodCourtSystem.Model
{
    partial class frmSaleByCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.sDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.eDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnreport = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date";
            // 
            // sDate
            // 
            this.sDate.Animated = true;
            this.sDate.BackColor = System.Drawing.Color.Transparent;
            this.sDate.BorderThickness = 1;
            this.sDate.Checked = true;
            this.sDate.FillColor = System.Drawing.Color.WhiteSmoke;
            this.sDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sDate.IndicateFocus = true;
            this.sDate.Location = new System.Drawing.Point(23, 80);
            this.sDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.sDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.sDate.Name = "sDate";
            this.sDate.Size = new System.Drawing.Size(130, 29);
            this.sDate.TabIndex = 2;
            this.sDate.UseTransparentBackground = true;
            this.sDate.Value = new System.DateTime(2023, 6, 14, 0, 0, 0, 0);
            // 
            // eDate
            // 
            this.eDate.Animated = true;
            this.eDate.BackColor = System.Drawing.Color.Transparent;
            this.eDate.BorderThickness = 1;
            this.eDate.Checked = true;
            this.eDate.FillColor = System.Drawing.Color.WhiteSmoke;
            this.eDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.eDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.eDate.IndicateFocus = true;
            this.eDate.Location = new System.Drawing.Point(217, 80);
            this.eDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.eDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.eDate.Name = "eDate";
            this.eDate.Size = new System.Drawing.Size(130, 29);
            this.eDate.TabIndex = 2;
            this.eDate.UseTransparentBackground = true;
            this.eDate.Value = new System.DateTime(2023, 6, 13, 18, 18, 39, 2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "End Date";
            // 
            // btnreport
            // 
            this.btnreport.Animated = true;
            this.btnreport.AutoRoundedCorners = true;
            this.btnreport.BackColor = System.Drawing.Color.Transparent;
            this.btnreport.BorderRadius = 14;
            this.btnreport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnreport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnreport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnreport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnreport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnreport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnreport.ForeColor = System.Drawing.Color.White;
            this.btnreport.IndicateFocus = true;
            this.btnreport.Location = new System.Drawing.Point(23, 126);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(80, 31);
            this.btnreport.TabIndex = 3;
            this.btnreport.Text = "Report";
            this.btnreport.UseTransparentBackground = true;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(350, 13);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 4;
            // 
            // frmSaleByCategory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(407, 183);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnreport);
            this.Controls.Add(this.eDate);
            this.Controls.Add(this.sDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSaleByCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale by Category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker sDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker eDate;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnreport;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}