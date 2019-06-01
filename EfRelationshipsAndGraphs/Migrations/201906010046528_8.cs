namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            //RenameColumn("dbo.Expenditures", "Name", "ExpenditureName");
            //RenameColumn("dbo.DirectSupport", "Name", "DirectSupportName");
            //RenameColumn("dbo.Exemptions", "Name", "ExemptionName");
            //AddColumn("dbo.DirectSupports", "Name", c => c.String());
            //AddColumn("dbo.Exemptions", "Name", c => c.String());
            //AddColumn("dbo.Expenditures", "Name", c => c.String());
            //DropColumn("dbo.DirectSupports", "DirectSupportName");
            //DropColumn("dbo.Exemptions", "ExemptionName");
            //DropColumn("dbo.Expenditures", "ExpenditureName");
        }

        public override void Down()
        {
            AddColumn("dbo.Expenditures", "ExpenditureName", c => c.String());
            AddColumn("dbo.Exemptions", "ExemptionName", c => c.String());
            AddColumn("dbo.DirectSupports", "DirectSupportName", c => c.String());
            DropColumn("dbo.Expenditures", "Name");
            DropColumn("dbo.Exemptions", "Name");
            DropColumn("dbo.DirectSupports", "Name");
        }
    }
}
