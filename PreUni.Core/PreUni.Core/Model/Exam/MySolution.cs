using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class MySolution
    {
        public int MySolutionsID { get; set; }

        public string TrialAnswer { get; set; }

        public int ITakeExamNowID { get; set; }
        public ITakeExamNow ITakeExamNow { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }

        public int SolutionID { get; set; }
        public Solution Solution { get; set; }
    }
}
