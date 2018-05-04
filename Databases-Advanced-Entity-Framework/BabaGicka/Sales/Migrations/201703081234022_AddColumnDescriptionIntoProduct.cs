namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnDescriptionIntoProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        CreditCardNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Customer_Id = c.Int(),
                        Product_Id = c.Int(),
                        StoreLocation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.StoreLocations", t => t.StoreLocation_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.StoreLocation_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Double(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Desctiption = c.String(defaultValue: "No Description"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "StoreLocation_Id", "dbo.StoreLocations");
            DropForeignKey("dbo.Sales", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Sales", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "StoreLocation_Id" });
            DropIndex("dbo.Sales", new[] { "Product_Id" });
            DropIndex("dbo.Sales", new[] { "Customer_Id" });
            DropTable("dbo.StoreLocations");
            DropTable("dbo.Products");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
        }
    }
}
