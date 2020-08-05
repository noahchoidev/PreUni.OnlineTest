namespace PreUni.Core.Model
{
    public class TermProductModel    
    {

        public int ProductID { get; set; }
        
        public int TermID { get; set; }

        public ProductModel Product { get; set; }

        public TermModel Term { get; set; }
    }
}
