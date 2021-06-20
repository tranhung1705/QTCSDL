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

                // 

                /* khi bắt đầu mở form, chưa có dữ liệu về HÓA ĐƠN nên ko thể lấy dữ liệu về HD CHI TIẾT
                 * Nhớ: 1 HÓA ĐƠN có nhiều HÓA ĐƠN CHI TIẾT
                 * đoạn code này chỉ chạy khi chọn mã hóa đơn ở mục tìm kiếm
                 * 
                
                
                */


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
                for (int i = 0; i < iCout; i++)
                {
                 if (DataGridView1.Rows[i].Cells[0].Value.ToString() == cbTenH.ToString())
                    {
                        DataGridView1.Rows[i].Cells[3].Value = iSoLuong;
                        DataGridView1.Rows[i].Cells[3].Value = iSoLuong * iDonGia;
                        ktra = 1;
                    }
                }
                if (ktra == 0)
                {
                    DataGridView1.Rows.Add(cbTenH.SelectedValue, cbTenH, iDonGia, iSoLuong, iThanhtien);
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
            string sNgayNhap = daNgaynhap.Value.ToString("yy-MM-dd");
            string sGioNhap = daGionhap.Value.ToString("h:mm:ss");
            string sMaCungCap = cbMaCC.Text;
            string sTongtien = txtTongtien.Text;
            int iSoLuong = Convert.ToInt16(txtSoluong.Text);

            string sQuery = " insert into HOADON_NHAP(MaHDN,NgayNhap,GioNhap,MaCC,Tongtien) values(@MaHDN, @NgayNhap, @GioNhap, @MaCC, @Tongtien)";
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
            catch(Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!");
            }
            int iCount = DataGridView1.Rows.Count;
            for (int i = 0; i < iCount; i++)
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
                catch(Exception)
            {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!");
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

            string sQuery = "Update HOADON_NHAP set NgayNhap = @NgayNhap, GioNhap = @GioNhap, MaCungCap = @MaCC, Tongtien = @Tongtien," + "where MaHD = @MaHD";
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
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!");
            }
             int iCount = DataGridView1.Rows.Count;
             for (int i = 0; i < iCount; i++)
             {
                 string sQuery1 = "Update HDNHAP_CHI_TIET set MaH = @MaH, SoLuongNhap = @SoLuongNhap, Thanhtien = @Thanhtien," + "where MaHD = @MaHD";
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
                 catch (Exception)
                 {
                     MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật!");
                 }
                 con.Close();

             }

        }
        
    }

}

