namespace OdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cuisines", "ImagePath", c => c.String());
            AddColumn("dbo.MenuItems", "MenuItemType", c => c.Int(nullable: false));
            AddColumn("dbo.MenuItems", "Description", c => c.String());
            AddColumn("dbo.MenuItems", "isPromoted", c => c.Boolean(nullable: false));
            AddColumn("dbo.MenuItems", "ImagePath", c => c.String());
            AddColumn("dbo.Restaurants", "Address", c => c.String());
            AddColumn("dbo.Restaurants", "Phone", c => c.String());
            AddColumn("dbo.Restaurants", "isPromoted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Restaurants", "ImagePath", c => c.String());
            AlterColumn("dbo.Cuisines", "CuisineName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cuisines", "CuisineName", c => c.String());
            DropColumn("dbo.Restaurants", "ImagePath");
            DropColumn("dbo.Restaurants", "isPromoted");
            DropColumn("dbo.Restaurants", "Phone");
            DropColumn("dbo.Restaurants", "Address");
            DropColumn("dbo.MenuItems", "ImagePath");
            DropColumn("dbo.MenuItems", "isPromoted");
            DropColumn("dbo.MenuItems", "Description");
            DropColumn("dbo.MenuItems", "MenuItemType");
            DropColumn("dbo.Cuisines", "ImagePath");
        }
    }
}
