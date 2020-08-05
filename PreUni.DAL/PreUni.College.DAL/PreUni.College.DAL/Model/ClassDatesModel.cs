using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreUni.College.DAL.Model
{
    public class ClassDatesModel 
    {
        public int ClassId { get; set; }

        public int TotalWeek { get; set; }

        public List<ClassWeekNDate> WeekNDate { get; set; }
    }

    public class ClassWeekNDate
    {
        public int WeekNum { get; set; }

        public String ClassDate { get; set; }

    }
}