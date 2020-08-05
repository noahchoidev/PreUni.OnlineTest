using PUNC.TEACHER.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.College.DAL.Repository
{
    public class RolesRepository : IRolesRepository, IDisposable
    {
        private RoleContext context;

        public RolesRepository(RoleContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserRole> GetMemberRoles(int userId)
        {

            //IEnumerable<UserRole> query = context.webpages_UsersInRoles
            //    .Include(m => m.webpages_Roles)
            //    .Select(m => new UserRole
            //    {
            //        UserId = m.UserId,
            //        RoleId = m.RoleId,
            //        RoleName = m.webpages_Roles.RoleName
            //    });

            //return query.ToList();


            return context.webpages_UsersInRoles
                .Join(context.webpages_Roles, userRole => userRole.RoleId, roles => roles.RoleId, (userRole, roles)
                    => new UserRole
                    {
                        UserRoleId = userRole.UserRoleId,
                        UserId = userRole.UserId,
                        RoleId = userRole.RoleId,
                        RoleName = roles.RoleName
                    })
                    .Where(u => u.UserId == userId)
                    .ToList();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            var administrator = from m in context.webpages_Roles
                                where m.RoleId == 1
                                select m;

            IEnumerable<Role> query = context.webpages_Roles
                .Except(administrator)
                .OrderBy(r => r.RoleId)
                .Select(r => new Role
                {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName
                });



            return query.ToList();

            //return context.webpages_Roles.ToList();
        }

        public UserRole CreateUserRole(UserRole userRole)
        {
            webpages_UsersInRoles role = new webpages_UsersInRoles()
            {
                UserRoleId = Guid.NewGuid(),
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            };

            var obj = context.webpages_UsersInRoles.Add(role);

            UserRole addedUserRole = new UserRole
            {
                UserRoleId = obj.UserRoleId,
                UserId = obj.UserId,
                RoleId = obj.RoleId
            };



            return addedUserRole;
        }

        public void UpdateUserRole(webpages_UsersInRoles userRole)
        {
            var foundUserRole = context.webpages_UsersInRoles
                                .Where(r => r.UserId == userRole.UserId)
                                .Where(r => r.RoleId == userRole.RoleId)
                                .FirstOrDefault();
            if (foundUserRole == null)
            {
                return;
            }

            foundUserRole.RoleId = userRole.RoleId;
        }

        public void DeleteUserRole(UserRole userRole)
        {
            //var foundUserRole = context.webpages_UsersInRoles
            //                    .Where(r => r.UserId == userRole.UserId)
            //                    .Where(r => r.RoleId == userRole.RoleId)
            //                    .FirstOrDefault();

            var foundUserRole = context.webpages_UsersInRoles
                                .Where(r => r.UserRoleId == userRole.UserRoleId)
                                .FirstOrDefault();

            if (foundUserRole == null)
            {
                return;
            }
            context.webpages_UsersInRoles.Remove(foundUserRole);

        }

        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
