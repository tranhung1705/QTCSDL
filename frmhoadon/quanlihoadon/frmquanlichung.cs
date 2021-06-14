using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlihoadon
{
    public partial class frmquanlichung : Form
    {
        public frmquanlichung()
        {
            InitializeComponent();
        }

        private void quảnLíHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmhoadon hoadon = new frmhoadon();
            hoadon.MdiParent = this;
            hoadon.Show();
        }

        private void quảnLíNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmnhacungcap nhacungcap = new frmnhacungcap();
            nhacungcap.MdiParent = this;
            nhacungcap.Show();
        
        }

        private void quảnLíHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmhang hang = new frmhang();
            hang.MdiParent = this;
            hang.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmthongke thongke = new frmthongke();
            thongke.MdiParent = this;
            thongke.Show();
        }

        private void frmquanlichung_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

    }

}
