namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePageTags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PageTags", "PageId", "dbo.Pages");
            DropForeignKey("dbo.PageTags", "TagId", "dbo.Tags");
            DropIndex("dbo.PageTags", new[] { "PageId" });
            DropIndex("dbo.PageTags", new[] { "TagId" });
            CreateTable(
                "dbo.TagPages",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Page_PageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Page_PageId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Pages", t => t.Page_PageId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Page_PageId);
            
            DropTable("dbo.PageTags");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PageTags",
                c => new
                    {
                        PageTagId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PageTagId);
            
            DropForeignKey("dbo.TagPages", "Page_PageId", "dbo.Pages");
            DropForeignKey("dbo.TagPages", "Tag_TagId", "dbo.Tags");
            DropIndex("dbo.TagPages", new[] { "Page_PageId" });
            DropIndex("dbo.TagPages", new[] { "Tag_TagId" });
            DropTable("dbo.TagPages");
            CreateIndex("dbo.PageTags", "TagId");
            CreateIndex("dbo.PageTags", "PageId");
            AddForeignKey("dbo.PageTags", "TagId", "dbo.Tags", "TagId", cascadeDelete: true);
            AddForeignKey("dbo.PageTags", "PageId", "dbo.Pages", "PageId", cascadeDelete: true);
        }
    }
}
