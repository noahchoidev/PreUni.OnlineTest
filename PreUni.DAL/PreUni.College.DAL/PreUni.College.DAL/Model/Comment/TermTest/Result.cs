using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreUni.College.DAL.Model
{
    public class Result
    {
        public double Maths { get; set; }
        public double Eng { get; set; }
        public double GA { get; set; }
        public double StudentAVG { get; set; }
        public double GradeAVG { get; set; }
        public int StudentRanking { get; set; }
        public int TotalRanking { get; set; }
        public int StudentID { get; set; }
    }
}