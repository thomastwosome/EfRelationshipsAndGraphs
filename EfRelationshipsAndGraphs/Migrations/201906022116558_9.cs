namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes");
            AddForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes", "MoeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes");
            AddForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes", "MoeId");
        }
    }
}
