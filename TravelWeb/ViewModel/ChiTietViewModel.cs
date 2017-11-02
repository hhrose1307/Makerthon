using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelWeb.ViewModel
{
    public class ChiTietViewModel
    {
        public int Id { get; set; }
        public string MaKh { get; set; }
        public string TenKh { get; set; }
        public DateTime ngaysinh { get; set; }

        public bool gioitinh { get; set; }
        public string linkfb { get; set; }

        public string Mota { get; set; }
        public bool TinhTrang { get; set; }
    }
}