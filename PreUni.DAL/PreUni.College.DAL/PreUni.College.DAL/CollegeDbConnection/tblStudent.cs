namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblStudent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }

        public int? RowID { get; set; }

        [StringLength(2)]
        public string BranchCode { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string ParentName { get; set; }

        [StringLength(50)]
        public string ParentMiddleName { get; set; }

        [StringLength(50)]
        public string ParentLastName { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        public int? SuburbID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateEnrolled { get; set; }

        public byte? StudentYear { get; set; }

        [StringLength(6)]
        public string Sex { get; set; }

        public int? NationalityID { get; set; }

        public int? SchoolID { get; set; }

        public DateTime? InactiveDate { get; set; }

        [StringLength(25)]
        public string HomePhone { get; set; }

        [StringLength(25)]
        public string MobilePhone { get; set; }

        [StringLength(25)]
        public string BusinessPhone { get; set; }

        [StringLength(25)]
        public string FAX { get; set; }

        public DateTime? TestAgainDate { get; set; }

        [StringLength(10)]
        public string ParentDriversLicenseNo { get; set; }

        [StringLength(50)]
        public string ParentDriversLicenseName { get; set; }

        [StringLength(8)]
        public string SelectiveStudentNo { get; set; }

        public int? SelectiveSchoolOffer { get; set; }

        [StringLength(1)]
        public string StudentAlert { get; set; }

        public int? IntroducedByID { get; set; }

        [StringLength(50)]
        public string IntroducedByName { get; set; }

        [StringLength(1000)]
        public string Comments { get; set; }

        [StringLength(1)]
        public string Inactive { get; set; }

        public int? TimePreferenceID { get; set; }

        public byte? Scholarship { get; set; }

        [StringLength(1)]
        public string CardIssued { get; set; }

        public DateTime? ScholarshipTestBookingDate { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? WhenLastModified { get; set; }

        [StringLength(100)]
        public string MatchKey { get; set; }

        [StringLength(50)]
        public string CurrentClass { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LatestSelectiveTestdate { get; set; }

        [StringLength(1)]
        public string AttendingWEMG { get; set; }

        [StringLength(50)]
        public string WebSitePassword { get; set; }

        [StringLength(1)]
        public string StudentPhoto { get; set; }

        [StringLength(50)]
        public string HighSchool { get; set; }

        [StringLength(1)]
        public string Modified { get; set; }

        [StringLength(1)]
        public string OC { get; set; }

        [StringLength(1)]
        public string ISValid { get; set; }

        [StringLength(4)]
        public string Pcode { get; set; }

        [StringLength(50)]
        public string Locality { get; set; }

        [StringLength(3)]
        public string State { get; set; }

        [StringLength(50)]
        public string EditorUserID { get; set; }

        public DateTime? EditedDate { get; set; }
    }
}
