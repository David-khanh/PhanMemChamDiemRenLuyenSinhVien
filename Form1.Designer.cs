namespace QL_DanhGiaDiemRL
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_dnhap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_mk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_tk = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_dnhap);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_mk);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_tk);
            this.panel1.Location = new System.Drawing.Point(43, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 459);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 58F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Document, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Đăng Nhập";
            // 
            // btn_dnhap
            // 
            this.btn_dnhap.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_dnhap.FlatAppearance.BorderSize = 0;
            this.btn_dnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dnhap.Location = new System.Drawing.Point(279, 272);
            this.btn_dnhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_dnhap.Name = "btn_dnhap";
            this.btn_dnhap.Size = new System.Drawing.Size(193, 56);
            this.btn_dnhap.TabIndex = 6;
            this.btn_dnhap.Text = "Đăng nhập";
            this.btn_dnhap.UseVisualStyleBackColor = false;
            this.btn_dnhap.Click += new System.EventHandler(this.btn_dnhap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(169, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tài khoản";
            // 
            // txt_mk
            // 
            this.txt_mk.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_mk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mk.Location = new System.Drawing.Point(292, 198);
            this.txt_mk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_mk.Name = "txt_mk";
            this.txt_mk.PasswordChar = '*';
            this.txt_mk.Size = new System.Drawing.Size(180, 26);
            this.txt_mk.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(169, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu";
            // 
            // txt_tk
            // 
            this.txt_tk.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_tk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tk.Location = new System.Drawing.Point(292, 132);
            this.txt_tk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_tk.Name = "txt_tk";
            this.txt_tk.Size = new System.Drawing.Size(180, 26);
            this.txt_tk.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 562);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_dnhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_mk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_tk;
    }
}

