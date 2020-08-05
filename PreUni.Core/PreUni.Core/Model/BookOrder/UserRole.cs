namespace PreUni.Core.Model
{
    //[Table("Tbl_UserRole")]
    public class UserRoleModel
    {
        //public int key { get; set; }

        //[Key, Column(Order = 0)]
        public string UserId { get; set; }
        //[ForeignKey("UserId")]
        public UserModel User { get; set; }

        //[Key, Column(Order = 1)]
        public int RoleId { get; set; }

        //[ForeignKey("RoleId")]
        public RoleModel Role { get; set; }

    }
}
