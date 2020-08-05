using System.Collections.Generic;

namespace PreUni.Core.Model
{
    public class UserRoleViewModel
    {
        //public string UserId { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string UserName { get; set; }
    }

    public class UserRoleSelectedViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }

    public class UserRoleEditViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        //public int RoleId { get; set; }
        //public string RoleName { get; set; }

        public List<UserRoleSelectedViewModel> Roles { get; set; } 

    }
}
