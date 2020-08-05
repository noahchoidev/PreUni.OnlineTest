using System.Collections.Generic;

namespace PreUni.Core.Model
{
    public class UserDTOIndexViewModel
    {
        //[Display(Name = LocalConstants.USERID)]
        public string UserID { get; set; }

        //[Display(Name = LocalConstants.USERNAME)]
        public string UserName { get; set; }

        //[Display(Name = LocalConstants.EMAIL)]
        public string EmailAddress { get; set; }

        //[Display(Name = LocalConstants.BRANCH)]
        public int Department { get; set; }

        public IEnumerable<UserRoleViewModel> UserRoles { get; set; }
    }

    public class UserDTOCreateViewModel
    {

    }

    public class UserDTOEditViewModel
    {

    }

    public class UserDTODeleteViewModel
    {

    }
}
