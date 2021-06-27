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
        string sCon = "Data Source=.\\sqlExpress;Initial Catalog=CUAHANG_TAPHOA;Integrated Security=True";
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
            string sQuery = "select TenH,TenCC, SUM(SoLuongNhap)SoLuongNhap, SUM(ThanhTien)TongTien from HANG join HDNHAP_CHI_TIET on HANG.MaH = HDNHAP_CHI_TIET.MaH join HOADON_NHAP on HOADON_NHAP.MaHDN = HDNHAP_CHI_TIET.MAHDN join CUNG_CAP on CUNG_CAP.MaCC = HOADON_NHAP.MaCC where NgayNhap between @from and @to group by TenH, TenCC ";
            string sFrom = date1.Value.ToString("yyyy-MM-dd");
            string sTo = date2.Value.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@from", sFrom);
            cmd.Parameters.AddWithValue("@to", sTo);
            try
            {
                cmd.ExecuteNonQuery();
                DataTable TK = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(TK);
                dataGridView1.DataSource = TK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }
    }
}
