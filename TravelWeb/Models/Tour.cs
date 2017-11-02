namespace TravelWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            ChiTietTours = new HashSet<ChiTietTour>();
        }

        [Key]
        [Display(Name ="Mã tour")]
        public int MaTour { get; set; }

        [Display(Name = "Ngày đi dự kiến")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ThoiGianDi { get; set; }

        [Display(Name ="Số ngày đi")]
        public int? NgayDiDuKien { get; set; }

        [Display(Name ="Tỉnh đi")]
        public string TinhDi { get; set; }

        [Display(Name ="Huyện đi")]
        public string HuyenDi { get; set; }

        [Display(Name ="Tỉnh tới")]
        public string TinhToi { get; set; }

        [Display(Name ="Huyện tới")]
        public string HuyenToi { get; set; }

        [StringLength(150)]
        public string DiaDiemToi { get; set; }

        [Display(Name ="Số người")]
        public int? SoNguoi { get; set; }


        [Display(Name ="Số người đã có")]
        public int? SoNguoiDaCo { get; set; }
        
        [Display(Name ="Phương tiện")]
        public string PhuongTien { get; set; }

        [Display(Name ="Giới tính")]
        public string GioiTinh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTour> ChiTietTours { get; set; }
    }
}
