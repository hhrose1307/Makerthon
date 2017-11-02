namespace TravelWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietTour")]
    public partial class ChiTietTour
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTour { get; set; }

        [Key]
        [Column(Order = 1)]
        public string MaKH { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public bool TinhTrang { get; set; }
        public virtual ApplicationUser AspNetUser { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
