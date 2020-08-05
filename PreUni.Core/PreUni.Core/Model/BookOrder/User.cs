namespace PreUni.Core.Model
{
    //[Table("View_Users")]
    public class UserModel
    {
        //[Key]
        //[Required]
        public string UserID { get; set; }

        //[Required]
        public string Password { get; set; }

        //이름
        //[Required]
        public string UserName { get; set; }

        //[Required]
        public int Department { get; set; }

        public int? User_Level { get; set; }

        //[Required]
        public int BranchCode { get; set; }

        //[Required]
        public string BranchName { get; set; }

        //[Required]
        public string EmailAddress { get; set; }

        //[Required]
        public string Street { get; set; }

        //[Required]
        public string Suburb { get; set; }

        //[Required]
        public string State { get; set; }

        //[Required]
        public string Postcode { get; set; }

        //[StringLength(25)]
        public string Phone { get; set; }

        //[StringLength(1)]
        public string Activated { get; set; }

        //[StringLength(50)]
        public string Principal { get; set; }
    }
}
