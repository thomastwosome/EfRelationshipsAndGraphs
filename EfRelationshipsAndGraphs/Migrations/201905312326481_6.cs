namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exemptions",
                c => new
                    {
                        MoeId = c.Int(nullable: false),
                        ExemptionName = c.String(),
                    })
                .PrimaryKey(t => t.MoeId)
                .ForeignKey("dbo.Moes", t => t.MoeId)
                .Index(t => t.MoeId);
            
            AddColumn("dbo.Charters", "CharterName", c => c.String());
            AddColumn("dbo.Moes", "MoeName", c => c.String());
            AddColumn("dbo.DirectSupports", "DirectSupportName", c => c.String());
            AddColumn("dbo.Expenditures", "ExpenditureName", c => c.String());
            DropColumn("dbo.Charters", "Name");
            DropColumn("dbo.Moes", "Name");
            DropColumn("dbo.DirectSupports", "Name");
            DropColumn("dbo.Expenditures", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenditures", "Name", c => c.String());
            AddColumn("dbo.DirectSupports", "Name", c => c.String());
            AddColumn("dbo.Moes", "Name", c => c.String());
            AddColumn("dbo.Charters", "Name", c => c.String());
            DropForeignKey("dbo.Exemptions", "MoeId", "dbo.Moes");
            DropIndex("dbo.Exemptions", new[] { "MoeId" });
            DropColumn("dbo.Expenditures", "ExpenditureName");
            DropColumn("dbo.DirectSupports", "DirectSupportName");
            DropColumn("dbo.Moes", "MoeName");
            DropColumn("dbo.Charters", "CharterName");
            DropTable("dbo.Exemptions");
        }
    }
}
