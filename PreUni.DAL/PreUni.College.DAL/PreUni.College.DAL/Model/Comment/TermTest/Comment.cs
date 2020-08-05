using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.College.DAL.Model
{
    public class Comment
    {
        public int Year { get; set; }
        public string Term { get; set; }
        public int Grade { get; set; }
        public int StudentID { get; set; }
        public string TeacherComment { get; set; }
    }
}
