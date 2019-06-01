namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CostlyExpenditures",
                c => new
                    {
                        CostlyExpenditureId = c.Int(nullable: false, identity: true),
                        CostlyExpenditureName = c.String(),
                        MoeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CostlyExpenditureId)
                .ForeignKey("dbo.Exemptions", t => t.MoeId, cascadeDelete: true)
                .Index(t => t.MoeId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        StaffName = c.String(),
                        MoeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId)
                .ForeignKey("dbo.Exemptions", t => t.MoeId, cascadeDelete: true)
                .Index(t => t.MoeId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        MoeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Exemptions", t => t.MoeId, cascadeDelete: true)
                .Index(t => t.MoeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "MoeId", "dbo.Exemptions");
            DropForeignKey("dbo.Staffs", "MoeId", "dbo.Exemptions");
            DropForeignKey("dbo.CostlyExpenditures", "MoeId", "dbo.Exemptions");
            DropIndex("dbo.Students", new[] { "MoeId" });
            DropIndex("dbo.Staffs", new[] { "MoeId" });
            DropIndex("dbo.CostlyExpenditures", new[] { "MoeId" });
            DropTable("dbo.Students");
            DropTable("dbo.Staffs");
            DropTable("dbo.CostlyExpenditures");
        }
    }
}
