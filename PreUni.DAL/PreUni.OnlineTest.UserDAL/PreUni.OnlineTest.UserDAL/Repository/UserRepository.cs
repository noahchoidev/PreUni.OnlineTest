using PreUni.Core.EFModel;
using PreUni.OnlineTest.UserDAL.IdentityManagers;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PreUni.OnlineTest.UserDAL.Repository
{
    public class UserRepository
    {
        private readonly DbContext mDbContext;

        private readonly UserStore mUserStore;

        private readonly ApplicationUserManager mApplicationUserManager;


        public UserRepository(DbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string username)
        {
            return await mUserStore.FindByNameAsync(username);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await mUserStore.Users.ToArrayAsync();

        }
        public async Task CreateAsync(ApplicationUser user, string password)
        {
            await mApplicationUserManager.CreateAsync(user, password);
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            await mApplicationUserManager.DeleteAsync(user);
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            await mApplicationUserManager.UpdateAsync(user);
        }

        private bool _disposed = false;
        public void Dispose()
        {
            if (!_disposed)
            {
                mApplicationUserManager.Dispose();
                mUserStore.Dispose();
            }

            _disposed = true;
        }
    }
}
