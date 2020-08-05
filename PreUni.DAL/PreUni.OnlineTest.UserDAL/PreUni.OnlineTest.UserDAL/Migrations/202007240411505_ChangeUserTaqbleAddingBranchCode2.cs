namespace PreUni.OnlineTest.UserDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserTaqbleAddingBranchCode2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "BranchCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "BranchCode", c => c.Int(nullable: false));
        }
    }
}
