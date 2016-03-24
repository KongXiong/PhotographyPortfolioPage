namespace PhotoPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.userid);
            
            AddColumn("dbo.Clients", "RegisteredUserID", c => c.String());
            AddColumn("dbo.Clients", "RegisteredUser_ID", c => c.Int());
            AddColumn("dbo.Expenses", "RegisteredUserID", c => c.String());
            AddColumn("dbo.Expenses", "RegisteredUser_ID", c => c.Int());
            AddColumn("dbo.Revenues", "RegisteredUserID", c => c.String());
            AddColumn("dbo.Revenues", "RegisteredUser_ID", c => c.Int());
            CreateIndex("dbo.Clients", "RegisteredUser_ID");
            CreateIndex("dbo.Expenses", "RegisteredUser_ID");
            CreateIndex("dbo.Revenues", "RegisteredUser_ID");
            AddForeignKey("dbo.Clients", "RegisteredUser_ID", "dbo.RegisteredUsers", "ID");
            AddForeignKey("dbo.Expenses", "RegisteredUser_ID", "dbo.RegisteredUsers", "ID");
            AddForeignKey("dbo.Revenues", "RegisteredUser_ID", "dbo.RegisteredUsers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Revenues", "RegisteredUser_ID", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Expenses", "RegisteredUser_ID", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Clients", "RegisteredUser_ID", "dbo.RegisteredUsers");
            DropForeignKey("dbo.RegisteredUsers", "userid", "dbo.AspNetUsers");
            DropIndex("dbo.Revenues", new[] { "RegisteredUser_ID" });
            DropIndex("dbo.Expenses", new[] { "RegisteredUser_ID" });
            DropIndex("dbo.RegisteredUsers", new[] { "userid" });
            DropIndex("dbo.Clients", new[] { "RegisteredUser_ID" });
            DropColumn("dbo.Revenues", "RegisteredUser_ID");
            DropColumn("dbo.Revenues", "RegisteredUserID");
            DropColumn("dbo.Expenses", "RegisteredUser_ID");
            DropColumn("dbo.Expenses", "RegisteredUserID");
            DropColumn("dbo.Clients", "RegisteredUser_ID");
            DropColumn("dbo.Clients", "RegisteredUserID");
            DropTable("dbo.RegisteredUsers");
        }
    }
}
