namespace PreUni.OnlineTest.UserDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUserModel7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.User", "Id");
            AddForeignKey("dbo.UserClaim", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.UserLogin", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.User", "Id");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.UserLogin", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.UserClaim", "UserId", "dbo.User", "Id");
        }
    }
}
