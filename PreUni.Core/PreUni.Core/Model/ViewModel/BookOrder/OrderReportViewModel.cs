using System;
using System.Collections.Generic;

namespace PreUni.Core.Model
{
    public class OrderReportViewModel
    {
        public int Year { get; set; }

        public int TermId { get; set; }

        public string Term { get; set; }

        public string State { get; set; }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        
        public string ProductName { get; set; }
        
        public int BranchCode { get; set; }
        
        public string BranchName { get; set; }
        
        public int Grade { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }
        
        public int Quantity { get; set; }

        public int TeachersCopyQty { get; set; }

        public decimal Price { get; set; }

        public int Week { get; set; }

        public string UserID { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TTC_NoOfTests { get; set; }

        public int OC_NoOfTests { get; set; }

        public int TotalBookQty { get; set; }

        public int[] WeeklyQty { get; set; } = new int[12];

        public List<OrderReportSubElement> GroupingSubList { get; set; }
    }

    //public class OrderReportElement
    //{
    //    public int Year { get; set; }

    //    public int TermId { get; set; }

    //    public string State { get; set; }

    //    public int ProductId { get; set; }

    //    public int Grade { get; set; }

    //    //public int TotalQuantity { get; set; }
    //    //public int TotalTeachersCopyQty { get; set; }
    //}

    public class OrderReportSubElement
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string TermName { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    //public class Weekly
    //{

    //    public int W0 { get; set; }

    //    public int W1 { get; set; }

    //    public int W2 { get; set; }

    //    public int W3 { get; set; }

    //    public int W4 { get; set; }

    //    public int W5 { get; set; }

    //    public int W6 { get; set; }

    //    public int W7 { get; set; }

    //    public int W8 { get; set; }

    //    public int W9 { get; set; }

    //    public int W10 { get; set; }

    //    public int W11 { get; set; }

    //    public int W12 { get; set; }
    //}
}
