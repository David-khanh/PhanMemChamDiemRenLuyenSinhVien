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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.panel1.Dock = DockStyle.Fill;
        }
        private Form currentFormchild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormchild != null)//có nghĩa form này khởi tạo rồi thì đóng lại
            {
                currentFormchild.Close();
            }
            currentFormchild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }



        private void QL_KHOA_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QL_Khoa());
        }

        private void QL_LOP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QL_Lop());
        }

        private void QL_SINHVIEN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QL_SinhVien());
        }

        private void DANHGIADRL_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhGiaDRL_ADMIN());
        }

        private void QL_THONGKE_Click(object sender, EventArgs e)
        {
           OpenChildForm(new QL_ThongKe());
        }
    }
}
