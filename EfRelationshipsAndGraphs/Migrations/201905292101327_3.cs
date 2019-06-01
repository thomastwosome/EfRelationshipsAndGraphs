namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Children", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Children", "ParentId", c => c.Int(nullable: false));
        }
    }
}
