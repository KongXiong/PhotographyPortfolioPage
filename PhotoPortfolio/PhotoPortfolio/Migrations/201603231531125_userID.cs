namespace PhotoPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RegisteredUsers", new[] { "userid" });
            CreateIndex("dbo.RegisteredUsers", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RegisteredUsers", new[] { "UserID" });
            CreateIndex("dbo.RegisteredUsers", "userid");
        }
    }
}
