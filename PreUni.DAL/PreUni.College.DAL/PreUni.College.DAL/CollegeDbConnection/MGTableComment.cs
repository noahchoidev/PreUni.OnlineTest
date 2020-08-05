namespace PreUni.College.DAL.CollegeDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MGTableComment")]
    public partial class MGTableComment
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
        [StringLength(50)]
        public string Type { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "text")]
        public string Comment { get; set; }

        public int? BookingSessionID { get; set; }

        [StringLength(50)]
        public string CreateUser { get; set; }
    }
}
