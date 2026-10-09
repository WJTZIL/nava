using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nava_Browser
{
    public partial class Form1 : Form
    {
        string version = "1.5.0";
        string mode = "public";
        string windows_ver = Convert.ToBase64String(Encoding.UTF8.GetBytes(Environment.OSVersion.Version.ToString()));
        string current_dir = Convert.ToBase64String(Encoding.UTF8.GetBytes(Environment.CurrentDirectory));
        string profile = "main";
        string main_profile_password = "main";
        string profile_display_name;
        string btn3 = "switch_btn";
        public Form1()
        {
            InitializeComponent();
            SaveValues();
            ProfileCheck();
            ProfileValueApply();
            this.Icon = Properties.Resources.nava;
        }

        public void ProfileCheck()
        {
            if (profile == "main")
            {
                profile_display_name = "Main Profile";
            }
            else if (profile == "guest")
            {
                profile_display_name = "Guest Profile";
            }
            else
            {
                profile_display_name = null;
            }
        }

        public void ProfileValueApply()
        {
            if (profile == "main")
            {
                label2.Text = "Main Profile";
                label4.Text = "main";
            }
            else if (profile == "guest")
            {
                label2.Text = "Guest Profile";
                label4.Text = "guest";
            }
        }

        public void SaveValues()
        {
            string content = $"[NAVA]\nversion = {version}\nmode = {mode}\nprofile = {profile}\n\n[ENCRYPTED]\nwindows_ver = {windows_ver}\ncurrent_dir = {current_dir}";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            System.IO.File.WriteAllText(System.IO.Path.Combine(appDataPath, "NAVA.INI"), content);
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

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "nava.test")
            {
                label3.Font = new Font(label3.Font.FontFamily, 20);
                label3.Text = "This site is used for testing.";
                this.Text = "Test Site - Nava Browser";
            }
            else if (textBox1.Text == "nava.welcome")
            {
                label3.Font = new Font(label3.Font.FontFamily, 20);
                label3.Text = "Welcome!";
                this.Text = "New Tab - Nava Browser";
            }
            else if (textBox1.Text == "nava.404")
            {
                MessageBox.Show("Website failed to load or was blacklisted to search.", "Nava Browser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                label3.Font = new Font(label3.Font.FontFamily, 20);
                label3.Text = "Site not found!";
                this.Text = "404 Page Not Found - Nava Browser";
            }
            SaveValues();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (profile == "main" && textBox2.Text == main_profile_password)
            {
                textBox2.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button3.Text = "Logout";
                btn3 = "logout";
                textBox1.Visible = true;
                button1.Visible = true;
                label3.Visible = true;
                navaToolStripMenuItem.Visible = true;
            }
            else if (profile == "guest" && textBox2.Text == "")
            {
                textBox2.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button3.Text = "Logout";
                btn3 = "logout";
                textBox1.Visible = true;
                button1.Visible = true;
                label3.Visible = true;
                navaToolStripMenuItem.Visible = true;
            }
            else
            {
                MessageBox.Show("Incorrect password!", "Nava Browser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Profile Function
        private void button3_Click(object sender, EventArgs e)
        {
            if (btn3 == "switch_btn")
            {
                if (profile == "main")
                {
                    profile = "guest";
                    ProfileCheck();
                    ProfileValueApply();
                    textBox2.Visible = false;
                }
                else if (profile == "guest")
                {
                    profile = "main";
                    ProfileCheck();
                    ProfileValueApply();
                    textBox2.Visible = true;
                }
            }
            else if (btn3 == "logout")
            {
                button3.Text = "Switch Profile";
                btn3 = "switch_btn";
                textBox2.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                textBox1.Visible = false;
                button1.Visible = false;
                label3.Visible = false;
                navaToolStripMenuItem.Visible = false;
            }
        }
    }
}