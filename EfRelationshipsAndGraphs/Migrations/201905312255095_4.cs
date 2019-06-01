namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Charters",
                c => new
                    {
                        CharterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CharterId);
            
            CreateTable(
                "dbo.Moes",
                c => new
                    {
                        MoeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CharterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoeId)
                .ForeignKey("dbo.Charters", t => t.CharterId, cascadeDelete: true)
                .Index(t => t.CharterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Moes", "CharterId", "dbo.Charters");
            DropIndex("dbo.Moes", new[] { "CharterId" });
            DropTable("dbo.Moes");
            DropTable("dbo.Charters");
        }
    }
}
