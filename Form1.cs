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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nava_Browser
{
    public partial class Form1 : Form
    {
        string lockscrn_setting = "off";
        string last_visited_site = "nava.welcome";
        string lockscrn_password;
        string version = "1.4.0";
        string mode = "public";
        string windows_ver = Convert.ToBase64String(Encoding.UTF8.GetBytes(Environment.OSVersion.Version.ToString()));
        string current_dir = Convert.ToBase64String(Encoding.UTF8.GetBytes(Environment.CurrentDirectory));
        string theme_name = "default";

        public Form1()
        {
            InitializeComponent();
            lockscrn_password = last_visited_site;
            SaveValues();
        }

        public void SaveValues()
        {
            string content = $"L#{lockscrn_setting}.{lockscrn_password}$D#{version}.{mode}";
            string theme_content = $"T#{theme_name}";
            string system_content = $"S#{windows_ver}.{current_dir}";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string navaBrowserPath = Path.Combine(appDataPath, "Nava Browser");
            if (!Directory.Exists(navaBrowserPath))
            {
                Directory.CreateDirectory(navaBrowserPath);
            }
            System.IO.File.WriteAllText(System.IO.Path.Combine(navaBrowserPath, "nava.log"), content);
            System.IO.File.WriteAllText(System.IO.Path.Combine(navaBrowserPath, "theme.log"), theme_content);
            System.IO.File.WriteAllText(System.IO.Path.Combine(navaBrowserPath, "system.log"), system_content);
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
            if (textBox1.Text == "nava.wjtzil")
            {
                label3.Font = new Font(label3.Font.FontFamily, 12);
                label3.Text = "WJTZIL\nNava Browser Creator/Dev";
                last_visited_site = "nava.wjtzil";
                this.Text = "About Me! - Nava Browser";
            }
            else if (textBox1.Text == "nava.welcome")
            {
                label3.Font = new Font(label3.Font.FontFamily, 20);
                label3.Text = "Welcome!";
                last_visited_site = "nava.welcome";
                this.Text = "New Tab - Nava Browser";
            }
            else if (textBox1.Text == "nava.blox/2015")
            {
                label3.Font = new Font(label3.Font.FontFamily, 12);
                label3.Text = "So retro!\nWJTZIL in GoingTo2014\n(a Roblox game that brings old Roblox)";
                last_visited_site = "nava.blox/2015";
                this.Text = "I'm so retro! - Nava Browser";
            }
            else if (textBox1.Text == "nava.404")
            {
                MessageBox.Show("Website failed to load or was blacklisted to search.", "Nava Browser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                label3.Font = new Font(label3.Font.FontFamily, 20);
                label3.Text = "Site not found!";
                last_visited_site = "nava.404";
                this.Text = "404 Page Not Found - Nava Browser";
            }
            SaveValues();  // Save after changing last_visited_site
        }

        private void lockNavaBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lockscrn_password == "")
            {
                MessageBox.Show("Password is empty.", "Nava Browser", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.Text = "Locked 🔒 - Nava Browser";
                this.ControlBox = false;
                this.ShowInTaskbar = false;
                lockscrn_setting = "on";
                lockscrn_password = last_visited_site;
                button1.Visible = false;
                textBox1.Visible = false;
                label3.Visible = false;
                menuStrip1.Visible = false;
                textBox2.Visible = true;
                button2.Visible = true;
                SaveValues();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == lockscrn_password)
            {
                this.Text = "Nava Browser";
                this.ControlBox = true;
                this.ShowInTaskbar = true;
                lockscrn_setting = "off";
                button1.Visible = true;
                textBox1.Visible = true;
                label3.Visible = true;
                menuStrip1.Visible = true;
                textBox2.Visible = false;
                button2.Visible = false;
                textBox2.Text = "";
                SaveValues();
                if (last_visited_site == "nava.wjtzil")
                {
                    this.Text = "About Me! - Nava Browser";
                }
                else if (last_visited_site == "nava.blox/2015")
                {
                    this.Text = "I'm so retro! - Nava Browser";
                }
                else
                {
                    this.Text = "New Tab - Nava Browser";
                }
            }
            else
            {
                MessageBox.Show("Incorrect password. Please try again.", "Nava Browser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void looveDiscoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
            looveDiscoToolStripMenuItem.Checked = true;
            defaultToolStripMenuItem.Checked = false;
            robloxToolStripMenuItem.Checked = false;
            menuStrip1.BackColor = Color.Transparent;
            label1.ForeColor = Color.FromArgb(255, 255, 255);
            label3.ForeColor = Color.FromArgb(255, 255, 255);
            this.BackColor = Color.FromArgb(235, 70, 159);
            pictureBox2.Visible = true;
            theme_name = "looveDisco";
            this.Icon = Properties.Resources.loovedisco1;
            SaveValues();
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.background;
            looveDiscoToolStripMenuItem.Checked = false;
            defaultToolStripMenuItem.Checked = true;
            robloxToolStripMenuItem.Checked = false;
            menuStrip1.BackColor = Color.Transparent;
            label1.ForeColor = Color.FromArgb(255, 255, 255);
            label3.ForeColor = Color.FromArgb(255, 255, 255);
            this.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox2.Visible = false;
            theme_name = "default";
            this.Icon = Properties.Resources.add;
            SaveValues();
        }

        private void robloxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
            looveDiscoToolStripMenuItem.Checked = false;
            defaultToolStripMenuItem.Checked = false;
            robloxToolStripMenuItem.Checked = true;
            menuStrip1.BackColor = Color.FromArgb(0, 116, 189);
            this.BackColor = Color.FromArgb(255, 255, 255);
            label1.ForeColor = Color.FromArgb(0, 0, 0);
            label3.ForeColor = Color.FromArgb(0, 0, 0);
            pictureBox2.Visible = false;
            theme_name = "2015_roblox";
            this.Icon = Properties.Resources._2015;
            SaveValues();
        }
    }
}