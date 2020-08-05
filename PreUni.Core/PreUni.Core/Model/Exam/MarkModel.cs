using PreUni.Core.Model.Local.Mark;
using System;
using System.Collections.Generic;

namespace PreUni.Core.Model
{
    public class WritingMark
    {
        public int TestTakerID { get; set; }

        public int ExamID { get; set; }

        public int SubjectID { get; set; }

        public int QuestionID { get; set; }

        public string TrialAnswer { get; set; }

        public DateTime MarkedAt { get; set; }

        public IDictionary<Writing_Criteria_Item, int> Writing_Criteria_Items { get; set; }
    }
}
