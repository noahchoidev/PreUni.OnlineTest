namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MGTableHomeWork")]
    public partial class MGTableHomeWork
    {
        [Key]
        [Column(Order = 0)]
        public int Seq { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassID { get; set; }

        public int? W1E { get; set; }

        public int? W1M { get; set; }

        public int? W1N { get; set; }

        public int? W1G { get; set; }

        public int? W1A { get; set; }

        public int? W2E { get; set; }

        public int? W2M { get; set; }

        public int? W2N { get; set; }

        public int? W2G { get; set; }

        public int? W2A { get; set; }

        public int? W3E { get; set; }

        public int? W3M { get; set; }

        public int? W3N { get; set; }

        public int? W3G { get; set; }

        public int? W3A { get; set; }

        public int? W4E { get; set; }

        public int? W4M { get; set; }

        public int? W4N { get; set; }

        public int? W4G { get; set; }

        public int? W4A { get; set; }

        public int? W5E { get; set; }

        public int? W5M { get; set; }

        public int? W5N { get; set; }

        public int? W5G { get; set; }

        public int? W5A { get; set; }

        public int? W6E { get; set; }

        public int? W6M { get; set; }

        public int? W6N { get; set; }

        public int? W6G { get; set; }

        public int? W6A { get; set; }

        public int? W7E { get; set; }

        public int? W7M { get; set; }

        public int? W7N { get; set; }

        public int? W7G { get; set; }

        public int? W7A { get; set; }

        public int? W8E { get; set; }

        public int? W8M { get; set; }

        public int? W8N { get; set; }

        public int? W8G { get; set; }

        public int? W8A { get; set; }

        public int? W9E { get; set; }

        public int? W9M { get; set; }

        public int? W9N { get; set; }

        public int? W9G { get; set; }

        public int? W9A { get; set; }

        public int? W10E { get; set; }

        public int? W10M { get; set; }

        public int? W10N { get; set; }

        public int? W10G { get; set; }

        public int? W10A { get; set; }

        public int? W11E { get; set; }

        public int? W11M { get; set; }

        public int? W11N { get; set; }

        public int? W11G { get; set; }

        public int? W11A { get; set; }

        public int? W12E { get; set; }

        public int? W12M { get; set; }

        public int? W12N { get; set; }

        public int? W12G { get; set; }

        public int? W12A { get; set; }

        public int? W1W { get; set; }

        public int? W2W { get; set; }

        public int? W3W { get; set; }

        public int? W4W { get; set; }

        public int? W5W { get; set; }

        public int? W6W { get; set; }

        public int? W7W { get; set; }

        public int? W8W { get; set; }

        public int? W9W { get; set; }

        public int? W10W { get; set; }

        public int? W11W { get; set; }

        public int? W12W { get; set; }
    }
}
