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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmquanlichung));
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1570, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLíHàngHóaToolStripMenuItem
            // 
            this.quảnLíHàngHóaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quảnLíHàngHóaToolStripMenuItem.Name = "quảnLíHàngHóaToolStripMenuItem";
            this.quảnLíHàngHóaToolStripMenuItem.Size = new System.Drawing.Size(170, 29);
            this.quảnLíHàngHóaToolStripMenuItem.Text = "Quản lí hàng hóa";
            this.quảnLíHàngHóaToolStripMenuItem.Click += new System.EventHandler(this.quảnLíHàngHóaToolStripMenuItem_Click);
            // 
            // quảnLíNhàCungCấpToolStripMenuItem
            // 
            this.quảnLíNhàCungCấpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quảnLíNhàCungCấpToolStripMenuItem.Name = "quảnLíNhàCungCấpToolStripMenuItem";
            this.quảnLíNhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(204, 29);
            this.quảnLíNhàCungCấpToolStripMenuItem.Text = "Quản lí nhà cung cấp";
            this.quảnLíNhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.quảnLíNhàCungCấpToolStripMenuItem_Click);
            // 
            // quảnLíHóaĐơnToolStripMenuItem
            // 
            this.quảnLíHóaĐơnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quảnLíHóaĐơnToolStripMenuItem.Name = "quảnLíHóaĐơnToolStripMenuItem";
            this.quảnLíHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(160, 29);
            this.quảnLíHóaĐơnToolStripMenuItem.Text = "Quản lí hóa đơn";
            this.quảnLíHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.quảnLíHóaĐơnToolStripMenuItem_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(225, 29);
            this.thốngKêToolStripMenuItem.Text = "Thống kê hóa đơn nhập";
            this.thốngKêToolStripMenuItem.Click += new System.EventHandler(this.thốngKêToolStripMenuItem_Click);
            // 
            // frmquanlichung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(1570, 1033);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmquanlichung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lí chung";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmquanlichung_FormClosing);
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