using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreUni.College.DAL.NewcollegeDbConnection
{
    public partial class NC_STUDENT_RESULT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RESULT_ID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int test_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STUDENTID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short YEAR { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short test_type_ID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SUBJECT_ID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short TEST_NO { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short TEST_GRADE { get; set; }

        public short? class_ID { get; set; }

        [StringLength(5000)]
        public string Mark_result { get; set; }

        public int? PARTA_SCORE { get; set; }

        public int? PARTA_PSCORE { get; set; }

        public int? PARTB_SCORE { get; set; }

        public int? PARTB_PSCORE { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        [StringLength(1)]
        public string LetterPrinted { get; set; }
    }
}
