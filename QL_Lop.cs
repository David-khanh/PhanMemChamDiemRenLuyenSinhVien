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
    public partial class QL_Lop : Form
    {
        public QL_Lop()
        {
            InitializeComponent();
        }
        DataClasses1DataContext data = new DataClasses1DataContext();
        private void QL_Lop_Load(object sender, EventArgs e)
        {
            data = new DataClasses1DataContext();
            var quyry = from a in data.Lops
                        join khoa in data.Khoas on a.maKhoa equals khoa.maKhoa

                        select new
                        {
                            Mã_Lớp = a.maLop,
                            Tên_Lớp = a.tenLop,
                            Tên_Khoa = khoa.tenKhoa
                        };

            cbo_tenkhoa.DataSource = data.Khoas;
            cbo_tenkhoa.DisplayMember = "tenKhoa";
            cbo_tenkhoa.ValueMember = "maKhoa";

            data_lop.DataSource = quyry.ToList();
            data_lop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txt_malop.Enabled   = false;
            txt_malop.Text = "";
            txt_tenlop.Text = "";
        }

        private void data_lop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = data_lop.Rows[e.RowIndex];
            txt_malop.Text = row.Cells["Mã_Lớp"].Value.ToString();
            txt_malop.Enabled = false;
            txt_tenlop.Text = row.Cells["Tên_Lớp"].Value.ToString();
            cbo_tenkhoa.Text = row.Cells["Tên_Khoa"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Lop l = new Lop();

                l.tenLop = txt_tenlop.Text.ToString();
                var a = (from ass in data.Khoas
                         where ass.tenKhoa == cbo_tenkhoa.Text
                         select ass.maKhoa).FirstOrDefault();
                l.maKhoa = a;


                data.Lops.InsertOnSubmit(l);
                data.SubmitChanges();
                var b = l.tenLop;
                MessageBox.Show("Thêm thông tin lớp " + b.ToString() + " thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Thất Bại");
            }
            finally
            {
                var qlpb = data.Lops;
                data_lop.DataSource = qlpb;
                QL_Lop_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var pb1 = txt_malop.Text;
                Lop edit_l = data.Lops.Where(o => o.maLop.Equals(pb1)).FirstOrDefault();

                edit_l.tenLop = txt_tenlop.Text.ToString();
                var a = (from ass in data.Khoas
                         where ass.tenKhoa == cbo_tenkhoa.Text
                         select ass.maKhoa).FirstOrDefault();
                edit_l.maKhoa = a;

                var n = edit_l.tenLop;
                MessageBox.Show("Sửa thông tin Lớp " + n.ToString() + " thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa Thông Tin lớp Thất Bại!");
            }
            finally
            {
                var qlpb = data.Lops;
                data_lop.DataSource = qlpb;
                data.SubmitChanges();

                QL_Lop_Load(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var pb2 = txt_malop.Text;
                Lop del_pb = data.Lops.Where(o => o.maLop.Equals(pb2)).FirstOrDefault();
                data.Lops.DeleteOnSubmit(del_pb);
                data.SubmitChanges();
                var a = del_pb.tenLop;
                MessageBox.Show("Đã xóa thông tin lớp " + a.ToString() + " khỏi cơ sở dữ liệu");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa Thất Bại !");
            }
            finally
            {
                var pb3 = data.Lops;
                data_lop.DataSource = pb3;

                QL_Lop_Load (sender, e);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QL_Lop_Load(sender,e);
        }
    }
}
