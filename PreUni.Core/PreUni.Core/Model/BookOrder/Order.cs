using System;
using System.Collections;
using System.Collections.Generic;

namespace PreUni.Core.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        //public int ProductID { get; set; }

        public string OrderNo { get; set; }

        //public int TermID { get; set; }
        //public TermModel TermModel { get; set; }

        public string UserId { get; set; }

        public int BranchCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        //public decimal GrandTotal { get; set; }

        public virtual ICollection<OrderDetailModel> OrderDetailModels { get; set; }
    }
}
