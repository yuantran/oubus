namespace OUBus
{
    partial class AdminThemChuyen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpNgayChay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClearTrip = new System.Windows.Forms.Button();
            this.btnUpdateTrip = new System.Windows.Forms.Button();
            this.btnDeleteTrip = new System.Windows.Forms.Button();
            this.btnAddTrip = new System.Windows.Forms.Button();
            this.btnImportImage = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.taiXe_image = new System.Windows.Forms.PictureBox();
            this.caChay = new System.Windows.Forms.ComboBox();
            this.tuyen = new System.Windows.Forms.ComboBox();
            this.taiXe = new System.Windows.Forms.TextBox();
            this.bienSoXe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chuyen_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taiXe_image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(11, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 288);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dữ liệu chuyến xe";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(13, 46);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(909, 227);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dtpNgayChay);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnClearTrip);
            this.panel2.Controls.Add(this.btnUpdateTrip);
            this.panel2.Controls.Add(this.btnDeleteTrip);
            this.panel2.Controls.Add(this.btnAddTrip);
            this.panel2.Controls.Add(this.btnImportImage);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.caChay);
            this.panel2.Controls.Add(this.tuyen);
            this.panel2.Controls.Add(this.taiXe);
            this.panel2.Controls.Add(this.bienSoXe);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.chuyen_id);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(11, 314);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(934, 221);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dtpNgayChay
            // 
            this.dtpNgayChay.Location = new System.Drawing.Point(491, 125);
            this.dtpNgayChay.Name = "dtpNgayChay";
            this.dtpNgayChay.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayChay.TabIndex = 28;
            this.dtpNgayChay.ValueChanged += new System.EventHandler(this.dtpNgayChay_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(401, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Ngày chạy:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(420, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 18);
            this.label5.TabIndex = 26;
            this.label5.Text = "Ca chạy:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(401, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 24;
            this.label6.Text = "Tên tài xế: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(115, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Tuyến:";
            // 
            // btnClearTrip
            // 
            this.btnClearTrip.BackColor = System.Drawing.Color.Teal;
            this.btnClearTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTrip.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearTrip.ForeColor = System.Drawing.Color.White;
            this.btnClearTrip.Location = new System.Drawing.Point(554, 165);
            this.btnClearTrip.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearTrip.Name = "btnClearTrip";
            this.btnClearTrip.Size = new System.Drawing.Size(89, 42);
            this.btnClearTrip.TabIndex = 22;
            this.btnClearTrip.Text = "Clear";
            this.btnClearTrip.UseVisualStyleBackColor = false;
            this.btnClearTrip.Click += new System.EventHandler(this.adminAddUsers_clearBtn_Click);
            // 
            // btnUpdateTrip
            // 
            this.btnUpdateTrip.BackColor = System.Drawing.Color.Teal;
            this.btnUpdateTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTrip.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTrip.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTrip.Location = new System.Drawing.Point(303, 165);
            this.btnUpdateTrip.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateTrip.Name = "btnUpdateTrip";
            this.btnUpdateTrip.Size = new System.Drawing.Size(89, 42);
            this.btnUpdateTrip.TabIndex = 21;
            this.btnUpdateTrip.Text = "Update";
            this.btnUpdateTrip.UseVisualStyleBackColor = false;
            this.btnUpdateTrip.Click += new System.EventHandler(this.adminAddUsers_updateBtn_Click);
            // 
            // btnDeleteTrip
            // 
            this.btnDeleteTrip.BackColor = System.Drawing.Color.Teal;
            this.btnDeleteTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTrip.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTrip.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTrip.Location = new System.Drawing.Point(429, 165);
            this.btnDeleteTrip.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteTrip.Name = "btnDeleteTrip";
            this.btnDeleteTrip.Size = new System.Drawing.Size(89, 42);
            this.btnDeleteTrip.TabIndex = 20;
            this.btnDeleteTrip.Text = "Delete";
            this.btnDeleteTrip.UseVisualStyleBackColor = false;
            this.btnDeleteTrip.Click += new System.EventHandler(this.adminAddUsers_deleteBtn_Click);
            // 
            // btnAddTrip
            // 
            this.btnAddTrip.BackColor = System.Drawing.Color.Teal;
            this.btnAddTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTrip.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTrip.ForeColor = System.Drawing.Color.White;
            this.btnAddTrip.Location = new System.Drawing.Point(177, 165);
            this.btnAddTrip.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddTrip.Name = "btnAddTrip";
            this.btnAddTrip.Size = new System.Drawing.Size(89, 42);
            this.btnAddTrip.TabIndex = 19;
            this.btnAddTrip.Text = "Add";
            this.btnAddTrip.UseVisualStyleBackColor = false;
            this.btnAddTrip.Click += new System.EventHandler(this.adminAddUsers_addBtn_Click);
            // 
            // btnImportImage
            // 
            this.btnImportImage.BackColor = System.Drawing.Color.Teal;
            this.btnImportImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportImage.Location = new System.Drawing.Point(728, 140);
            this.btnImportImage.Name = "btnImportImage";
            this.btnImportImage.Size = new System.Drawing.Size(83, 33);
            this.btnImportImage.TabIndex = 18;
            this.btnImportImage.Text = "Import";
            this.btnImportImage.UseVisualStyleBackColor = false;
            this.btnImportImage.Click += new System.EventHandler(this.adminAddProducts_importBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.taiXe_image);
            this.panel3.Location = new System.Drawing.Point(728, 20);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(83, 114);
            this.panel3.TabIndex = 15;
            // 
            // taiXe_image
            // 
            this.taiXe_image.BackColor = System.Drawing.Color.LightGray;
            this.taiXe_image.Location = new System.Drawing.Point(0, 0);
            this.taiXe_image.Name = "taiXe_image";
            this.taiXe_image.Size = new System.Drawing.Size(83, 114);
            this.taiXe_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.taiXe_image.TabIndex = 17;
            this.taiXe_image.TabStop = false;
            // 
            // caChay
            // 
            this.caChay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caChay.FormattingEnabled = true;
            this.caChay.Items.AddRange(new object[] {
            "Ca sáng",
            "Ca chiều"});
            this.caChay.Location = new System.Drawing.Point(491, 73);
            this.caChay.Margin = new System.Windows.Forms.Padding(2);
            this.caChay.Name = "caChay";
            this.caChay.Size = new System.Drawing.Size(153, 25);
            this.caChay.TabIndex = 14;
            // 
            // tuyen
            // 
            this.tuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuyen.FormattingEnabled = true;
            this.tuyen.Items.AddRange(new object[] {
            "Cung văn hóa lao động",
            "Trường Chinh",
            "Huỳnh Lan Khanh"});
            this.tuyen.Location = new System.Drawing.Point(177, 118);
            this.tuyen.Margin = new System.Windows.Forms.Padding(2);
            this.tuyen.Name = "tuyen";
            this.tuyen.Size = new System.Drawing.Size(153, 25);
            this.tuyen.TabIndex = 12;
            // 
            // taiXe
            // 
            this.taiXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taiXe.Location = new System.Drawing.Point(491, 25);
            this.taiXe.Margin = new System.Windows.Forms.Padding(2);
            this.taiXe.Name = "taiXe";
            this.taiXe.Size = new System.Drawing.Size(153, 24);
            this.taiXe.TabIndex = 8;
            // 
            // bienSoXe
            // 
            this.bienSoXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bienSoXe.Location = new System.Drawing.Point(177, 74);
            this.bienSoXe.Margin = new System.Windows.Forms.Padding(2);
            this.bienSoXe.Name = "bienSoXe";
            this.bienSoXe.Size = new System.Drawing.Size(153, 24);
            this.bienSoXe.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Biển số xe: ";
            // 
            // chuyen_id
            // 
            this.chuyen_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chuyen_id.Location = new System.Drawing.Point(177, 24);
            this.chuyen_id.Margin = new System.Windows.Forms.Padding(2);
            this.chuyen_id.Name = "chuyen_id";
            this.chuyen_id.Size = new System.Drawing.Size(153, 24);
            this.chuyen_id.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bus ID:";
            // 
            // AdminThemChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminThemChuyen";
            this.Size = new System.Drawing.Size(960, 605);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taiXe_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox chuyen_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox taiXe;
        private System.Windows.Forms.TextBox bienSoXe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox caChay;
        private System.Windows.Forms.ComboBox tuyen;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnImportImage;
        private System.Windows.Forms.PictureBox taiXe_image;
        private System.Windows.Forms.Button btnClearTrip;
        private System.Windows.Forms.Button btnUpdateTrip;
        private System.Windows.Forms.Button btnDeleteTrip;
        private System.Windows.Forms.Button btnAddTrip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNgayChay;
    }
}
