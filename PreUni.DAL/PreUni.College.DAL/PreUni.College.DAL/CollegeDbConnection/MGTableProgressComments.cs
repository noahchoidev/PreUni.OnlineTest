namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MGTableProgressComments")]
    public partial class MGTableProgressComments
    {
        [Key]
        public int CommentID { get; set; }

        public int ClassID { get; set; }

        public int StudentID { get; set; }

        public int? Week { get; set; }

        [StringLength(5000)]
        public string Attitude1 { get; set; }

        [StringLength(5000)]
        public string Attitude2 { get; set; }

        [StringLength(5000)]
        public string Attitude3 { get; set; }

        [StringLength(5000)]
        public string AttitudeComment { get; set; }

        [StringLength(5000)]
        public string Comment { get; set; }

        public int? TeacherID { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }
    }
}
