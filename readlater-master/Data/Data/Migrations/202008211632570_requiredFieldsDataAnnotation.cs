namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredFieldsDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Bookmarks", "URL", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Bookmarks", "ShortDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookmarks", "ShortDescription", c => c.String());
            AlterColumn("dbo.Bookmarks", "URL", c => c.String(maxLength: 500));
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 50));
        }
    }
}
