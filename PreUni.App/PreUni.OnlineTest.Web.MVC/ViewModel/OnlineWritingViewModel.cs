using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreUni.OnlineTest.Web.MVC.ViewModel
{
    public class OnlineWritingViewModel
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public int TestID { get; set; }

        public string TEST_NAME { get; set; }

        public int Year { get; set; }

        public string Term { get; set; }

        public int TEST_NO { get; set; }

        public string WritingText { get; set; }

        public string ReWritingText { get; set; }

        public string Mark { get; set; }

        public string OriginalMark { get; set; }

        public string Comment { get; set; }
        
        public int? IsFinish { get; set; }

        public bool IsGeneralTest { get; set; }

        public int Score { get; set; }

        public string Marker { get; set; }

        public int TestTypeID { get; set; }

    }
}