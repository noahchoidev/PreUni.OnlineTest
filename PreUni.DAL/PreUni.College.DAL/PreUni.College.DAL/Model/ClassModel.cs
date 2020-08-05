using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreUni.College.DAL.Model
{
    public class ClassModel
    {
        public int ClassID { get; set; }

        public int Year { get; set; }

        public String Term { get; set; }

        public int Grade { get; set; }

        public String Subject { get; set; }

        public String Day { get; set; }

        public DateTime? StartDate { get; set; }

        public int ClassNo { get; set; }

        public int? CourseSubjectId { get; set; }
    }

}