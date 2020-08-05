namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MGTableStudentEnroll")]
    public partial class MGTableStudentEnroll
    {
        [Key]
        public int RollID { get; set; }

        public int ClassID { get; set; }

        public int StudentID { get; set; }

        [StringLength(200)]
        public string Day1 { get; set; }

        [StringLength(200)]
        public string Day2 { get; set; }

        [StringLength(200)]
        public string Day3 { get; set; }

        [StringLength(200)]
        public string Day4 { get; set; }

        [StringLength(200)]
        public string Day5 { get; set; }

        [StringLength(200)]
        public string Day6 { get; set; }

        [StringLength(200)]
        public string Day7 { get; set; }

        [StringLength(200)]
        public string Day8 { get; set; }

        [StringLength(200)]
        public string Day9 { get; set; }

        [StringLength(200)]
        public string Day10 { get; set; }

        [StringLength(200)]
        public string Day11 { get; set; }

        [StringLength(200)]
        public string Day12 { get; set; }

        [StringLength(255)]
        public string Comments { get; set; }

        [StringLength(50)]
        public string MakeUp { get; set; }

        [StringLength(1)]
        public string Eng1 { get; set; }

        [StringLength(1)]
        public string Math1 { get; set; }

        [StringLength(1)]
        public string GA1 { get; set; }

        [StringLength(1)]
        public string MentalMath { get; set; }

        [StringLength(1)]
        public string Novel { get; set; }

        [StringLength(1)]
        public string Reading { get; set; }

        [StringLength(1)]
        public string Eng2 { get; set; }

        [StringLength(1)]
        public string Math2 { get; set; }

        [StringLength(1)]
        public string GA2 { get; set; }

        [StringLength(50)]
        public string ModifyUserID { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? MGTableStudentDropClassIDX { get; set; }
    }
}
