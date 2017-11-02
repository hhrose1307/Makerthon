namespace TravelWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaDanh")]
    public partial class DiaDanh
    {
        [Key]
        public int MaDiaDanh { get; set; }

        public int? MaTinh { get; set; }

        [StringLength(10)]
        public string TenDiaDanh { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        [Column(TypeName = "ntext")]
        public string Anh { get; set; }

        [Column(TypeName = "ntext")]
        public string Anh1 { get; set; }

        [Column(TypeName = "ntext")]
        public string Anh2 { get; set; }

        [Column(TypeName = "ntext")]
        public string Anh3 { get; set; }

        public virtual DiaDiemToi DiaDiemToi { get; set; }
    }
}
