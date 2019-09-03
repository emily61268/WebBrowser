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
            this.SuspendLayout();
            // 
            // listBoxHistoryManager
            // 
            this.listBoxHistoryManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHistoryManager.FormattingEnabled = true;
            this.listBoxHistoryManager.ItemHeight = 20;
            this.listBoxHistoryManager.Location = new System.Drawing.Point(0, 0);
            this.listBoxHistoryManager.Name = "listBoxHistoryManager";
            this.listBoxHistoryManager.Size = new System.Drawing.Size(1240, 786);
            this.listBoxHistoryManager.TabIndex = 0;
            // 
            // HistoryManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 786);
            this.Controls.Add(this.listBoxHistoryManager);
            this.Name = "HistoryManagerForm";
            this.Text = "HistoryManagerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxHistoryManager;
    }
}