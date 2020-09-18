namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClickCounterAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookmarks", "ClickCounter", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookmarks", "ClickCounter");
        }
    }
}
