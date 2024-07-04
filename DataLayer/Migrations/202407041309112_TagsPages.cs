namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagsPages : DbMigration
    {
        public override void Up()
        {
            DropTable("TagPages");
        }
        
        public override void Down()
        {
        }
    }
}
