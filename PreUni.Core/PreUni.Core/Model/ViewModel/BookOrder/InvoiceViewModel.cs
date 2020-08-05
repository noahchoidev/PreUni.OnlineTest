using System;
using System.Collections.Generic;

namespace PreUni.Core.Model
{
    public class InvoiceViewModel
    {
        public InvoiceViewModel()
        {

        }

        public InvoiceViewModel(OrderModel row)
        {
            OrderId = row.OrderId;
            OrderNo = row.OrderNo;
            CreatedAt = row.CreatedAt;
            //GrandTotal = row.GrandTotal.ToString("C");
        }
        
        public int OrderId { get; set; }
        
        public string OrderNo { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public string CreatedDay { get; set; }
        
        public string CreatedTerm { get; set; }
        
        public string BranchName { get; set; }
        
        public string BranchAddress { get; set; }
        
        public List<OrderDetailViewModel> OrderDetailList { get; set; }
        
        public string GST { get; set; }
        
        public string Price { get; set; }
        
        public string SubTotal { get; set; }
        
        public string DiscountTotal { get; set; }
            
        public string GrandTotal { get; set; }
    }
}
