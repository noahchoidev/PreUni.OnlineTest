namespace PreUni.OnlineTest.UserDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfile : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.UserProfile",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false),
            //            UserName = c.String(unicode: false),
            //            FirstName = c.String(unicode: false),
            //            LastName = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfile");
        }
    }
}
