using PreUni.College.DAL.Model;
using System.Collections.Generic;

namespace PreUni.College.DAL.ViewModel
{
    public class ProgressCommentVM
    {
        
        public int ClassID { get; set; }
        
        public int TeacherID { get; set; }
        
        public string TeacherName { get; set; }
        
        public int CourseWeek { get; set; }
        
        public int Year { get; set; }
        
        public string Term { get; set; }
        
        public int TestNo { get; set; }
        
        public int Grade { get; set; }
        
        public int StudentID { get; set; }
        
        public string StudentName { get; set; }
        
        //public ProgressComment TeacherComments { get; set; }
        
        public IEnumerable<ProgressComments> TeacherProgressComments { get; set; }
        
        public IEnumerable<ClassResults> StudentRecord { get; set; }
        
        public IEnumerable<TeacherModel> TeacherRecord { get; set; }
    }
}