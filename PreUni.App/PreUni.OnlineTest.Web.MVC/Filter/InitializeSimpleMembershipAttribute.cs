using System;
using System.Web.Mvc;
using System.Data.Entity;
using PreUni.OnlineTest.DAL.EntityFramework;
using PreUni.OnlineTest.UserDAL;

namespace PreUni.OnlineTest.Web.MVC.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            //LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        public  class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer(DbContext dbContext)
            {

                if(dbContext is PreUniDbContext a)
                {
                    var ss = "a:";
                }
                else if(dbContext is UsersContext b)
                {
                    var ss = "a:";
                }
                /*
                Database.SetInitializer<DbContext>(null);

                try
                {
                    if(!dbContext.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        ((IObjectContextAdapter)dbContext).ObjectContext.CreateDatabase();
                    }

                    WebSecurity.InitializeDatabaseConnection("UserManageDbConext", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
                */
            }
        }
    }
}