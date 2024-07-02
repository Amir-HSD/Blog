namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueTagName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tags", "TagName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tags", new[] { "TagName" });
        }
    }
}
