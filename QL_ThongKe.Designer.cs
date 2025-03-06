namespace QL_DanhGiaDiemRL
{
    partial class QL_ThongKe
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
            this.data_tk = new System.Windows.Forms.DataGridView();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Btnbaocao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_tk)).BeginInit();
            this.SuspendLayout();
            // 
            // data_tk
            // 
            this.data_tk.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.data_tk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_tk.Location = new System.Drawing.Point(35, 188);
            this.data_tk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.data_tk.Name = "data_tk";
            this.data_tk.RowHeadersWidth = 51;
            this.data_tk.RowTemplate.Height = 24;
            this.data_tk.Size = new System.Drawing.Size(1427, 434);
            this.data_tk.TabIndex = 136;
            // 
            // txt2
            // 
            this.txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt2.Location = new System.Drawing.Point(467, 82);
            this.txt2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(112, 26);
            this.txt2.TabIndex = 135;
            // 
            // txt1
            // 
            this.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt1.Location = new System.Drawing.Point(467, 22);
            this.txt1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(112, 26);
            this.txt1.TabIndex = 134;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(35, 82);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(368, 42);
            this.button2.TabIndex = 132;
            this.button2.Text = "Số lượng sinh viên chưa đánh giá điểm rèn luyện:";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(368, 42);
            this.button1.TabIndex = 133;
            this.button1.Text = "Số lượng sinh viên đã đánh giá điểm rèn luyện:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btnbaocao
            // 
            this.Btnbaocao.Location = new System.Drawing.Point(707, 49);
            this.Btnbaocao.Name = "Btnbaocao";
            this.Btnbaocao.Size = new System.Drawing.Size(116, 37);
            this.Btnbaocao.TabIndex = 3;
            this.Btnbaocao.Text = "Báo cáo";
            this.Btnbaocao.UseVisualStyleBackColor = true;
            this.Btnbaocao.Click += new System.EventHandler(this.Btnbaocao_Click);
            // 
            // QL_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 650);
            this.Controls.Add(this.Btnbaocao);
            this.Controls.Add(this.data_tk);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QL_ThongKe";
            this.Text = "QL_ThongKe";
            ((System.ComponentModel.ISupportInitialize)(this.data_tk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView data_tk;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btnbaocao;
    }
}