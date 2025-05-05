﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace OUBus
{
    public partial class AdminAddProducts : UserControl
    {
        //vô lấy lại đường dẫn của cafe.mdf
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\OUBus_2\OUBus_2\OUBus\cafe.mdf;Integrated Security=True;Connect Timeout=30");
        public AdminAddProducts()
        {
            InitializeComponent();
            displayData();
        }


        public bool emptyFields()
        {
            if (adminAddProducts_id.Text == "" || adminAddProducts_name.Text == "" 
                || adminAddProducts_type.SelectedIndex == -1 || adminAddProducts_stock.Text == ""
                || adminAddProducts_price.Text == "" || adminAddProducts_status.SelectedIndex == -1)
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
            AdminAddProductsData prodData = new AdminAddProductsData();
            List<AdminAddProductsData> listData = prodData.productsListData();

            dataGridView1.DataSource=listData;
        }
        private void adminAddUsers_deleteBtn_Click(object sender, EventArgs e) // delete product 
        {
            if (emptyFields())
            {
                MessageBox.Show("All fields are requried to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to Delete Product ID: " + adminAddProducts_id.Text.Trim() + "?"
                    , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE products SET date_delete = @dateDelete WHERE prod_id = @prodID";
                            DateTime today = DateTime.Today;

                            using (SqlCommand updateD = new SqlCommand(updateData, connect))
                            {

                                updateD.Parameters.AddWithValue("@dateDelete", today);
                                updateD.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());

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

        private void adminAddUsers_clearBtn_Click(object sender, EventArgs e) // clear product 
        {
            clearFields();
        }

        private void adminAddUsers_updateBtn_Click(object sender, EventArgs e) // update product
        {
            if(emptyFields())
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure want to Update Product ID: " + adminAddProducts_id.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check==DialogResult.Yes)
                {
                    if(connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE products SET prod_name = @prodName" +
                                ", prod_type = @prodType, prod_stock= @prodStock, prod_price = @prodPrice, prod_status=@prodStatus" +
                                ", date_update = @dateUpdate WHERE prod_id =@prodID";
                            DateTime today = DateTime.Today;

                            using (SqlCommand updateD= new SqlCommand(updateData, connect))
                            {
                                updateD.Parameters.AddWithValue("@prodName", adminAddProducts_name.Text.Trim());
                                updateD.Parameters.AddWithValue("@prodType", adminAddProducts_type.Text.Trim());
                                updateD.Parameters.AddWithValue("@prodStock", adminAddProducts_stock.Text.Trim());
                                updateD.Parameters.AddWithValue("@prodPrice", adminAddProducts_price.Text.Trim());
                                updateD.Parameters.AddWithValue("@prodStatus", adminAddProducts_status.Text.Trim());
                                updateD.Parameters.AddWithValue("@dateUpdate", today);
                                updateD.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());

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

        private void adminAddUsers_addBtn_Click(object sender, EventArgs e) // add product
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

                        // Check nếu sản phẩm sẵn sàng
                        string selectProdID = "SELECT * FROM products WHERE prod_id = @prodID";
                        
                        using (SqlCommand selectPID = new SqlCommand(selectProdID, connect))
                        {
                            selectPID.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(selectPID);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if(table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Product ID: " + adminAddProducts_id.Text.Trim() + "is taken already", "Error Message" 
                                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }   
                            else
                            {
                                string insertData = "INSERT INTO products (prod_id, prod_name, prod_type, prod_stock, " +
                                    "prod_price, prod_status, prod_image, date_insert) VALUES(@prodID, @prodName, @prodType, @prodStock" +
                                    ", @prodPrice, @prodStatus, @prodImage, @dateInsert)";

                                DateTime today = DateTime.Today;

                                //sửa lại đường dẫn ở dưới
                                string path = Path.Combine(@"H:\OUBus_2\OUBus_2\OUBus\Product_Directory\"
                                    + adminAddProducts_id.Text.Trim()+ ".jpg");

                                string directoryPath = Path.GetDirectoryName(path);

                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }
                                if (string.IsNullOrEmpty(adminAddProducts_imageView.ImageLocation))
                                {
                                    MessageBox.Show("Please select an image before adding the product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                File.Copy(adminAddProducts_imageView.ImageLocation, path, true);

                                using (SqlCommand cmd = new SqlCommand(insertData, connect)) 
                                {
                                    cmd.Parameters.AddWithValue("@prodId", adminAddProducts_id.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodName", adminAddProducts_name.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodType", adminAddProducts_type.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodStock", adminAddProducts_stock.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodPrice", adminAddProducts_price.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodStatus", adminAddProducts_status.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodImage", path);
                                    cmd.Parameters.AddWithValue("@dateInsert", today);

                                    cmd.ExecuteNonQuery();
                                    displayData();
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

        private void adminAddProducts_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Filter (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    adminAddProducts_imageView.ImageLocation = imagePath;
                }    

            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clearFields()
        {
            adminAddProducts_id.Text = "";
            adminAddProducts_name.Text = "";
            adminAddProducts_type.SelectedIndex = -1;
            adminAddProducts_stock.Text = "";
            adminAddProducts_price.Text = "";
            adminAddProducts_status.SelectedIndex = -1;
            adminAddProducts_imageView.Image = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row= dataGridView1.Rows[e.RowIndex];
                adminAddProducts_id.Text = row.Cells[1].Value.ToString();
                adminAddProducts_name.Text = row.Cells[2].Value.ToString();
                adminAddProducts_type.Text = row.Cells[3].Value.ToString();
                adminAddProducts_stock.Text = row.Cells[4].Value.ToString();
                adminAddProducts_price.Text = row.Cells[5].Value.ToString();
                adminAddProducts_status.Text = row.Cells[6].Value.ToString();

                string imagepath = row.Cells[7].Value.ToString();
                try
                {
                    if (imagepath != null)
                    {
                        adminAddProducts_imageView.Image = Image.FromFile(imagepath);

                    }
                    else
                    {
                        adminAddProducts_imageView.Image = null;
                    }    
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error Image: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                   

            }
        }
    }
}
