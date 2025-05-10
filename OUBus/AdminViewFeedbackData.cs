using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUBus
{
    public class AdminViewFeedbackData
    {
        public int Id { get; set; } // Giả sử bảng Feedback có cột Id
        public string MSSV { get; set; }
        public string TuyenXe { get; set; }
        public string VanDe { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayPhanAnh { get; set; }
        public string TrangThai { get; set; }
    }
}
