namespace TravelWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaDiemToi")]
    public partial class DiaDiemToi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiaDiemToi()
        {
            DiaDanhs = new HashSet<DiaDanh>();
        }

        [Key]
        public int MaTinh { get; set; }

        [StringLength(200)]
        public string Ten { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiaDanh> DiaDanhs { get; set; }
    }
}
