using Microsoft.AspNet.Identity.EntityFramework;
using PreUni.Core.EFModel;

namespace PreUni.OnlineTest.DAL.EntityFramework
{
    public class UserStore : UserStore<ApplicationUser, ApplicationRole, int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(UsersContext context) : base(context)
        {
        }
    }

    public class RoleStore : RoleStore<ApplicationRole, int, UserRole>
    {
        public RoleStore(UsersContext context) : base(context)
        {
        }
    }

    public class UsersContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, UserLogin, UserRole, UserClaim>
    {
        public UsersContext() : base("UserManageDbConext")
        {
        }

        public static UsersContext Create()
        {
            return new UsersContext();
        }
        
        //public DbSet<Shop> Shops { get; set; }
    }
}
