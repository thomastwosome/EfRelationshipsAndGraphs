namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenditures", "ExpenditureId", "dbo.Moes");
            AddColumn("dbo.Expenditures", "ExpenditureName", c => c.String());
            AddForeignKey("dbo.Expenditures", "ExpenditureId", "dbo.Moes", "MoeId", cascadeDelete: true);
            DropColumn("dbo.Expenditures", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenditures", "Name", c => c.String());
            DropForeignKey("dbo.Expenditures", "ExpenditureId", "dbo.Moes");
            DropColumn("dbo.Expenditures", "ExpenditureName");
            AddForeignKey("dbo.Expenditures", "ExpenditureId", "dbo.Moes", "MoeId");
        }
    }
}
