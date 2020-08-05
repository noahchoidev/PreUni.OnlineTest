using PreUni.College.DAL.Model;
using PUNC.TEACHER.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.College.DAL.Repository
{
    public interface IRolesRepository : IDisposable
    {
        IEnumerable<UserRole> GetMemberRoles(int userId);

        IEnumerable<Role> GetAllRoles();

        UserRole CreateUserRole(UserRole userRole);

        void UpdateUserRole(webpages_UsersInRoles userRole);

        void DeleteUserRole(UserRole userRole);

        void Save();
    }
}
