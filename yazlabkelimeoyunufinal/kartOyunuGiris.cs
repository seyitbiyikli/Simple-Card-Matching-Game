using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazlabkelimeoyunufinal
{
    public partial class kartOyunuGiris : Form
    {
        public kartOyunuGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kartOyunu3x4 f3 = new kartOyunu3x4();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _3x5 f2 = new _3x5();
            f2.Show();
        }
    }
}
