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
    public partial class frmhoadon : Form
    {
        string scon = "Data Source=.\\SQLEXPRESS;Initial Catalog=CUAHANG_TAPHOA;Integrated Security=True";
        int isLoad = 0;
        public frmhoadon()
        {
            InitializeComponent();
        }

        private void frmhoadon_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(scon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
      
                string sQuery1 = "select MaH, TenH from HANG";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery1, con);
                DataSet ds1 = new DataSet();
                adapter1.Fill(ds1, "HANG");
                cbTenH.DataSource = ds1.Tables["HANG"];
                cbTenH.ValueMember = "MaH";
                cbTenH.DisplayMember = "TenH";

                string sQuery2 = "select TenCC, MaCC from CUNG_CAP";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sQuery2, con);
                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2, "CUNG_CAP");
                cbMaCC.DataSource = ds2.Tables["CUNG_CAP"];
                cbMaCC.ValueMember = "TenCC";
                cbMaCC.DisplayMember = "MaCC";
                con.Close();

                isLoad = 1;
            
        }

        private void cbTenH_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void cbTenH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isLoad != 0)
            {
                SqlConnection con = new SqlConnection(scon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }

           
            string sQuery1 = "select DonGiaNhap from HANG where MaH = " +
            cbTenH.SelectedValue.ToString(); 

            SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery1, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "HANG");
            txtDongia.Text = ds1.Tables["HANG"].Rows[0][0].ToString();
            con.Close();

            }
            
           
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            if (txtSoluong.Text != "")
            {
                int iSoLuong = Convert.ToInt32(txtSoluong.Text);
                int iDonGia = Convert.ToInt32(txtDongia.Text);
                int iThanhtien = iSoLuong * iDonGia;
                txtThanhtien.Text = iThanhtien.ToString();

                int iCout = DataGridView1.Rows.Count;
                int ktra = 0;
                if (iCout > 1)
                {
                    for (int i = 0; i < iCout-1; i++)
                    {
                       // MessageBox.Show(DataGridView1.Rows[i].Cells[0].ToString());
                        if (DataGridView1.Rows[i].Cells[0].Value.ToString() == cbTenH.ToString())
                        {
                            DataGridView1.Rows[i].Cells[3].Value = iSoLuong + Convert.ToInt32(DataGridView1.Rows[i].Cells[3].Value);
                            DataGridView1.Rows[i].Cells[4].Value = Convert.ToInt32(DataGridView1.Rows[i].Cells[3].Value) * iDonGia;
                            ktra = 1;
                        }
                    }

                }
                
                if (ktra == 0)
                {
                    DataGridView1.Rows.Add(cbTenH.SelectedValue, cbTenH.Text, iDonGia, iSoLuong, iThanhtien);
                }

                long iTongtien;
                if (txtTongtien.Text == "")
                    iTongtien = 0;
                else
                    iTongtien = Convert.ToInt32(txtTongtien.Text);

                iTongtien = iTongtien + iThanhtien;
                txtTongtien.Text = iTongtien.ToString();

            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            int iMaHD = Convert.ToInt16(txtMaHD.Text);
            string sNgayNhap = daNgaynhap.Value.ToString("yyyy-MM-dd"); //kiem tra lại dinh dang nay co dung trong CSDL ko
            string sGioNhap = daGionhap.Value.ToString("h:mm:ss");
            string sMaCungCap = cbMaCC.Text;
            string sTongtien = txtTongtien.Text;
            int iSoLuong = Convert.ToInt16(txtSoluong.Text);

            string sQuery = " insert into HOADON_NHAP(MaHDN, NgayNhap, GioNhap, MaCC, Tongtien) values(@MaHDN, @NgayNhap, @GioNhap, @MaCC, @Tongtien)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHDN", iMaHD);
            cmd.Parameters.AddWithValue("@NgayNhap", sNgayNhap);
            cmd.Parameters.AddWithValue("@GioNhap", sGioNhap);
            cmd.Parameters.AddWithValue("@Tongtien", sTongtien);
            cmd.Parameters.AddWithValue("@MaCC", sMaCungCap);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            int iCount = DataGridView1.Rows.Count;
            for (int i = 0; i < iCount; i++) //check lại
            {
            string sQuery1 = "insert into HDNHAP_CHI_TIET values(@MaHDN, @MaH, @SoLuongNhap, @Thanhtien)";
            SqlCommand cmd1 = new SqlCommand(sQuery1, con);
            cmd1.Parameters.AddWithValue("@MaHDN", iMaHD);
            cmd1.Parameters.AddWithValue("@MaH", DataGridView1.Rows[i].Cells[0].Value);
            cmd1.Parameters.AddWithValue("@SoLuongNhap", DataGridView1.Rows[i].Cells[3].Value);
            cmd1.Parameters.AddWithValue("@Thanhtien", DataGridView1.Rows[i].Cells[4].Value);

            try
            {
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!");
            }
                catch(Exception ex)
            {
                    MessageBox.Show(ex.ToString());
            }
            con.Close();
            }

        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            int iMaHD = Convert.ToInt16(txtMaHD.Text);
            string sNgayNhap = daNgaynhap.Value.ToString("yy-MM-dd");
            string sGioNhap = daGionhap.Value.ToString("h:mm:ss");
            string sMaCungCap = cbMaCC.Text;
            string sTongtien = txtTongtien.Text;
            int iSoLuong = Convert.ToInt16(txtSoluong.Text);

            string sQuery = "Update HOADON_NHAP set NgayNhap = @NgayNhap, GioNhap = @GioNhap, MaCungCap = @MaCC, Tongtien = @Tongtien where MaHD = @MaHD";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHDN", iMaHD);
            cmd.Parameters.AddWithValue("@NgayNhap", sNgayNhap);
            cmd.Parameters.AddWithValue("@GioNhap", sGioNhap);
            cmd.Parameters.AddWithValue("@Tongtien", sTongtien);
            cmd.Parameters.AddWithValue("@MaCC", sMaCungCap);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
             int iCount = DataGridView1.Rows.Count;
             for (int i = 0; i < iCount; i++)
             {
                 string sQuery1 = "Update HDNHAP_CHI_TIET set MaH = @MaH, SoLuongNhap = @SoLuongNhap, Thanhtien = @Thanhtien where MaHD = @MaHD";
                 SqlCommand cmd1 = new SqlCommand(sQuery1, con);
                 cmd1.Parameters.AddWithValue("@MaHDN", iMaHD);
                 cmd1.Parameters.AddWithValue("@MaH", DataGridView1.Rows[i].Cells[0].Value);
                 cmd1.Parameters.AddWithValue("@SoLuongNhap", DataGridView1.Rows[i].Cells[3].Value);
                 cmd1.Parameters.AddWithValue("@Thanhtien", DataGridView1.Rows[i].Cells[4].Value);

                 try
                 {
                     cmd1.ExecuteNonQuery();
                     MessageBox.Show("Cập nhật thành công!");
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
                 con.Close();

             }

        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            {
                DialogResult ret = MessageBox.Show("Bạn có chắc xóa không!", "Thông báo", MessageBoxButtons.OKCancel);
                if (ret == DialogResult.OK)
                {
                    SqlConnection con = new SqlConnection(scon);
                    try
                    {
                        con.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    string sMaHDN = "";
                    string sQuery = " delete HDNHAP_CHI_TIET where MaHDN = @MaHDN";
                    string sQuery1 = " delete HOADON_NHAP where MaHDN = @MaHDN";
                    SqlCommand cmd = new SqlCommand(sQuery, con);
                    cmd.Parameters.AddWithValue("@MaHDN", sMaHDN);
                    SqlCommand cmd1 = new SqlCommand(sQuery1, con);
                    cmd1.Parameters.AddWithValue("@MaHDN", sMaHDN);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa!", "Thông báo!");
                    }
                    con.Close();

                }
            }
        }

        private void txtSoluong_TabIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void txtSoluong_TabStopChanged(object sender, EventArgs e)
        {
           
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            string sQuery = " select MaHDN, NgayNhap, GioNhap, MaCC, Tongtien from HOADON_NHAP where MaHDN = ' " + txtTimkiem.Text + "'";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            SqlDataReader ds = cmd.ExecuteReader();
            if (ds.Read() == true)
            {
                txtMaHD.Text = ds["MaHDN"].ToString();
                txtTongtien.Text = ds["Tongtien"].ToString();
                daNgaynhap.Value = Convert.ToDateTime(ds["NgayNhap"].ToString());
                daGionhap.Value = Convert.ToDateTime(ds["GioNhap"].ToString());
            }
            else
                MessageBox.Show("Đơn hàng không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ds.Close();

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaHD.Text = DataGridView1.Rows[e.RowIndex].Cells["MaHDN"].Value.ToString();
                daNgaynhap.Value = Convert.ToDateTime(DataGridView1.Rows[e.RowIndex].Cells["NgayNhap"].Value);
                daGionhap.Value = Convert.ToDateTime(DataGridView1.Rows[e.RowIndex].Cells["GioNhap"].Value);
                cbTenH.Text = DataGridView1.Rows[e.RowIndex].Cells["TenH"].Value.ToString();
                txtSoluong.Text = DataGridView1.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
                txtMaHD.Enabled = false;
            }
            catch(Exception ex)
            {

            }
           

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        
    }
}

