using System;

namespace PreUni.Core.Model
{
    public class UnPermittableBranchProduct
    {
        //[Key]
        //[Column(Order = 0)]
        public int ProductID { get; set; }
        public ProductModel ProductModel { get; set; }

        //[Key]
        //[Column(Order = 1)]
        public string BranchCode { get; set; } // Switched int into string
        public CollegeModel CollegeModel { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
