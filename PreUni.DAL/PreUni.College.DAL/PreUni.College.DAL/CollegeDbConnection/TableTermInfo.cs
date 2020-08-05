namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableTermInfo")]
    public partial class TableTermInfo
    {
        [Key]
        public int Seq { get; set; }

        public int Year { get; set; }

        [Required]
        [StringLength(50)]
        public string Term { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EarlyBirdDate { get; set; }

        public DateTime? FullTermDate { get; set; }

        [StringLength(10)]
        public string FullTermEnable { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrentTerm { get; set; }

        public int? Week { get; set; }

        public int? TTC_STARTNO { get; set; }

        [StringLength(50)]
        public string TTC_START_SUBJECT { get; set; }

        public int? OC_STARTNO { get; set; }

        [StringLength(10)]
        public string IS_CURRENT { get; set; }

        public int? TTC_NoOfTests { get; set; }

        public int? OC_NoOfTests { get; set; }

        public DateTime? SSCDate { get; set; }
    }
}
