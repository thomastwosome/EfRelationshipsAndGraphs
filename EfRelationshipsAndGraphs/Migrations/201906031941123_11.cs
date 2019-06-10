namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CostlyExpenditures", "Description", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.CostlyExpenditures", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CostlyExpenditures", "CostlyExpenditureName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CostlyExpenditures", "CostlyExpenditureName", c => c.String());
            DropColumn("dbo.CostlyExpenditures", "Total");
            DropColumn("dbo.CostlyExpenditures", "Description");
        }
    }
}
