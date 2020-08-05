namespace PreUni.Core.Model
{
    public class CollegeModel
    {
        public string BranchCode { get; set; }
        
        public string BranchName { get; set; }

        public string Street { get; set; }

        public string Pcode { get; set; }

        public string Locality { get; set; }

        public string State { get; set; }

        public int SuburbID { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Principal { get; set; }

        public string EmailAddress { get; set; }

        public int? nextavailablerowid { get; set; }

    }
}
