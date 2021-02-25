using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeMain.SizeInit();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ResizeMain.form1 = this;
            FormInitSize.Width = this.Width;
            FormInitSize.Height = this.Height;
            ResizeMain.SizeInit();
        }
    }
}
