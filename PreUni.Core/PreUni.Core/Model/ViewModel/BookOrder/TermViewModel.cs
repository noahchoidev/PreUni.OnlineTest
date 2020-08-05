using System;

namespace PreUni.Core.Model
{
    public class TermViewModel
    {
        public int TermId { get; set; }
        
        public int Year { get; set; }
        
        public string Term { get; set; }
        
        public string Name { get; set; }

        public int IsCurrent { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Week { get; set; }
    }

}
