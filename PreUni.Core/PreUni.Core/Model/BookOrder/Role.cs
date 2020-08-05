namespace PreUni.Core.Model
{
    //Summary:
    //  Roles - Franchise, Branch
    //  ForeignKey : UserRoleDTO_RoleId
    //[Table("Tbl_Role")]
    public class RoleModel
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }
    }
}
