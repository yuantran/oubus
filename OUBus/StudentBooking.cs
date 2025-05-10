using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OUBus.Form1;

namespace OUBus
{
    public partial class StudentBooking : UserControl
    {
        public StudentBooking()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void chonThoiGianDi()
        {
            tblThoiGianDi.SuspendLayout(); // Ngừng layout để đỡ giật
            tblThoiGianDi.Controls.Clear();
            tblThoiGianDi.ColumnCount = 3;
            tblThoiGianDi.RowCount = 6;

            // Set size %
            for (int i = 0; i < 3; i++)
                tblThoiGianDi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            for (int i = 0; i < 6; i++)
                tblThoiGianDi.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));

            DateTime today = DateTime.Today;
            // Tìm thứ 2 tuần sau
            int daysUntilNextMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            DateTime startDate = today.AddDays(daysUntilNextMonday); // Tuần sau

            for (int i = 0; i < 6; i++)
            {
                DateTime day = startDate.AddDays(i);
                string ngay = day.ToString("dddd, dd/MM", new System.Globalization.CultureInfo("vi-VN"));

                // Tạo dòng
                tblThoiGianDi.Controls.Add(new Label() { Text = ngay, TextAlign = ContentAlignment.MiddleLeft }, 0, i);

                CheckBox chkSang = new CheckBox() { Name = $"chk_Di_Sang_{i}", Tag = i }; // Tag để lưu index ngày
                CheckBox chkTrua = new CheckBox() { Name = $"chk_Di_Trua_{i}", Tag = i };
                chkSang.CheckedChanged += CheckBoxDi_CheckedChanged; // Thêm sự kiện
                chkTrua.CheckedChanged += CheckBoxDi_CheckedChanged; // Thêm sự kiện

                tblThoiGianDi.Controls.Add(chkSang, 1, i);
                tblThoiGianDi.Controls.Add(chkTrua, 2, i);
            }

