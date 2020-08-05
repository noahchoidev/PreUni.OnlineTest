namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseSubjectClassSubject")]
    public partial class CourseSubjectClassSubject
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseSubjectId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ClassSubject { get; set; }

        public virtual CourseSubject CourseSubject { get; set; }
    }
}
