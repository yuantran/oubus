namespace OUBus
{
    partial class AdminViewBooking
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewBookings = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxChonTuyen = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDiSang = new System.Windows.Forms.Label();
            this.lblDiTrua = new System.Windows.Forms.Label();
            this.lblVeTrua = new System.Windows.Forms.Label();
            this.lblVeChieu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpChonNgay = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridViewBookings);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 239);
            this.panel1.TabIndex = 4;
            // 
            // dataGridViewBookings
            // 
            this.dataGridViewBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBookings.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewBookings.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewBookings.Name = "dataGridViewBookings";
            this.dataGridViewBookings.RowHeadersWidth = 62;
            this.dataGridViewBookings.RowTemplate.Height = 28;
            this.dataGridViewBookings.Size = new System.Drawing.Size(705, 214);
            this.dataGridViewBookings.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dữ liệu đặt vé";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dtpChonNgay);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblVeChieu);
            this.panel2.Controls.Add(this.lblVeTrua);
            this.panel2.Controls.Add(this.lblDiTrua);
            this.panel2.Controls.Add(this.lblDiSang);
            this.panel2.Controls.Add(this.cbxChonTuyen);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(12, 285);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(729, 182);
            this.panel2.TabIndex = 5;
            // 
            // cbxChonTuyen
            // 
            this.cbxChonTuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxChonTuyen.FormattingEnabled = true;
            this.cbxChonTuyen.Items.AddRange(new object[] {
            "Cung văn hóa lao động",
            "Trường Chinh",
            "Huỳnh Lan Khanh"});
            this.cbxChonTuyen.Location = new System.Drawing.Point(103, 36);
            this.cbxChonTuyen.Margin = new System.Windows.Forms.Padding(2);
            this.cbxChonTuyen.Name = "cbxChonTuyen";
            this.cbxChonTuyen.Size = new System.Drawing.Size(153, 25);
            this.cbxChonTuyen.TabIndex = 25;
            this.cbxChonTuyen.SelectedIndexChanged += new System.EventHandler(this.cbxChonTuyen_SelectedIndexChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(41, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 18);
            this.label8.TabIndex = 24;
            this.label8.Text = "Tuyến:";
            // 
            // lblDiSang
            // 
            this.lblDiSang.AutoSize = true;
            this.lblDiSang.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiSang.Location = new System.Drawing.Point(41, 99);
            this.lblDiSang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiSang.Name = "lblDiSang";
            this.lblDiSang.Size = new System.Drawing.Size(98, 18);
            this.lblDiSang.TabIndex = 27;
            this.lblDiSang.Text = "SL đi sáng: 0";
            // 
            // lblDiTrua
            // 
            this.lblDiTrua.AutoSize = true;
            this.lblDiTrua.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiTrua.Location = new System.Drawing.Point(183, 99);
            this.lblDiTrua.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiTrua.Name = "lblDiTrua";
            this.lblDiTrua.Size = new System.Drawing.Size(94, 18);
            this.lblDiTrua.TabIndex = 28;
            this.lblDiTrua.Text = "SL đi trưa: 0";
            // 
            // lblVeTrua
            // 
            this.lblVeTrua.AutoSize = true;
            this.lblVeTrua.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeTrua.Location = new System.Drawing.Point(333, 99);
            this.lblVeTrua.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVeTrua.Name = "lblVeTrua";
            this.lblVeTrua.Size = new System.Drawing.Size(99, 18);
            this.lblVeTrua.TabIndex = 29;
            this.lblVeTrua.Text = "SL về trưa: 0";
            // 
            // lblVeChieu
            // 
            this.lblVeChieu.AutoSize = true;
            this.lblVeChieu.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeChieu.Location = new System.Drawing.Point(476, 99);
            this.lblVeChieu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVeChieu.Name = "lblVeChieu";
            this.lblVeChieu.Size = new System.Drawing.Size(108, 18);
            this.lblVeChieu.TabIndex = 30;
            this.lblVeChieu.Text = "SL về chiều: 0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(350, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "Ngày:";
            // 
            // dtpChonNgay
            // 
            this.dtpChonNgay.Location = new System.Drawing.Point(421, 37);
            this.dtpChonNgay.Name = "dtpChonNgay";
            this.dtpChonNgay.Size = new System.Drawing.Size(200, 20);
            this.dtpChonNgay.TabIndex = 32;
            this.dtpChonNgay.ValueChanged += new System.EventHandler(this.dtpChonNgay_ValueChanged_1);
            // 
            // AdminViewBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "AdminViewBooking";
            this.Size = new System.Drawing.Size(752, 451);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewBookings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbxChonTuyen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblVeChieu;
        private System.Windows.Forms.Label lblVeTrua;
        private System.Windows.Forms.Label lblDiTrua;
        private System.Windows.Forms.Label lblDiSang;
        private System.Windows.Forms.DateTimePicker dtpChonNgay;
        private System.Windows.Forms.Label label6;
    }
}
