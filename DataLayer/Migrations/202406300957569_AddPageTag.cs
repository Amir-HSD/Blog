namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPageTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageTags",
                c => new
                    {
                        PageTagId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PageTagId)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PageId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PageTags", "PageId", "dbo.Pages");
            DropIndex("dbo.PageTags", new[] { "TagId" });
            DropIndex("dbo.PageTags", new[] { "PageId" });
            DropTable("dbo.Tags");
            DropTable("dbo.PageTags");
        }
    }
}
