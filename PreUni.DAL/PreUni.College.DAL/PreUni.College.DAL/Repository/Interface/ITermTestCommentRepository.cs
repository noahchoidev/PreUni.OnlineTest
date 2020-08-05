using PreUni.College.DAL.Model;
using PreUni.College.DAL.ViewModel;
using System;
using System.Collections.Generic;

namespace PreUni.College.DAL.Repository
{
    public interface ITermTestCommentRepository
    {
        //IEnumerable<ProgressCommentVM> GetStudentListForProgress(int ClassID);

        // Test , Delete later on.
        IEnumerable<ClassResults> GetClassResults(int classId);

        IEnumerable<TeacherModel> GetTeachers();

        IEnumerable<ProgressComments> GetTeacherComments(int classId);

        IEnumerable<ProgressCommentVM> GetStudentListForProgress(int classId, int? studnetID = null);

        string GetClassName(int classId);

        List<OnlineQuizScore> GetOnlineQuizScores(int ClassID, int StudentID);

        List<HomeworkScore> GetHomeworkMark(int ClassID, int StudentID, int Year, string Term);

        int SaveProgressComment(int ClassID, int StudentID, string Attitude1,
                                string Attitude2, string Attitude3, string Comment,
                                int Week, int Teacher, string Editor, int CommentID, 
                                string userID);
        /*        
                IEnumerable<TermTestCommentVM> GetStudentList(int ClassID);

                void Save(int Year, string Term, int Grade, int StudentID, string Comment, string editor);

                void SaveAll(List<Comment> TeacherComments, string editor);

                void SaveProgressComment(int ClassID, int StudentID, string Comment1, string Comment2, string Comment3, string Comment4, string editor);

                int SaveProgressComment(int ClassID, int StudentID, string Attitude1, string Attitude2, string Attitude3, string Comment, int Week, int Teacher, string Editor, int CommentID, string userID);

                void SaveAllProgressComment(List<ProgressComment> ProgressComments, string editor);

                List<HomeworkScore> GetHomeworkMark(int ClassID, int StudentID, int Year, string Term);

                List<OnlineQuizScore> GetOnlineQuizScores(int ClassID, int StudentID);

                bool CheckAnyCommentChanged(List<Comment> TeacherComments);

                bool CheckAnyProgressCommentChanged(List<ProgressComment> ProgressComments);

                string GetClassName(int ClassID);
        */
    }
}
