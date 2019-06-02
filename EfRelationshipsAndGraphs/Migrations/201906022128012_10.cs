namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DirectSupports", "MoeId", "dbo.Moes");
            DropForeignKey("dbo.Exemptions", "MoeId", "dbo.Moes");
            AddForeignKey("dbo.DirectSupports", "MoeId", "dbo.Moes", "MoeId", cascadeDelete: true);
            AddForeignKey("dbo.Exemptions", "MoeId", "dbo.Moes", "MoeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exemptions", "MoeId", "dbo.Moes");
            DropForeignKey("dbo.DirectSupports", "MoeId", "dbo.Moes");
            AddForeignKey("dbo.Exemptions", "MoeId", "dbo.Moes", "MoeId");
            AddForeignKey("dbo.DirectSupports", "MoeId", "dbo.Moes", "MoeId");
        }
    }
}
