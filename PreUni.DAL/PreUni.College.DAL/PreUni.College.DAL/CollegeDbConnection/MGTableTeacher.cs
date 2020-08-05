namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MGTableTeacher")]
    public partial class MGTableTeacher
    {
        [Key]
        public int TeacherID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(50)]
        public string Suburb { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone1 { get; set; }

        [StringLength(50)]
        public string Phone2 { get; set; }

        [StringLength(50)]
        public string School { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(2)]
        public string BRANCHCODE { get; set; }

        public int? PUNCUserId { get; set; }

        [StringLength(10)]
        public string Postcode { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
