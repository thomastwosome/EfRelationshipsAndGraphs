namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Expenditures", name: "ExpenditureId", newName: "MoeId");
            RenameIndex(table: "dbo.Expenditures", name: "IX_ExpenditureId", newName: "IX_MoeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Expenditures", name: "IX_MoeId", newName: "IX_ExpenditureId");
            RenameColumn(table: "dbo.Expenditures", name: "MoeId", newName: "ExpenditureId");
        }
    }
}
