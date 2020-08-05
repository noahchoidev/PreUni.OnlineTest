using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PreUni.College.DAL.NewcollegeDbConnection
{
    public partial class NC_STUDENT_SCAN_DATA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SCAN_DATA_ID { get; set; }

        public int? SCAN_ID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string TERM { get; set; }

        public int? CLASS_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YEAR { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TEST_TYPE_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TEST_GRADE { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STUDENTID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SUBJECT_ID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TEST_NO { get; set; }

        [StringLength(200)]
        public string STUDENT_NAME { get; set; }

        [StringLength(10)]
        public string STUDENT_INITIAL { get; set; }

        [StringLength(10)]
        public string DATEOFBIRTH { get; set; }

        [StringLength(1000)]
        public string TEST_RESULT { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        [StringLength(10)]
        public string TEST_DATE { get; set; }

        [StringLength(50)]
        public string ISGENERATED { get; set; }
    }
}
