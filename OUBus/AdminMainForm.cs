using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OUBus.Form1;

namespace OUBus
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
            LoadProfileImage();
            LoadUserInfo();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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
                        ptbAdminImage.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Nếu không có ảnh, có thể gán ảnh mặc định
                    ptbAdminImage.Image = null; // Ảnh mặc định từ Resources
                                                  // Hoặc để trống: ptbAdminImage.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ptbAdminImage.Image = null; // Xử lý lỗi, để trống PictureBox
            }
        }
        private void LoadUserInfo()
        {
            try
            {
                // Gán username vào Label
                if (!string.IsNullOrEmpty(LoggedInUser.Username))
                {
                    lblAdminUsername.Text = $"Username: {LoggedInUser.Username}";
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
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }    
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure want to Sign out", "Configuration Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check==DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }    
        }

        private void button1_Click(object sender, EventArgs e) //Dashboard
        {
            adminDashboardForm1.Visible = true;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = false;
            adminViewBooking1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e) //Thêm ng dùng
        {

            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = true;
            adminAddProducts1.Visible = false;
            adminViewBooking1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e) //Thêm chuyến
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = true;
            adminViewBooking1.Visible = false;
        }

        private void btnViewBooking_Click(object sender, EventArgs e) //Xem ds đặt vé
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = false;
            adminViewBooking1.Visible = true;
        }
    }
}
