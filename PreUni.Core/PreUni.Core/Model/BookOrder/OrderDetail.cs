namespace PreUni.Core.Model
{
    public class OrderDetailModel
    {
        //[Key]
        //[Column(Order = 0)]
        public int OrderDetailID { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //public string UserId { get; set; }

        //[Key]
        //[Column(Order = 2)]
        //public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int TeachersCopyQty { get; set; }

        public int Status { get; set; }

        public int Week { get; set; }

        //public decimal GrandTotal { get; set; }

        public int TermID { get; set; }

        public TermModel TermModel { get; set; }

        public int OrderId { get; set; }
        public virtual OrderModel Order { get; set; }

        public int ProductID { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}
