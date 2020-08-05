using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class TestTerm
    {
        public int TestTermID { get; set; }

        public string TermName { get; set; }

        public int Year { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
