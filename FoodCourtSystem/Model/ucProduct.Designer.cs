namespace FoodCourtSystem.Model
{
    partial class ucProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProduct));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtImg = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2ShadowPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImg)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.guna2Separator1);
            this.guna2ShadowPanel1.Controls.Add(this.guna2Panel1);
            this.guna2ShadowPanel1.Controls.Add(this.txtImg);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(3, 3);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(171, 171);
            this.guna2ShadowPanel1.TabIndex = 0;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(3, 114);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(165, 10);
            this.guna2Separator1.TabIndex = 2;
            this.guna2Separator1.Click += new System.EventHandler(this.guna2Separator1_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblName);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 123);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(171, 48);
            this.guna2Panel1.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(10, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(151, 37);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Product Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // txtImg
            // 
            this.txtImg.Image = ((System.Drawing.Image)(resources.GetObject("txtImg.Image")));
            this.txtImg.ImageRotate = 0F;
            this.txtImg.Location = new System.Drawing.Point(46, 19);
            this.txtImg.Name = "txtImg";
            this.txtImg.Size = new System.Drawing.Size(81, 89);
            this.txtImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.txtImg.TabIndex = 0;
            this.txtImg.TabStop = false;
            this.txtImg.UseTransparentBackground = true;
            this.txtImg.Click += new System.EventHandler(this.txtImg_Click);
            // 
            // ucProduct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "ucProduct";
            this.Size = new System.Drawing.Size(177, 177);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox txtImg;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblName;
    }
}
