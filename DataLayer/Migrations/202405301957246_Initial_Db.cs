namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageComments",
                c => new
                    {
                        PageCommentId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        PageCommentName = c.String(nullable: false),
                        PageCommentEmail = c.String(nullable: false),
                        PageCommentText = c.String(nullable: false),
                        PageCommentCreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PageCommentId)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        PageGroupId = c.Int(nullable: false, identity: true),
                        PageGroupTitle = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PageGroupId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        PageGroupId = c.Int(nullable: false),
                        PageTitle = c.String(nullable: false, maxLength: 50),
                        PageDescription = c.String(maxLength: 255),
                        PageContent = c.String(nullable: false),
                        PageImage = c.String(),
                        PageVisitorCount = c.Int(nullable: false),
                        PageCreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.PageGroups", t => t.PageGroupId, cascadeDelete: true)
                .Index(t => t.PageGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "PageGroupId", "dbo.PageGroups");
            DropForeignKey("dbo.PageComments", "PageId", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "PageGroupId" });
            DropIndex("dbo.PageComments", new[] { "PageId" });
            DropTable("dbo.Pages");
            DropTable("dbo.PageGroups");
            DropTable("dbo.PageComments");
        }
    }
}
