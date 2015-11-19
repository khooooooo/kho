namespace QuanLyKho.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuaHang")]
    public partial class CuaHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuaHang()
        {
            ChuCuaHangs = new HashSet<ChuCuaHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaCH { get; set; }

        [Required]
        public string TenCH { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuCuaHang> ChuCuaHangs { get; set; }

        public virtual KhoHang KhoHang { get; set; }
    }
}
