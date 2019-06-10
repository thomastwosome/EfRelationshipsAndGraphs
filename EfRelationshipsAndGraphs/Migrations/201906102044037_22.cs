namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Expenditures", name: "MoeId", newName: "ExpenditureId");
            RenameIndex(table: "dbo.Expenditures", name: "IX_MoeId", newName: "IX_ExpenditureId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Expenditures", name: "IX_ExpenditureId", newName: "IX_MoeId");
            RenameColumn(table: "dbo.Expenditures", name: "ExpenditureId", newName: "MoeId");
        }
    }
}
