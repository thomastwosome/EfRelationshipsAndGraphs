namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
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
                .ForeignKey("dbo.Moes", t => t.MoeId, cascadeDelete: true)
                .Index(t => t.MoeId);
            
            CreateTable(
                "dbo.Exemptions",
                c => new
                    {
                        MoeId = c.Int(nullable: false),
                        Name = c.String(),
                        CostlyExpendituresTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MoeId)
                .ForeignKey("dbo.Moes", t => t.MoeId, cascadeDelete: true)
                .Index(t => t.MoeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exemptions", "MoeId", "dbo.Moes");
            DropForeignKey("dbo.DirectSupports", "MoeId", "dbo.Moes");
            DropIndex("dbo.Exemptions", new[] { "MoeId" });
            DropIndex("dbo.DirectSupports", new[] { "MoeId" });
            DropTable("dbo.Exemptions");
            DropTable("dbo.DirectSupports");
        }
    }
}
