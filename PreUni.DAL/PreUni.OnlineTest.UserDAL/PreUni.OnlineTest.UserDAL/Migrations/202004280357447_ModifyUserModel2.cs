namespace PreUni.OnlineTest.UserDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUserModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "UserFullName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "UserFullName", c => c.String());
        }
    }
}
