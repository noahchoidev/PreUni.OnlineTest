using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreUni.College.DAL.Model
{
    public class ClassResults
    {
        public int ClassID { get; set; }

        public int Year { get; set; }

        public String Term { get; set; }

        public int StudentID { get; set; }

        public int? Maths { get; set; }

        public int? Eng { get; set; }

        public int? GA { get; set; }

        public int? Writing { get; set; }

        public int? StudentAVG { get; set; }

        public int? GradeAVG { get; set; }

        public int? StudentRanking { get; set; }

        public int? TotalRanking { get; set; }
    }
}
