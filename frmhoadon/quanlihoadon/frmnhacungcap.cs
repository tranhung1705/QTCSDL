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
        string sCon = "";
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
            String sQuery = "select * from NHACUNGCAP";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHACUNGCAP");
            dataGridView1.DataSource = ds.Tables["NHACUNGCAP"];
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
            String sDiachi = txtDiachi.Text;
            string sSodienthoai = txtSodienthoai.Text;
           

            String sQuery = " insert into NHACUNGCAP values(@MaNCC, @TenNCC, @DiaChi, @Sđt)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaNCC", sMaCC);
            cmd.Parameters.AddWithValue("@TenNCC", sTenCC);
            cmd.Parameters.AddWithValue("@DiaChi", sDiachi);
            cmd.Parameters.AddWithValue("@Sđt", sSodienthoai);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình thêm mới!", "Thông báo");
            }
            
            string sQuery1 = "Select * from NHACUNGCAP ";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery1, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHACUNGCAP ");
            dataGridView1.DataSource = ds.Tables["NHACUNGCAP "];
            con.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCC.Text = dataGridView1.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
            txtTenCC.Text = dataGridView1.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();
            txtDiachi.Text = dataGridView1.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            txtSodienthoai.Text = dataGridView1.Rows[e.RowIndex].Cells["Sđt"].Value.ToString();

           
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
            String sDiachi = txtDiachi.Text;
            String sSodienthoai = txtSodienthoai.Text;
           
            String sQuery = "update NHACUNGCAP set TenCC = @TenNCC, Diachi = @DiaChi, Sodienthoai= @Sđt where MaCC = @MaNCC ";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaNCC", sMaCC);
            cmd.Parameters.AddWithValue("@TenNCC", sTenCC);
            cmd.Parameters.AddWithValue("@DiaChi", sDiachi);
            cmd.Parameters.AddWithValue("@Sđt", sSodienthoai);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật!", "Thông báo");
            }
            string sQuery1 = "Select * from NHACUNGCAP";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery1, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHACUNGCAP");
            dataGridView1.DataSource = ds.Tables["NHACUNGCAP"];

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
                String sQuery = "  delete NHACUNGCAP where MaCC = @MaNCC";
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
                string sQuery1 = "Select * from HANGHOA";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery1, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "HANGHOA");
                dataGridView1.DataSource = ds.Tables["HANGHOA"];
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

            String sQuery = "Select * from NHACUNGCAP where TenCC like N'%" + txtTimkiem.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds, "NHACUNGCAP");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            dataGridView1.DataSource = ds.Tables["NHACUNGCAP"];

            con.Close();

        }

                
    }
}
