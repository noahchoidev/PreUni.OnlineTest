using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class TestType 
    {
        public int TestTypeID { get; set; }

        public string TestTypeName { get; set; }

        public ICollection<Exam> Exams { get; set; }

    }
}
