using System.Data.Entity;

namespace PreUni.College.DAL.CollegeDbConnection
{
    public partial class CollegeDbContext : DbContext
    {
        public CollegeDbContext()
            : base("name=CollegeDbContext")
        {
           // Database.SetInitializer<CollegeDbContext>(null);
        }

        public virtual DbSet<CourseSubject> CourseSubjects { get; set; }

        public virtual DbSet<MGTableClassInfo> MGTableClassInfoes { get; set; }

        public virtual DbSet<MGTableProgressComment> MGTableProgressComment { get; set; }

        public virtual DbSet<MGTableProgressComments> MGTableProgressComments { get; set; }

        public virtual DbSet<MGTableStudentEnroll> MGTableStudentEnrolls { get; set; }

        public virtual DbSet<MGTableTeacher> MGTableTeachers { get; set; }

        public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

        public virtual DbSet<StudentMedicalCondition> StudentMedicalConditions { get; set; }

        public virtual DbSet<TableTermInfo> TableTermInfoes { get; set; }

        public virtual DbSet<TableUser> TableUsers { get; set; }

        public virtual DbSet<tblCollege> tblColleges { get; set; }

        public virtual DbSet<tblStudent> tblStudents { get; set; }

        public virtual DbSet<CourseSubjectClassSubject> CourseSubjectClassSubjects { get; set; }

        public virtual DbSet<MGTableComment> MGTableComments { get; set; }

        public virtual DbSet<MGTableHomeWork> MGTableHomeWorks { get; set; }

        public virtual DbSet<MGTableMakeUp> MGTableMakeUps { get; set; }

        public virtual DbSet<View_ClassStudent> View_ClassStudent { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseSubject>()
                .HasMany(e => e.CourseSubjectClassSubjects)
                .WithRequired(e => e.CourseSubject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MGTableClassInfo>().ToTable("MGTableClassInfo");

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.Term)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.Day)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.Room)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.Adviser1)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.Adviser2)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.EngLevel)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.MathLevel)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.Supervisor)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.BRANCHCODE)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableClassInfo>()
                .Property(e => e.EditorUserID)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComment>()
                .Property(e => e.COMMENT1)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComment>()
                .Property(e => e.COMMENT2)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComment>()
                .Property(e => e.COMMENT3)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComment>()
                .Property(e => e.COMMENT4)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComment>()
                .Property(e => e.Editor)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComments>()
            .Property(e => e.Attitude1)
            .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComments>()
                .Property(e => e.Attitude2)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComments>()
                .Property(e => e.Attitude3)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComments>()
                .Property(e => e.AttitudeComment)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComments>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComments>()
                .Property(e => e.Editor)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableProgressComments>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day1)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day2)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day3)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day4)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day5)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day6)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day7)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day8)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day9)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day10)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day11)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Day12)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.MakeUp)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Eng1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Math1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.GA1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.MentalMath)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Novel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Reading)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Eng2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.Math2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.GA2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MGTableStudentEnroll>()
                .Property(e => e.ModifyUserID)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableTeacher>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableTeacher>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableTeacher>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableTeacher>()
                .Property(e => e.Phone1)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableTeacher>()
                .Property(e => e.Phone2)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableTeacher>()
                .Property(e => e.School)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableTeacher>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableTeacher>()
                .Property(e => e.BRANCHCODE)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableTeacher>()
                .Property(e => e.Postcode)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableTeacher>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TableTermInfo>()
                .Property(e => e.Term)
                .IsUnicode(false);

            modelBuilder.Entity<TableTermInfo>()
                .Property(e => e.FullTermEnable)
                .IsUnicode(false);

            modelBuilder.Entity<TableTermInfo>()
                .Property(e => e.CurrentTerm)
                .IsUnicode(false);

            modelBuilder.Entity<TableTermInfo>()
                .Property(e => e.TTC_START_SUBJECT)
                .IsUnicode(false);

            modelBuilder.Entity<TableTermInfo>()
                .Property(e => e.IS_CURRENT)
                .IsUnicode(false);

            modelBuilder.Entity<TableUser>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<TableUser>()
                .Property(e => e.PW)
                .IsUnicode(false);

            modelBuilder.Entity<TableUser>()
                .Property(e => e.Permission)
                .IsUnicode(false);

            modelBuilder.Entity<TableUser>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TableUser>()
                .Property(e => e.Activated)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblCollege>().ToTable("tblCollege");

            modelBuilder.Entity<tblCollege>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollege>()
                .Property(e => e.BranchName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollege>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollege>()
                .Property(e => e.Pcode)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollege>()
                .Property(e => e.Locality)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollege>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollege>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollege>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollege>()
                .Property(e => e.Principal)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollege>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.ParentName)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.ParentMiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.ParentLastName)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.HomePhone)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.BusinessPhone)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.ParentDriversLicenseNo)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.ParentDriversLicenseName)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.SelectiveStudentNo)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.StudentAlert)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.IntroducedByName)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.Inactive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.CardIssued)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.MatchKey)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.CurrentClass)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.AttendingWEMG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.WebSitePassword)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.StudentPhoto)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.HighSchool)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.Modified)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.OC)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.ISValid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.Pcode)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.Locality)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.EditorUserID)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableComment>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableComment>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<MGTableComment>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Term)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Room)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.BRANCHCODE)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.BranchName)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.EditorUserID)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.BusinessPhone)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.HomePhone)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day1)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day2)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day3)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day4)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day5)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day6)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day7)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day8)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day9)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day10)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day11)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Day12)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.ModifyUserID)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.EngLevel)
                .IsUnicode(false);

            modelBuilder.Entity<View_ClassStudent>()
                .Property(e => e.MathLevel)
                .IsUnicode(false);
        }
    }
}
