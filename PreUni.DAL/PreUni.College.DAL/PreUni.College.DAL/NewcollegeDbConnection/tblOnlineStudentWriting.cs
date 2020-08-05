using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreUni.College.DAL.NewcollegeDbConnection
{
    public partial class tblOnlineStudentWriting
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public int TestID { get; set; }

        public int SubjectID { get; set; }

        public int? MDBTestID { get; set; }

        [Column(TypeName = "text")]
        public string WritingText { get; set; }

        [Column(TypeName = "text")]
        public string WritingHTML { get; set; }

        [StringLength(20)]
        public string Mark { get; set; }

        [StringLength(5000)]
        public string Comment { get; set; }

        public int? IsFinish { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Score { get; set; }

        [StringLength(50)]
        public string Marker { get; set; }
    }
}
