namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableUser")]
    public partial class TableUser
    {
        [Key]
        [Column(Order = 0)]
        public int SEQ { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PW { get; set; }

        [Required]
        [StringLength(50)]
        public string Permission { get; set; }

        public int Branch { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Department { get; set; }

        public int? User_Level { get; set; }

        public int? POSLevel { get; set; }

        [StringLength(1)]
        public string Activated { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InactivatedDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
