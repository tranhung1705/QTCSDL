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
        string scon = "";
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
      
                string sQuery1 = "select MaHH, TenHH from HANGHOA";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery1, con);
                DataSet ds1 = new DataSet();
                adapter1.Fill(ds1, "HANGHOA");
                cbTenH.DataSource = ds1.Tables["HANGHOA"];
                cbTenH.ValueMember = "MaHH";
                cbTenH.DisplayMember = "TenHH";

                string sQuery2 = "select TenNCC, MaNCC from NHACUNGCAP";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sQuery2, con);
                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2, "NHACUNGCAP");
                cbMaCC.DataSource = ds2.Tables["NHACUNGCAP"];
                cbMaCC.DisplayMember = "TenNCC";
                cbMaCC.ValueMember = "MaNCC";
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

           
            string sQuery1 = "select DonGia from HANGHOA where MaHH = " +
            cbTenH.SelectedValue.ToString(); 

            SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery1, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "HANGHOA");
            txtDongia.Text = ds1.Tables["HANGHOA"].Rows[0][0].ToString();
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
           // string sGioNhap = daGionhap.Value.ToString("h:mm:ss");
            string sMaCungCap = cbMaCC.Text;
            string sTongtien = txtTongtien.Text;
            int iSoLuong = Convert.ToInt16(txtSoluong.Text);

            string sQuery = " insert into NHAP(MaHDN, NgayLapHD, MaNCC, TongTien) values(@MaHDN, @NgayLapHD, @ManCC, @TongTien)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHDN", iMaHD);
            cmd.Parameters.AddWithValue("@NgayLapHD", sNgayNhap);
           // cmd.Parameters.AddWithValue("@GioNhap", sGioNhap);
            cmd.Parameters.AddWithValue("@TongTien", sTongtien);
            cmd.Parameters.AddWithValue("@MaNCC", sMaCungCap);

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
                string sQuery1 = "insert into NHAP_CHITIET values(@MaHDN, @MaHH, @SoLuong, @ThanhTien)";
                SqlCommand cmd1 = new SqlCommand(sQuery1, con);
                cmd1.Parameters.AddWithValue("@MaHDN", iMaHD);
                cmd1.Parameters.AddWithValue("@MaHH", DataGridView1.Rows[i].Cells[0].Value);
                cmd1.Parameters.AddWithValue("@SoLuong", DataGridView1.Rows[i].Cells[3].Value);
                cmd1.Parameters.AddWithValue("@ThanhTien", DataGridView1.Rows[i].Cells[4].Value);
                /*
                string sQuery2 = "update HANGHOA set SoLuongTon = SoLuongTon + @SoLuongNhap where mah = @mah";
                SqlCommand cmd2 = new SqlCommand(sQuery2, con);
                cmd2.Parameters.AddWithValue("@SoLuongNhap", DataGridView1.Rows[i].Cells[3].Value);
                cmd2.Parameters.AddWithValue("@mah", DataGridView1.Rows[i].Cells[0].Value);
                try
                {
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    //MessageBox.Show("Thêm mới thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                */
                {
                    MessageBox.Show("Thêm mới thành công");
                }
                con.Close();
            }

        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {

            if (DataGridView1.SelectedRows.Count == 1) // ktra mot lan sua chi duoc sua 1 mat hang 
            {
                SqlConnection con = new SqlConnection(scon);
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
                }
            }
        }
                /*
                // lay sl truoc khi cap nhat 
                int slbandau = Convert.ToInt32(DataGridView1.SelectedRows[0].Cells["SoLuongNhap"].Value.ToString());
                //gan du lieu vao bien
                string sMahang = txtMaH.Text;
                string sDonGiaNhap = txtDongia.Text;
                string sSoLuongNhap = txtSoluong.Text;
                // tinh tien sau khi cap nhat  = don gia * sl nhap mới
                int tien = Convert.ToInt32(sDonGiaNhap) * Convert.ToInt32(sSoLuongNhap);
                string sMaHD = txtMaHD.Text;
                string sMaH = txtMaH.Text;
                // chuan bi cau truy van 
                string squery = "update HDNHAP_CHI_TIET set SoLuongNhap = @SoLuongNhap, Thanhtien = @Thanhtien where MaHD = @MaHD and MaH = @MaH ";
                SqlCommand cmd = new SqlCommand(squery, con);
                //thiet lap bien de biet gia tri bien 
                cmd.Parameters.AddWithValue("@MaH", sMahang);
                cmd.Parameters.AddWithValue("@SoLuongNhap", sSoLuongNhap);
                cmd.Parameters.AddWithValue("@Thanhtien", tien);
                cmd.Parameters.AddWithValue("@MaHD", sMaHD);
                try
                {
                    cmd.ExecuteNonQuery();// đẩy lệnh vào sql     
                    MessageBox.Show("Sửa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình sửa!");
                }
                // tinh tong tien 
                int ttien = (slbandau + Convert.ToInt32(sSoLuongNhap)) * Convert.ToInt32(sDonGiaNhap);
                // update textbox thanh tien 
                txtThanhtien.Text = (Convert.ToInt32(txtThanhtien.Text) + ttien).ToString();

                con.Close();
            }
        }
              */

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
                
                    string sQuery = " delete NHAP_CHITIET where MaHDN = @MaHDN";
                    string sQuery1 = " delete NHAP where MaHDN = @MaHDN";
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
            string sQuery = " select MaHDN, NgayLapHD, MaNCC, TongTien from NHAP where MaHDN = ' " + txtTimkiem.Text + "'";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            SqlDataReader ds = cmd.ExecuteReader();
            if (ds.Read() == true)
            {
                txtMaHD.Text = ds["MaHDN"].ToString();
                txtTongtien.Text = ds["TongTien"].ToString();
                daNgaynhap.Value = Convert.ToDateTime(ds["NgayLapHD"].ToString());
                //daGionhap.Value = Convert.ToDateTime(ds["GioNhap"].ToString());
            }
            else
                MessageBox.Show("Đơn hàng không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ds.Close();

            ////2. Lay du lieu tu HDNHAP hiển thị lên datagr
            string SQuery1 = "select NHAP_CHITIET.MaHH, TenHH, HANGHOA.DonGia, NHAP_CHITIET.SoLuong, ThanhTien from NHAP_CHITIET inner join HANGHOA on NHAP_CHITIET.MaHH = HANGHOA.MaHH where NHAP_CHITIET.MaHDN = @MaHDN";
            SqlCommand cmd1 = new SqlCommand(SQuery1, con);
            cmd1.Parameters.AddWithValue("@MaHDN", txtTimkiem.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataSet ts = new DataSet();
            adapter.Fill(ts, "HDCHITIET");
            int iRows = ts.Tables["HDCHITIET"].Rows.Count;
            for (int i = 0; i < iRows; i++)
            {
                DataGridView1.Rows.Add(ts.Tables["HDCHITIET"].Rows[i][0], ts.Tables["HDCHITIET"].Rows[i][1], ts.Tables["HDCHITIET"].Rows[i][2], ts.Tables["HDCHITIET"].Rows[i][3], ts.Tables["HDCHITIET"].Rows[i][4]);
            }
            con.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
            string sQuery = "select * from HANGHOA where TenHH = '" + cbTenH.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"HANGHOA");
            DataTable dt = ds.Tables["HANGHOA"];
            DataRow r = dt.Rows[0]; // lay hang dau tien trong data tble
            // hien thi tenh va dongia
            cbTenH.Text = r["TenHH"].ToString();
            txtDongia.Text = r["DonGia"].ToString();
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

            int indexOfRows = DataGridView1.CurrentCell.RowIndex;
            DataGridView1.Rows.RemoveAt(indexOfRows);
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

