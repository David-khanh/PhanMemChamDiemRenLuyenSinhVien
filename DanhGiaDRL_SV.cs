using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DanhGiaDiemRL
{
    public partial class DanhGiaDRL_SV : Form
    {
        public DanhGiaDRL_SV()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }       
        public int MaSV { get; set; }
        DataClasses1DataContext data = new DataClasses1DataContext();
        private void DanhGiaDRL_SV_Load(object sender, EventArgs e)
        {
            Txtmssv.Text = this.MaSV.ToString();
            Txtmaphieucham.Enabled = false;
            date_ngaylap.Enabled = false;

            var quyry = from a in data.TieuChis

                        select new
                        {
                            Mã_Tiêu_Chí = a.maTieuChi,
                            Tên_Tiêu_Chí = a.tenTieuChi,
                            Điểm_Tối_Đa = a.diemToiDa,
                        };
            dgvtieuchi.DataSource = quyry.ToList();
            dgvtieuchi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }




        private void doimatkhau_Click(object sender, EventArgs e)
        {
            Frmdoimatkhau doimatkhau = new Frmdoimatkhau();
            doimatkhau.ShowDialog();
        }

        private void Btntaophieu_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuCham kh = new PhieuCham();

                kh.ngayLap = DateTime.Now;
                kh.nienKhoa = txt_nienkhoa.Text;
                kh.hocKi = cbo_hocki.Text;
                data.PhieuChams.InsertOnSubmit(kh);
                data.SubmitChanges();

                MessageBox.Show("Tạo phiếu chấm thành công");

                Txtmaphieucham.Text = kh.maPhieuCham.ToString();

                ChamDiemRL cd = new ChamDiemRL();
                cd.maSV = Convert.ToInt32(Txtmssv.Text);
                cd.maPhieuCham = Convert.ToInt32(Txtmaphieucham.Text);
                cd.diemRL = 0;
                data.ChamDiemRLs.InsertOnSubmit(cd);
                data.SubmitChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Tạo Thất Bại");
            }
            finally
            {


            }
        }

        private void Btnxacnhan_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTieuPhieuCham kh = new ChiTieuPhieuCham();

                kh.maPhieuCham = Convert.ToInt32(Txtmaphieucham.Text.ToString());
                kh.maTieuChi = Convert.ToInt32(Txtmatieuchi.Text.ToString());
                kh.maNoiDung = Convert.ToInt32(txt_mand.Text.ToString());

                int diemToiDa = Convert.ToInt32(txt_diemtoida2.Text.ToString());
                int diemNhap = Convert.ToInt32(txt_nhapdiem.Text.ToString());
                if (diemNhap > diemToiDa)
                {
                    MessageBox.Show("Bạn đã nhập quá số điểm tối đa cho phép, vui lòng nhập lại!");
                    txt_nhapdiem.Text = "";
                    return;
                }
                else
                {

                    kh.diemRL1 = diemNhap;
                    kh.diemL2 = 0;
                    kh.diemL3 = 0;

                    data.ChiTieuPhieuChams.InsertOnSubmit(kh);
                    data.SubmitChanges();
                    var quyry = from a in data.ChamDiemRLs
                                join pc in data.ChiTieuPhieuChams on a.maPhieuCham equals pc.maPhieuCham
                                join tc in data.TieuChis on pc.maTieuChi equals tc.maTieuChi
                                join nd in data.NoiDungs on pc.maNoiDung equals nd.maNoiDung
                                where a.maSV == Convert.ToInt32(Txtmssv.Text.ToString())

                                select new
                                {
                                    Mã_Sinh_Viên = a.maSV,
                                    Tên_Tiêu_Chí = tc.tenTieuChi,
                                    Tên_Nội_Dung = nd.tenNoiDung,
                                    Điểm_Đánh_Giá = pc.diemRL1,
                                    Mã_Phiếu_Chấm = pc.maPhieuCham,
                                    Mã_Nội_Dung = nd.maNoiDung,
                                    Mã_Tiêu_Chí = tc.maTieuChi,
                                };
                    dgvdiem.DataSource = quyry.ToList();
                    dgvdiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                }

            }
            catch (Exception)
            {
                MessageBox.Show("Thất Bại");
            }
            finally
            {

            }
        }

        private void Btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                var pb1 = Txtmaphieucham.Text;
                var pb2 = Txtmatieuchi.Text;
                var pb3 = txt_mand.Text;
                ChiTieuPhieuCham edit_l = data.ChiTieuPhieuChams.Where(o => o.maPhieuCham.Equals(pb1) && o.maTieuChi.Equals(pb2) && o.maNoiDung.Equals(pb3)).FirstOrDefault();
                data.ChiTieuPhieuChams.DeleteOnSubmit(edit_l);
                data.SubmitChanges();

                MessageBox.Show("Đã xóa thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa Thất Bại !");
            }
            finally
            {
                var quyry = from a in data.ChamDiemRLs
                            join pc in data.ChiTieuPhieuChams on a.maPhieuCham equals pc.maPhieuCham
                            join tc in data.TieuChis on pc.maTieuChi equals tc.maTieuChi
                            join nd in data.NoiDungs on pc.maNoiDung equals nd.maNoiDung
                            where a.maSV == Convert.ToInt32(Txtmssv.Text.ToString())

                            select new
                            {
                                Mã_Sinh_Viên = a.maSV,
                                Tên_Tiêu_Chí = tc.tenTieuChi,
                                Tên_Nội_Dung = nd.tenNoiDung,
                                Điểm_Đánh_Giá = pc.diemRL1,
                                Mã_Phiếu_Chấm = pc.maPhieuCham,
                                Mã_Nội_Dung = nd.maNoiDung,
                                Mã_Tiêu_Chí = tc.maTieuChi,
                            };
                dgvdiem.DataSource = quyry.ToList();
                dgvdiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            }
        }

        private void Btnluudanhgia_Click(object sender, EventArgs e)
        {
            try
            {
                DataClasses1DataContext dataClasses1 = new DataClasses1DataContext();
                var pb1 = Txtmssv.Text;
                var pb2 = Txtmaphieucham.Text;
                ChamDiemRL chamDiem = data.ChamDiemRLs
                                          .Where(o => o.maPhieuCham.Equals(Convert.ToInt32(pb2)) && o.maSV.Equals(Convert.ToInt32(pb1)))
                                          .FirstOrDefault();

                var a1 = (from ass in data.ChiTieuPhieuChams
                          where ass.maTieuChi == Convert.ToInt32(Txtmatieuchi.Text.ToString())
                          select ass.diemRL1).Sum();

                var a11 = (from ass in data.TieuChis
                           where ass.maTieuChi == Convert.ToInt32(Txtmatieuchi.Text.ToString())
                           select ass.diemToiDa).FirstOrDefault();

                var a12 = (from ass in data.TieuChis
                           where ass.maTieuChi == Convert.ToInt32(Txtmatieuchi.Text.ToString())
                           select ass.maTieuChi).FirstOrDefault();

                if (a1 > a11)
                {
                    MessageBox.Show("Bạn đã nhập quá số điểm tối đa cho phép của tiêu chí mã " + a12 + ", vui lòng nhập lại!");
                    return;
                }
                else
                {
                    var a = (from ass in data.ChiTieuPhieuChams
                             where ass.maPhieuCham == Convert.ToInt32(pb2)
                             select ass.diemRL1).Sum();

                    if (chamDiem == null)
                    {
                        chamDiem = new ChamDiemRL();
                        chamDiem.maSV = Convert.ToInt32(pb1);
                        chamDiem.maPhieuCham = Convert.ToInt32(pb2);
                        data.ChamDiemRLs.InsertOnSubmit(chamDiem);
                    }

                    chamDiem.diemRL = Convert.ToInt32(a);
                    Txttongdiem.Text = chamDiem.diemRL.ToString();

                    MessageBox.Show("Lưu Thành Công");
                }

                data.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu Thất Bại! Lỗi: " + ex.Message);
            }
        }

        private void dgvtieuchi_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvdiem_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvnoidung_Click(object sender, EventArgs e)
        {

        }

        private void dgvtieuchi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvtieuchi.Rows[e.RowIndex];
            Txtmatieuchi.Text = row.Cells["Mã_Tiêu_Chí"].Value.ToString();
            Txtmatieuchi.Enabled = false;
            txt_diemtoida.Text = row.Cells["Điểm_Tối_Đa"].Value.ToString();
            txt_tentieuchi.Text = row.Cells["Tên_Tiêu_Chí"].Value.ToString();


            int maTieuChi = Convert.ToInt32(row.Cells["Mã_Tiêu_Chí"].Value);


            var quyry = from a in data.NoiDungs
                        where a.maTieuChi == maTieuChi

                        select new
                        {
                            Mã_Nội_Dung = a.maNoiDung,
                            Tên_Nội_Dung = a.tenNoiDung,
                            Điểm_Tối_Đa = a.diemToiDa,
                            Mã_Tiêu_Chí = a.maTieuChi
                        };
            dgvnoidung.DataSource = quyry.ToList();
            dgvnoidung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvdiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvdiem.Rows[e.RowIndex];
            Txtmaphieucham.Text = row.Cells["Mã_Phiếu_Chấm"].Value.ToString();
            Txtmatieuchi.Text = row.Cells["Mã_Tiêu_Chí"].Value.ToString();
            txt_mand.Text = row.Cells["Mã_Nội_Dung"].Value.ToString();
        }

        private void dgvnoidung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvnoidung.Rows[e.RowIndex];
            txt_mand.Text = row.Cells["Mã_Nội_Dung"].Value.ToString();
            txt_mand.Enabled = false;
            txt_diemtoida2.Text = row.Cells["Điểm_Tối_Đa"].Value.ToString();
            txt_tennd.Text = row.Cells["Tên_Nội_Dung"].Value.ToString();
            txt_matieuchi2.Text = row.Cells["Mã_Tiêu_Chí"].Value.ToString();
        }
    }
}
