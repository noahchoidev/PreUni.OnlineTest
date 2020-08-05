using System;

namespace PreUni.Core.Model
{
    public class TermModel
    {
        public int TermId { get; set; }

        public int Year { get; set; }

        public string Term { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public int Week { get; set; }
        
        public DateTime StartDate2 { get; set; }
        
        public DateTime EndDate2 { get; set; }
        
        public int Week2 { get; set; }
        
        public int IsCurrent { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
