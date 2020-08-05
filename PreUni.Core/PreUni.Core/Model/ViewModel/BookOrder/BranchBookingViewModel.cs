using System;

namespace PreUni.Core.Model
{
    public class BranchBookingViewModel
    {
        public DateTime BookDate { get; set; }
        
        public int BookingID { get; set; }

        public int ScanTimeID { get; set; }
        
        public int BranchCode { get; set; }
        
        public string BranchName { get; set; }
        
        public DateTime? UpdateDate { get; set; }
        
        public DateTime? CreateDate { get; set; }

        //public bool IsAccessEdit { get; set; }
    }
}
