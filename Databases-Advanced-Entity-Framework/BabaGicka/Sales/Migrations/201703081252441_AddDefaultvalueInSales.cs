namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultvalueInSales : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "Date", c => c.String(defaultValue: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "Date", c => c.DateTime());
        }
    }
}
