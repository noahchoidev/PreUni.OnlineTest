using PreUni.College.DAL.CollegeDbConnection;
using PreUni.College.DAL.Model;
using PreUni.College.DAL.NewcollegeDbConnection;
using PreUni.College.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace PreUni.College.DAL.Repository
{
    public class TermTestCommentRepository: ITermTestCommentRepository
    {
        private CollegeDbContext mCollegeDbContext;
        private NewcollegeDbContext mNewcollegeDbContext;

        public TermTestCommentRepository(DbContext SourceCollegeContext, DbContext SourceNewcollegeContext) // 
        {
            mCollegeDbContext = SourceCollegeContext as CollegeDbContext;
            mNewcollegeDbContext = SourceNewcollegeContext as NewcollegeDbContext;
        }
        
        public IEnumerable<ClassResults> GetClassResults(int classId)
        {
            var clienetParam = new SqlParameter("@ClassID", classId);
            var TermTestClassAnalysis = mNewcollegeDbContext.Database.SqlQuery<ClassResults>("SP_GetTermTestClassAnalysis @ClassID", clienetParam).ToList();
            
            return TermTestClassAnalysis;
        }

        public IEnumerable<OnlineQuizScore_Result> GetOnlineQuizSummaryByStudentID(int StudentID, int Year, string Term, int TestGrade)
        {
            var clienetParam1 = new SqlParameter("@StudentID", StudentID);
            var clienetParam2 = new SqlParameter("@Year", Year);
            var clienetParam3 = new SqlParameter("@Term", Term);
            var clienetParam4 = new SqlParameter("@TestGrade", TestGrade);

            var result = mNewcollegeDbContext.Database.SqlQuery<OnlineQuizScore_Result>("GetOnlineQuizSummaryByStudentID @StudentID,@Year,@Term,@TestGrade", clienetParam1, clienetParam2, clienetParam3, clienetParam4).ToList();

            return result;
        }

        public IEnumerable<TeacherModel> GetTeachers()
        {
            return (from a in mCollegeDbContext.MGTableTeachers
                    where a.BRANCHCODE == "4"
                    select new TeacherModel
                    {
                        TeacherID = a.TeacherID,
                        Name = a.Name,
                    }).OrderBy(o => o.Name).ToList();
        }

        public IEnumerable<ProgressComments> GetTeacherComments(int classId)
        {
            return (from a in mCollegeDbContext.MGTableProgressComments
                    where a.ClassID == classId
                    select new ProgressComments
                    {
                        CommentID = a.CommentID,
                        ClassID = a.ClassID,
                        StudentID = a.StudentID,
                        Week = (int)a.Week,
                        Attitude1 = a.Attitude1,
                        Attitude2 = a.Attitude2,
                        Attitude3 = a.Attitude3,
                        AttitudeComment = a.AttitudeComment,
                        Comment = a.Comment,
                        Editor = a.Editor,
                        TeacherID = (int)a.TeacherID,
                        CreatedDate = (DateTime)a.CreatedDate
                    }).OrderBy(o => new { o.Week, o.CreatedDate }).ToList();
        }

        public string GetClassName(int ClassID)
        {
            string ClassName = string.Empty;

            var ClassObj = (from a in mCollegeDbContext.MGTableClassInfoes
                            where a.ClassID == ClassID
                            select a).FirstOrDefault();


            ClassName = ClassObj.Year + (ClassObj.Term.Length <= 2 ? " T" + ClassObj.Term.Substring(1, 1) : " " + ClassObj.Term) + " Year " + ClassObj.Grade + " " + ClassObj.Subject + " " + ClassObj.Day + " " + ClassObj.ClassNo;

            return ClassName;
        }

        public IEnumerable<ProgressCommentVM> GetStudentListForProgress(int classId,int? studnetID = null)
        {
            var StudentTermTestResult = GetClassResults(classId);
            var TeacherObj = GetTeachers();
            var TeacherCommentsObj = GetTeacherComments(classId);

            var targetVM =
                    (from a in mCollegeDbContext.MGTableClassInfoes
                    join s in mCollegeDbContext.MGTableStudentEnrolls on a.ClassID equals s.ClassID
                    join std in mCollegeDbContext.tblStudents on s.StudentID equals std.StudentID
                    join t in mCollegeDbContext.MGTableTeachers on a.TeacherID1 equals t.TeacherID
                    where a.ClassID == classId && s.MGTableStudentDropClassIDX == null
                    select new
                    {
                        ClassID = a.ClassID,
                        TeacherID = a.TeacherID1,
                        TeacherName = t.Name,
                        CourseWeek = a.Week,
                        Year = a.Year,
                        Term = a.Term,
                        TestNo = 1,
                        StudentID = s.StudentID,
                        StudentName = std.FullName,
                        TestGrade = a.Grade
                    }).ToList().Select(vm => new ProgressCommentVM
                    {
                        Grade = vm.TestGrade,
                        StudentID = vm.StudentID,
                        StudentName = vm.StudentName,
                        ClassID = vm.ClassID,
                        TeacherID = (int)vm.TeacherID,
                        TeacherName = vm.TeacherName,
                        Year = vm.Year,
                        Term = vm.Term,
                        TestNo = vm.TestNo,
                        CourseWeek = vm.CourseWeek,
                        // This data comes from store-procedure, 'SP_GetTermTestClassAnalysis'. 
                        // Note: One class has multiple students and each of student id is found at most two times or 1 time or nothing  in the condition with the same student.
                        // First filtering is 'ClassID' and the second is 'StudentID'
                        StudentRecord = (from t in StudentTermTestResult
                                        where t.StudentID == vm.StudentID
                                        select t).ToList(),
                        // First filtering is 'ClassID' and the second is 'StudentID'
                        // Total number of comments is normally 1 
                        // but, it can be more than 1. ex> StudentID = 4075018 and ClassID=38202 in table 'MGTableProgressComments'
                        TeacherProgressComments = (from c in TeacherCommentsObj
                                                   where c.StudentID == vm.StudentID
                                                   select c).ToList(),
                        // All the teachers in html-contorl, dropwodn for user-selection
                        TeacherRecord = TeacherObj.ToList()

                    });

            if (studnetID.HasValue)
                targetVM = targetVM.Where(x => x.StudentID == studnetID.Value);

            return targetVM.OrderBy(s => s.StudentName);
        }

        public List<OnlineQuizScore> GetOnlineQuizScores(int ClassID, int StudentID)
        {
            int Year = 0;
            string Term = string.Empty;
            int TestGrade = 0;

            List<OnlineQuizScore> _OnlineQuizScores = new List<OnlineQuizScore>();

            var ClassInfo = from a in mCollegeDbContext.MGTableClassInfoes
                            where a.ClassID == ClassID
                            select a;

            Year = ClassInfo.FirstOrDefault().Year;
            Term = ClassInfo.FirstOrDefault().Term;
            TestGrade = ClassInfo.FirstOrDefault().Grade;

            int prevYear = Year;
            string prevTerm = Term;

            if (Term.Equals("01") || Term.ToUpper().Equals("SUMMER"))
            {
                prevYear = Year - 1;
                prevTerm = "4";
                TestGrade = TestGrade - 1;
            }
            else
            {
                if (Term.Equals("02") || Term.ToUpper().Equals("AUTUMN"))
                    prevTerm = "1";
                else if (Term.Equals("03") || Term.ToUpper().Equals("WINTER"))
                    prevTerm = "2";
                else if (Term.Equals("04") || Term.ToUpper().Equals("SPRING"))
                    prevTerm = "3";
            }

            //Year = ClassInfo.FirstOrDefault().Year;
            //Term = ClassInfo.FirstOrDefault().Term.Length == 2 ? ClassInfo.FirstOrDefault().Term.Substring(1, 1) : ClassInfo.FirstOrDefault().Term;
            //TestGrade = ClassInfo.FirstOrDefault().Grade;

            var QuizScore = (from a in GetOnlineQuizSummaryByStudentID(StudentID, prevYear, prevTerm, TestGrade)
                             select new OnlineQuizScore
                             {
                                 TestNo = a.TEST_NO,
                                 Maths = a.Maths,
                                 Eng = a.Eng,
                                 GA = a.GA,
                                 AVG = a.Average
                             }).ToList();

            return QuizScore;
        }

        public List<HomeworkScore> GetHomeworkMark(int ClassID, int StudentID, int Year, string Term)
        {
            int prevYear = Year;
            string prevTerm = Term;

            if (Term.Equals("01") || Term.ToUpper().Equals("SUMMER"))
            {
                prevYear = Year - 1;
                prevTerm = "04";
            }
            else
            {
                if (Term.Equals("02") || Term.ToUpper().Equals("AUTUMN")) prevTerm = "01";
                else if (Term.Equals("03") || Term.ToUpper().Equals("WINTER")) prevTerm = "02";
                else if (Term.Equals("04") || Term.ToUpper().Equals("SPRING")) prevTerm = "03";
            }

            var _classID = (from a in mCollegeDbContext.MGTableClassInfoes
                            join b in mCollegeDbContext.MGTableStudentEnrolls on a.ClassID equals b.ClassID
                            where a.Subject.Contains("EM") && a.Grade <= 6
                               && a.Year == prevYear && a.Term == prevTerm
                               && b.StudentID == StudentID
                            select b.ClassID).FirstOrDefault();

            if (!_classID.ToString().Equals(string.Empty))  // _classID != null &&
                ClassID = Convert.ToInt32(_classID);
            else 
                ClassID = 0;

            List<HomeworkScore> HomeworkScores = new List<HomeworkScore>();

            for (int i = 1; i < 13; i++)
            {
                HomeworkScores.Add(HomeWorkSubjectScore(ClassID, i, StudentID));
            }

            return HomeworkScores;
        }

        public HomeworkScore HomeWorkSubjectScore(int ClassID, int Week, int StudentID)
        {
            string MathsField = "W" + Week.ToString() + 'M';
            string EngField = "W" + Week.ToString() + 'E';
            string GAField = "W" + Week.ToString() + 'G';
            string NovelField = "W" + Week.ToString() + 'N';
            string AvgField = "W" + Week.ToString() + 'A';
            string WritingField = "W" + Week.ToString() + 'W';

            var HomeworkMarkObj = (from a in mCollegeDbContext.MGTableHomeWorks
                                   where a.ClassID == ClassID && a.StudentID == StudentID
                                   select a).ToList();

            HomeworkScore _HomeworkScore = new HomeworkScore();

            if (HomeworkMarkObj.Count() > 0)
            {
                var Scores = HomeworkMarkObj.Select(s => new 
                {
                    Maths = s.GetType().GetProperty(MathsField).GetValue(s, null) == null ? 0 : s.GetType().GetProperty(MathsField).GetValue(s, null),
                    Eng = s.GetType().GetProperty(EngField).GetValue(s, null) == null ? 0 : s.GetType().GetProperty(EngField).GetValue(s, null),
                    GA = s.GetType().GetProperty(GAField).GetValue(s, null) == null ? 0 : s.GetType().GetProperty(GAField).GetValue(s, null),
                    Novel = s.GetType().GetProperty(NovelField).GetValue(s, null) == null ? 0 : s.GetType().GetProperty(NovelField).GetValue(s, null),
                    AVG = s.GetType().GetProperty(AvgField).GetValue(s, null) == null ? 0 : s.GetType().GetProperty(AvgField).GetValue(s, null),
                    Writing = s.GetType().GetProperty(WritingField).GetValue(s, null) == null ? 0 : s.GetType().GetProperty(WritingField).GetValue(s, null)
                }).FirstOrDefault();

                _HomeworkScore.Week = Week;
                _HomeworkScore.Maths = Int32.Parse(Scores.Maths.ToString());
                _HomeworkScore.Eng = Int32.Parse(Scores.Eng.ToString());
                _HomeworkScore.GA = Int32.Parse(Scores.GA.ToString());
                _HomeworkScore.Novel = Int32.Parse(Scores.Novel.ToString());
                _HomeworkScore.Avg = Int32.Parse(Scores.AVG.ToString());
                _HomeworkScore.Writing = Int32.Parse(Scores.Writing.ToString());

            }
            else
            {
                _HomeworkScore.Week = Week;
                _HomeworkScore.Maths = 0;
                _HomeworkScore.Eng = 0;
                _HomeworkScore.GA = 0;
                _HomeworkScore.Novel = 0;
                _HomeworkScore.Avg = 0;
                _HomeworkScore.Writing = 0;
            }


            return _HomeworkScore;
        }

        public int SaveProgressComment(int ClassID, 
                                       int StudentID, 
                                       string Attitude1, 
                                       string Attitude2,
                                       string Attitude3,
                                       string Comment, 
                                       int Week, 
                                       int Teacher,
                                       string Editor, 
                                       int CommentID, 
                                       string userName)
        {
            Comment = Comment.Trim();
            if (CommentID == -1) // Create
            {
                MGTableProgressComments TeacherComment = new MGTableProgressComments();
                TeacherComment.StudentID = StudentID;
                TeacherComment.ClassID = ClassID;
                TeacherComment.Week = Week;
                TeacherComment.TeacherID = Teacher;
                TeacherComment.Editor = Editor;
                TeacherComment.UserID = userName; // This is not right. DB table requires UserName, not UserID (Table Name is wrong)
                TeacherComment.CommentID = CommentID;
                TeacherComment.Attitude1 = Attitude1;
                TeacherComment.Attitude2 = Attitude2;
                TeacherComment.Attitude3 = Attitude3;
                TeacherComment.Comment = Comment;
                TeacherComment.CreatedDate = DateTime.Now;
                TeacherComment.LastModifiedDate = DateTime.Now;

                mCollegeDbContext.MGTableProgressComments.Add(TeacherComment);
                mCollegeDbContext.SaveChanges();
                mCollegeDbContext.Entry(TeacherComment).GetDatabaseValues();

                return TeacherComment.CommentID;
            }
            else // Update
            {
                var modelFound = mCollegeDbContext.MGTableProgressComments.Find(CommentID);
                modelFound.ClassID = ClassID;
                modelFound.StudentID = StudentID;
                modelFound.Week = Week;
                modelFound.TeacherID = Teacher;
                modelFound.Comment = Comment;
                modelFound.Attitude1 = Attitude1;
                modelFound.Attitude2 = Attitude2;
                modelFound.Attitude3 = Attitude3;
                modelFound.LastModifiedDate = DateTime.Now;
                modelFound.Editor = Editor;
                modelFound.UserID = userName;
                
                mCollegeDbContext.Entry(modelFound);
                mCollegeDbContext.SaveChanges();

                return CommentID;
            }
        }
    }
}
