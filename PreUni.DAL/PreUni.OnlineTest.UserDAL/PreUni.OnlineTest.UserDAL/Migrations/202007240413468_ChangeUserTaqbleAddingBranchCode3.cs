namespace PreUni.OnlineTest.UserDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserTaqbleAddingBranchCode3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "BranchCode", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "BranchCode");
        }
    }
}
