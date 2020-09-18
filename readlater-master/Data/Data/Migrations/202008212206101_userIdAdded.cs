namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "UserId");
        }
    }
}
