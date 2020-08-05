namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseSubject")]
    public partial class CourseSubject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseSubject()
        {
            CourseSubjectClassSubjects = new HashSet<CourseSubjectClassSubject>();
        }

        public int CourseSubjectId { get; set; }

        public int CourseId { get; set; }

        [Required]
        public string Subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseSubjectClassSubject> CourseSubjectClassSubjects { get; set; }
    }
}
