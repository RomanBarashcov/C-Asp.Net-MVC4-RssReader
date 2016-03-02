namespace Rss.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsItems", "Title", c => c.String());
            AddColumn("dbo.NewsItems", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsItems", "Link");
            DropColumn("dbo.NewsItems", "Title");
        }
    }
}
