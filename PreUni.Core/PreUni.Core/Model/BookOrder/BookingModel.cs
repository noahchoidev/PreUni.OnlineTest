using System;

namespace PreUni.Core.Model
{
    public class BookingModel
    {
        public int ID { get; set; }
        
        public DateTime BookDate { get; set; }
        
        public int? BranchCode { get; set; }
        
        public DateTime? UpdateDate { get; set; }
        
        public DateTime? CreateDate { get; set; }

        public int ScanTimeID { get; set; }
        //public ScanningTimeModel ScanningTimeModel { get; set; }   
    }
}
