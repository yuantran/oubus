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
    public partial class AdminDashboardForm : UserControl
    {
        private SqlConnection connect;

        public AdminDashboardForm()
        {
            InitializeComponent();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=H:\\OUBus_Manage\\OUBus\\oubus.mdf;Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(connectionString);

            // Tải số phản ánh
            LoadFeedbackCount();
        }
        private void LoadFeedbackCount()
        {
            if (lblSoPhanAnh == null)
            {
                MessageBox.Show("Label lblPhanAnh chưa được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                // Giả định ngày là 05/05/2025
                DateTime now = DateTime.Now;

                string query = @"
                    SELECT COUNT(*) 
                    FROM feedback 
                    WHERE CAST(ngay_phan_anh AS DATE) = @ngayPhanAnh";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@ngayPhanAnh", now.Date);

                    int count = (int)cmd.ExecuteScalar();
                    lblSoPhanAnh.Text = count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải số phản ánh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect != null && connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }
            private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
