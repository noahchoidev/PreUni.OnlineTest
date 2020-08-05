using System;
using System.ComponentModel.DataAnnotations;

namespace PreUni.College.DAL.NewcollegeDbConnection
{
    public partial class NC_TEST_TEST
    {
        [Key]
        public int TEST_ID { get; set; }

        public int? YEAR { get; set; }

        [StringLength(6)]
        public string TERM { get; set; }

        public int? TEST_TYPE_ID { get; set; }

        public int? TEST_NO { get; set; }

        public int? TEST_GRADE { get; set; }

        [Required]
        [StringLength(100)]
        public string TEST_NAME { get; set; }

        public DateTime? CREATE_DATE { get; set; }
    }
}
