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
    public partial class QL_Khoa : Form
    {
        public QL_Khoa()
        {
            InitializeComponent();
        }
        DataClasses1DataContext data = new DataClasses1DataContext();
        private void QL_Khoa_Load(object sender, EventArgs e)
        {
            data = new DataClasses1DataContext();
            var quyry = from a in data.Khoas

                        select new
                        {
                            Mã_Khoa = a.maKhoa,
                            Tên_Khoa = a.tenKhoa
                        };
            data_khoa.DataSource = quyry.ToList();
            data_khoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txt_makhoa.Enabled = false;
            txt_makhoa.Text = "";
            txt_tenkhoa.Text = "";
        }

        private void data_khoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = data_khoa.Rows[e.RowIndex];
            txt_makhoa.Text = row.Cells["Mã_Khoa"].Value.ToString();
            txt_makhoa.Enabled = false;
            txt_tenkhoa.Text = row.Cells["Tên_Khoa"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Khoa kh = new Khoa();
              
                kh.tenKhoa = txt_tenkhoa.Text.ToString();



                data.Khoas.InsertOnSubmit(kh);
                data.SubmitChanges();
                var a = kh.tenKhoa;
                MessageBox.Show("Thêm thông tin khoa " + a.ToString() + " thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Thất Bại");
            }
            finally
            {
                var qlpb = data.Khoas;
                data_khoa.DataSource = qlpb;
                QL_Khoa_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var pb1 = txt_makhoa.Text;
                Khoa edit_l = data.Khoas.Where(o => o.maKhoa.Equals(pb1)).FirstOrDefault();
                edit_l.tenKhoa = txt_tenkhoa.Text.ToString();

                var a = edit_l.tenKhoa;
                MessageBox.Show("Sửa thông tin Khoa " + a.ToString() + " thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa Thông Tin Khoa Thất Bại!");
            }
            finally
            {
                var qlpb = data.Khoas;
                data_khoa.DataSource = qlpb;
                data.SubmitChanges();

                QL_Khoa_Load(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var pb2 = txt_makhoa.Text;
                Khoa del_pb = data.Khoas.Where(o => o.maKhoa.Equals(pb2)).FirstOrDefault();
                data.Khoas.DeleteOnSubmit(del_pb);
                data.SubmitChanges();
                var a = del_pb.tenKhoa;
                MessageBox.Show("Đã xóa thông tin khoa " + a.ToString() + " khỏi cơ sở dữ liệu");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa Thất Bại !");
            }
            finally
            {
                var pb3 = data.Khoas;
                data_khoa.DataSource = pb3;

                QL_Khoa_Load(sender, e);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QL_Khoa_Load(sender, e);
        }
    }
}
