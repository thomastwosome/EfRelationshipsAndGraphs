namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DirectSupports", name: "DirectSupportId", newName: "MoeId");
            RenameColumn(table: "dbo.Exemptions", name: "ExemptionId", newName: "MoeId");
            RenameColumn(table: "dbo.Expenditures", name: "ExpenditureId", newName: "MoeId");
            RenameIndex(table: "dbo.DirectSupports", name: "IX_DirectSupportId", newName: "IX_MoeId");
            RenameIndex(table: "dbo.Exemptions", name: "IX_ExemptionId", newName: "IX_MoeId");
            RenameIndex(table: "dbo.Expenditures", name: "IX_ExpenditureId", newName: "IX_MoeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Expenditures", name: "IX_MoeId", newName: "IX_ExpenditureId");
            RenameIndex(table: "dbo.Exemptions", name: "IX_MoeId", newName: "IX_ExemptionId");
            RenameIndex(table: "dbo.DirectSupports", name: "IX_MoeId", newName: "IX_DirectSupportId");
            RenameColumn(table: "dbo.Expenditures", name: "MoeId", newName: "ExpenditureId");
            RenameColumn(table: "dbo.Exemptions", name: "MoeId", newName: "ExemptionId");
            RenameColumn(table: "dbo.DirectSupports", name: "MoeId", newName: "DirectSupportId");
        }
    }
}
