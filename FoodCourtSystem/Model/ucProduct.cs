using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodCourtSystem.Model
{
   
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
        }
        public event EventHandler onSelect = null;

        public int id { get; set; }
        public string PPrice { get; set; }
        public string PCategory { get; set; }

        public string PName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }

        }

        public Image PImage
        {
            get { return txtImg.Image; }
            set { txtImg.Image = value; }

        }

        private void txtImg_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
