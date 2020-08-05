using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class ExamSubject : BasicEntity
    {
        public int ExamSubjectID { get; set; }

        public int ExamID { get; set; }
        public Exam Exam { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public TimeSpan TestDuration { get; set; }

    }
}
