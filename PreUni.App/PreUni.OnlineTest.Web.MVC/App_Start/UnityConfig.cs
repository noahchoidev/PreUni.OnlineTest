using PreUni.College.DAL.CollegeDbConnection;
using PreUni.College.DAL.NewcollegeDbConnection;
using PreUni.College.DAL.Repository;
using PreUni.Core.Repository;
using PreUni.OnlineTest.DAL.EntityFramework;
using PreUni.OnlineTest.DAL.Repository;
using PreUni.OnlineTest.UserDAL;
using PreUni.OnlineTest.UserDAL.Repository;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace PreUni.OnlineTest.Web.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<DbContext, PreUniDbContext>(typeof(PreUniDbContext).Name, new ContainerControlledLifetimeManager());
            container.RegisterType<DbContext, UsersContext>(typeof(UsersContext).Name, new ContainerControlledLifetimeManager());
            container.RegisterType<DbContext, CollegeDbContext>(typeof(CollegeDbContext).Name, new ContainerControlledLifetimeManager());
            container.RegisterType<DbContext, NewcollegeDbContext>(typeof(NewcollegeDbContext).Name, new ContainerControlledLifetimeManager());


            container.RegisterType<ICreateRepository, CreateRepository>(typeof(CreateRepository).Name);
            //container.RegisterType<ICreateRepository, CreateEFRepository>(typeof(CreateEFRepository).Name);

            container.RegisterType<ICreateRepository, CreateEFRepository>
            (
                typeof(CreateEFRepository).Name,
                new InjectionConstructor
                (
                    new ResolvedParameter<DbContext>(typeof(PreUniDbContext).Name)
                )
            );

            container.RegisterType<ICreateUserRepository, CreateEFUserRepository> // ICreateRepository
            (
                typeof(CreateEFUserRepository).Name,
                new InjectionConstructor
                (
                    new ResolvedParameter<DbContext>(typeof(UsersContext).Name)
                )
            );

            //container.RegisterType<DbContext, CollegeDbContext>
            //(
            //    typeof(CollegeDbContext).Name,
            //    new InjectionConstructor
            //    (
            //        new ResolvedParameter<DbContext>(typeof(UsersContext).Name)
            //    )
            //);

            //container.RegisterType<DbContext, NewcollegeDbContext>
            //(
            //    typeof(NewcollegeDbContext).Name,
            //    new InjectionConstructor
            //    (
            //        new ResolvedParameter<DbContext>(typeof(UsersContext).Name)
            //    )
            //);


            container.RegisterType<ICreateEFCollegeRepository, CreateEFCollegeRepository>();

            /*
            container.RegisterType<IUserStore<ApplicationUser, int>, UserStore>();
            container.RegisterType<IRoleStore<ApplicationRole, int>, RoleStore>();

            container.RegisterType<UserManager<ApplicationUser, int>, ApplicationUserManager>();
            container.RegisterType<RoleManager<ApplicationRole, int>, ApplicationRoleManager>();
            */

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}