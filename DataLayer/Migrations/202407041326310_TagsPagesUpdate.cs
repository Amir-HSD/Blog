namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagsPagesUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagPages", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.TagPages", "Page_PageId", "dbo.Pages");
            DropIndex("dbo.TagPages", new[] { "Tag_TagId" });
            DropIndex("dbo.TagPages", new[] { "Page_PageId" });
            DropPrimaryKey("dbo.TagsPages");
            AlterColumn("dbo.TagsPages", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TagsPages", new[] { "TagId", "PageId" });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagPages",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Page_PageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Page_PageId });
            
            DropPrimaryKey("dbo.TagsPages");
            AlterColumn("dbo.TagsPages", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TagsPages", "Id");
            CreateIndex("dbo.TagPages", "Page_PageId");
            CreateIndex("dbo.TagPages", "Tag_TagId");
            AddForeignKey("dbo.TagPages", "Page_PageId", "dbo.Pages", "PageId", cascadeDelete: true);
            AddForeignKey("dbo.TagPages", "Tag_TagId", "dbo.Tags", "TagId", cascadeDelete: true);
        }
    }
}
