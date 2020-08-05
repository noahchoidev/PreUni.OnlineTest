using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class ITakeExamNowViewModel
    {
        public int ITakeExamNowID { get; set; }

        public int TestTakerID { get; set; }

        public int ExamSubjectID { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndingDate { get; set; }

        public DateTime LastConnectAt { get; set; }

        public int TestTypeID { get; set; }

        public string TestTypeName { get; set; }

        public int TestTermID { get; set; }

        public string TermName { get; set; }

        public int ExamID { get; set; }

        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public TimeSpan TestDuration { get; set; }
    }
}
