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
        // Values
        string lockscrn_setting = "off";
        string last_visited_site = "nava.welcome";
        string lockscrn_password;

        public Form1()
        {
            InitializeComponent();
            lockscrn_password = last_visited_site;
        }

        // Functions of NavaWeb
        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "nava.wjtzil")
            {
                label3.Text = "WJTZIL\nNava Browser Creator/Dev";
                last_visited_site = "nava.wjtzil";
            }
            else
            {
                label3.Text = "Welcome!";
                last_visited_site = "nava.welcome";
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

        private void lockNavaBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lockscrn_setting = "on";
            lockscrn_password = last_visited_site;
            button1.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
            menuStrip1.Visible = false;
            textBox2.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == lockscrn_password)
            {
                lockscrn_setting = "off";
                lockscrn_password = last_visited_site;
                button1.Visible = true;
                textBox1.Visible = true;
                label3.Visible = true;
                menuStrip1.Visible = true;
                textBox2.Visible = false;
                button2.Visible = false;
            }
            else
            {
                MessageBox.Show("Incorrect password. Please try again.", "Nava Browser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
