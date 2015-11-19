namespace QuanLyKho.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoiTac")]
    public partial class DoiTac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoiTac()
        {
            CongNoes = new HashSet<CongNo>();
            HoaDons = new HashSet<HoaDon>();
            NganQuys = new HashSet<NganQuy>();
            PhieuThuChis = new HashSet<PhieuThuChi>();
            NhomHangs = new HashSet<NhomHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaDT { get; set; }

        [Required]
        [StringLength(50)]
        public string MaSoThue { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string SDT { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(100)]
        public string KieuDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongNo> CongNoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NganQuy> NganQuys { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThuChi> PhieuThuChis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomHang> NhomHangs { get; set; }
    }
}
