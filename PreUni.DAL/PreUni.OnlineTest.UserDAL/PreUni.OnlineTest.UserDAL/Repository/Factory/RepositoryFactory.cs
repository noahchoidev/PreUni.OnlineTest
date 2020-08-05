using PreUni.Core.Repository;
using System.Data.Entity;

namespace PreUni.OnlineTest.UserDAL.Repository
{
    public class CreateEFUserRepository : ICreateUserRepository
    {
        private readonly DbContext mDbContext;

        public CreateEFUserRepository(DbContext dbContext)
        {
            mDbContext = dbContext;
        }


    }
}