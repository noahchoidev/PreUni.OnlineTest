namespace PreUni.OnlineTest.UserDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserFullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserFullName");
        }
    }
}
