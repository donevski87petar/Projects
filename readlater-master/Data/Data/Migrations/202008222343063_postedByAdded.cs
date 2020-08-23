namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postedByAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookmarks", "PostedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookmarks", "PostedBy");
        }
    }
}
