using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreUni.College.DAL.CollegeDbConnection
{
    public partial class tblCollege
    {
        [Key]
        [StringLength(2)]
        public string BranchCode { get; set; }

        [Required]
        [StringLength(25)]
        public string BranchName { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(4)]
        public string Pcode { get; set; }

        [StringLength(50)]
        public string Locality { get; set; }

        [StringLength(3)]
        public string State { get; set; }

        public int SuburbID { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(25)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Principal { get; set; }

        [StringLength(100)]
        public string EmailAddress { get; set; }

        public int? nextavailablerowid { get; set; }
    }
}
