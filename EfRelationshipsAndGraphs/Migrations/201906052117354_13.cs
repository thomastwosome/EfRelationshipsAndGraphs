namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Moes", "ActualOrBudget", c => c.String());
            AddColumn("dbo.Moes", "RelatedMoeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Moes", "RelatedMoeId");
            DropColumn("dbo.Moes", "ActualOrBudget");
        }
    }
}
