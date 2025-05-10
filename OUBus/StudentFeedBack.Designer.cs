namespace OUBus
{
    partial class StudentFeedBack
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTuyenPhanAnh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxVanDe = new System.Windows.Forms.ComboBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(131, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHẢN ẢNH CÁC VẤN ĐỀ VỀ OU BUS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbxTuyenPhanAnh
            // 
            this.cbxTuyenPhanAnh.FormattingEnabled = true;
            this.cbxTuyenPhanAnh.Items.AddRange(new object[] {
            "Cung văn hóa lao động",
            "Trường Chinh",
            "Huỳnh Lan Khanh"});
            this.cbxTuyenPhanAnh.Location = new System.Drawing.Point(277, 70);
            this.cbxTuyenPhanAnh.Name = "cbxTuyenPhanAnh";
            this.cbxTuyenPhanAnh.Size = new System.Drawing.Size(221, 21);
            this.cbxTuyenPhanAnh.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chọn tuyến xe cần phản ảnh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vấn đề cần phản ảnh";
            // 
            // cbxVanDe
            // 
            this.cbxVanDe.FormattingEnabled = true;
            this.cbxVanDe.Items.AddRange(new object[] {
            "Tài xế đến trễ",
            "Tài xế đi trước giờ",
            "Tài xế có thái độ không chuẩn mực",
            "Tài xế chạy ẩu",
            "Xe bus hư hỏng, có vấn đề",
            "Vấn đề khác"});
            this.cbxVanDe.Location = new System.Drawing.Point(277, 127);
            this.cbxVanDe.Name = "cbxVanDe";
            this.cbxVanDe.Size = new System.Drawing.Size(221, 21);
            this.cbxVanDe.TabIndex = 4;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(277, 191);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(221, 43);
            this.txtMoTa.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 53);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mô tả chi tiết về vấn đề mà bạn gặp phải (Ngày, giờ,... tại xe nào)";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(240, 333);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 34);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Xác nhận";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // StudentFeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.cbxVanDe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxTuyenPhanAnh);
            this.Controls.Add(this.label1);
            this.Name = "StudentFeedBack";
            this.Size = new System.Drawing.Size(579, 380);
            this.Load += new System.EventHandler(this.StudentFeedBack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTuyenPhanAnh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxVanDe;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
    }
}
