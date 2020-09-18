namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isSharedPropertyAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookmarks", "isShared", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookmarks", "isShared");
        }
    }
}
