using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class TestInfoViewModel
    {
        public int ExamSubjectID { get; set; }

        public int ExamID { get; set; }

        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public string Year { get; set; }

        public string ExamDescription { get; set; }

        // Relationships Below

        public int TestTypeID { get; set; }

        public string TestTypeName { get; set; }

        public int TestTermID { get; set; }

        public string TermName { get; set; }

        public TimeSpan TestDuration { get; set; }
    }
}
