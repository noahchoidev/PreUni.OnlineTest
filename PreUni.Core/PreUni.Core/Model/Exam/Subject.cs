using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class Subject : BasicEntity
    {
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        // Relationships

        public ICollection<ExamSubject> ExamSubjectList { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
