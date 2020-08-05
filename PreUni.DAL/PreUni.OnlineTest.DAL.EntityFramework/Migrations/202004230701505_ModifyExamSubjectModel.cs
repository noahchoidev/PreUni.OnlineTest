namespace PreUni.OnlineTest.DAL.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyExamSubjectModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ExamSubject", "Exam_ExamID");
            DropColumn("dbo.ExamSubject", "Exam_Year");
            DropColumn("dbo.ExamSubject", "Exam_ExamDescription");
            DropColumn("dbo.ExamSubject", "Exam_TestTypeID");
            DropColumn("dbo.ExamSubject", "Exam_TestTypeName");
            DropColumn("dbo.ExamSubject", "Exam_TestTermID");
            DropColumn("dbo.ExamSubject", "Exam_TermName");
            DropColumn("dbo.ExamSubject", "Exam_EditedAt");
            DropColumn("dbo.ExamSubject", "Exam_CreatedAt");
            DropColumn("dbo.ExamSubject", "Exam_DeletedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExamSubject", "Exam_DeletedAt", c => c.DateTime());
            AddColumn("dbo.ExamSubject", "Exam_CreatedAt", c => c.DateTime());
            AddColumn("dbo.ExamSubject", "Exam_EditedAt", c => c.DateTime());
            AddColumn("dbo.ExamSubject", "Exam_TermName", c => c.String());
            AddColumn("dbo.ExamSubject", "Exam_TestTermID", c => c.Int(nullable: false));
            AddColumn("dbo.ExamSubject", "Exam_TestTypeName", c => c.String());
            AddColumn("dbo.ExamSubject", "Exam_TestTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.ExamSubject", "Exam_ExamDescription", c => c.String());
            AddColumn("dbo.ExamSubject", "Exam_Year", c => c.String());
            AddColumn("dbo.ExamSubject", "Exam_ExamID", c => c.Int(nullable: false));
        }
    }
}
