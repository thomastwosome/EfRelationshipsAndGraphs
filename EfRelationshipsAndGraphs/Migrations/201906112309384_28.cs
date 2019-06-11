namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Moes", "Name", c => c.String());
            AddColumn("dbo.DirectSupports", "Name", c => c.String());
            AddColumn("dbo.Exemptions", "Name", c => c.String());
            AddColumn("dbo.Expenditures", "Name", c => c.String());
            DropColumn("dbo.Moes", "MoeName");
            DropColumn("dbo.DirectSupports", "DirectSupportName");
            DropColumn("dbo.Exemptions", "ExemptionName");
            DropColumn("dbo.Expenditures", "ExpenditureName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenditures", "ExpenditureName", c => c.String());
            AddColumn("dbo.Exemptions", "ExemptionName", c => c.String());
            AddColumn("dbo.DirectSupports", "DirectSupportName", c => c.String());
            AddColumn("dbo.Moes", "MoeName", c => c.String());
            DropColumn("dbo.Expenditures", "Name");
            DropColumn("dbo.Exemptions", "Name");
            DropColumn("dbo.DirectSupports", "Name");
            DropColumn("dbo.Moes", "Name");
        }
    }
}
