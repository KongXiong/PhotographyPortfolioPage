namespace PhotoPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableDouble2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "Total", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "Total", c => c.Double(nullable: false));
        }
    }
}
