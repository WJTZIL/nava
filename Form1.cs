using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace Nava_Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "d")
            {
                label3.Text = "d";
            }
            else
            {
                label3.Text = "Nothing to show up.";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 info = new Form6();
            info.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void navaAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NavaAIForm aiForm = new NavaAIForm();
            aiForm.ShowDialog();
        }
    }
}
