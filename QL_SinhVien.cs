using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DanhGiaDiemRL
{
    public partial class QL_SinhVien : Form
    {
        public QL_SinhVien()
        {
            InitializeComponent();
        }
        DataClasses1DataContext data = new DataClasses1DataContext();
        private void QL_SinhVien_Load(object sender, EventArgs e)
        {
            data = new DataClasses1DataContext();
            var quyry = from a in data.SinhViens
                        join lop in data.Lops on a.maLop equals lop.maLop

                        select new
                        {
                            Mã_Sinh_Viên = a.maSV,
                            Họ_Tên = a.hoTen,
                            Địa_Chỉ = a.diaChi,
                            Số_Điện_Thoại = a.soDienThoai,
                            Lớp = lop.tenLop,
                            Ngày_Sinh = a.ngaySinh,





                        };
            data_sv.DataSource = quyry.ToList();
            data_sv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            cbo_malop.DataSource = data.Lops;
            cbo_malop.DisplayMember = "tenLop";
            cbo_malop.ValueMember = "maLop";
            txt_masv.Text = "";
            txt_tenkh.Text = "";
            txt_diachi.Text = "";
            txt_sdt.Text = "";
            
        }

        private void data_sv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = data_sv.Rows[e.RowIndex];
            txt_masv.Text = row.Cells["Mã_Sinh_Viên"].Value.ToString();
            txt_masv.Enabled = false;
            txt_sdt.Text = row.Cells["Số_Điện_Thoại"].Value.ToString();

            txt_diachi.Text = row.Cells["Địa_Chỉ"].Value.ToString();
            txt_tenkh.Text = row.Cells["Họ_Tên"].Value.ToString();


            date_ns.Text = row.Cells["Ngày_Sinh"].Value.ToString();
            cbo_malop.Text = row.Cells["Lớp"].Value.ToString();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien kh = new SinhVien();
                kh.maSV = Convert.ToInt32(txt_masv.Text);
                kh.hoTen = txt_tenkh.Text.ToString();

                kh.diaChi = txt_diachi.Text.ToString();
                kh.soDienThoai = txt_sdt.Text.ToString();
                kh.ngaySinh = Convert.ToDateTime(date_ns.Text.ToString());

                kh.matKhau = txt_masv.Text.ToString();  

                var a = (from ass in data.Lops
                         where ass.tenLop == cbo_malop.Text
                         select ass.maLop).FirstOrDefault();
                kh.maLop = a;

                data.SinhViens.InsertOnSubmit(kh);
                data.SubmitChanges();
                var b = kh.hoTen;
                MessageBox.Show("Thêm thông tin Sinh Viên " + b.ToString() + " thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Thất Bại");
            }
            finally
            {
                var qlpb = data.SinhViens;
                data_sv.DataSource = qlpb;
                QL_SinhVien_Load(sender, e);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                var pb1 = txt_masv.Text;
                SinhVien edit_sv = data.SinhViens.Where(o => o.maSV.Equals(pb1)).FirstOrDefault();

                edit_sv.hoTen = txt_tenkh.Text.ToString();

                edit_sv.diaChi = txt_diachi.Text.ToString();
                edit_sv.soDienThoai = txt_sdt.Text.ToString();
                edit_sv.ngaySinh = Convert.ToDateTime(date_ns.Text.ToString());

                var a = (from ass in data.Lops
                         where ass.tenLop == cbo_malop.Text
                         select ass.maLop).FirstOrDefault();
                edit_sv.maLop = a;

                var n = edit_sv.hoTen;
                MessageBox.Show("Sửa thông tin sinh viên " + n.ToString() + " thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa Thông Tin Sinh Viên Thất Bại!");
            }
            finally
            {
                var qlpb = data.SinhViens;
                data_sv.DataSource = qlpb;
                data.SubmitChanges();

                QL_SinhVien_Load(sender, e);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                var pb1 = txt_masv.Text;
                SinhVien edit_sv = data.SinhViens.Where(o => o.maSV.Equals(pb1)).FirstOrDefault();
                data.SinhViens.DeleteOnSubmit(edit_sv);
                data.SubmitChanges();
                var a = edit_sv.hoTen;
                MessageBox.Show("Đã xóa thông tin sinh viên " + a.ToString() + " khỏi cơ sở dữ liệu");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa Thất Bại !");
            }
            finally
            {
                var pb3 = data.SinhViens;
                data_sv.DataSource = pb3;

                QL_SinhVien_Load(sender, e);

            }
        }

        private void btn_lm_Click(object sender, EventArgs e)
        {
            QL_SinhVien_Load(sender, e);
            txt_masv.Enabled=true;
        }
    }
}
