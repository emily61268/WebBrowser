using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser.UI
{
    public partial class HistoryManagerForm : Form
    {
        public HistoryManagerForm()
        {
            InitializeComponent();
        }

        private void HistoryManagerForm_Load(object sender, EventArgs e)
        {
            List<HistoryItem> items = HistoryManager.GetHistoryItems();
            listBoxHistoryManager.Items.Clear();

            foreach (HistoryItem item in items)
            {
                listBoxHistoryManager.Items.Add(string.Format("[{0}] {1} ({2})", item.DateTime, item.Title, item.URL));
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<HistoryItem> items = HistoryManager.GetHistoryItems();
            List<HistoryItem> resultList = new List<HistoryItem>();
            listBoxHistoryManager.Items.Clear();

            foreach (var item in items)
            {
                string itemString = string.Format("[{0}] {1} ({2})", item.DateTime, item.Title, item.URL);
                if (Regex.IsMatch(itemString, string.Format(@"\b{0}\b", Regex.Escape(searchTerm.Text)), RegexOptions.IgnoreCase))
                {
                    resultList.Add(item);
                }
            }

            foreach (var result in resultList)
            {
                listBoxHistoryManager.Items.Add(string.Format("[{0}] {1} ({2})", result.DateTime, result.Title, result.URL));
            }
        }

        private void searchTerm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<HistoryItem> items = HistoryManager.GetHistoryItems();
                List<HistoryItem> resultList = new List<HistoryItem>();
                listBoxHistoryManager.Items.Clear();

                foreach (var item in items)
                {
                    string itemString = string.Format("[{0}] {1} ({2})", item.DateTime, item.Title, item.URL);
                    if (Regex.IsMatch(itemString, string.Format(@"\b{0}\b", Regex.Escape(searchTerm.Text)), RegexOptions.IgnoreCase))
                    {
                        resultList.Add(item);
                    }
                }

                foreach (var result in resultList)
                {
                    listBoxHistoryManager.Items.Add(string.Format("[{0}] {1} ({2})", result.DateTime, result.Title, result.URL));
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            List<HistoryItem> items = HistoryManager.GetHistoryItems();
            listBoxHistoryManager.Items.Clear();
            searchTerm.Text = "";

            foreach (HistoryItem item in items)
            {
                listBoxHistoryManager.Items.Add(string.Format("[{0}] {1} ({2})", item.DateTime, item.Title, item.URL));
            }
        }

        private void deleteHistoryButton_Click(object sender, EventArgs e)
        {
            int index = listBoxHistoryManager.SelectedIndex;

            List<HistoryItem> items = HistoryManager.GetHistoryItems();
            HistoryItem item = items.ElementAt(index);
            DateTime time = item.Date;
            int id = item.ID;
            HistoryManager.DeleteHistoryItem(id, time);

            listBoxHistoryManager.Items.Clear();

            items = HistoryManager.GetHistoryItems();

            foreach (HistoryItem i in items)
            {
                listBoxHistoryManager.Items.Add(string.Format("[{0}] {1} ({2})", i.DateTime, i.Title, i.URL));
            }
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            listBoxHistoryManager.Items.Clear();

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
