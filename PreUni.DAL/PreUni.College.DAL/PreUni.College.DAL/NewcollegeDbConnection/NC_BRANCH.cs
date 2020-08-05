using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreUni.College.DAL.NewcollegeDbConnection
{
    public partial class NC_BRANCH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassID { get; set; }

        public int? BranchCode { get; set; }

        [StringLength(255)]
        public string BranchName { get; set; }
    }
}
