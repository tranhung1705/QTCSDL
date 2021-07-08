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
    public partial class frmnhacungcap : Form
    {
        string sCon = "Data Source=.\\SqlExpress;Initial Catalog=CUAHANG_TAPHOA;Integrated Security=True";
        public frmnhacungcap()
        {
            InitializeComponent();
        
        }

        private void frmnhacungcap_Load(object sender, EventArgs e)
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
            String sQuery = "select * from CUNG_CAP";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "CUNG_CAP");
            dataGridView1.DataSource = ds.Tables["CUNG_CAP"];
            con.Close();
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);

            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi trong qúa trình kết nối ");
            }
            String sMaCC = txtMaCC.Text;
            String sTenCC = txtTenCC.Text;
            String sLoaiHang = txtLoaihang.Text;
            String iTrangThai = "Co";
            if (rbnCo.Checked == true)
            {
                iTrangThai = "Khong";
            }

            String sQuery = " insert into CUNG_CAP values(@MaCC, @TenCC, @LoaiHang, @TrangThai)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaCC", sMaCC);
            cmd.Parameters.AddWithValue("@TenCC", sTenCC);
            cmd.Parameters.AddWithValue("@LoaiHang", sLoaiHang);
            cmd.Parameters.AddWithValue("@TrangThai", iTrangThai);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình thêm mới!", "Thông báo");
            }
            
            string sQuery1 = "Select * from CUNG_CAP";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery1, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "CUNG_CAP");
            dataGridView1.DataSource = ds.Tables["CUNG_CAP"];
            con.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCC.Text = dataGridView1.Rows[e.RowIndex].Cells["MaCC"].Value.ToString();
            txtTenCC.Text = dataGridView1.Rows[e.RowIndex].Cells["TenCC"].Value.ToString();
            txtLoaihang.Text = dataGridView1.Rows[e.RowIndex].Cells["LoaiHang"].Value.ToString();
            string iTrangThai = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["TrangThai"].Value);
            if (iTrangThai == "Co")
            {
                rbnCo.Checked = true;
            }
            else
            {
                rbnKhong.Checked = true;
            }
            txtMaCC.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi trong qúa trình kết nối ");
            }
            String sMaCC = txtMaCC.Text;
            String sTenCC = txtTenCC.Text;
            String sLoaiHang = txtLoaihang.Text;
            String iTrangThai = "Co";
            if (rbnCo.Checked == true)
            {
                iTrangThai = "Khong";
            }
            String sQuery = "update CUNG_CAP set TenCC = @TenCC, Loaihang = @LoaiHang, Trangthai= @TrangThai where MaCC = @MaCC ";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaCC", sMaCC);
            cmd.Parameters.AddWithValue("@TenCC", sTenCC);
            cmd.Parameters.AddWithValue("@LoaiHang", sLoaiHang);
            cmd.Parameters.AddWithValue("@TrangThai", iTrangThai);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật!", "Thông báo");
            }
            string sQuery1 = "Select * from CUNG_CAP";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery1, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "CUNG_CAP");
            dataGridView1.DataSource = ds.Tables["CUNG_CAP"];

            con.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn xóa không", "Thông báo", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection(sCon);
                try
                {
                    con.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong qúa trình kết nối ");
                }
                String sMaCC = txtMaCC.Text;
                String sQuery = "  delete CUNG_CAP where MaCC = @MaCC";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("MaCC", sMaCC);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                }
                catch (Exception)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa!", "Thông báo");
                }
                string sQuery1 = "Select * from HANG";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery1, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "HANG");
                dataGridView1.DataSource = ds.Tables["HANG"];
                con.Close();
            }

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong  trong qúa trình kết nối");
            }

            String sQuery = "Select * from CUNG_CAP where TenCC like N'%" + txtTimkiem.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds, "CUNG_CAP");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            dataGridView1.DataSource = ds.Tables["CUNG_CAP"];

            con.Close();

        }

                
    }
}
