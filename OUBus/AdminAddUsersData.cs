﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;


namespace OUBus
{
    public class AdminAddUsersData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\OUBus_2\OUBus_2\OUBus\cafe.mdf;Integrated Security=True;Connect Timeout=30");
        public int ID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Phone { set; get; }
        public string Role { set; get; }
        public string MSSV { set; get; }
        public byte[] Image { set; get; }
        public string DateRegistered { set; get; }


        public List<AdminAddUsersData> usersListData()
        {
            List<AdminAddUsersData> listData = new List<AdminAddUsersData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM users";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AdminAddUsersData userData = new AdminAddUsersData();
                            userData.ID = (int)reader["id"];
                            userData.Username = reader["username"].ToString();
                            userData.Password = reader["password"].ToString();
                            userData.Phone = reader["phone"].ToString();
                            userData.Role = reader["role"].ToString();
                            userData.MSSV = reader["mssv"].ToString();
                            userData.Image = reader["profile_image"] as byte[];
                            userData.DateRegistered = reader["date_reg"].ToString();

                            listData.Add(userData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection Failed" + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;
        }
    }
}
