namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DirectSupports",
                c => new
                    {
                        MoeId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MoeId)
                .ForeignKey("dbo.Moes", t => t.MoeId)
                .Index(t => t.MoeId);
            
            CreateTable(
                "dbo.Expenditures",
                c => new
                    {
                        MoeId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MoeId)
                .ForeignKey("dbo.Moes", t => t.MoeId)
                .Index(t => t.MoeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes");
            DropForeignKey("dbo.DirectSupports", "MoeId", "dbo.Moes");
            DropIndex("dbo.Expenditures", new[] { "MoeId" });
            DropIndex("dbo.DirectSupports", new[] { "MoeId" });
            DropTable("dbo.Expenditures");
            DropTable("dbo.DirectSupports");
        }
    }
}
