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
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\OUBus_2\OUBus_2\OUBus\cafe.mdf;Integrated Security=True;Connect Timeout=30");
        public AdminAddUsers()
        {
            InitializeComponent();

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

     
        public bool emptyField()
        {
            if (adminAddUsers_username.Text == "" || adminAddUsers_password.Text == "" || adminAddUsers_role.Text == "" || adminAddUsers_status.Text == "" || adminAddUsers_imageView.Image==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)//adminAddUsers_addBtn
        {
            if(emptyField())
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(connect.State== ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        //Check username if existing already
                        string selectUsern = "SELECT * FROM users WHERE username= @usern";


                        using (SqlCommand checkUsern = new SqlCommand(selectUsern, connect))
                        {
                            checkUsern.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUsern);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if(table.Rows.Count>=1)
                            {
                                string usern= adminAddUsers_username.Text.Substring(0,1).ToUpper()+ adminAddUsers_username.Text.Substring(1);
                                MessageBox.Show(usern+" is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                string insertData = "INSERT INTO users (username, password,profile_image, role, status, date_reg)" +
                                    "VALUES(@usern, @pass, @image, @role, @status, @date)";


                                DateTime today = DateTime.Today;
                                //Đổi đường dẫn ở dưới lại 
                                string path = Path.Combine(@"H:\OUBus_2\OUBus_2\OUBus\User_Directory", adminAddUsers_username.Text.Trim() + ".jpg");

                                string directoryPath = Path.GetDirectoryName(path);

                                if(!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);   
                                }

                                File.Copy(adminAddUsers_imageView.ImageLocation, path, true);

                                using(SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", adminAddUsers_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@image", "");
                                    cmd.Parameters.AddWithValue("@role", adminAddUsers_role.Text.Trim());
                                    cmd.Parameters.AddWithValue("@status", adminAddUsers_status.Text.Trim());
                                    cmd.Parameters.AddWithValue("@date", today);

                                    cmd.ExecuteNonQuery();
                                    clearField();

                                    MessageBox.Show("Added successfully!", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    displayAddUsersData();
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: "+ex,"Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                    finally
                    {

                    }
                }
            }
                
        }

        private void button3_Click(object sender, EventArgs e) //adminAddUsers_updateBtn
        {
            if (emptyField())
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure to want to Update Username: " + adminAddUsers_username.Text.Trim()
                    + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE users SET username =@usern, password= @pass, role= @role, status= @status WHERE id=@id";

                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", adminAddUsers_password.Text.Trim());
                                cmd.Parameters.AddWithValue("@role", adminAddUsers_role.Text.Trim());
                                cmd.Parameters.AddWithValue("@status", adminAddUsers_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@id", adminAddUsers_username.Text.Trim());

                                cmd.ExecuteNonQuery();
                                clearField();

                                MessageBox.Show("Updated successfully! ", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

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


        public void clearField()
        {
            adminAddUsers_username.Text = "";
            adminAddUsers_password.Text = "";
            adminAddUsers_role.SelectedIndex = -1;
            adminAddUsers_status.SelectedIndex = -1;
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
                              
                                cmd.Parameters.AddWithValue("@id", adminAddUsers_username.Text.Trim());

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
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            id = (int) row.Cells[0].Value;
            adminAddUsers_username.Text = row.Cells[1].Value.ToString();
            adminAddUsers_password.Text = row.Cells[2].Value.ToString();
            adminAddUsers_role.Text = row.Cells[3].Value.ToString();
            adminAddUsers_status.Text = row.Cells[4].Value.ToString();

            string imagePath = row.Cells[5].Value.ToString();

            try
            {
                if (imagePath != null)
                {
                    adminAddUsers_imageView.Image = Image.FromFile(imagePath);
                }
                else
                {
                    adminAddUsers_imageView.Image = null;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("No Image :3", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

    
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
