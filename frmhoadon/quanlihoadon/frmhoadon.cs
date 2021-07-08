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
                cbMaCC.DisplayMember = "TenCC";
                cbMaCC.ValueMember = "MaCC";
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
            string sNgayNhap = daNgaynhap.Value.ToString("yyyy-MM-dd"); 
            string sGioNhap = daGionhap.Value.ToString("h:mm:ss");
            string sMaCungCap = cbMaCC.SelectedValue.ToString(); 
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
               // MessageBox.Show("Thêm mới thành công!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            int iCount = DataGridView1.Rows.Count;
            for (int i = 0; i < iCount - 1; i++)
            {
                //thêm mới vào hóa đơn chi tiết
                string sQuery1 = "insert into HDNHAP_CHI_TIET values(@MaHDN, @MaH, @SoLuongNhap, @Thanhtien)";
                SqlCommand cmd1 = new SqlCommand(sQuery1, con);
                cmd1.Parameters.AddWithValue("@MaHDN", iMaHD);
                cmd1.Parameters.AddWithValue("@MaH", DataGridView1.Rows[i].Cells[0].Value);
                cmd1.Parameters.AddWithValue("@SoLuongNhap", DataGridView1.Rows[i].Cells[3].Value);
                cmd1.Parameters.AddWithValue("@Thanhtien", DataGridView1.Rows[i].Cells[4].Value);
                
                //cập nhật lại số  lượng hàng tồn
                string sQuery2 = "update HANG set SoLuongTon = SoLuongTon + @SoLuongNhap where mah = @mah";
                SqlCommand cmd2 = new SqlCommand(sQuery2, con);
                cmd2.Parameters.AddWithValue("@SoLuongNhap", DataGridView1.Rows[i].Cells[3].Value);
                cmd2.Parameters.AddWithValue("@mah", DataGridView1.Rows[i].Cells[0].Value);
                //
                
                try
                {
                  
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                 
                    //MessageBox.Show("Thêm mới thành công!");
                }
                catch (Exception ex)

                {
                   // MessageBox.Show(ex.ToString());
                }
                
                 MessageBox.Show("Thêm mới thành công");
                

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
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối Database!", "Thông báo");
            }
           
            //gan du lieu vao bien
            string sMahang = cbTenH.Text;
            string sDonGiaNhap = txtDongia.Text;
            string sSoLuongNhap = txtSoluong.Text;
            string sMaCC = cbMaCC.Text;
            string sMaHDN = txtMaHD.Text;
            //
            int iMaHD = Convert.ToInt16(txtMaHD.Text);
            string sNgayNhap = daNgaynhap.Value.ToString("yyyy-MM-dd");
            string sGioNhap = daGionhap.Value.ToString("h:mm:ss");
            string sMaCungCap = cbMaCC.SelectedValue.ToString();
            string sTongtien = txtTongtien.Text;
            int iSoLuong = Convert.ToInt16(txtSoluong.Text);
            // chuan i cau truy van
            string sQuery1 = " update HOADON_NHAP set(MaHDN, NgayNhap, GioNhap, MaCC, Tongtien) values( @NgayNhap, @GioNhap, @MaCC, @Tongtien where MaHD = @MaHDN)";
            SqlCommand cmd1 = new SqlCommand(sQuery1, con);
            cmd1.Parameters.AddWithValue("@MaHDN", iMaHD);
            cmd1.Parameters.AddWithValue("@NgayNhap", sNgayNhap);
            cmd1.Parameters.AddWithValue("@GioNhap", sGioNhap);
            cmd1.Parameters.AddWithValue("@Tongtien", sTongtien);
            cmd1.Parameters.AddWithValue("@MaCC", sMaCungCap);
            // chuan bi cau truy van 
            string squery = "update HDNHAP_CHI_TIET set SoLuongNhap = @SoLuongNhap, Thanhtien = @Thanhtien where MaHD = @MaHDN and MaH = @MaH ";
            SqlCommand cmd = new SqlCommand(squery, con);
            //thiet lap bien de biet gia tri bien 
            cmd.Parameters.AddWithValue("@MaH", sMahang);
            cmd.Parameters.AddWithValue("@SoLuongNhap", sSoLuongNhap);
            cmd.Parameters.AddWithValue("@Thanhtien", ThanhTien);
            cmd.Parameters.AddWithValue("@MaHD", sMaHDN);
            try
            {
                cmd.ExecuteNonQuery();// đẩy những lệnh vào insert/ update / delete vao sql     
                //MessageBox.Show("Sửa thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Xảy ra lỗi trong quá trình sửa!", "Thông báo");
            }
            MessageBox.Show("Sửa thành công");
                             
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            {
                string sMaHDN = "";
                if (txtMaHD.Text == "")
                {

                }
                else
                    sMaHDN = txtMaHD.Text;

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
                        txtDongia.Text = "";
                        txtMaHD.Text = "";
                        txtTongtien.Text = "";
                        txtThanhtien.Text = "";
                        txtSoluong.Text = "";
                        txtTimkiem.Text = "";

                        int indexOfRows = DataGridView1.CurrentCell.RowIndex;
                        DataGridView1.Rows.RemoveAt(indexOfRows);
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
           
            DataGridView1.Rows.Clear();

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
           /*
            string sQuery2 = "update dbo.HOADON_NHAP set Tongtien = @Tongtien where MaHD = @MaHDN";
            SqlCommand cmd2 = new SqlCommand(sQuery2, con);
            cmd2.Parameters.AddWithValue("@MaHDN", txtMaHD.Text);
            cmd2.Parameters.AddWithValue("@Tongtien", txtThanhtien.Text);
         */
            if (ds.Read() == true)
            {
                txtMaHD.Text = ds["MaHDN"].ToString();
                txtTongtien.Text = ds["Tongtien"].ToString();
                daNgaynhap.Value = Convert.ToDateTime(ds["NgayNhap"].ToString());
                daGionhap.Value = Convert.ToDateTime(ds["GioNhap"].ToString());
                cbMaCC.Text = ds["MaCC"].ToString();
            }
            else
                MessageBox.Show("Đơn hàng không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ds.Close();

            ////2. Lay du lieu tu HDNHAP hiển thị lên datagr
            string SQuery1 = "select HDNHAP_CHI_TIET.MaH, TenH, HANG.DonGiaNhap, HDNHAP_CHI_TIET.SoLuongNhap, ThanhTien from HDNHAP_CHI_TIET inner join HANG on HDNHAP_CHI_TIET.MaH = HANG.MaH where HDNHAP_CHI_TIET.MaHDN = @MaHD";
            SqlCommand cmd1 = new SqlCommand(SQuery1, con);
            cmd1.Parameters.AddWithValue("@MaHD", txtTimkiem.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataSet ts = new DataSet();
            adapter.Fill(ts, "HDCHITIET");
            int iRows = ts.Tables["HDCHITIET"].Rows.Count;
            for (int i = 0; i < iRows; i++)
            {
                DataGridView1.Rows.Add(ts.Tables["HDCHITIET"].Rows[i][0], ts.Tables["HDCHITIET"].Rows[i][1], ts.Tables["HDCHITIET"].Rows[i][2], ts.Tables["HDCHITIET"].Rows[i][3], ts.Tables["HDCHITIET"].Rows[i][4]);
            }
            txtMaHD.Enabled = false;
            txtTongtien.Enabled = false;
            cbTenH.Enabled = false;
            txtThanhtien.Enabled = false;
            con.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lấy giá trị hàn, cột đổ vào ....
            cbTenH.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoluong.Text = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            SqlConnection con = new SqlConnection(scon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            //lay hang khi biet mah va truyen vao gd
            string sQuery = "select * from HANG where TenH = '" + cbTenH.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"HANG");
            DataTable dt = ds.Tables["HANG"];
            DataRow r = dt.Rows[0]; // lay hang dau tien trong data tble
            // hien thi tenh va dongia
            cbTenH.Text = r["TenH"].ToString();
            txtDongia.Text = r["DonGiaNhap"].ToString();
            con.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
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
                    for (int i = 0; i < iCout - 1; i++)
                    {
                        // MessageBox.Show(DataGridView1.Rows[i].Cells[0].ToString());
                        if (DataGridView1.Rows[i].Cells[0].Value.ToString() == cbTenH.SelectedValue.ToString())
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            cbMaCC.Text = "";
            txtSoluong.Text = "";         
            txtThanhtien.Text = "";
            cbTenH.Text = "";
            txtDongia.Text = "";
            DataGridView1.Rows.Clear();
            //int indexOfRows = DataGridView1.CurrentCell.RowIndex;
            //DataGridView1.Rows.RemoveAt(indexOfRows);
            
        }
        
    }
}

