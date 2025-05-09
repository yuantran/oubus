using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace OUBus
{
    class AdminThemChuyenData
    {
        public int ID { set; get; } //0
        public string ChuyenId { set; get; } //1
        public string BienSoXe { set; get; } //2
        public string Tuyen { set; get; } //3
        public string TaiXe { set; get; } //4
        public string CaChay { set; get; } //5
        public string NgayChay { set; get; } //6
        public string TaiXeImage { set; get; } //7
        public string DateInsert { set; get; } //8
        public string DateUpdate { set;get; } //9

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\OUBus_2\OUBus_2\OUBus\cafe.mdf;Integrated Security=True;Connect Timeout=30");
        
        public List<AdminThemChuyenData> productsListData()
        {
            List<AdminThemChuyenData> listData=    new List<AdminThemChuyenData>();
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM chuyenxe WHERE date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while(reader.Read())
                        {
                            AdminThemChuyenData apd = new AdminThemChuyenData();  
                            apd.ID = (int)reader["id"];
                            apd.ChuyenId= reader["chuyen_id"].ToString();
                            apd.BienSoXe= reader["bien_so_xe"].ToString();
                            apd.Tuyen = reader["tuyen_xe"].ToString();
                            apd.TaiXe = reader["tai_xe"].ToString();
                            apd.CaChay = reader["ca_chay"].ToString();
                            apd.NgayChay = reader["ngay_chay"].ToString();
                            apd.TaiXeImage = reader["taixe_image"].ToString();
                            apd.DateInsert= reader["date_insert"].ToString();
                            apd.DateUpdate = reader["date_update"].ToString();

                            listData.Add(apd);
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Failed connection:" + ex);
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
