using Microsoft.AspNet.Identity.EntityFramework;
using PreUni.Core.EFModel;
using PreUni.OnlineTest.UserDAL.DatabaseEntityFrameworkStrategy;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PreUni.OnlineTest.UserDAL
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

    public class UserProfile
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class UsersContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, UserLogin, UserRole, UserClaim>
    {
        /// <summary>
        /// <see cref="https://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx"/>
        /// </summary>
        public UsersContext() : base("UserManageDbConext")
        {
            //Database.SetInitializer<UsersContext>(new CustomUserContextInitializer());
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }

        //Identity and Authorization
        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public static UsersContext Create()
        {
            return new UsersContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<UserProfile>().ToTable("UserProfile")
                .HasKey(x => x.UserId);

            modelBuilder.Entity<UserProfile>()
                .Property(x => x.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Configure Asp Net Identity Tables
            modelBuilder.Entity<UserProfile>().ToTable("UserProfile")
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>().ToTable("UserProfile")
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>().ToTable("UserProfile")
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationUser>().ToTable("User");

            modelBuilder.Entity<ApplicationUser>().Property(u => u.Id);
                // This is used to bring user id from external system.
                // .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<ApplicationUser>().Property(u => u.PasswordHash).HasMaxLength(500);

            modelBuilder.Entity<ApplicationUser>().Property(u => u.UserFullName)
                .HasMaxLength(200);

            modelBuilder.Entity<ApplicationUser>().Property(u => u.PhoneNumber).HasMaxLength(50);

            modelBuilder.Entity<ApplicationUser>().ToTable("User")
                .Property(e => e.BranchCode);

            modelBuilder.Entity<ApplicationRole>().ToTable("Role");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<UserClaim>().Property(u => u.ClaimType).HasMaxLength(150);
            modelBuilder.Entity<UserClaim>().Property(u => u.ClaimValue).HasMaxLength(500);
        }
    }
}
