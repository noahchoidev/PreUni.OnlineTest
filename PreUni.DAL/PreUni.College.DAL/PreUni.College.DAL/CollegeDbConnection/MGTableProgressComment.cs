namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MGTableProgressComment")]
    public partial class MGTableProgressComment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CLASSID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STUDENTID { get; set; }

        [StringLength(5000)]
        public string COMMENT1 { get; set; }

        [StringLength(5000)]
        public string COMMENT2 { get; set; }

        [StringLength(5000)]
        public string COMMENT3 { get; set; }

        [StringLength(5000)]
        public string COMMENT4 { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }
    }
}
