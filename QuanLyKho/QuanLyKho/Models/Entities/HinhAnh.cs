namespace QuanLyKho.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhAnh")]
    public partial class HinhAnh
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "Mã ảnh")]
        public string MaIMG { get; set; }

        [Display(Name ="Tên ảnh")]
        public string TenIMG { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="Mã HH")]
        public string MaHH { get; set; }

        [Display(Name ="Nội dung")]
        public string PathFile { get; set; }
        public virtual HangHoa HangHoa { get; set; }
    }
}
