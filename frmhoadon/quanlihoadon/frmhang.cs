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
        string sCon = "";
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
            string sQuery = " select * from HANGHOA ";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"HANGHOA");
            dataGridView1.DataSource = ds.Tables["HANGHOA"];
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
            string sMaH = txtMaH.Text;
            string sTenH = txtTenH.Text;
            string sDonVi = txtDonVi.Text;
            string sDonGiaNhap = txtDongia.Text;
           // string sDonGiaBan = txtDongiaban.Text;

            string sQuery = "insert into HANG values(@MaHH, @TenHH, @DonVi, @DonGia)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHH", sMaH);
            cmd.Parameters.AddWithValue("@TenHH", sTenH);
            cmd.Parameters.AddWithValue("@DonVi", sDonVi);
            cmd.Parameters.AddWithValue("@DonGia", sDonGiaNhap);
           // cmd.Parameters.AddWithValue("@DonGiaBan", sDonGiaBan);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!");
            }
            string sQuery1 = "Select * from HANGHOA";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery1, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HANGHOA");
            dataGridView1.DataSource = ds.Tables["HANGHOA"];
            con.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaH.Text = dataGridView1.Rows[e.RowIndex].Cells["MaHH"].Value.ToString();
            txtTenH.Text = dataGridView1.Rows[e.RowIndex].Cells["TenHH"].Value.ToString();
            txtDonVi.Text = dataGridView1.Rows[e.RowIndex].Cells["DonVi"].Value.ToString();
            txtDongia.Text = dataGridView1.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
           // txtDongiaban.Text = dataGridView1.Rows[e.RowIndex].Cells["DonGiaBan"].Value.ToString();

            txtMaH.Enabled = false;
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
            string sMaH = txtMaH.Text;
            string sTenH = txtTenH.Text;
            string sDonVi = txtDonVi.Text;
            string sDonGiaNhap = txtDongia.Text;
           // string sDonGiaBan = txtDongiaban.Text;

            string sQuery = "update HANGHOA set TenH = @TenHH, DonVi =@DonVi, " +
                             "DonGiaNhap=@DonGia where MaH=@MaHH";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHH", sMaH);
            cmd.Parameters.AddWithValue("@TenHH", sTenH);
            cmd.Parameters.AddWithValue("@DonVi", sDonVi);
            cmd.Parameters.AddWithValue("@DonGia", sDonGiaNhap);
           // cmd.Parameters.AddWithValue("@DonGiaBan", sDonGiaBan);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật!");
            }
            string sQuery1 = "Select * from HANGHOA";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery1, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HANGHOA");
            dataGridView1.DataSource = ds.Tables["HANGHOA"];
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
                string sMaH = txtMaH.Text;

                string sQuery = "delete HANGHOA where MaH= @MaHH";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@MaHH", sMaH);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình xóa!");
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

                String sQuery = "Select * from HANGHOA where TenH like N'%" + txtTimkiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                DataSet ds = new DataSet();
                try
                {
                    adapter.Fill(ds, "HANGHOA");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                dataGridView1.DataSource = ds.Tables["HANGHOA"];
                con.Close();
            }

        }

        private void txtSoluongton_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
