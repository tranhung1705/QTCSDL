using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
{
    public partial class fromCalculator : Form
    {
        public fromCalculator()
        {
            InitializeComponent();
        }
          private void fromCalculator_Click(object sender, EventArgs e)
       
        {

        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            string sSo1 = txtSo1.Text;
            decimal dSo1 = Convert.ToDecimal(sSo1);
            string sSo2 = txtSo2.Text;
            decimal dSo2 = Convert.ToDecimal(sSo2);
            string sSo3 = txtSo3.Text;
            decimal dSo3 = Convert.ToDecimal(sSo3);
            decimal dKQ = dSo1 + dSo2 + dSo3;
            txtKQ.Text = dKQ.ToString();
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            string sSo1 = txtSo1.Text;
            decimal dSo1 = Convert.ToDecimal(sSo1);
            string sSo2 = txtSo2.Text;
            decimal dSo2 = Convert.ToDecimal(sSo2);
            string sSo3 = txtSo3.Text;
            decimal dSo3 = Convert.ToDecimal(sSo3);
            decimal dKQ = dSo1 - dSo3 - dSo2;
            txtKQ.Text = dKQ.ToString();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            string sSo1 = txtSo1.Text;
            int iSo1 = Int32.Parse(sSo1);
            string sSo2 = txtSo2.Text;
            int iSo2 = Int32.Parse(sSo2);
            string sSo3 = txtSo3.Text;
            int iSo3 = Int32.Parse(sSo3);
            int iKQ = iSo1 * iSo2 * iSo3;
            txtKQ.Text = iKQ.ToString();
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            string sSo1 = txtSo1.Text;
            decimal dSo1 = Convert.ToDecimal(sSo1);
            string sSo2 = txtSo2.Text;
            decimal dSo2 = Convert.ToDecimal(sSo2);
            string sSo3 = txtSo3.Text;
            decimal dSo3 = Convert.ToDecimal(sSo3);
            decimal dKQ = dSo1 / dSo2 / dSo3;
            txtKQ.Text = dKQ.ToString();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);

        }

    }

}
