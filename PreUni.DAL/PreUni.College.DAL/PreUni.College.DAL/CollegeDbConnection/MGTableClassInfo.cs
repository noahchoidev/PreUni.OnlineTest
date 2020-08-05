using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreUni.College.DAL.CollegeDbConnection
{
    [Table("MGTableClassInfo")]
    public partial class MGTableClassInfo
    {
        [Key]
        public int ClassID { get; set; }

        public int Year { get; set; }

        [Required]
        [StringLength(15)]
        public string Term { get; set; }

        public int Grade { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        [Required]
        [StringLength(20)]
        public string Day { get; set; }

        public int ClassNo { get; set; }

        public int Week { get; set; }

        public int StudentNo { get; set; }

        public int TeacherNo { get; set; }

        public int PayNo { get; set; }

        [StringLength(50)]
        public string Room { get; set; }

        public DateTime? Day1Start { get; set; }

        public DateTime? Day1End { get; set; }

        public DateTime? Day2Start { get; set; }

        public DateTime? Day2End { get; set; }

        public DateTime? Day3Start { get; set; }

        public DateTime? Day3End { get; set; }

        public DateTime? Day4Start { get; set; }

        public DateTime? Day4End { get; set; }

        public DateTime? Day5Start { get; set; }

        public DateTime? Day5End { get; set; }

        public DateTime? Day6Start { get; set; }

        public DateTime? Day6End { get; set; }

        public DateTime? Day7Start { get; set; }

        public DateTime? Day7End { get; set; }

        public DateTime? Day8Start { get; set; }

        public DateTime? Day8End { get; set; }

        public DateTime? Day9Start { get; set; }

        public DateTime? Day9End { get; set; }

        public DateTime? Day10Start { get; set; }

        public DateTime? Day10End { get; set; }

        public DateTime? Day11Start { get; set; }

        public DateTime? Day11End { get; set; }

        public DateTime? Day12Start { get; set; }

        public DateTime? Day12End { get; set; }

        [StringLength(50)]
        public string Adviser1 { get; set; }

        [StringLength(50)]
        public string Adviser2 { get; set; }

        [StringLength(50)]
        public string EngLevel { get; set; }

        [StringLength(50)]
        public string MathLevel { get; set; }

        public int? TeacherID1 { get; set; }

        public int? TeacherID2 { get; set; }

        [StringLength(50)]
        public string Supervisor { get; set; }

        [StringLength(2)]
        public string BRANCHCODE { get; set; }

        public int? SCAN_CLASS_ID { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        public int? SUBJECTINFO_ID { get; set; }

        public int? PKG_SUBJECTINFO_ID { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        [StringLength(50)]
        public string EditorUserID { get; set; }
    }
}
