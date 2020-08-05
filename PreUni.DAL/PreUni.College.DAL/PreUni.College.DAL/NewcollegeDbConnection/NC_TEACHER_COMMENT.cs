namespace PreUni.College.DAL.NewcollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NC_TEACHER_COMMENT
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STUDENTID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TEST_YEAR { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(6)]
        public string Term { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TEST_TYPE_ID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TEST_GRADE { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TEST_NO { get; set; }

        [StringLength(100)]
        public string EFFORT { get; set; }

        [StringLength(100)]
        public string BEHAVIOUR { get; set; }

        [StringLength(100)]
        public string HOMEWORK { get; set; }

        [StringLength(5000)]
        public string COMMENT { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }
    }
}
