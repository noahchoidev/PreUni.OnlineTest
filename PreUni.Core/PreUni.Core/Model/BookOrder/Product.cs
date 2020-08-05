namespace PreUni.Core.Model
{
    //Table("Tbl_Product")]
    public class ProductModel
    {
        //[Key]
        public int ProductId { get; set; }

        public int ProductYear { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel Categories { get; set; }

        //public int TermId { get; set; }        
        //public TermModel Terms { get; set; }

    }
}
