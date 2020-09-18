namespace OdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        CuisineId = c.Int(nullable: false, identity: true),
                        CuisineName = c.String(),
                    })
                .PrimaryKey(t => t.CuisineId);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuItemId = c.Int(nullable: false, identity: true),
                        MenuItemName = c.String(),
                        Price = c.Double(nullable: false),
                        CuisineId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuItemId)
                .ForeignKey("dbo.Cuisines", t => t.CuisineId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.CuisineId)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        CuisineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantId)
                .ForeignKey("dbo.Cuisines", t => t.CuisineId, cascadeDelete: false)
                .Index(t => t.CuisineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "CuisineId", "dbo.Cuisines");
            DropForeignKey("dbo.MenuItems", "CuisineId", "dbo.Cuisines");
            DropIndex("dbo.Restaurants", new[] { "CuisineId" });
            DropIndex("dbo.MenuItems", new[] { "RestaurantId" });
            DropIndex("dbo.MenuItems", new[] { "CuisineId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Cuisines");
        }
    }
}
