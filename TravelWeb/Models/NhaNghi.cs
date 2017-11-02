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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ma { get; set; }

        [StringLength(150)]
        public string TenNhaNghi { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        public decimal? GiaPhong { get; set; }

        [Column(TypeName = "ntext")]
        public string Anh1 { get; set; }

        [Column(TypeName = "ntext")]
        public string Anh2 { get; set; }

        [Column(TypeName = "ntext")]
        public string Anh3 { get; set; }

        [Column(TypeName = "ntext")]
        public string Anh4 { get; set; }

        [Column(TypeName = "ntext")]
        public string Anh5 { get; set; }

        [StringLength(128)]
        public string MaKH { get; set; }

        public virtual ApplicationUser AspNetUser { get; set; }
    }
}
