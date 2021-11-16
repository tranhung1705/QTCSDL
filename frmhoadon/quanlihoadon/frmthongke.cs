using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quanlihoadon
{
    public partial class frmthongke : Form
    {
        string sCon = "";
        public frmthongke()
        {
            InitializeComponent();
        }

        private void frmthongke_Load(object sender, EventArgs e)
        {

        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            string sQuery = "select TenHH,TenNCC, SUM(SoLuong)SoLuongNhap, SUM(ThanhTien)TongTien from HANGHOA join NHAP_CHITIET on HANGHOA.MaHH = NHAP_CHITIET.MaHH join NHAP on NHAP.MaHDN = NHAP_CHITIET.MaHDN join NHACUNGCAP on NHACUNGCAP.MaNCC = NHAP.MaNCC where NgayLapHD between @from and @to group by TenHH, TenNCC ";
            string sFrom = date1.Value.ToString("yyyy-MM-dd");
            string sTo = date2.Value.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@from", sFrom);
            cmd.Parameters.AddWithValue("@to", sTo);
            DataTable TK = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(TK);
            dataGridView1.DataSource = TK;
            if (TK.Rows.Count > 0)
            {
            txtTong.Text = (Convert.ToInt32(TK.Compute("SUM (TongTien)", string.Empty)).ToString());
            }
            else
           
            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }
    }
}
