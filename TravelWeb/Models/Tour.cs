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
        public int MaTour { get; set; }

        public DateTime? ThoiGianDi { get; set; }

        public int? NgayDiDuKien { get; set; }

        [StringLength(150)]
        public string DiaDiemDi { get; set; }

        [StringLength(150)]
        public string DiaDiemToi { get; set; }

        public int? SoNguoi { get; set; }

        public int? PhuongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTour> ChiTietTours { get; set; }
    }
}
