using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Crox web browser is created by Peng-Yuan (Emily) Huang." + 
                "\nStudent ID: 904004475\nContact information: pzh0032@tigermail.auburn.edu");
        }

        private void addressTextBox_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(addressTextBox.ToString());
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(addressTextBox.ToString());
        }
    }
}
