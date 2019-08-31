using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private string currentPage;

        private void addressTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(addressTextBox.ToString());
                currentPage = addressTextBox.ToString();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(addressTextBox.ToString());
            currentPage = addressTextBox.ToString();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(currentPage);
        }
    }
}
