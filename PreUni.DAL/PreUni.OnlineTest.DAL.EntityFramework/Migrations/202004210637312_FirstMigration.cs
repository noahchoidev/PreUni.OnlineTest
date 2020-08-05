namespace PreUni.OnlineTest.DAL.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestType",
                c => new
                    {
                        TestTypeID = c.Int(nullable: false, identity: true),
                        TestTypeName = c.String(),
                    })
                .PrimaryKey(t => t.TestTypeID);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        ExamID = c.Int(nullable: false, identity: true),
                        Year = c.String(),
                        ExamDescription = c.String(),
                        TestTypeID = c.Int(nullable: false),
                        TestTermID = c.Int(nullable: false),
                        EditedAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ExamID)
                .ForeignKey("dbo.TestTerm", t => t.TestTermID, cascadeDelete: true)
                .ForeignKey("dbo.TestType", t => t.TestTypeID, cascadeDelete: true)
                .Index(t => t.TestTypeID)
                .Index(t => t.TestTermID);
            
            CreateTable(
                "dbo.ExamSubject",
                c => new
                    {
                        ExamSubjectID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(nullable: false),
                        Exam_ExamID = c.Int(nullable: false),
                        Exam_Year = c.String(),
                        Exam_ExamDescription = c.String(),
                        Exam_TestTypeID = c.Int(nullable: false),
                        Exam_TestTypeName = c.String(),
                        Exam_TestTermID = c.Int(nullable: false),
                        Exam_TermName = c.String(),
                        Exam_EditedAt = c.DateTime(),
                        Exam_CreatedAt = c.DateTime(),
                        Exam_DeletedAt = c.DateTime(),
                        SubjectID = c.Int(nullable: false),
                        TestDuration = c.Time(nullable: false, precision: 7),
                        EditedAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ExamSubjectID)
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Exam", t => t.ExamID, cascadeDelete: true)
                .Index(t => t.ExamID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        EditedAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionPictureURL = c.String(),
                        ExamID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        EditedAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Exam", t => t.ExamID, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.ExamID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.TestTerm",
                c => new
                    {
                        TestTermID = c.Int(nullable: false, identity: true),
                        TermName = c.String(),
                    })
                .PrimaryKey(t => t.TestTermID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exam", "TestTypeID", "dbo.TestType");
            DropForeignKey("dbo.Exam", "TestTermID", "dbo.TestTerm");
            DropForeignKey("dbo.ExamSubject", "ExamID", "dbo.Exam");
            DropForeignKey("dbo.Question", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Question", "ExamID", "dbo.Exam");
            DropForeignKey("dbo.ExamSubject", "SubjectID", "dbo.Subject");
            DropIndex("dbo.Question", new[] { "SubjectID" });
            DropIndex("dbo.Question", new[] { "ExamID" });
            DropIndex("dbo.ExamSubject", new[] { "SubjectID" });
            DropIndex("dbo.ExamSubject", new[] { "ExamID" });
            DropIndex("dbo.Exam", new[] { "TestTermID" });
            DropIndex("dbo.Exam", new[] { "TestTypeID" });
            DropTable("dbo.TestTerm");
            DropTable("dbo.Question");
            DropTable("dbo.Subject");
            DropTable("dbo.ExamSubject");
            DropTable("dbo.Exam");
            DropTable("dbo.TestType");
        }
    }
}
