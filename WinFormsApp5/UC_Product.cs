using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class UC_Product : UserControl
    {
        public UC_Product()
        {
            InitializeComponent();
        }
        public Image picturebox
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        public string Labeltxt { get => lbl_Valyuta.Text; set => lbl_Valyuta.Text = value; }
        public string ProductCount { get => checkBox1.Text; set => checkBox1.Text = value; }
        public string Price { get => lbl_Price.Text; set => lbl_Price.Text = value; }
        public bool Checked { get => checkBox1.Checked; set => checkBox1.Checked = value; }
    }
}
