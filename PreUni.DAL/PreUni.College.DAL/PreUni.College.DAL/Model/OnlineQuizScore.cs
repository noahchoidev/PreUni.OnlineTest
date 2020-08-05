using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.College.DAL.Model
{
    public class OnlineQuizScore
    {
        public int TestNo { get; set; }
        public int Maths { get; set; }
        public int Eng { get; set; }
        public int GA { get; set; }
        public int AVG { get; set; }
        public int Ranking { get; set; }
    }

    public class OnlineQuizScore_Result
    {
        //*****************************************
        public short YEAR { get; set; }
        public string TERM { get; set; }
        public short test_type_ID { get; set; }
        public short TEST_GRADE { get; set; }
        //*****************************************

        public short TEST_NO { get; set; }
        public int Maths { get; set; }
        public int Eng { get; set; }
        public int GA { get; set; }
        public int Average { get; set; }
        //public int Ranking { get; set; }
    }
}
