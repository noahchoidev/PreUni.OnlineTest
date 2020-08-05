namespace PreUni.College.DAL.NewcollegeDbConnection
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class NewcollegeDbContext : DbContext
    {
        public NewcollegeDbContext()
            : base("name=NewcollegeDbContext")
        {
            //Database.SetInitializer<NewcollegeDbContext>(null);
        }

        public virtual DbSet<NC_STUDENT_RESULT> NC_STUDENT_RESULT { get; set; }

        public virtual DbSet<NC_STUDENT_SCAN_DATA> NC_STUDENT_SCAN_DATA { get; set; }

        public virtual DbSet<NC_TEACHER_COMMENT> NC_TEACHER_COMMENT { get; set; }

        public virtual DbSet<NC_TEST_TEST> NC_TEST_TEST { get; set; }

        public virtual DbSet<tblOnlineStudentWriting> OnlineStudentWriting { get; set; }

        public virtual DbSet<NC_BRANCH> NC_BRANCH { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NC_BRANCH>()
                .Property(e => e.BranchName)
                .IsUnicode(false);

            modelBuilder.Entity<tblOnlineStudentWriting>().ToTable("tblOnlineStudentWriting");

            modelBuilder.Entity<tblOnlineStudentWriting>()
                .Property(e => e.WritingText)
                .IsUnicode(false);

            modelBuilder.Entity<tblOnlineStudentWriting>()
                .Property(e => e.WritingHTML)
                .IsUnicode(false);

            modelBuilder.Entity<tblOnlineStudentWriting>()
                .Property(e => e.Mark)
                .IsUnicode(false);

            modelBuilder.Entity<tblOnlineStudentWriting>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<tblOnlineStudentWriting>()
                .Property(e => e.Score);

            modelBuilder.Entity<tblOnlineStudentWriting>()
                .Property(e => e.Marker)
                .IsUnicode(false);

            modelBuilder.Entity<NC_STUDENT_RESULT>()
                .Property(e => e.Mark_result)
                .IsUnicode(false);

            modelBuilder.Entity<NC_STUDENT_RESULT>()
                .Property(e => e.LetterPrinted)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NC_STUDENT_SCAN_DATA>()
                .Property(e => e.TERM)
                .IsUnicode(false);

            modelBuilder.Entity<NC_STUDENT_SCAN_DATA>()
                .Property(e => e.STUDENT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<NC_STUDENT_SCAN_DATA>()
                .Property(e => e.STUDENT_INITIAL)
                .IsUnicode(false);

            modelBuilder.Entity<NC_STUDENT_SCAN_DATA>()
                .Property(e => e.DATEOFBIRTH)
                .IsUnicode(false);

            modelBuilder.Entity<NC_STUDENT_SCAN_DATA>()
                .Property(e => e.TEST_RESULT)
                .IsUnicode(false);

            modelBuilder.Entity<NC_STUDENT_SCAN_DATA>()
                .Property(e => e.TEST_DATE)
                .IsUnicode(false);

            modelBuilder.Entity<NC_STUDENT_SCAN_DATA>()
                .Property(e => e.ISGENERATED)
                .IsUnicode(false);

            modelBuilder.Entity<NC_TEACHER_COMMENT>()
                .Property(e => e.Term)
                .IsUnicode(false);

            modelBuilder.Entity<NC_TEACHER_COMMENT>()
                .Property(e => e.EFFORT)
                .IsUnicode(false);

            modelBuilder.Entity<NC_TEACHER_COMMENT>()
                .Property(e => e.BEHAVIOUR)
                .IsUnicode(false);

            modelBuilder.Entity<NC_TEACHER_COMMENT>()
                .Property(e => e.HOMEWORK)
                .IsUnicode(false);

            modelBuilder.Entity<NC_TEACHER_COMMENT>()
                .Property(e => e.COMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<NC_TEACHER_COMMENT>()
                .Property(e => e.Editor)
                .IsUnicode(false);

            modelBuilder.Entity<NC_TEST_TEST>()
                .Property(e => e.TERM)
                .IsUnicode(false);

            modelBuilder.Entity<NC_TEST_TEST>()
                .Property(e => e.TEST_NAME)
                .IsUnicode(false);
        }
    }
}