            tblThoiGianDi.ResumeLayout(); // Bật layout lại
        }

        private void chonThoiGianVe()
        {
            tblThoiGianVe.SuspendLayout(); // Ngừng layout để đỡ giật
            tblThoiGianVe.Controls.Clear();
            tblThoiGianVe.ColumnCount = 3;
            tblThoiGianVe.RowCount = 6;

            // Set size %
            for (int i = 0; i < 3; i++)
                tblThoiGianVe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            for (int i = 0; i < 6; i++)
                tblThoiGianVe.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));

            DateTime today = DateTime.Today;
            // Tìm thứ 2 tuần sau
            int daysUntilNextMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            DateTime startDate = today.AddDays(daysUntilNextMonday); // Tuần sau

            for (int i = 0; i < 6; i++)
            {
                DateTime day = startDate.AddDays(i);
                string ngay = day.ToString("dddd, dd/MM", new System.Globalization.CultureInfo("vi-VN"));

                // Tạo dòng
                tblThoiGianVe.Controls.Add(new Label() { Text = ngay, TextAlign = ContentAlignment.MiddleLeft }, 0, i);

                CheckBox chkTrua = new CheckBox() { Name = $"chk_Ve_Trua_{i}", Tag = i }; // Tag để lưu index ngày
                CheckBox chkChieu = new CheckBox() { Name = $"chk_Ve_Chieu_{i}", Tag = i };
                chkTrua.CheckedChanged += CheckBoxVe_CheckedChanged; // Thêm sự kiện
                chkChieu.CheckedChanged += CheckBoxVe_CheckedChanged; // Thêm sự kiện

                tblThoiGianVe.Controls.Add(chkTrua, 1, i);
                tblThoiGianVe.Controls.Add(chkChieu, 2, i);
            }

            tblThoiGianVe.ResumeLayout(); // Bật layout lại
        }
        private void CheckBoxDi_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            int dayIndex = (int)chk.Tag; // Lấy index ngày

            // Lấy các CheckBox của ngày đó
            CheckBox chkSang = tblThoiGianDi.Controls[$"chk_Di_Sang_{dayIndex}"] as CheckBox;
            CheckBox chkTrua = tblThoiGianDi.Controls[$"chk_Di_Trua_{dayIndex}"] as CheckBox;

            // Ràng buộc: Chỉ chọn 1 trong 2 (Sáng hoặc Trưa)
            if (chk.Checked)
            {
                if (chk == chkSang)
                    chkTrua.Checked = false; // Bỏ chọn Trưa nếu chọn Sáng
                else if (chk == chkTrua)
                    chkSang.Checked = false; // Bỏ chọn Sáng nếu chọn Trưa
            }

            // Kiểm tra ràng buộc: Nếu chọn Đi, phải chọn Về
            CheckBox chkVeTrua = tblThoiGianVe.Controls[$"chk_Ve_Trua_{dayIndex}"] as CheckBox;
            CheckBox chkVeChieu = tblThoiGianVe.Controls[$"chk_Ve_Chieu_{dayIndex}"] as CheckBox;

            if (chkSang.Checked || chkTrua.Checked)
            {
                // Nếu chọn Đi, yêu cầu chọn Về
                if (!chkVeTrua.Checked && !chkVeChieu.Checked)
                {
                    MessageBox.Show($"Vui lòng chọn thời gian Về cho ngày {tblThoiGianDi.Controls[dayIndex * 3].Text}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CheckBoxVe_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            int dayIndex = (int)chk.Tag; // Lấy index ngày

            // Lấy các CheckBox của ngày đó
            CheckBox chkTrua = tblThoiGianVe.Controls[$"chk_Ve_Trua_{dayIndex}"] as CheckBox;
            CheckBox chkChieu = tblThoiGianVe.Controls[$"chk_Ve_Chieu_{dayIndex}"] as CheckBox;

            // Ràng buộc: Chỉ chọn 1 trong 2 (Trưa hoặc Chiều)
            if (chk.Checked)
            {
                if (chk == chkTrua)
                    chkChieu.Checked = false; // Bỏ chọn Chiều nếu chọn Trưa
                else if (chk == chkChieu)
                    chkTrua.Checked = false; // Bỏ chọn Trưa nếu chọn Chiều
            }

            // Kiểm tra ràng buộc: Nếu chọn Về, phải chọn Đi
            CheckBox chkDiSang = tblThoiGianDi.Controls[$"chk_Di_Sang_{dayIndex}"] as CheckBox;
            CheckBox chkDiTrua = tblThoiGianDi.Controls[$"chk_Di_Trua_{dayIndex}"] as CheckBox;

            if (chkTrua.Checked || chkChieu.Checked)
            {
                // Nếu chọn Về, yêu cầu chọn Đi
                if (!chkDiSang.Checked && !chkDiTrua.Checked)
                {
                    MessageBox.Show($"Vui lòng chọn thời gian Đi cho ngày {tblThoiGianVe.Controls[dayIndex * 3].Text}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        string lastSelectedTuyen = ""; // biến này lưu lại tuyến cũ
        private bool IsBookingTimeValid()
        {
            DateTime now = new DateTime(2025, 5, 5);
            DateTime today = now.Date; //có thể chỉnh thời gian ảo để test

            // Tìm thứ 2 của tuần hiện tại
            int daysSinceMonday = ((int)today.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            DateTime monday = today.AddDays(-daysSinceMonday);

            // Tính thời điểm 17h thứ 4
            DateTime wednesday17h = monday.AddDays(2).AddHours(17); // Thứ 4, 17:00

            // Kiểm tra xem thời gian hiện tại có trong khoảng thứ 2 đến 17h thứ 4 không
            return now >= monday && now <= wednesday17h;
        }
        private void chonTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentValue = chonTuyen.SelectedItem?.ToString();
            if (IsBookingTimeValid())
            {
                // Hiển thị panel đặt vé
                pnlDatVe.Visible = true;
                

                if (currentValue != null && currentValue != lastSelectedTuyen)
                {
                    lastSelectedTuyen = currentValue; // cập nhật lại
                    chonThoiGianDi(); // gọi hàm render bảng
                    chonThoiGianVe();
                }
            }
            else
            {
                MessageBox.Show(
                    "Thời gian đặt vé hàng tuần từ thứ 2 đến 17h thứ 4, đã hết thời gian đặt vui lòng quay lại vào tuần sau.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        public class LichDiVe
        {
            public DateTime Ngay { get; set; }
            public bool DiSang { get; set; }
            public bool DiTrua { get; set; }
            public bool VeTrua { get; set; }
            public bool VeChieu { get; set; }
        }

        public List<LichDiVe> LayLichDiVe()
        {
            List<LichDiVe> danhSach = new List<LichDiVe>();
            DateTime today = DateTime.Today;
            int daysUntilNextMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            DateTime startDate = today.AddDays(daysUntilNextMonday); // Thứ 2 tuần sau

            for (int i = 0; i < 6; i++)
            {
                DateTime ngay = startDate.AddDays(i);

                var diSang = (tblThoiGianDi.Controls.Find($"chk_Di_Sang_{i}", true).FirstOrDefault() as CheckBox)?.Checked ?? false;
                var diTrua = (tblThoiGianDi.Controls.Find($"chk_Di_Trua_{i}", true).FirstOrDefault() as CheckBox)?.Checked ?? false;

                var veTrua = (tblThoiGianVe.Controls.Find($"chk_Ve_Trua_{i}", true).FirstOrDefault() as CheckBox)?.Checked ?? false;
                var veChieu = (tblThoiGianVe.Controls.Find($"chk_Ve_Chieu_{i}", true).FirstOrDefault() as CheckBox)?.Checked ?? false;

                // Nếu không chọn gì thì bỏ qua
                if (diSang || diTrua || veTrua || veChieu)
                {
                    danhSach.Add(new LichDiVe
                    {
                        Ngay = ngay,
                        DiSang = diSang,
                        DiTrua = diTrua,
                        VeTrua = veTrua,
                        VeChieu = veChieu
                    });
                }
            }

            return danhSach;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void pnlStudentBooking_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LuuLichVaoDatabase(List<LichDiVe> danhSachLich)
        {
            using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\OUBus_Manage\OUBus\oubus.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                try
                {
                    connect.Open();

                    // Lấy profile_image từ bảng users nếu LoggedInUser.Image là null
                    byte[] imageData = LoggedInUser.Image;
                    if (imageData == null)
                    {
                        string getImageQuery = "SELECT profile_image FROM users WHERE mssv = @mssv";
                        using (SqlCommand getImageCmd = new SqlCommand(getImageQuery, connect))
                        {
                            getImageCmd.Parameters.AddWithValue("@mssv", LoggedInUser.MSSV);
                            imageData = getImageCmd.ExecuteScalar() as byte[];
                        }
                    }

                    foreach (var lich in danhSachLich)
                    {
                        string query = @"INSERT INTO datve (mssv, tuyen_xe, profile_image, phone, ngay_di, di_sang, di_trua, ve_trua, ve_chieu)
                                VALUES (@mssv, @tuyen, @image, @phone, @ngay, @diSang, @diTrua, @veTrua, @veChieu)";

                        using (SqlCommand cmd = new SqlCommand(query, connect))
                        {
                            cmd.Parameters.AddWithValue("@mssv", LoggedInUser.MSSV);
                            cmd.Parameters.AddWithValue("@tuyen", chonTuyen.SelectedItem?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@image", imageData ?? (object)DBNull.Value); // Gán NULL nếu không có hình ảnh
                            cmd.Parameters.AddWithValue("@phone", LoggedInUser.Phone);
                            cmd.Parameters.AddWithValue("@ngay", lich.Ngay);
                            cmd.Parameters.AddWithValue("@diSang", lich.DiSang ? 1 : 0);
                            cmd.Parameters.AddWithValue("@diTrua", lich.DiTrua ? 1 : 0);
                            cmd.Parameters.AddWithValue("@veTrua", lich.VeTrua ? 1 : 0);
                            cmd.Parameters.AddWithValue("@veChieu", lich.VeChieu ? 1 : 0);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        private bool ValidateSelections()
        {
            for (int i = 0; i < 6; i++)
            {
                CheckBox chkDiSang = tblThoiGianDi.Controls[$"chk_Di_Sang_{i}"] as CheckBox;
                CheckBox chkDiTrua = tblThoiGianDi.Controls[$"chk_Di_Trua_{i}"] as CheckBox;
                CheckBox chkVeTrua = tblThoiGianVe.Controls[$"chk_Ve_Trua_{i}"] as CheckBox;
                CheckBox chkVeChieu = tblThoiGianVe.Controls[$"chk_Ve_Chieu_{i}"] as CheckBox;

                bool hasDi = chkDiSang.Checked || chkDiTrua.Checked;
                bool hasVe = chkVeTrua.Checked || chkVeChieu.Checked;

                // Kiểm tra: Nếu có Đi, phải có Về và ngược lại
                if (hasDi && !hasVe)
                {
                    MessageBox.Show($"Ngày {tblThoiGianDi.Controls[i * 3].Text} đã chọn thời gian Đi nhưng chưa chọn thời gian Về.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (hasVe && !hasDi)
                {
                    MessageBox.Show($"Ngày {tblThoiGianVe.Controls[i * 3].Text} đã chọn thời gian Về nhưng chưa chọn thời gian Đi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void btn_BookingSave_Click(object sender, EventArgs e)
        {
            var lichDangKy = LayLichDiVe();
            if (chonTuyen.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tuyến xe!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lichDangKy.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn thời gian đi – về!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Hiển thị MessageBox xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn lưu các lựa chọn thời gian này không?",
                "Xác nhận lưu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes
            if (result == DialogResult.Yes)
            {
                // Kiểm tra ràng buộc
                if (ValidateSelections())
                {
                    MessageBox.Show("Đã xác nhận thời gian thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Thêm logic lưu dữ liệu vào cơ sở dữ liệu hoặc xử lý tiếp
                    LuuLichVaoDatabase(lichDangKy);
                }
            }
            else
            { }    

        }
        public class DatVeData
        {
            public int Id { get; set; }
            public string MSSV { get; set; }
            public string TuyenXe { get; set; }
            public string Phone { get; set; }
            public DateTime NgayDi { get; set; }
            public bool DiSang { get; set; }
            public bool DiTrua { get; set; }
            public bool VeTrua { get; set; }
            public bool VeChieu { get; set; }
            public byte[] ProfileImage { get; set; } // Thêm để lưu dữ liệu hình ảnh

        }

        public static List<DatVeData> GetDatVeData(string mssv = null)
        {
            List<DatVeData> datVeList = new List<DatVeData>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\OUBus_Manage\OUBus\oubus.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                try
                {
                    connect.Open();

                    string query = "SELECT id, mssv, tuyen_xe, phone, ngay_di, di_sang, di_trua, ve_trua, " +
                        "ve_chieu, profile_image FROM datve";
                    if (!string.IsNullOrEmpty(mssv))
                    {
                        query += " WHERE mssv = @mssv";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        if (!string.IsNullOrEmpty(mssv))
                        {
                            cmd.Parameters.AddWithValue("@mssv", mssv);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datVeList.Add(new DatVeData
                                {
                                    Id = reader.GetInt32(0),
                                    MSSV = reader.GetString(1),
                                    TuyenXe = reader.GetString(2),
                                    Phone = reader.GetString(3),
                                    NgayDi = reader.GetDateTime(4),
                                    DiSang = reader.GetBoolean(5),
                                    DiTrua = reader.GetBoolean(6),
                                    VeTrua = reader.GetBoolean(7),
                                    VeChieu = reader.GetBoolean(8),
                                    ProfileImage = reader[9] as byte[] // Lấy dữ liệu hình ảnh

                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu đặt vé: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }

            return datVeList;
        }

        public event EventHandler BookingSaved; // Sự kiện được kích hoạt khi lưu lịch

    }
}
