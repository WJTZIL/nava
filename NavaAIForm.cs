using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nava_Browser
{
    public partial class NavaAIForm : Form
    {
        public NavaAIForm()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "yo")
            {
                label2.Location = new Point(10, 135);
                label1.Visible = false;
                label2.Text = "Yo wsp!";
            }
            if (textBox1.Text == "Who created this browser?")
            {
                label2.Location = new Point(10, 135);
                label1.Visible = false;
                label2.Text = "Ofc it is, WJTZIL!";
            }
            else
            {
                label2.Location = new Point(10, 168);
                label1.Visible = true;
                label2.Text = "Ask me!";
            }
        }
    }
}
