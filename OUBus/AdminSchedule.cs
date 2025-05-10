using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace OUBus
{
    public partial class AdminSchedule : UserControl
    {
        //vô lấy lại đường dẫn của oubus.mdf
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\OUBus_2\OUBus_2\OUBus\oubus.mdf;Integrated Security=True;Connect Timeout=30");
        public AdminSchedule()
        {
            InitializeComponent();
            dtpNgayChay.CustomFormat = "dddd, dd/MM/yyyy";
            dtpNgayChay.MinDate = DateTime.Today;

            displayData();
        }


        public bool emptyFields()
        {
            if (chuyen_id.Text == "" || bienSoXe.Text == "" 
                || tuyen.SelectedIndex == -1 || taiXe.Text == ""
                 || caChay.SelectedIndex == -1 )
            {
                return true;
            }
            else
            {
                return false;
            } 
                
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void displayData()
        {
            AdminScheduleData prodData = new AdminScheduleData();
            List<AdminScheduleData> listData = prodData.productsListData();

            dataGridView1.DataSource = listData;
            

        }
        private void adminAddUsers_deleteBtn_Click(object sender, EventArgs e) // delete product 
        {
            if (emptyFields())
            {
                MessageBox.Show("All fields are requried to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to Delete Chuyen ID: " + chuyen_id.Text.Trim() + "?"
                    , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE chuyenxe SET date_delete = @dateDelete WHERE chuyen_id = @chuyenId";
                            DateTime today = DateTime.Today;

                            using (SqlCommand updateD = new SqlCommand(updateData, connect))
                            {

                                updateD.Parameters.AddWithValue("@dateDelete", today);
                                updateD.Parameters.AddWithValue("@chuyenId", chuyen_id.Text.Trim());

                                updateD.ExecuteNonQuery();
                                clearFields();

                                MessageBox.Show("Removed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayData();

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

        private void adminAddUsers_clearBtn_Click(object sender, EventArgs e) // clear dữ liệu
        {
            clearFields();
        }

        private void adminAddUsers_updateBtn_Click(object sender, EventArgs e) // update lịch
        {
            if(emptyFields())
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure want to Update Chuyen ID: " + chuyen_id.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check==DialogResult.Yes)
                {
                    if(connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE chuyenxe SET bien_so_xe = @bienSoXe" +
                                ", tuyen_xe = @tuyen, tai_xe= @taiXe, ca_chay=@caChay" +
                                ", ngay_chay=@ngayChay, date_update = @dateUpdate WHERE chuyen_id =@chuyenId";
                            DateTime today = DateTime.Today;

                            using (SqlCommand updateD= new SqlCommand(updateData, connect))
                            {
                                updateD.Parameters.AddWithValue("@bienSoXe", bienSoXe.Text.Trim());
                                updateD.Parameters.AddWithValue("@tuyen", tuyen.Text.Trim());
                                updateD.Parameters.AddWithValue("@taiXe", taiXe.Text.Trim());
                                updateD.Parameters.AddWithValue("@caChay", caChay.Text.Trim());
                                updateD.Parameters.AddWithValue("@ngayChay", dtpNgayChay.Value);
                                updateD.Parameters.AddWithValue("@dateUpdate", today);
                                updateD.Parameters.AddWithValue("@chuyenId", chuyen_id.Text.Trim());

                                updateD.ExecuteNonQuery();
                                clearFields();

                                MessageBox.Show("Updated Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayData();
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

        private void adminAddUsers_addBtn_Click(object sender, EventArgs e) // add chuyến xe
        {
            if (emptyFields())
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        
                        string selectProdID = "SELECT * FROM chuyenxe WHERE chuyen_id = @chuyenId";

                        using (SqlCommand selectPID = new SqlCommand(selectProdID, connect))
                        {
                            selectPID.Parameters.AddWithValue("@chuyenId", chuyen_id.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(selectPID);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if(table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Chuyen ID: " + chuyen_id.Text.Trim() + " is taken already", "Error Message" 
                                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }   
                            else
                            {
                                string insertData = "INSERT INTO chuyenxe (chuyen_id, bien_so_xe, tuyen_xe, tai_xe, " +
                                    " ca_chay,ngay_chay, taixe_image, date_insert) VALUES(@chuyenId, @bienSoXe, @tuyen, @taiXe, @caChay , @ngayChay, @taiXeImage, @dateInsert )";

                                DateTime today = DateTime.Today;

                                //sửa lại đường dẫn ở dưới
                                string path = Path.Combine(@"H:\OUBus_Manage\OUBus\Driver_Directory"
                                    + chuyen_id.Text.Trim()+ ".jpg");

                                string directoryPath = Path.GetDirectoryName(path);

                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }
                                if (string.IsNullOrEmpty(taiXe_image.ImageLocation))
                                {
                                    MessageBox.Show("Vui lòng thêm ảnh tài xế!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                File.Copy(taiXe_image.ImageLocation, path, true);

                                using (SqlCommand cmd = new SqlCommand(insertData, connect)) 
                                {
                                    cmd.Parameters.AddWithValue("@chuyenId", chuyen_id.Text.Trim());
                                    cmd.Parameters.AddWithValue("@bienSoXe", bienSoXe.Text.Trim());
                                    cmd.Parameters.AddWithValue("@tuyen", tuyen.Text.Trim());
                                    cmd.Parameters.AddWithValue("@taiXe", taiXe.Text.Trim());
                                    cmd.Parameters.AddWithValue("@caChay", caChay.Text.Trim());
                                    cmd.Parameters.AddWithValue("@ngayChay", dtpNgayChay.Value);
                                    cmd.Parameters.AddWithValue("@taiXeImage", path);
                                    cmd.Parameters.AddWithValue("@dateInsert", today);

                                    cmd.ExecuteNonQuery();
                                    clearFields();
                                    MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    displayData();
                                }    
                                  
                            }    
                        }    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed connection: " + ex, "Error Message"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void adminAddProducts_importBtn_Click(object sender, EventArgs e)// add ảnh tài xế
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Filter (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    taiXe_image.ImageLocation = imagePath;
                }    

            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clearFields()
        {
            chuyen_id.Text = "";
            bienSoXe.Text = "";
            tuyen.SelectedIndex = -1;
            taiXe.Text = "";
            caChay.SelectedIndex = -1;
            dtpNgayChay.Value = DateTime.Today;
            taiXe_image.Image = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row= dataGridView1.Rows[e.RowIndex];
                chuyen_id.Text = row.Cells[1].Value.ToString();
                bienSoXe.Text = row.Cells[2].Value.ToString();
                tuyen.Text = row.Cells[3].Value.ToString();
                taiXe.Text = row.Cells[4].Value.ToString();
                caChay.Text = row.Cells[5].Value.ToString();
                dtpNgayChay.Value = Convert.ToDateTime(row.Cells[6].Value);


                string imagepath = row.Cells[7].Value.ToString();
                try
                {
                    if (imagepath != null)
                    {
                        taiXe_image.Image = Image.FromFile(imagepath);

                    }
                    else
                    {
                        taiXe_image.Image = null;
                    }    
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error Image: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                   

            }
        }

        private void dtpNgayChay_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
