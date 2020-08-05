namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_ClassStudent
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string Term { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Grade { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Subject { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string Day { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassNo { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Week { get; set; }

        [StringLength(50)]
        public string Room { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        public DateTime? Day1Start { get; set; }

        public DateTime? Day1End { get; set; }

        [StringLength(2)]
        public string BRANCHCODE { get; set; }

        [StringLength(25)]
        public string BranchName { get; set; }

        [StringLength(50)]
        public string EditorUserID { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RollID { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(25)]
        public string MobilePhone { get; set; }

        [StringLength(25)]
        public string BusinessPhone { get; set; }

        [StringLength(25)]
        public string HomePhone { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

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

        [StringLength(50)]
        public string ModifyUserID { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? MGTableStudentDropClassIDX { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DroppedDate { get; set; }

        [Column(TypeName = "text")]
        public string Reason { get; set; }

        [StringLength(50)]
        public string EngLevel { get; set; }

        [StringLength(50)]
        public string MathLevel { get; set; }
    }
}
