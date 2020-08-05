using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class Exam : BasicEntity
    {
        public int ExamID { get; set; }

        public string Year { get; set; }

        public string ExamDescription { get; set; }

        public int TestNo { get; set; }

        // Relationships Below
        public int TestTypeID { get; set; }
        public TestType TestType { get; set; }

        public int TestTermID { get; set; }
        public TestTerm TestTerm { get; set; }

        public ICollection<ExamSubject> ExamSubjectList { get; set; }
    }

    public class ExamFromSP : BasicEntity
    {
        public int ExamID { get; set; }

        public string Year { get; set; }

        public string ExamDescription { get; set; }

        // Relationships Below

        public int TestTypeID { get; set; }
        public string TestTypeName { get; set; }

        public int TestTermID { get; set; }
        public string TermName { get; set; }

    }
}
