namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeyTagsPages4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TagsPages");
            AlterColumn("dbo.TagsPages", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TagsPages", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TagsPages");
            AlterColumn("dbo.TagsPages", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TagsPages", new[] { "TagId", "PageId" });
        }
    }
}
