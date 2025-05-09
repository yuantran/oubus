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
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=H:\\OUBus_2\\OUBus_2\\OUBus\\cafe.mdf;Integrated Security=True;Connect Timeout=30";
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

                string query = "SELECT DISTINCT tuyen_xe FROM chuyenxe WHERE tuyen_xe IS NOT NULL";
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
                    mssv,
                    CASE 
                        WHEN di_sang = 1 THEN 'Sáng'
                        WHEN di_trua = 1 THEN 'Trưa'
                        ELSE ''
                    END AS DepartureTime,
                    CASE 
                        WHEN ve_trua = 1 THEN 'Trưa'
                        WHEN ve_chieu = 1 THEN 'Chiều'
                        ELSE ''
                    END AS ReturnTime
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string mssv = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                LoadProfileImage(mssv);
            }
            else
            {
                ptbStudent.Image = null;
            }
        }

        private void LoadProfileImage(string mssv)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                // Ưu tiên lấy profile_image từ datve
                string query = @"
                SELECT profile_image 
                FROM datve 
                WHERE mssv = @mssv AND ngay_di = @ngayDi AND tuyen_xe = @tuyenXe";
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    cmd.Parameters.AddWithValue("@ngayDi", dtpChonNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@tuyenXe", cbxChonTuyen.SelectedItem.ToString());

                    var imageData = cmd.ExecuteScalar() as byte[];

                    if (imageData != null && imageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            ptbStudent.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // Nếu không có trong datve, lấy từ users
                        query = "SELECT profile_image FROM users WHERE mssv = @mssv";
                        cmd.CommandText = query;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@mssv", mssv);

                        imageData = cmd.ExecuteScalar() as byte[];
                        if (imageData != null && imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                ptbStudent.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            ptbStudent.Image = null; // Ảnh mặc định
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ptbStudent.Image = null;
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }
    

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
