using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OUBus.Form1;

namespace OUBus
{
    public partial class CheckerMainForm : Form
    {
        public CheckerMainForm()
        {
            InitializeComponent();
            LoadProfileImage();
            LoadUserInfo();
        }
        private void LoadProfileImage()
        {
            try
            {
                if (LoggedInUser.Image != null && LoggedInUser.Image.Length > 0)
                {
                    // Chuyển byte[] thành Image
                    using (MemoryStream ms = new MemoryStream(LoggedInUser.Image))
                    {
                        ptbCheckerImage.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Nếu không có ảnh, có thể gán ảnh mặc định
                    ptbCheckerImage.Image = null; // Ảnh mặc định từ Resources
                                                  // Hoặc để trống: ptbCheckerImage.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ptbCheckerImage.Image = null; // Xử lý lỗi, để trống PictureBox
            }
        }
        private void LoadUserInfo()
        {
            try
            {


                // Gán MSSV vào Label
                if (!string.IsNullOrEmpty(LoggedInUser.MSSV))
                {
                    lblMSSV.Text = $"MSSV: {LoggedInUser.MSSV}";
                }
                else
                {
                    lblMSSV.Text = "MSSV: N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            
                DialogResult result = MessageBox.Show("Are you sure want to exit", "Configuration Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {

            DialogResult check = MessageBox.Show("Are you sure want to Sign out", "Configuration Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }
    }


}
