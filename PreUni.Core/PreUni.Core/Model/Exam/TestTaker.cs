using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    public class TestTaker : BasicEntity
    {
        public int TestTakerID { get; set; }
 
        public string FullName { get; set; }

        public DateTime TakingExamAt { get; set; }
    }
}
