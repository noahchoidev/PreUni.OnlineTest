using PreUni.College.DAL.Model;

namespace PreUni.College.DAL.ViewModel
{
    public class TermTestCommentVM
    {
        public int ClassID { get; set; }
        public int Year { get; set; }
        public string Term { get; set; }
        public int TestNo { get; set; }
        public int Grade { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public Result StudentRecord { get; set; }
        public string Comment { get; set; }

    }
}