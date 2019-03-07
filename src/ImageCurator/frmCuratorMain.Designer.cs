namespace ImageCurator
{
    partial class frmCuratorMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuratorMain));
            this.bottomToolstrip = new System.Windows.Forms.ToolStrip();
            this.tsRootFolderButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsRootDirectoryLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.bottomToolstrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomToolstrip
            // 
            this.bottomToolstrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomToolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRootFolderButton,
            this.toolStripSeparator1,
            this.tsRootDirectoryLabel,
            this.toolStripSeparator2,
            this.toolStripProgressBar1});
            this.bottomToolstrip.Location = new System.Drawing.Point(0, 425);
            this.bottomToolstrip.Name = "bottomToolstrip";
            this.bottomToolstrip.Size = new System.Drawing.Size(800, 25);
            this.bottomToolstrip.TabIndex = 0;
            this.bottomToolstrip.Text = "toolStrip1";
            // 
            // tsRootFolderButton
            // 
            this.tsRootFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRootFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("tsRootFolderButton.Image")));
            this.tsRootFolderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRootFolderButton.Name = "tsRootFolderButton";
            this.tsRootFolderButton.Size = new System.Drawing.Size(23, 22);
            this.tsRootFolderButton.Text = "Root Folder";
            this.tsRootFolderButton.Click += new System.EventHandler(this.tsRootFolderButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsRootDirectoryLabel
            // 
            this.tsRootDirectoryLabel.Name = "tsRootDirectoryLabel";
            this.tsRootDirectoryLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            // 
            // frmCuratorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bottomToolstrip);
            this.Name = "frmCuratorMain";
            this.Text = "Image Curator";
            this.bottomToolstrip.ResumeLayout(false);
            this.bottomToolstrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip bottomToolstrip;
        private System.Windows.Forms.ToolStripButton tsRootFolderButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tsRootDirectoryLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    }
}

