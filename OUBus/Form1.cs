using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace OUBus
{
    
    public partial class Form1 : Form
    {
	//Nhớ đổi lại
        SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=H:\OUBus_2\OUBus_2\OUBus\cafe.mdf;Integrated Security = True; Connect Timeout = 30");

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) //close
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e) //login_registerBtn
        {
            
            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }
        public bool emptyField()
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static class LoggedInUser
        {
            public static string MSSV { get; set; }
            public static string Phone { get; set; }
            public static byte[] Image { get; set; }
            public static string Username { get; set; }

        }

        private void button1_Click(object sender, EventArgs e) //login_btn_Click
        {
            if (emptyField())
            {
                MessageBox.Show("All fields are required to be filled.", "Error Message", MessageBoxButtons.OK);
            }
            else
            {
                if(connect.State== ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        string selectAccount = "SELECT * FROM users WHERE username = @usern AND password = @pass";

                        using (SqlCommand cmd = new SqlCommand(selectAccount, connect))
                        {
                            cmd.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@pass", login_password.Text.Trim());

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read()) // nếu có tài khoản
                                {
                                    string userRole = reader["role"].ToString();
                                    LoggedInUser.Username = reader["username"].ToString(); // ✅ lưu MSSV vào biến static
                                    LoggedInUser.MSSV = reader["mssv"].ToString(); // ✅ lưu MSSV vào biến static
                                    LoggedInUser.Phone = reader["phone"].ToString();
                                    LoggedInUser.Image = reader["profile_image"] as byte[];

                                    MessageBox.Show("Login successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    if (userRole == "Admin")
                                    {
                                        AdminMainForm adminForm = new AdminMainForm();
                                        adminForm.Show();
                                        this.Hide();
                                    }
                                    else if (userRole == "Student")
                                    {
                                        StudentMainForm studentMainForm = new StudentMainForm();
                                        studentMainForm.Show();
                                        this.Hide();
                                    }
                                    else if (userRole == "Checker")
                                    {
                                        CheckerMainForm checkerMainForm = new CheckerMainForm();
                                        checkerMainForm.Show();
                                        this.Hide();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Username/Password or there's no admin's approval.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
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
}
