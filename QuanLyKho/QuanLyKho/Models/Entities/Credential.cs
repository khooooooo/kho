namespace QuanLyKho.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Credential")]
    [Serializable]
    public partial class Credential
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string UserGroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string RoleID { get; set; }
    }
}
