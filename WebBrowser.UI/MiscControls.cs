using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser.UI
{
    public partial class MiscControls : UserControl
    {
        public MiscControls()
        {
            InitializeComponent();
        }

        private Stack<string> backLinks = new Stack<string>();
        private Stack<string> forwardLinks = new Stack<string>();

        private void addressTextBox_KeyUp(object sender, KeyEventArgs e)
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

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            addressTextBox.Text = webBrowser1.Url.ToString();
            HistoryItem history = new HistoryItem();
            history.Title = webBrowser1.DocumentTitle;
            history.URL = webBrowser1.Url.ToString();
            history.Date = DateTime.Now;

            HistoryManager.AddHistoryItem(history);

            if (!backLinks.Contains(webBrowser1.Url.ToString()))
                backLinks.Push(webBrowser1.Url.ToString());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(webBrowser1.Url.ToString());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoBack();
            if(!forwardLinks.Contains(webBrowser1.Url.ToString()))
                forwardLinks.Push(webBrowser1.Url.ToString());
            if (backLinks.Count == 0)
            {
                webBrowser1.Navigate(webBrowser1.Url.ToString());
            }
            else
            {
                while (backLinks.Contains(webBrowser1.Url.ToString()))
                    backLinks.Pop();
                webBrowser1.Navigate(backLinks.Pop());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoForward();
            backLinks.Push(webBrowser1.Url.ToString());
            if (forwardLinks.Count == 0)
            {
                webBrowser1.Navigate(webBrowser1.Url.ToString());
            }
            else
            {
                while (forwardLinks.Contains(webBrowser1.Url.ToString()))
                    forwardLinks.Pop();
                webBrowser1.Navigate(forwardLinks.Pop());
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            BookmarkItem bookmark = new BookmarkItem();
            bookmark.Title = webBrowser1.DocumentTitle;
            bookmark.URL = webBrowser1.Url.ToString();

            BookmarkManager.AddBookmarkItem(bookmark);
        }
    }
}
