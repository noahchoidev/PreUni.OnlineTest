using System;

namespace PreUni.College.DAL.Model
{
    public class ProgressComments
    {
        
        public int CommentID { get; set; }
        
        public int ClassID { get; set; }
        
        public int StudentID { get; set; }
        
        public int Week { get; set; }
        
        public int TeacherID { get; set; }
        
        public string Editor { get; set; }
        
        public string Attitude1 { get; set; }
        
        public string Attitude2 { get; set; }
        
        public string Attitude3 { get; set; }
        
        public string AttitudeComment { get; set; }
        
        public string Comment { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}
