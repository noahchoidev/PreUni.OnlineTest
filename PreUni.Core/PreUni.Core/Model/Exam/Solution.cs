using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class Solution : BasicEntity
    {
        public string Content { get; set; }

        public string SolutionPictureURL { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }

    }
}
