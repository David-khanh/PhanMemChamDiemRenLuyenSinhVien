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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public int MaSV ;
        public static int SafeConvertToInt(object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (OverflowException)
            {
                return 0;
            }
            catch (ArgumentNullException)
            {
                return 0;
            }
        }
        private void btn_dnhap_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            var conn = data.Taikhoans;
            var sv = data.SinhViens;
            int aa = SafeConvertToInt(txt_tk.Text);
         

            try
            {

                var tk = txt_tk.Text;
                var mk = txt_mk.Text;

                if (aa == 0)
                {

                    var admin = conn.FirstOrDefault(b => b.taikhoan1 == tk && b.matkhau == mk && b.Idtaikhoan == 2);
                    var GV = conn.FirstOrDefault(a => a.taikhoan1 == tk && a.matkhau == mk && a.Idtaikhoan == 1);

                    if (admin != null)
                    {

                        this.Hide();
                        main ac = new main();
                        ac.ShowDialog();
                        ac = null;
                        this.Show();


                    }
                    else if (GV != null)
                    {

                      

                        this.Hide();
                        DanhGiaDRL_GV ac = new DanhGiaDRL_GV();
                        ac.ShowDialog();
                        ac = null;
                        this.Show();


                    }

                }


                var SV = sv.FirstOrDefault(a => a.maSV == aa && a.matKhau == mk );

                if (SV != null)
                {

                    this.Hide();
                    DanhGiaDRL_SV danhGiaDRL_SV = new DanhGiaDRL_SV() { MaSV = SV.maSV };
                    danhGiaDRL_SV.ShowDialog();
                    danhGiaDRL_SV = null;
                    this.Show();
                }



               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
