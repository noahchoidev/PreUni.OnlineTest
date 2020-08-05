namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentAttendance")]
    public partial class StudentAttendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int RollId { get; set; }

        public int ClassId { get; set; }

        public int StudentId { get; set; }

        [Column(TypeName = "date")]
        public DateTime ClassDate { get; set; }

        public int DayNo { get; set; }

        public int AttendanceTypeId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ModifyDate { get; set; }

        public int? UserId { get; set; }
    }
}
