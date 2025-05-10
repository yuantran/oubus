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
    public partial class AdminAddUsers : UserControl
    {
        //vô lấy lại đường dẫn của cafe.mdf
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\OUBus_Manage\OUBus\cafe.mdf;Integrated Security=True;Connect Timeout=30";
        private readonly string userDirectoryPath = @"H:\OUBus_Manage\OUBus\User_Directory";
        private SqlConnection connect;
        public AdminAddUsers()
        {
            InitializeComponent();
            connect = new SqlConnection(connectionString);
            displayAddUsersData();

        }

        public void displayAddUsersData()
        {
            AdminAddUsersData usersData = new AdminAddUsersData();
            List<AdminAddUsersData> listData = usersData.usersListData();

            dataGridView1.DataSource = listData;
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private byte[] ConvertImageToByteArray(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                return null;

            return File.ReadAllBytes(imagePath);
        }
        private string SaveImageToDirectory(string username, string sourceImagePath)
        {
            string path = Path.Combine(userDirectoryPath, username + ".jpg");
            string directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            File.Copy(sourceImagePath, path, true);
            return path;
        }


        public bool emptyField()
        {
            if (adminAddUsers_username.Text == "" || adminAddUsers_password.Text == "" || adminAddUsers_phone.Text == ""  || adminAddUsers_role.Text == "" || adminAddUsers_imageView.Image==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e) // adminAddUsers_addBtn
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @usern";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show($"{adminAddUsers_username.Text} is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string path = SaveImageToDirectory(adminAddUsers_username.Text.Trim(), adminAddUsers_imageView.ImageLocation);
                    byte[] imageData = ConvertImageToByteArray(path); // Convert image to byte array

                    string insertQuery = "INSERT INTO users (username, password, profile_image, phone, role, mssv, date_reg) VALUES (@usern, @pass, @image, @phone, @role, @mssv, @date)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connect))
                    {
                        insertCmd.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@pass", adminAddUsers_password.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@image", imageData ?? (object)DBNull.Value); // Handle null image
                        insertCmd.Parameters.AddWithValue("@phone", adminAddUsers_phone.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@role", adminAddUsers_role.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@mssv", txtMSSV.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@date", DateTime.Today);

                        insertCmd.ExecuteNonQuery();
                    }

                    clearField();
                    MessageBox.Show("Added successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayAddUsersData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e) // adminAddUsers_updateBtn
        {
            if (emptyField())
            {
                MessageBox.Show("All required fields must be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to Update Username: " + adminAddUsers_username.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    connect.Open();

                    string updateData;
                    SqlCommand cmd;

                    // Nếu có ảnh mới (từ ImageLocation)
                    if (!string.IsNullOrEmpty(adminAddUsers_imageView.ImageLocation) && File.Exists(adminAddUsers_imageView.ImageLocation))
                    {
                        string imagePath = SaveImageToDirectory(adminAddUsers_username.Text.Trim(), adminAddUsers_imageView.ImageLocation);
                        byte[] imageData = ConvertImageToByteArray(imagePath);

                        updateData = "UPDATE users SET username = @usern, password = @pass, profile_image = @image, phone = @phone, role = @role, mssv = @mssv WHERE id = @id";
                        cmd = new SqlCommand(updateData, connect);
                        cmd.Parameters.AddWithValue("@image", imageData ?? (object)DBNull.Value);
                    }
                    else
                    {
                        // Không cập nhật profile_image
                        updateData = "UPDATE users SET username = @usern, password = @pass, phone = @phone, role = @role, mssv = @mssv WHERE id = @id";
                        cmd = new SqlCommand(updateData, connect);
                    }

                    cmd.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", adminAddUsers_password.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", adminAddUsers_phone.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", adminAddUsers_role.Text.Trim());
                    cmd.Parameters.AddWithValue("@mssv", string.IsNullOrEmpty(txtMSSV.Text.Trim()) ? (object)DBNull.Value : txtMSSV.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    clearField();

                    MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayAddUsersData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                        connect.Close();
                }
            }
        }
        public void clearField()
        {
            adminAddUsers_username.Text = "";
            adminAddUsers_password.Text = "";
            adminAddUsers_phone.Text = "";
            adminAddUsers_role.SelectedIndex = -1;
            txtMSSV.Text = "";

            adminAddUsers_imageView.Image = null;
        }

        private void button4_Click(object sender, EventArgs e) //adminAddUsers_clearBtn
        {
            clearField();
        }

        private void button2_Click(object sender, EventArgs e) //adminAddUsers_deleteBtn
        {
            if (emptyField())
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure to want to Delete Username: " + adminAddUsers_username.Text.Trim()
                    + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string deleteData = "DELETE FROM users WHERE id =@id";

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                              
                                cmd.Parameters.AddWithValue("@id", id);

                                cmd.ExecuteNonQuery();
                                clearField();

                                MessageBox.Show("Deleted successfully! ", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                displayAddUsersData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void adminAddUsers_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "";

                if(dialog.ShowDialog()==DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    adminAddUsers_imageView.ImageLocation = imagePath;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id = (int)row.Cells[0].Value;
                adminAddUsers_username.Text = row.Cells[1].Value.ToString();
                adminAddUsers_password.Text = row.Cells[2].Value.ToString();
                adminAddUsers_phone.Text = row.Cells[3].Value.ToString();
                adminAddUsers_role.Text = row.Cells[4].Value.ToString();
                txtMSSV.Text = row.Cells[5].Value.ToString();

                // Tải hình ảnh từ cơ sở dữ liệu
                try
                {
                    connect.Open();
                    string query = "SELECT profile_image FROM users WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        byte[] imageData = cmd.ExecuteScalar() as byte[];

                        if (imageData != null && imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                adminAddUsers_imageView.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            adminAddUsers_imageView.Image = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adminAddUsers_imageView.Image = null;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void adminAddUsers_role_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = adminAddUsers_role.SelectedItem?.ToString();

            // Hiển thị txtMSSV và lblMSSV nếu vai trò là Student hoặc Checker
            bool showMSSV = selectedRole == "Student" || selectedRole == "Checker";
            txtMSSV.Visible = showMSSV;
            lblMSSV.Visible = showMSSV;
        }
    }
}
