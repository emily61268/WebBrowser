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
using System.Data.SqlTypes;


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
        private HtmlDocument document;

        //When hit enter, the web browser will navigate to the address in the address TextBox
        private void addressTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(addressTextBox.ToString());
            }
        }

        //Go button
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(addressTextBox.ToString());
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            loadLabel.Text = "Done";

            addressTextBox.Text = webBrowser1.Url.ToString();

            HistoryItem history = new HistoryItem();
            history.Title = webBrowser1.DocumentTitle;
            history.URL = webBrowser1.Url.ToString();
            history.Date = DateTime.Now;

            HistoryManager.AddHistoryItem(history);

            if (!backLinks.Contains(webBrowser1.Url.ToString()) && !webBrowser1.Url.ToString().Contains("#spf="))
            {
                backLinks.Push(addressTextBox.Text);
                goBackButton.Enabled = true;
            }

            this.document = this.webBrowser1.Document;
            this.document.MouseOver += new HtmlElementEventHandler(document_MouseOver);
            this.document.MouseLeave += new HtmlElementEventHandler(document_MouseLeave);

        }

        private void document_MouseOver(object sender, HtmlElementEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void document_MouseLeave(object sender, HtmlElementEventArgs e)
        {
            throw new NotImplementedException();
        }

        //Refresh button
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(webBrowser1.Url.ToString());
        }

        //GoBack button
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoBack();
            
            if (!forwardLinks.Contains(webBrowser1.Url.ToString()) || !forwardLinks.Peek().Contains("#spf="))
            {
                forwardLinks.Push(webBrowser1.Url.ToString());
                goForward.Enabled = true;
            }

            try
            {
                while (backLinks.Contains(webBrowser1.Url.ToString()) || backLinks.Peek().Contains("#spf="))
                    backLinks.Pop();

                if (backLinks.Count == 1)
                {
                    webBrowser1.Navigate(backLinks.Peek());
                    goBackButton.Enabled = false;
                }
                else
                {
                    if (webBrowser1.Url.ToString().Contains(backLinks.Peek()))
                    {
                        backLinks.Pop();
                    }
                    webBrowser1.Navigate(backLinks.Pop());
                }
            }
            catch (Exception)
            {
                goBackButton.Enabled = false;
            }    

        }

        //GoForward button
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoForward();
            
            if (!backLinks.Contains(webBrowser1.Url.ToString()))
            {
                backLinks.Push(webBrowser1.Url.ToString());
                goBackButton.Enabled = true;
            }

            while (forwardLinks.Contains(webBrowser1.Url.ToString()))
                forwardLinks.Pop();

            try
            {
                webBrowser1.Navigate(forwardLinks.Pop());
            }
            catch (Exception)
            {
                goForward.Enabled = false;
            }
        }

        //Add a bookmark
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            BookmarkItem bookmark = new BookmarkItem();
            bookmark.Title = webBrowser1.DocumentTitle;
            bookmark.URL = webBrowser1.Url.ToString();

            BookmarkManager.AddBookmarkItem(bookmark);
        }

        //Home button
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com");
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progressBar1.Maximum = (int)e.MaximumProgress;
            progressBar1.Value = ((int)e.CurrentProgress < 0 || (int)e.MaximumProgress < (int)e.CurrentProgress) ? (int)e.MaximumProgress : (int)e.CurrentProgress;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            loadLabel.Text = "Loading...";
        }
    }
}
