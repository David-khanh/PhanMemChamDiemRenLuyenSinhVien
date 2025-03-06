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
    public partial class DanhGiaDRL_GV : Form
    {
        public DanhGiaDRL_GV()
        {
            InitializeComponent();
        }
        DataClasses1DataContext data = new DataClasses1DataContext();
        private void DanhGiaDRL_GV_Load(object sender, EventArgs e)
        {
            var quyry = from a in data.ChamDiemRLs
                      join sv in data.SinhViens on a.maSV equals sv.maSV
                      join pc in data.PhieuChams on a.maPhieuCham equals pc.maPhieuCham
                      /*join b in data.ChiTieuPhieuChams on a.diemRL equals b.diemRL1*/
                       

                        select new
                        {
                            Mã_Sinh_Viên = a.maSV,
                            Mã_Phiếu =a.maPhieuCham,
                            Tên_Sinh_Viên = sv.hoTen,
                            Ngày_Lập = pc.ngayLap,
                            Niên_Khóa = pc.nienKhoa,
                            Học_Kì =pc.hocKi,
                            Tổng_Điểm = a.diemRL,
                        };
            data_tong.DataSource = quyry.ToList();
            data_tong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var quyry1 = from a in data.TieuChis

                        select new
                        {
                            Mã_Tiêu_Chí = a.maTieuChi,
                            Tên_Tiêu_Chí = a.tenTieuChi,
                            Điểm_Tối_Đa = a.diemToiDa,
                        };
            data_tieuchi.DataSource = quyry1.ToList();
            data_tieuchi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void data_tong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = data_tong.Rows[e.RowIndex];
            txt_masv.Text = row.Cells["Mã_Sinh_Viên"].Value.ToString();
            txt_maphieu.Text = row.Cells["Mã_Phiếu"].Value.ToString();

           

        }

        private void data_tieuchi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = data_tieuchi.Rows[e.RowIndex];
            txt_matieuchi.Text = row.Cells["Mã_Tiêu_Chí"].Value.ToString();
            txt_matieuchi.Enabled = false;
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
            data_nd.DataSource = quyry.ToList();
            data_nd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Xóa_Click(object sender, EventArgs e)
        {
            try
            {
                var pb1 = txt_maphieu.Text;
                var pb2 = txt_matieuchi.Text;
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
                            where a.maSV == Convert.ToInt32(txt_masv.Text.ToString())

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
                data_dssv.DataSource = quyry.ToList();
                data_dssv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var pb1 = txt_masv.Text;
                var pb2 = txt_maphieu.Text;
                ChamDiemRL chamDiem = data.ChamDiemRLs.Where(o => o.maPhieuCham.Equals(pb1) && o.maSV.Equals(pb2)).FirstOrDefault();

                var a1 = (from ass in data.ChiTieuPhieuChams
                          where ass.maTieuChi == Convert.ToInt32(txt_matieuchi.Text.ToString())
                          select ass.diemL2).Sum();

                var a11 = (from ass in data.TieuChis
                           where ass.maTieuChi == Convert.ToInt32(txt_matieuchi.Text.ToString())
                           select ass.diemToiDa).FirstOrDefault();

                var a12 = (from ass in data.TieuChis
                           where ass.maTieuChi == Convert.ToInt32(txt_matieuchi.Text.ToString())
                           select ass.maTieuChi).FirstOrDefault();

                if (a1 > a11)
                {
                    MessageBox.Show("Bạn đã nhập quá số điểm tối đa cho phép của tiêu chí mã" + a12 + ", vui lòng nhập lại!");

                    return;
                }
                else
                {
                    var a = (from ass in data.ChiTieuPhieuChams
                             where ass.maPhieuCham == Convert.ToInt32(pb2)
                             select ass.diemL2).Sum();

                    if (chamDiem == null)
                    {
                        chamDiem = new ChamDiemRL();
                        chamDiem.maSV = Convert.ToInt32(pb1);
                        chamDiem.maPhieuCham = Convert.ToInt32(pb2);
                        data.ChamDiemRLs.InsertOnSubmit(chamDiem);
                    }

                    chamDiem.diemRL = Convert.ToInt32(a);
                    txt_td.Text = chamDiem.diemRL.ToString();

                    MessageBox.Show("Lưu Thành Công");
                }

                data.SubmitChanges();






            }
            catch (Exception)
            {
                MessageBox.Show("Lưu Thất Bại!");
            }
            finally
            {
                data.SubmitChanges();
            }
        }

        private void data_nd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = data_nd.Rows[e.RowIndex];
            txt_mand.Text = row.Cells["Mã_Nội_Dung"].Value.ToString();
            txt_mand.Enabled = false;
            txt_diemtoida2.Text = row.Cells["Điểm_Tối_Đa"].Value.ToString();
            txt_tennd.Text = row.Cells["Tên_Nội_Dung"].Value.ToString();
            txt_matieuchi2.Text = row.Cells["Mã_Tiêu_Chí"].Value.ToString();
        }

        private void data_dssv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = data_dssv.Rows[e.RowIndex];
            txt_maphieu.Text = row.Cells["Mã_Phiếu_Chấm"].Value.ToString();
            txt_matieuchi.Text = row.Cells["Mã_Tiêu_Chí"].Value.ToString();
            txt_mand.Text = row.Cells["Mã_Nội_Dung"].Value.ToString();

        }

        private void nhapdiem_Click(object sender, EventArgs e)
        {
            try
            {
                var pb1 = txt_maphieu.Text;
                var pb2 = txt_matieuchi.Text;
                var pb3 = txt_mand.Text;
                ChiTieuPhieuCham edit_l = data.ChiTieuPhieuChams.Where(o => o.maPhieuCham.Equals(pb1) && o.maTieuChi.Equals(pb2) && o.maNoiDung.Equals(pb3)).FirstOrDefault();


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


                    edit_l.diemL2 = diemNhap;
                    edit_l.diemL3 = 0;


                    data.SubmitChanges();
                    var quyry = from a in data.ChamDiemRLs
                                join pc in data.ChiTieuPhieuChams on a.maPhieuCham equals pc.maPhieuCham
                                join tc in data.TieuChis on pc.maTieuChi equals tc.maTieuChi
                                join nd in data.NoiDungs on pc.maNoiDung equals nd.maNoiDung
                                where a.maPhieuCham == Convert.ToInt32(txt_maphieu.Text.ToString()) && pc.diemL2 != 0


                                select new
                                {
                                    Mã_Sinh_Viên = a.maSV,
                                    Tên_Tiêu_Chí = tc.tenTieuChi,
                                    Tên_Nội_Dung = nd.tenNoiDung,
                                    Điểm_Đánh_Giá = pc.diemL2,
                                    Mã_Phiếu_Chấm = pc.maPhieuCham,
                                    Mã_Nội_Dung = nd.maNoiDung,
                                    Mã_Tiêu_Chí = tc.maTieuChi,
                                };
                    data_dssv.DataSource = quyry.ToList();
                    data_dssv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;




                }

            }
            catch (Exception)
            {
                MessageBox.Show("Nhập Thất Bại!");
            }
            finally
            {

                data.SubmitChanges();


            }
        }
    }
}
