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
    public partial class Frmdoimatkhau : Form
    {
        public Frmdoimatkhau()
        {
           
            InitializeComponent();
        }

        
        private DataClasses1DataContext db;
        private void Frmdoimatkhau_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
        }

        private void btn_dnhap_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Txtmatkhaucu.Text)) 
            {   
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               Txtmatkhaucu.Select();
                return;
            }
            if (string.IsNullOrEmpty(Txtmatkhaumoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Txtmatkhaumoi.Select();
                return;
            }
            if (string.IsNullOrEmpty(Txtnhaplai.Text))
            {
                MessageBox.Show("Không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Txtnhaplai.Select();
                return;
            }
            var taikhoan = db.SinhViens.SingleOrDefault(x => x.matKhau == Txtmatkhaucu.Text);
            if(taikhoan == null)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Txtmatkhaucu.Select();
                return;
            }
            taikhoan.matKhau = Txtmatkhaucu.Text;
            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();

        }

        private void Btnhuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
