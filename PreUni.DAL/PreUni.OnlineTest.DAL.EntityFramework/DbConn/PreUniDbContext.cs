using PreUni.Core.Model;
using System.Data.Entity;

namespace PreUni.OnlineTest.DAL.EntityFramework
{
    public class PreUniDbContext : DbContext
    {
        public PreUniDbContext() : base("name=PreUniDbContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var testType = modelBuilder.Entity<TestType>();
            testType.ToTable("dbo.TestType");

            var testTerm = modelBuilder.Entity<TestTerm>();
            testTerm.ToTable("dbo.TestTerm");

            var exam = modelBuilder.Entity<Exam>();
            exam.ToTable("dbo.Exam");

            var subject = modelBuilder.Entity<Subject>();
            subject.ToTable("dbo.Subject");

            var examSubject = modelBuilder.Entity<ExamSubject>();
            examSubject.ToTable("dbo.ExamSubject");

            var question = modelBuilder.Entity<Question>();
            question.ToTable("dbo.Question");
        }

        public DbSet<TestType> TestTypes { get; set; }

        public DbSet<TestTerm> TestTerms { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<ExamSubject> ExamSubjects { get; set; }

        public DbSet<Subject> Subjects { get; set; }
    }
}
