namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DirectSupports", "MoeId", "dbo.Moes");
            DropForeignKey("dbo.Exemptions", "MoeId", "dbo.Moes");
            DropIndex("dbo.DirectSupports", new[] { "MoeId" });
            DropIndex("dbo.Exemptions", new[] { "MoeId" });
            DropTable("dbo.DirectSupports");
            DropTable("dbo.Exemptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Exemptions",
                c => new
                    {
                        MoeId = c.Int(nullable: false),
                        Name = c.String(),
                        CostlyExpendituresTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MoeId);
            
            CreateTable(
                "dbo.DirectSupports",
                c => new
                    {
                        MoeId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MoeId);
            
            CreateIndex("dbo.Exemptions", "MoeId");
            CreateIndex("dbo.DirectSupports", "MoeId");
            AddForeignKey("dbo.Exemptions", "MoeId", "dbo.Moes", "MoeId", cascadeDelete: true);
            AddForeignKey("dbo.DirectSupports", "MoeId", "dbo.Moes", "MoeId", cascadeDelete: true);
        }
    }
}
