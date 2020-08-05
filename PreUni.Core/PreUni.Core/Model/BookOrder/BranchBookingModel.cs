using System;

namespace PreUni.Core.Model
{
    //[Table("tblBranchBooking")]
    public class BranchBookingModel
    {
        //[Key]
        public int ID { get; set; }
        //[Required]
        public DateTime BookDate { get; set; }
        //[Required]
        public int ScanTimeID { get; set; }
        public int BranchCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
