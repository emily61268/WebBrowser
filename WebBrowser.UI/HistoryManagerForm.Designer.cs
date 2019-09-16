namespace WebBrowser.UI
{
    partial class HistoryManagerForm
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
            this.listBoxHistoryManager = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.deleteHistoryButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTerm = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxHistoryManager
            // 
            this.listBoxHistoryManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHistoryManager.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxHistoryManager.FormattingEnabled = true;
            this.listBoxHistoryManager.ItemHeight = 27;
            this.listBoxHistoryManager.Location = new System.Drawing.Point(0, 120);
            this.listBoxHistoryManager.Name = "listBoxHistoryManager";
            this.listBoxHistoryManager.Size = new System.Drawing.Size(1311, 666);
            this.listBoxHistoryManager.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.clearAllButton);
            this.panel1.Controls.Add(this.deleteHistoryButton);
            this.panel1.Controls.Add(this.clearButton);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.searchTerm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 120);
            this.panel1.TabIndex = 1;
            // 
            // clearAllButton
            // 
            this.clearAllButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearAllButton.Location = new System.Drawing.Point(176, 71);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(197, 38);
            this.clearAllButton.TabIndex = 4;
            this.clearAllButton.Text = "Clear History";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // deleteHistoryButton
            // 
            this.deleteHistoryButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteHistoryButton.Location = new System.Drawing.Point(20, 71);
            this.deleteHistoryButton.Name = "deleteHistoryButton";
            this.deleteHistoryButton.Size = new System.Drawing.Size(138, 38);
            this.deleteHistoryButton.TabIndex = 3;
            this.deleteHistoryButton.Text = "Delete";
            this.deleteHistoryButton.UseVisualStyleBackColor = true;
            this.deleteHistoryButton.Click += new System.EventHandler(this.deleteHistoryButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(1119, 21);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(167, 44);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear Search";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(996, 21);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(115, 44);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTerm
            // 
            this.searchTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.searchTerm.Location = new System.Drawing.Point(22, 23);
            this.searchTerm.Name = "searchTerm";
            this.searchTerm.Size = new System.Drawing.Size(957, 37);
            this.searchTerm.TabIndex = 0;
            this.searchTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTerm_KeyUp);
            // 
            // HistoryManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 786);
            this.Controls.Add(this.listBoxHistoryManager);
            this.Controls.Add(this.panel1);
            this.Name = "HistoryManagerForm";
            this.Text = "HistoryManagerForm";
            this.Load += new System.EventHandler(this.HistoryManagerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxHistoryManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTerm;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Button deleteHistoryButton;
    }
}