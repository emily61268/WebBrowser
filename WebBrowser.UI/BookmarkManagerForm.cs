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
    public partial class BookmarkManagerForm : Form
    {
        public BookmarkManagerForm()
        {
            InitializeComponent();
        }

        private void BookmarkManagerForm_Load(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetBookmarkItems();
            listBoxBookmarkManager.Items.Clear();

            foreach (var item in items)
            {
                listBoxBookmarkManager.Items.Add(string.Format("{0} ({1})", item.Title, item.URL));
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<BookmarkItem> items = BookmarkManager.GetBookmarkItems();
            List<BookmarkItem> resultList = new List<BookmarkItem>();
            listBoxBookmarkManager.Items.Clear();

            foreach (var item in items)
            {
                string itemString = string.Format("{0} ({1})", item.Title, item.URL);
                if (Regex.IsMatch(itemString, string.Format(@"\b{0}\b", Regex.Escape(searchTerm.Text)), RegexOptions.IgnoreCase))
                {
                    resultList.Add(item);
                }
            }

            foreach (var result in resultList)
            {
                listBoxBookmarkManager.Items.Add(string.Format("{0} ({1})", result.Title, result.URL));
            }
        }

        private void searchTerm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<BookmarkItem> items = BookmarkManager.GetBookmarkItems();
                List<BookmarkItem> resultList = new List<BookmarkItem>();
                listBoxBookmarkManager.Items.Clear();

                foreach (var item in items)
                {
                    string itemString = string.Format("{0} ({1})", item.Title, item.URL);
                    if (Regex.IsMatch(itemString, string.Format(@"\b{0}\b", Regex.Escape(searchTerm.Text)), RegexOptions.IgnoreCase))
                    {
                        resultList.Add(item);
                    }
                }

                foreach (var result in resultList)
                {
                    listBoxBookmarkManager.Items.Add(string.Format("{0} ({1})", result.Title, result.URL));
                }
            }
        }

        private void clearSearchButton_Click(object sender, EventArgs e)
        {
            List<BookmarkItem> items = BookmarkManager.GetBookmarkItems();
            listBoxBookmarkManager.Items.Clear();
            searchTerm.Text = "";

            foreach (BookmarkItem item in items)
            {
                listBoxBookmarkManager.Items.Add(string.Format("{0} ({1})", item.Title, item.URL));
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int index = listBoxBookmarkManager.SelectedIndex;

            List<BookmarkItem> items = BookmarkManager.GetBookmarkItems();
            BookmarkItem item = items.ElementAt(index);
            int id = item.ID;
            BookmarkManager.DeleteBookmarkItem(id);

            listBoxBookmarkManager.Items.Clear();

            items = BookmarkManager.GetBookmarkItems();

            foreach (BookmarkItem i in items)
            {
                listBoxBookmarkManager.Items.Add(string.Format("{0} ({1})", i.Title, i.URL));
            }
        }
    }
}
