namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DirectSupports",
                c => new
                    {
                        DirectSupportId = c.Int(nullable: false),
                        DirectSupportName = c.String(),
                    })
                .PrimaryKey(t => t.DirectSupportId)
                .ForeignKey("dbo.Moes", t => t.DirectSupportId, cascadeDelete: true)
                .Index(t => t.DirectSupportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DirectSupports", "DirectSupportId", "dbo.Moes");
            DropIndex("dbo.DirectSupports", new[] { "DirectSupportId" });
            DropTable("dbo.DirectSupports");
        }
    }
}
