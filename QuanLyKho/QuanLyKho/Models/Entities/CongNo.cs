namespace QuanLyKho.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongNo")]
    public partial class CongNo
    {
        [Key]
        [StringLength(10)]
        public string MaCN { get; set; }

        [Required]
        [StringLength(10)]
        public string MaDT { get; set; }

        public bool LoaiCN { get; set; }

        [Required]
        [StringLength(10)]
        public string MaHD { get; set; }

        public decimal GiaTri { get; set; }

        public virtual DoiTac DoiTac { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
