using System;

namespace PreUni.Core.Model
{
    public class OrderDetailViewModel
    {
        //public OrderDetailViewModel(OrderDetailModel row)
        //{
        //    OrderId = row.OrderId;
        //    OrderDetailID = row.OrderDetailID;
        //    Quantity = row.Quantity;
        //    TeachersCopyQty = row.TeachersCopyQty;
        //    Status = row.Status;
        //    ProductYear = row.Product.ProductYear;
        //    ProductName = row.Product.ProductName;
        //    Week = row.Week;
        //    ProductId = row.ProductID;
        //    //Orderdate = row.Order.CreatedAt.ToString("yyyy-MM-dd");
        //    //UserId = row.user;
        //    //Price = row.Product.Price;
        //    //Total = row.Price;
        //    CategoryName = row.Product.Categories.CategoryName;
        //    //TermName = row.Product.Terms.Year + " - " + row.Product.Terms.Term;
        //}

        //public OrderDetailViewModel()
        //{

        //}

        public int OrderId { get; set; }

        public int OrderDetailID { get; set; }

        public string OrderNo { get; set; }

        public string BranchCode { get; set; }

        public string BranchName { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int Quantity { get; set; }

        public int TeachersCopyQty { get; set; }

        //public decimal GrandTotal { get; set; }
        
        public decimal Total { get; set; }

        public int Status { get; set; }

        public DateTime Orderdate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int Week { get; set; }

        //public int TotalWeek { get; set; }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public int TermID { get; set; }

        public string TermName { get; set; }

        public int Year { get; set; }

        public int ProductId { get; set; }

        public int ProductYear { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
