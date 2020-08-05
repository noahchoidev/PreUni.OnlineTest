using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreUni.College.DAL.Model
{
    public class MakeUpTargetModel
    {
        public int StudentId { get; set; }

        public String Name { get; set; }

        public String Branch { get; set; }

        public int Grade { get; set; }

        public int ClassId { get; set; }

        public String Class { get; set; }

        public String Locality { get; set; }

        public DateTime? DropDate { get; set; }
    }
}