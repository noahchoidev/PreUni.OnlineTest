using System.Collections.Generic;

namespace PreUni.Core.Model
{
    public class ProductViewModel
    {
        //Summary:
        //  Products for order
        //  Refer : 
        //      -> Branch/Cart/index/ - View cart
        //      -> Branch/Cart/AddToCart/ - Add items to cart
        //      -> Branch/Order/Index/ - View Products List
        public int ProductId { get; set; }

        public int ProductYear { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int TermId { get; set; }

        public string TermName { get; set; }

        public int TermYear { get; set; }

        public int Quantity { get; set; }

        public int TeachersCopyQty { get; set; }

        public int Total { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public string ImageOriginalURL { get; set; }

        public bool IsHolidayTerm { get; set; }

    }

    public class ProductCreateViewModel
    {
        public int ProductYear { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int TermId { get; set; }

        public List<BranchViewModel> BranchViewModels { get; set; }
    }

    public class ProductEditViewModel
    {
        public int ProductId { get; set; }

        public int ProductYear { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int TermId { get; set; }

        public List<BranchViewModel> BranchViewModels { get; set; }
    }

    public class BranchViewModel
    {
        public string BranchCode { get; set; }

        public string BranchName { get; set; }

        public bool IsSelected { get; set; }
    }
}
