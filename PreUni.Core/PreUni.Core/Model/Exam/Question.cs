using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class Question : BasicEntity
    {
        public int QuestionID { get; set; }

        public string QuestionPictureURL { get; set; }

        // Relationships

        public int ExamID { get; set; }
        public Exam Exam { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
    }
}
