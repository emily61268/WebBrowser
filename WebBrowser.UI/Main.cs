using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser.UI
{
    public partial class Main : Form
    {
        public Main()
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.T))
            {
                MiscControls newControls = new MiscControls();
                newControls.Dock = DockStyle.Fill;
                TabPage newPage = new TabPage("New Tab");
                newPage.Controls.Add(newControls);
                this.tab1.TabPages.Add(newPage);

            }

            if (e.Control && (e.KeyCode == Keys.W))
            {
                this.tab1.TabPages.RemoveAt(this.tab1.SelectedIndex);
            }
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MiscControls newControls = new MiscControls();
            newControls.Dock = DockStyle.Fill;
            TabPage newPage = new TabPage("New Tab");
            newPage.Controls.Add(newControls);
            this.tab1.TabPages.Add(newPage);
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tab1.TabPages.RemoveAt(this.tab1.SelectedIndex);
        }

        private void manageHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryManagerForm historyManagerForm = new HistoryManagerForm();
            historyManagerForm.ShowDialog();
        }

        private void manageBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookmarkManagerForm bookmarkManagerForm = new BookmarkManagerForm();
            bookmarkManagerForm.ShowDialog();
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<HistoryItem> items = HistoryManager.GetHistoryItems();

            foreach (var item in items)
            {
                DateTime time = item.Date;
                int id = item.ID;
                HistoryManager.DeleteHistoryItem(id, time);
            }
        }
    }
}
