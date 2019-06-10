namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes");
            RenameColumn(table: "dbo.Expenditures", name: "MoeId", newName: "ExpenditureId");
            RenameIndex(table: "dbo.Expenditures", name: "IX_MoeId", newName: "IX_ExpenditureId");
            AddForeignKey("dbo.Expenditures", "ExpenditureId", "dbo.Moes", "MoeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenditures", "ExpenditureId", "dbo.Moes");
            RenameIndex(table: "dbo.Expenditures", name: "IX_ExpenditureId", newName: "IX_MoeId");
            RenameColumn(table: "dbo.Expenditures", name: "ExpenditureId", newName: "MoeId");
            AddForeignKey("dbo.Expenditures", "MoeId", "dbo.Moes", "MoeId", cascadeDelete: true);
        }
    }
}
