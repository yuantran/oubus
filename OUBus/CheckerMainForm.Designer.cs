namespace OUBus
{
    partial class CheckerMainForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.btn_DatVe = new System.Windows.Forms.Button();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Label();
            this.lbl_oubus = new System.Windows.Forms.Label();
            this.ptbCheckerImage = new System.Windows.Forms.PictureBox();
            this.checkerCheckStudent1 = new OUBus.CheckerCheckStudent();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCheckerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkerCheckStudent1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 34);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(602, 644);
            this.panel3.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.btn_DatVe);
            this.panel2.Controls.Add(this.lblMSSV);
            this.panel2.Controls.Add(this.ptbCheckerImage);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 644);
            this.panel2.TabIndex = 7;
            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.logout_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_btn.ForeColor = System.Drawing.SystemColors.Window;
            this.logout_btn.Location = new System.Drawing.Point(24, 581);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(151, 34);
            this.logout_btn.TabIndex = 19;
            this.logout_btn.Text = "Logout";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // btn_DatVe
            // 
            this.btn_DatVe.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_DatVe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DatVe.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_DatVe.Location = new System.Drawing.Point(24, 282);
            this.btn_DatVe.Name = "btn_DatVe";
            this.btn_DatVe.Size = new System.Drawing.Size(151, 45);
            this.btn_DatVe.TabIndex = 15;
            this.btn_DatVe.Text = "Danh sách sinh viên đi";
            this.btn_DatVe.UseVisualStyleBackColor = false;
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSSV.ForeColor = System.Drawing.SystemColors.Window;
            this.lblMSSV.Location = new System.Drawing.Point(21, 212);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(49, 15);
            this.lblMSSV.TabIndex = 14;
            this.lblMSSV.Text = "MSSV:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(64, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kiểm Vé";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.lbl_oubus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 34);
            this.panel1.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(200, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(801, 715);
            this.panel4.TabIndex = 1;
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Dock = System.Windows.Forms.DockStyle.Right;
            this.close.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(787, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(15, 15);
            this.close.TabIndex = 13;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // lbl_oubus
            // 
            this.lbl_oubus.AutoSize = true;
            this.lbl_oubus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_oubus.Location = new System.Drawing.Point(3, 9);
            this.lbl_oubus.Name = "lbl_oubus";
            this.lbl_oubus.Size = new System.Drawing.Size(192, 15);
            this.lbl_oubus.TabIndex = 12;
            this.lbl_oubus.Text = "OU Bus Management System";
            // 
            // ptbCheckerImage
            // 
            this.ptbCheckerImage.Location = new System.Drawing.Point(38, 3);
            this.ptbCheckerImage.Name = "ptbCheckerImage";
            this.ptbCheckerImage.Size = new System.Drawing.Size(120, 145);
            this.ptbCheckerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbCheckerImage.TabIndex = 11;
            this.ptbCheckerImage.TabStop = false;
            // 
            // checkerCheckStudent1
            // 
            this.checkerCheckStudent1.Location = new System.Drawing.Point(0, 0);
            this.checkerCheckStudent1.Name = "checkerCheckStudent1";
            this.checkerCheckStudent1.Size = new System.Drawing.Size(603, 615);
            this.checkerCheckStudent1.TabIndex = 0;
            // 
            // CheckerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 678);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CheckerMainForm";
            this.Text = "CheckerMainForm";
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCheckerImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Button btn_DatVe;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbCheckerImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label lbl_oubus;
        private CheckerCheckStudent checkerCheckStudent1;
    }
}