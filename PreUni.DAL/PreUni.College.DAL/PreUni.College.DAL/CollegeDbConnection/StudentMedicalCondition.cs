namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentMedicalCondition")]
    public partial class StudentMedicalCondition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }

        public bool? HeartProblems { get; set; }

        public bool? IntellectualDisability { get; set; }

        public bool? ADHD { get; set; }

        public bool? Asthma { get; set; }

        public bool? RespiratoryProblem { get; set; }

        public bool? Allergie { get; set; }

        [StringLength(255)]
        public string Other { get; set; }
    }
}
