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
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchTerm = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.clearSearchButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.clearSearchButton);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.searchTerm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1263, 130);
            this.panel1.TabIndex = 1;
            // 
            // searchTerm
            // 
            this.searchTerm.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTerm.Location = new System.Drawing.Point(21, 23);
            this.searchTerm.Name = "searchTerm";
            this.searchTerm.Size = new System.Drawing.Size(867, 39);
            this.searchTerm.TabIndex = 0;
            this.searchTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTerm_KeyUp);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(907, 21);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(116, 49);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // clearSearchButton
            // 
            this.clearSearchButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearSearchButton.Location = new System.Drawing.Point(1044, 22);
            this.clearSearchButton.Name = "clearSearchButton";
            this.clearSearchButton.Size = new System.Drawing.Size(207, 48);
            this.clearSearchButton.TabIndex = 2;
            this.clearSearchButton.Text = "Clear Search";
            this.clearSearchButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(21, 73);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(140, 45);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // BookmarkManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 809);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBoxBookmarkManager);
            this.Name = "BookmarkManagerForm";
            this.Text = "BookmarkManagerForm";
            this.Load += new System.EventHandler(this.BookmarkManagerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBookmarkManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearSearchButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTerm;
    }
}