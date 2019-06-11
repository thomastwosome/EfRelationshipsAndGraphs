namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exemptions",
                c => new
                    {
                        ExemptionId = c.Int(nullable: false),
                        ExemptionName = c.String(),
                    })
                .PrimaryKey(t => t.ExemptionId)
                .ForeignKey("dbo.Moes", t => t.ExemptionId, cascadeDelete: true)
                .Index(t => t.ExemptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exemptions", "ExemptionId", "dbo.Moes");
            DropIndex("dbo.Exemptions", new[] { "ExemptionId" });
            DropTable("dbo.Exemptions");
        }
    }
}
