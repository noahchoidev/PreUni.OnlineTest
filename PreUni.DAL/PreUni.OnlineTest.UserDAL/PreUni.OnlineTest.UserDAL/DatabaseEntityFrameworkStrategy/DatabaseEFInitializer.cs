using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.OnlineTest.UserDAL.DatabaseEntityFrameworkStrategy
{
    public class CustomUserContextInitializer : CreateDatabaseIfNotExists<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            base.Seed(context);

            context.Roles.Add(new Core.EFModel.ApplicationRole { Name = "User" });
            context.Roles.Add(new Core.EFModel.ApplicationRole { Name = "Admin" });
            context.Roles.Add(new Core.EFModel.ApplicationRole { Name = "Teacher" });
            context.Roles.Add(new Core.EFModel.ApplicationRole { Name = "Tutor" });
            context.Roles.Add(new Core.EFModel.ApplicationRole { Name = "Head" });
            context.Roles.Add(new Core.EFModel.ApplicationRole { Name = "Franchise" });
        }
    }
}
