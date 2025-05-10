using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OUBus
{
    public partial class AdminViewFeedback : UserControl
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\OUBus_Manage\OUBus\oubus.mdf;Integrated Security=True;Connect Timeout=30";
        private readonly StudentFeedBack studentFeedback;
        public AdminViewFeedback()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
            dataGridViewFeedback.CellEndEdit += dataGridViewFeedback_CellEndEdit;
            if (!DesignMode)
            {
                DisplayFeedbackData();
            }
        }
        public AdminViewFeedback(StudentFeedBack feedbackControl) : this()
        {
            studentFeedback = feedbackControl;

            // Đăng ký sự kiện nếu StudentFeedBack có sự kiện FeedbackSaved
            if (studentFeedback != null)
            {
                studentFeedback.FeedbackSaved += StudentFeedback_FeedbackSaved;
            }
        }
        private void StudentFeedback_FeedbackSaved(object sender, EventArgs e)
        {
            DisplayFeedbackData();
        }
        private void SetupDataGridViewColumns()
        {
            dataGridViewFeedback.AutoGenerateColumns = false;
            dataGridViewFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id" });
            dataGridViewFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "MSSV", HeaderText = "MSSV", DataPropertyName = "MSSV" });
            dataGridViewFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "TuyenXe", HeaderText = "Tuyến Xe", DataPropertyName = "TuyenXe" });
            dataGridViewFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "VanDe", HeaderText = "Vấn Đề", DataPropertyName = "VanDe" });
            dataGridViewFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "MoTa", HeaderText = "Mô Tả", DataPropertyName = "MoTa" });
            dataGridViewFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayPhanAnh", HeaderText = "Ngày Phản Ánh", DataPropertyName = "NgayPhanAnh" });
            // Thêm cột ComboBox cho trạng thái
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn
            {
                Name = "TrangThai",
                HeaderText = "Trạng Thái",
                DataPropertyName = "TrangThai",
                DataSource = new string[] { "Chưa xử lý", "Đã xử lý", "Đang xử lý" },
                ReadOnly = false
            };
            dataGridViewFeedback.Columns.Add(statusColumn);

            // Cho phép chỉnh sửa DataGridView
            dataGridViewFeedback.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        
        private void DisplayFeedbackData()
        {
            try
            {
                List<AdminViewFeedbackData> adminViewFeedbackData = GetFeedbackData();
                dataGridViewFeedback.DataSource = adminViewFeedbackData;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi hiển thị dữ liệu phản hồi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<AdminViewFeedbackData> GetFeedbackData()
        {
            List<AdminViewFeedbackData> feedbackList = new List<AdminViewFeedbackData>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, mssv, tuyen_xe, van_de, mo_ta, ngay_phan_anh, trang_thai FROM feedback";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                feedbackList.Add(new AdminViewFeedbackData
                                {
                                    Id = reader.GetInt32(0),
                                    MSSV = reader.GetString(1),
                                    TuyenXe = reader.GetString(2),
                                    VanDe = reader.GetString(3),
                                    MoTa = reader.GetString(4),
                                    NgayPhanAnh = reader.GetDateTime(5),
                                    TrangThai = reader.GetString(6)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi truy vấn dữ liệu phản hồi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return feedbackList;
        }

        private void dataGridViewFeedback_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu chỉnh sửa cột TrangThai
            if (e.ColumnIndex == dataGridViewFeedback.Columns["TrangThai"].Index && e.RowIndex >= 0)
            {
                try
                {
                    // Lấy ID và trạng thái mới
                    int feedbackId = Convert.ToInt32(dataGridViewFeedback.Rows[e.RowIndex].Cells["Id"].Value);
                    string newStatus = dataGridViewFeedback.Rows[e.RowIndex].Cells["TrangThai"].Value?.ToString();

                    if (!string.IsNullOrEmpty(newStatus))
                    {
                        // Cập nhật trạng thái vào cơ sở dữ liệu
                        UpdateFeedbackStatus(feedbackId, newStatus);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật trạng thái: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Làm mới dữ liệu để tránh hiển thị sai
                    DisplayFeedbackData();
                }
            }
        }
        private void UpdateFeedbackStatus(int feedbackId, string newStatus)
        {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE feedback SET trang_thai = @TrangThai WHERE Id = @Id";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@TrangThai", newStatus);
                            command.Parameters.AddWithValue("@Id", feedbackId);
                            command.ExecuteNonQuery();
                            DisplayFeedbackData(); // cập nhật lại DataGridView sau khi update

                    }
                }
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật trạng thái: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw; // Ném lỗi để CellEndEdit có thể làm mới dữ liệu
                }
        }

        private void dataGridViewFeedback_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
