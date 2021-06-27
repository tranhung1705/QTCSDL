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
    public partial class frmhang : Form
    {
        string sCon = "Data Source=.\\SQLEXPRESS03;Initial Catalog=CUAHANG_TAPHOA;Integrated Security=True";
        public frmhang()
        {
            InitializeComponent();
        }

        private void frmhang_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình kết nối DB");
            }
            string sQuery = " select * from HANG ";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "HANG");
            dataGridView1.DataSource = ds.Tables["HANG"];
            con.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình kết nối DB");
            }
            string sMaH = cbMaH.Text;
            string sTenH = txtTenH.Text;
            string sSoLuongTon = txtSoluongton.Text;
            string sDonGiaNhap = txtDongianhap.Text;
            string sDonGiaBan = txtDongiaban.Text;

            string sQuery = "insert into HANG values(@MaH, @TenH, @SoLuongTon, @DonGiaNhap, @DonGiaBan)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaH", sMaH);
            cmd.Parameters.AddWithValue("@TenH", sTenH);
            cmd.Parameters.AddWithValue("@SoLuongTon", sSoLuongTon);
            cmd.Parameters.AddWithValue("@DonGiaNhap", sDonGiaNhap);
            cmd.Parameters.AddWithValue("@DonGiaBan", sDonGiaBan);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!");
            }
            string sQuery1 = "Select * from HANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery1, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HANG");
            dataGridView1.DataSource = ds.Tables["HANG"];
            con.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbMaH.Text = dataGridView1.Rows[e.RowIndex].Cells["MaH"].Value.ToString();
            txtTenH.Text = dataGridView1.Rows[e.RowIndex].Cells["TenH"].Value.ToString();
            txtSoluongton.Text = dataGridView1.Rows[e.RowIndex].Cells["SoLuongTon"].Value.ToString();
            txtDongianhap.Text = dataGridView1.Rows[e.RowIndex].Cells["DonGiaNhap"].Value.ToString();
            txtDongiaban.Text = dataGridView1.Rows[e.RowIndex].Cells["DonGiaBan"].Value.ToString();

            cbMaH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình kết nối DB");
            }
            string sMaH = cbMaH.Text;
            string sTenH = txtTenH.Text;
            string sSoLuongTon = txtSoluongton.Text;
            string sDonGiaNhap = txtDongianhap.Text;
            string sDonGiaBan = txtDongiaban.Text;

            string sQuery = "update HANG set TenH = @TenH, SoLuongTon =@SoLuongTon, " +
                             "DonGiaNhap=@DonGiaNhap, DonGiaBan=@DonGiaBan where MaH=@MaH";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaH", sMaH);
            cmd.Parameters.AddWithValue("@TenH", sTenH);
            cmd.Parameters.AddWithValue("@SoLuongTon", sSoLuongTon);
            cmd.Parameters.AddWithValue("@DonGiaNhap", sDonGiaNhap);
            cmd.Parameters.AddWithValue("@DonGiaBan", sDonGiaBan);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật!");
            }
            string sQuery1 = "Select * from HANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery1, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HANG");
            dataGridView1.DataSource = ds.Tables["HANG"];
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
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình kết nối DB");
                }
                string sMaH = cbMaH.Text;

                string sQuery = "delete HANG where MaH= @MaH";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@MaH", sMaH);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình xóa!");
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
            {
                SqlConnection con = new SqlConnection(sCon);
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong qúa trình kết nối db");
                }

                String sQuery = "Select * from HANG where TenH like N'%" + txtTimkiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                DataSet ds = new DataSet();
                try
                {
                    adapter.Fill(ds, "HANG");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                dataGridView1.DataSource = ds.Tables["HANG"];
                con.Close();
            }

        }

    }
}
