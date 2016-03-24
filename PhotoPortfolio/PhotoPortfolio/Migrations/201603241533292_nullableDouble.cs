namespace PhotoPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Revenues", "Total", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Revenues", "Total", c => c.Double(nullable: false));
        }
    }
}
