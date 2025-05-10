using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OUBus.Form1;

namespace OUBus
{
    public partial class StudentFeedBack : UserControl
    {
        private SqlConnection connect;
        public event EventHandler FeedbackSaved; // Sự kiện khi phản hồi được lưu
        public StudentFeedBack()
        {
            InitializeComponent();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=H:\\OUBus_Manage\\OUBus\\cafe.mdf;Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(connectionString);
        }

        private void StudentFeedBack_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (cbxTuyenPhanAnh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tuyến xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxVanDe.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn vấn đề.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string query = @"
                    INSERT INTO feedback (mssv, tuyen_xe, van_de, mo_ta, ngay_phan_anh, trang_thai)
                    VALUES (@mssv, @tuyenXe, @vanDe, @moTa, @ngayPhanAnh, @trangThai)"
                ;

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@mssv", LoggedInUser.MSSV);
                    cmd.Parameters.AddWithValue("@tuyenXe", cbxTuyenPhanAnh.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@vanDe", cbxVanDe.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@moTa", txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@ngayPhanAnh", DateTime.Now);
                    cmd.Parameters.AddWithValue("@trangThai", "Chưa xử lý");

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Phản ánh đã được gửi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Kích hoạt sự kiện FeedbackSaved
                FeedbackSaved?.Invoke(this, EventArgs.Empty);

                // Xóa form sau khi gửi
                cbxTuyenPhanAnh.SelectedIndex = 0;
                cbxVanDe.SelectedIndex = 0;
                txtMoTa.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi phản ánh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }

        }

    }
}

