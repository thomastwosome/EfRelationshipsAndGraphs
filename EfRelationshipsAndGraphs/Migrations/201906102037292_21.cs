namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes");
            AddForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes", "MoeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes");
            AddForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes", "MoeId", cascadeDelete: true);
        }
    }
}
