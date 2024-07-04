namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTagsPages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagsPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        PageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.PageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagsPages", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagsPages", "PageId", "dbo.Pages");
            DropIndex("dbo.TagsPages", new[] { "PageId" });
            DropIndex("dbo.TagsPages", new[] { "TagId" });
            DropTable("dbo.TagsPages");
        }
    }
}
