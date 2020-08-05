using System;

namespace PreUni.Core.Model
{
    public class ClassViewModel
    {
        public int ClassID { get; set; }

        public int Year { get; set; }

        public string Term { get; set; }

        public int Grade { get; set; }

        public string Subject { get; set; }

        public string Day { get; set; }

        public DateTime? StartDate { get; set; }

        public int ClassNo { get; set; }

        public int? CourseSubjectId { get; set; }
    }
}
