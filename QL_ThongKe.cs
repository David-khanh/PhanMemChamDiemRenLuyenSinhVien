using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QL_DanhGiaDiemRL
{
    public partial class QL_ThongKe : Form
    {
        public QL_ThongKe()
        {
            InitializeComponent();
        }
        DataClasses1DataContext data = new DataClasses1DataContext();

     
        private void button1_Click(object sender, EventArgs e)
        {
            data = new DataClasses1DataContext();
            var quyry = from a in data.ChamDiemRLs
                        join sv in data.SinhViens on a.maSV equals sv.maSV
                        join pc in data.PhieuChams on a.maPhieuCham equals pc.maPhieuCham


                        select new
                        {
                            Mã_Sinh_Viên = a.maSV,
                            Mã_Phiếu = a.maPhieuCham,
                            Tên_Sinh_Viên = sv.hoTen,
                            Ngày_Lập = pc.ngayLap,
                            Niên_Khóa = pc.nienKhoa,
                            Học_Kì = pc.hocKi,
                            Tổng_Điểm = a.diemRL,
                        };


            var h = (from ass in quyry
                     select ass).Count();


            txt1.Text = h.ToString();
            var tk = quyry.ToList();
            data_tk.DataSource = tk;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data = new DataClasses1DataContext();
            var query = from sv in data.SinhViens
                        where !data.ChamDiemRLs.Any(dr => dr.maSV == sv.maSV)
                        join lop in data.Lops on sv.maLop equals lop.maLop
                        select new
                        {
                            MaSV = sv.maSV,
                            HoTen = sv.hoTen,
                            TenLop = lop.tenLop
                        };
            var h = (from ass in query
                     select ass).Count();

            txt2.Text = h.ToString();
            var tk = query.ToList();
            data_tk.DataSource = tk;
        }

        private void export2Excel(DataGridView g, string duongdan, string tentap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)

                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }

             }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tentap + ".xlsx");
            obj.ActiveWorkbook.Saved = true; 

        }

        private void Btnbaocao_Click(object sender, EventArgs e)
        {

            export2Excel(data_tk, @"D:\", "Báo Cáo");
            MessageBox.Show("Xuất FIle Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
