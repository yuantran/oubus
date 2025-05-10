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
using static OUBus.StudentBooking;


namespace OUBus
{
    public partial class AdminViewBooking : UserControl
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\OUBus_Manage\OUBus\cafe.mdf;Integrated Security=True;Connect Timeout=30";
        private StudentBooking studentBooking; // Tham chiếu đến StudentBooking
        public AdminViewBooking()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
            LoadTuyenXeData();

            if (!DesignMode)
            {
                DisplayBookingData();
                UpdateBookingStatistics();
            }

        }
        public AdminViewBooking(StudentBooking bookingControl) : this()
        {
            studentBooking = bookingControl;

            if (studentBooking != null)
            {
                studentBooking.BookingSaved += StudentBooking_BookingSaved;
            }

            // Gọi DisplayBookingData lại nếu cần, tùy theo yêu cầu
            DisplayBookingData();
        }
        private void StudentBooking_BookingSaved(object sender, EventArgs e)
        {
            // Cập nhật DataGridView khi có vé mới được lưu
            DisplayBookingData();
            UpdateBookingStatistics();
        }
        private void SetupDataGridViewColumns()
        {
            dataGridViewBookings.AutoGenerateColumns = false;
            dataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id" });
            dataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "MSSV", HeaderText = "MSSV", DataPropertyName = "MSSV" });
            dataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "TuyenXe", HeaderText = "Tuyến Xe", DataPropertyName = "TuyenXe" });
            dataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Số Điện Thoại", DataPropertyName = "Phone" });
            dataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayDi", HeaderText = "Ngày Đi", DataPropertyName = "NgayDi" });
            dataGridViewBookings.Columns.Add(new DataGridViewCheckBoxColumn { Name = "DiSang", HeaderText = "Đi Sáng", DataPropertyName = "DiSang" });
            dataGridViewBookings.Columns.Add(new DataGridViewCheckBoxColumn { Name = "DiTrua", HeaderText = "Đi Trưa", DataPropertyName = "DiTrua" });
            dataGridViewBookings.Columns.Add(new DataGridViewCheckBoxColumn { Name = "VeTrua", HeaderText = "Về Trưa", DataPropertyName = "VeTrua" });
            dataGridViewBookings.Columns.Add(new DataGridViewCheckBoxColumn { Name = "VeChieu", HeaderText = "Về Chiều", DataPropertyName = "VeChieu" });

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                Name = "ProfileImage",
                HeaderText = "Hình Ảnh",
                DataPropertyName = "ProfileImage",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dataGridViewBookings.Columns.Add(imageColumn);
        }

        private void LoadTuyenXeData()
        {
            // Tải danh sách tuyến xe vào cbxChonTuyen
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT tuyen_xe FROM datve"; // 
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            cbxChonTuyen.Items.Clear();
                            while (reader.Read())
                            {
                                cbxChonTuyen.Items.Add(reader["tuyen_xe"].ToString());
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi tải danh sách tuyến xe: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayBookingData()
        {
            // Tạo instance tạm thời của StudentBooking để gọi GetDatVeData nếu cần
            List<DatVeData> bookingData = StudentBooking.GetDatVeData();
            // Lấy tất cả vé
            // Nếu chỉ muốn vé của người dùng hiện tại:
            // List<DatVeData> bookingData = tempBooking.GetDatVeData(LoggedInUser.MSSV);

            dataGridViewBookings.DataSource = null; // Xóa nguồn dữ liệu cũ
            dataGridViewBookings.Columns.Clear(); // Xóa cột cũ


            // Thêm cột thủ công
            dataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id" });
            dataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "MSSV", HeaderText = "MSSV", DataPropertyName = "MSSV" });
            dataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "TuyenXe", HeaderText = "Tuyến Xe", DataPropertyName = "TuyenXe" });
            dataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Số Điện Thoại", DataPropertyName = "Phone" });
            dataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayDi", HeaderText = "Ngày Đi", DataPropertyName = "NgayDi" });
            dataGridViewBookings.Columns.Add(new DataGridViewCheckBoxColumn { Name = "DiSang", HeaderText = "Đi Sáng", DataPropertyName = "DiSang" });
            dataGridViewBookings.Columns.Add(new DataGridViewCheckBoxColumn { Name = "DiTrua", HeaderText = "Đi Trưa", DataPropertyName = "DiTrua" });
            dataGridViewBookings.Columns.Add(new DataGridViewCheckBoxColumn { Name = "VeTrua", HeaderText = "Về Trưa", DataPropertyName = "VeTrua" });
            dataGridViewBookings.Columns.Add(new DataGridViewCheckBoxColumn { Name = "VeChieu", HeaderText = "Về Chiều", DataPropertyName = "VeChieu" });

            // Thêm cột hình ảnh
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                Name = "ProfileImage",
                HeaderText = "Hình Ảnh",
                DataPropertyName = "ProfileImage",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };

            dataGridViewBookings.Columns.Add(imageColumn);

            dataGridViewBookings.DataSource = bookingData;
        }

        private void UpdateBookingStatistics()
        {
            try
            {
                if (cbxChonTuyen.SelectedItem == null || dtpChonNgay.Value == null)
                {
                    lblDiSang.Text = "SL đi sáng: 0";
                    lblDiTrua.Text = "SL đi trưa: 0";
                    lblVeTrua.Text = "SL về trưa: 0";
                    lblVeChieu.Text = "SL về chiều: 0";
                    return;
                }

                string selectedTuyen = cbxChonTuyen.SelectedItem.ToString();
                DateTime selectedDate = dtpChonNgay.Value.Date;

                // GỌI TRỰC TIẾP luôn
                List<DatVeData> bookingData = GetDatVeData()
                    .Where(b => b.TuyenXe == selectedTuyen && b.NgayDi.Date == selectedDate)
                    .ToList();

                lblDiSang.Text = "SL đi sáng:" +bookingData.Count(b => b.DiSang).ToString() ;
                lblDiTrua.Text = "SL đi trưa:" +bookingData.Count(b => b.DiTrua).ToString();
                lblVeTrua.Text = "SL về trưa:"+ bookingData.Count(b => b.VeTrua).ToString();
                lblVeChieu.Text = "SL về chiều:" +bookingData.Count(b => b.VeChieu).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thống kê số liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblDiSang.Text = "0";
                lblDiTrua.Text = "0";
                lblVeTrua.Text = "0";
                lblVeChieu.Text = "0";
            }
        }

        private void cbxChonTuyen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateBookingStatistics();
        }

        private void dtpChonNgay_ValueChanged_1(object sender, EventArgs e)
        {
            UpdateBookingStatistics();
        }
    }
}
