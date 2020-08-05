using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{

    public class ITakeExamNow : BasicEntity
    {
        public int ITakeExamNowID { get; set; }

        public int TestTakerID { get; set; }

        public int ExamSubjectID { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndingDate { get; set; }

        public DateTime LastConnectAt { get; set; }
        
        // Relationships
        
        //public TestTaker TestTaker { get; set; }

        //public ExamSubject ExamSubject { get; set; }

        //public ICollection<MySolution> MySolutions { get; set; }
    }
}
