namespace quanlihoadon
{
    partial class frmquanlichung
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLíHàngHóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíNhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLíHàngHóaToolStripMenuItem,
            this.quảnLíNhàCungCấpToolStripMenuItem,
            this.quảnLíHóaĐơnToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1047, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLíHàngHóaToolStripMenuItem
            // 
            this.quảnLíHàngHóaToolStripMenuItem.Name = "quảnLíHàngHóaToolStripMenuItem";
            this.quảnLíHàngHóaToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.quảnLíHàngHóaToolStripMenuItem.Text = "Quản lí hàng hóa";
            // 
            // quảnLíNhàCungCấpToolStripMenuItem
            // 
            this.quảnLíNhàCungCấpToolStripMenuItem.Name = "quảnLíNhàCungCấpToolStripMenuItem";
            this.quảnLíNhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.quảnLíNhàCungCấpToolStripMenuItem.Text = "Quản lí nhà cung cấp";
            // 
            // quảnLíHóaĐơnToolStripMenuItem
            // 
            this.quảnLíHóaĐơnToolStripMenuItem.Name = "quảnLíHóaĐơnToolStripMenuItem";
            this.quảnLíHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.quảnLíHóaĐơnToolStripMenuItem.Text = "Quản lí hóa đơn";
            this.quảnLíHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.quảnLíHóaĐơnToolStripMenuItem_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // frmquanlichung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 746);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmquanlichung";
            this.Text = "frmquanlichung";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLíHàngHóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíNhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
    }
}