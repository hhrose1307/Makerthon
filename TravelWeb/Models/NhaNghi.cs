namespace TravelWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaNghi")]
    public partial class NhaNghi
    {
        [Key]
        [Display(Name ="Mã số")]
        public int Ma { get; set; }


        [Display(Name ="Tên nhà nghỉ")]
        [StringLength(150)]
        public string TenNhaNghi { get; set; }


        [Display(Name ="Địa chỉ")]
        [StringLength(50)]
        public string DiaChi { get; set; }

        [Display(Name ="Số điện thoại")]
        [StringLength(11)]
        public string SDT { get; set; }

        [Display(Name ="Giá phòng")]
        [DisplayFormat(DataFormatString = "{0:#,##0VND}")]
        public decimal? GiaPhong { get; set; }

        [Display(Name ="Ảnh")]
        [Column(TypeName = "ntext")]
        public string Anh1 { get; set; }

        [Display(Name = "Ảnh")]
        [Column(TypeName = "ntext")]
        public string Anh2 { get; set; }

        [Display(Name = "Ảnh")]
        [Column(TypeName = "ntext")]
        public string Anh3 { get; set; }

        [Display(Name = "Ảnh")]
        [Column(TypeName = "ntext")]
        public string Anh4 { get; set; }

        [Display(Name = "Ảnh")]
        [Column(TypeName = "ntext")]
        public string Anh5 { get; set; }

        [StringLength(128)]
        public string MaKH { get; set; }

        public virtual ApplicationUser AspNetUser { get; set; }
    }
}
