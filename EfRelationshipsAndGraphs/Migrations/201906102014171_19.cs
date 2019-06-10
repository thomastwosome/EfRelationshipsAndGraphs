namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenditures", "ExpenditureId", "dbo.Moes");
            AddForeignKey("dbo.Expenditures", "ExpenditureId", "dbo.Moes", "MoeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenditures", "ExpenditureId", "dbo.Moes");
            AddForeignKey("dbo.Expenditures", "ExpenditureId", "dbo.Moes", "MoeId");
        }
    }
}
