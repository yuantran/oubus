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

namespace OUBus
{
    public partial class CheckerCheckStudent : UserControl
    {
        private SqlConnection connect;
        public CheckerCheckStudent()
        {
            InitializeComponent();
            // Khởi tạo kết nối (thay bằng chuỗi kết nối của bạn)
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=H:\\OUBus_Manage\\OUBus\\oubus.mdf;Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(connectionString);

            

            // Tải danh sách tuyến
            LoadRoutes();

            // Gán sự kiện
            cbxChonTuyen.SelectedIndexChanged += cbxChonTuyen_SelectedIndexChanged;
            dtpChonNgay.ValueChanged += dtpChonNgay_ValueChanged;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void LoadRoutes()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string query = "SELECT DISTINCT tuyen_xe FROM datve WHERE tuyen_xe IS NOT NULL";
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cbxChonTuyen.Items.Clear();
                        while (reader.Read())
                        {
                            cbxChonTuyen.Items.Add(reader["tuyen_xe"].ToString());
                        }
                    }
                }

                if (cbxChonTuyen.Items.Count > 0)
                    cbxChonTuyen.SelectedIndex = 0; // Chọn tuyến đầu tiên
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading routes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void LoadBookingData()
        {
            if (cbxChonTuyen.SelectedItem == null)
                return;

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string query = @"
                SELECT 
                    mssv AS MSSV,
                    profile_image as [Ảnh sinh viên],
                    CASE 
                        WHEN di_sang = 1 THEN N'Sáng'
                        WHEN di_trua = 1 THEN N'Trưa'
                        ELSE ''
                    END AS [Đi],
                    CASE 
                        WHEN ve_trua = 1 THEN N'Trưa'
                        WHEN ve_chieu = 1 THEN N'Chiều'
                        ELSE ''
                    END AS [Về]
                FROM datve
                WHERE tuyen_xe = @tuyenXe AND ngay_di = @ngayDi";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@tuyenXe", cbxChonTuyen.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ngayDi", dtpChonNgay.Value.Date);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        // Tùy chỉnh kích thước để ảnh hiển thị to hơn
                        dataGridView1.Columns["Ảnh sinh viên"].Width = 150; // Tăng chiều rộng cột ảnh
                        dataGridView1.RowTemplate.Height = 180; // Tăng chiều cao hàng
                        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None; // Tắt auto-size để giữ chiều cao cố định
                        dataGridView1.AllowUserToAddRows = false; // Tắt hàng trống
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading booking data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void cbxChonTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookingData();
        }

        private void dtpChonNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadBookingData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

    

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
