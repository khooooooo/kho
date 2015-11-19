namespace QuanLyKho.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuThuChi")]
    public partial class PhieuThuChi
    {
        [Key]
        [StringLength(10)]
        public string MaPH { get; set; }

        [Required]
        [StringLength(10)]
        public string MaDT { get; set; }

        [Required]
        [StringLength(10)]
        public string MaHD { get; set; }

        public bool LoaiPhieu { get; set; }

        public DateTime Thoigian { get; set; }

        public double GiaTri { get; set; }

        public virtual DoiTac DoiTac { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
