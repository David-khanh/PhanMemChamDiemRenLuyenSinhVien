namespace QL_DanhGiaDiemRL
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.QL_KHOA = new System.Windows.Forms.ToolStripMenuItem();
            this.QL_LOP = new System.Windows.Forms.ToolStripMenuItem();
            this.QL_SINHVIEN = new System.Windows.Forms.ToolStripMenuItem();
            this.DANHGIADRL = new System.Windows.Forms.ToolStripMenuItem();
            this.QL_THONGKE = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1912, 822);
            this.panel1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QL_KHOA,
            this.QL_LOP,
            this.QL_SINHVIEN,
            this.DANHGIADRL,
            this.QL_THONGKE});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // QL_KHOA
            // 
            this.QL_KHOA.Name = "QL_KHOA";
            this.QL_KHOA.Size = new System.Drawing.Size(104, 20);
            this.QL_KHOA.Text = "QUẢN LÝ KHOA";
            this.QL_KHOA.Click += new System.EventHandler(this.QL_KHOA_Click);
            // 
            // QL_LOP
            // 
            this.QL_LOP.Name = "QL_LOP";
            this.QL_LOP.Size = new System.Drawing.Size(93, 20);
            this.QL_LOP.Text = "QUẢN LÝ LỚP";
            this.QL_LOP.Click += new System.EventHandler(this.QL_LOP_Click);
            // 
            // QL_SINHVIEN
            // 
            this.QL_SINHVIEN.Name = "QL_SINHVIEN";
            this.QL_SINHVIEN.Size = new System.Drawing.Size(126, 20);
            this.QL_SINHVIEN.Text = "QUẢN LÝ SINH VIÊN";
            this.QL_SINHVIEN.Click += new System.EventHandler(this.QL_SINHVIEN_Click);
            // 
            // DANHGIADRL
            // 
            this.DANHGIADRL.Name = "DANHGIADRL";
            this.DANHGIADRL.Size = new System.Drawing.Size(99, 20);
            this.DANHGIADRL.Text = "ĐÁNH GIÁ ĐRL";
            this.DANHGIADRL.Click += new System.EventHandler(this.DANHGIADRL_Click);
            // 
            // QL_THONGKE
            // 
            this.QL_THONGKE.Name = "QL_THONGKE";
            this.QL_THONGKE.Size = new System.Drawing.Size(76, 20);
            this.QL_THONGKE.Text = "THỐNG KÊ";
            this.QL_THONGKE.Click += new System.EventHandler(this.QL_THONGKE_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 961);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "main";
            this.Text = "main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem QL_KHOA;
        private System.Windows.Forms.ToolStripMenuItem QL_LOP;
        private System.Windows.Forms.ToolStripMenuItem QL_SINHVIEN;
        private System.Windows.Forms.ToolStripMenuItem DANHGIADRL;
        private System.Windows.Forms.ToolStripMenuItem QL_THONGKE;
    }
}