using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreUni.OnlineTest.Web.MVC.ViewModel
{
    public class BranchSelectionTriggerModel
    {
        public string TestType { get; set; }
     
        public int Year { get; set; }

        public string Term { get; set; }
    }

    public class ClassSelectionTriggerModel
    {
        public string TestType { get; set; }
        
        public int Year { get; set; }

        public string Term { get; set; }

        public string BranchCode { get; set; }
    }
}