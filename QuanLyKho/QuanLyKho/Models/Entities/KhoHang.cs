namespace QuanLyKho.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoHang")]
    public partial class KhoHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoHang()
        {
            CuaHangs = new HashSet<CuaHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaKho { get; set; }

        [Required]
        public string TenKho { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuaHang> CuaHangs { get; set; }

        public virtual LoaiHang LoaiHang { get; set; }
    }
}
