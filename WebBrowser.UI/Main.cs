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
        public static int index = 0;
        MiscControls newControls;
        public Main()
        {
            InitializeComponent();
            this.miscControls1.ParentForm = this;
            this.miscControls2.ParentForm = this;
        }

        private int tabNumber = 1;

        private void exitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Qrox web browser is created by Peng-Yuan (Emily) Huang." + 
                "\nStudent ID: 904004475\nContact information: pzh0032@tigermail.auburn.edu");
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.T))
            {
                newControls = new MiscControls();
                newControls.Dock = DockStyle.Fill;
                this.newControls.ParentForm = this;
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
            newControls = new MiscControls();
            newControls.Dock = DockStyle.Fill;
            this.newControls.ParentForm = this;
            TabPage newPage = new TabPage("New Tab " + tabNumber.ToString());
            newPage.Controls.Add(newControls);
            this.tab1.TabPages.Add(newPage);
            tabNumber++;
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

        private void tab1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == this.tab1.TabCount - 1)
            {
                e.Graphics.DrawString("+", e.Font, Brushes.Red, e.Bounds.Right - 15, e.Bounds.Top + 4);
                this.tab1.Padding = new Point(20, 3);
            }
            else
            {
                e.Graphics.DrawString("x", e.Font, Brushes.Red, e.Bounds.Right - 15, e.Bounds.Top + 4);
                e.Graphics.DrawString(this.tab1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
                e.DrawFocusRectangle();
            }
        }

        private void tab1_MouseDown(object sender, MouseEventArgs e)
        {
            //Add new tab or delete a tab
            var lastIndex = this.tab1.TabCount - 1;
            if (this.tab1.GetTabRect(lastIndex).Contains(e.Location))
            {
                newControls = new MiscControls();
                newControls.Dock = DockStyle.Fill;
                this.newControls.ParentForm = this;
                TabPage newPage = new TabPage("New Tab " + tabNumber.ToString());
                newPage.Controls.Add(newControls);
                this.tab1.TabPages.Add(newPage);
                //this.tab1.TabPages.Insert(lastIndex, "New Tab");
                this.tab1.SelectedIndex = lastIndex;
                tabNumber++;
            }
            else
            {
                for (int i = 0; i < this.tab1.TabPages.Count; i++)
                {
                    Rectangle r = tab1.GetTabRect(i);
                    //Getting the position of the "x" mark.
                    Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                    if (closeButton.Contains(e.Location))
                    {
                        this.tab1.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }

            //Drag and drop tabs
            //Store clicked tab
            TabControl tc = (TabControl)sender;
            int hover_index = this.getHoverTabIndex(tc);
            if (hover_index >= 0) { tc.Tag = tc.TabPages[hover_index]; }
        }

        //Prevent selecting last tab
        private void tab1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == this.tab1.TabCount - 1)
                e.Cancel = true;
        }

        private void tab1_MouseUp(object sender, MouseEventArgs e)
        {
            //Clear stored tab
            TabControl tc = (TabControl)sender;
            tc.Tag = null;
        }

        private void tab1_MouseMove(object sender, MouseEventArgs e)
        {
            //mouse button down? tab was clicked?
            TabControl tc = (TabControl)sender;
            if ((e.Button != MouseButtons.Left) || (tc.Tag == null)) return;
            TabPage clickedTab = (TabPage)tc.Tag;
            int clicked_index = tc.TabPages.IndexOf(clickedTab);

            //start drag n drop
            tc.DoDragDrop(clickedTab, DragDropEffects.All);
        }

        private void tab1_DragOver(object sender, DragEventArgs e)
        {
            TabControl tc = (TabControl)sender;

            //a tab is draged?
            if (e.Data.GetData(typeof(TabPage)) == null) return;
            TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
            int dragTab_index = tc.TabPages.IndexOf(dragTab);

            //hover over a tab?
            int hoverTab_index = this.getHoverTabIndex(tc);
            if (hoverTab_index < 0) { e.Effect = DragDropEffects.None; return; }
            TabPage hoverTab = tc.TabPages[hoverTab_index];
            e.Effect = DragDropEffects.Move;

            //start of drag?
            if (dragTab == hoverTab) return;

            //swap dragTab & hoverTab - avoids toggeling
            Rectangle dragTabRect = tc.GetTabRect(dragTab_index);
            Rectangle hoverTabRect = tc.GetTabRect(hoverTab_index);

            if (dragTabRect.Width < hoverTabRect.Width)
            {
                Point tcLocation = tc.PointToScreen(tc.Location);

                if (dragTab_index < hoverTab_index)
                {
                    if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
                else if (dragTab_index > hoverTab_index)
                {
                    if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
            }
            else this.swapTabPages(tc, dragTab, hoverTab);

            //select new pos of dragTab
            tc.SelectedIndex = tc.TabPages.IndexOf(dragTab);
        }

        private int getHoverTabIndex(TabControl tc)
        {
            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                if (tc.GetTabRect(i).Contains(tc.PointToClient(Cursor.Position)))
                    return i;
            }
            return -1;
        }

        private void swapTabPages(TabControl tc, TabPage src, TabPage dst)
        {
            int index_src = tc.TabPages.IndexOf(src);
            int index_dst = tc.TabPages.IndexOf(dst);
            tc.TabPages[index_dst] = src;
            tc.TabPages[index_src] = dst;
            tc.Refresh();
        }
    }
}
