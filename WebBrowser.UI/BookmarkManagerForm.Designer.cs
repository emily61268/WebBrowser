namespace WebBrowser.UI
{
    partial class BookmarkManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxBookmarkManager = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxBookmarkManager
            // 
            this.listBoxBookmarkManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxBookmarkManager.FormattingEnabled = true;
            this.listBoxBookmarkManager.ItemHeight = 20;
            this.listBoxBookmarkManager.Location = new System.Drawing.Point(0, 0);
            this.listBoxBookmarkManager.Name = "listBoxBookmarkManager";
            this.listBoxBookmarkManager.Size = new System.Drawing.Size(1263, 809);
            this.listBoxBookmarkManager.TabIndex = 0;
            // 
            // BookmarkManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 809);
            this.Controls.Add(this.listBoxBookmarkManager);
            this.Name = "BookmarkManagerForm";
            this.Text = "BookmarkManagerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBookmarkManager;
    }
}