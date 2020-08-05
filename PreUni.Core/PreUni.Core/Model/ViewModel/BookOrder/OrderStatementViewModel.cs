using System;

namespace PreUni.Core.Model
{
    public class OrderStatementViewModel
    {
        public OrderStatementViewModel(OrderModel row)
        {
            OrderId = row.OrderId;
            OrderNo = row.OrderNo;
            CreatedAt = row.CreatedAt;
            //GrandTotal = row.GrandTotal;
            UserId = row.UserId;
            BranchCode = row.BranchCode;
        }

        public OrderStatementViewModel()
        {

        }

        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public decimal GrandTotal { get; set; }
        public string UserId { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
