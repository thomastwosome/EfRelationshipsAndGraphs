namespace EfRelationshipsAndGraphs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DirectSupports", "MoeId", "dbo.Moes");
            DropForeignKey("dbo.CostlyExpenditures", "MoeId", "dbo.Exemptions");
            DropForeignKey("dbo.Staffs", "MoeId", "dbo.Exemptions");
            DropForeignKey("dbo.Students", "MoeId", "dbo.Exemptions");
            DropForeignKey("dbo.Exemptions", "MoeId", "dbo.Moes");
            DropIndex("dbo.DirectSupports", new[] { "MoeId" });
            DropIndex("dbo.Exemptions", new[] { "MoeId" });
            DropIndex("dbo.CostlyExpenditures", new[] { "MoeId" });
            DropIndex("dbo.Staffs", new[] { "MoeId" });
            DropIndex("dbo.Students", new[] { "MoeId" });
            DropTable("dbo.DirectSupports");
            DropTable("dbo.Exemptions");
            DropTable("dbo.CostlyExpenditures");
            DropTable("dbo.Staffs");
            DropTable("dbo.Students");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        MoeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        StaffName = c.String(),
                        MoeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.CostlyExpenditures",
                c => new
                    {
                        CostlyExpenditureId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MoeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CostlyExpenditureId);
            
            CreateTable(
                "dbo.Exemptions",
                c => new
                    {
                        MoeId = c.Int(nullable: false),
                        Name = c.String(),
                        CostlyExpendituresTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MoeId);
            
            CreateTable(
                "dbo.DirectSupports",
                c => new
                    {
                        MoeId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MoeId);
            
            CreateIndex("dbo.Students", "MoeId");
            CreateIndex("dbo.Staffs", "MoeId");
            CreateIndex("dbo.CostlyExpenditures", "MoeId");
            CreateIndex("dbo.Exemptions", "MoeId");
            CreateIndex("dbo.DirectSupports", "MoeId");
            AddForeignKey("dbo.Exemptions", "MoeId", "dbo.Moes", "MoeId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "MoeId", "dbo.Exemptions", "MoeId", cascadeDelete: true);
            AddForeignKey("dbo.Staffs", "MoeId", "dbo.Exemptions", "MoeId", cascadeDelete: true);
            AddForeignKey("dbo.CostlyExpenditures", "MoeId", "dbo.Exemptions", "MoeId", cascadeDelete: true);
            AddForeignKey("dbo.DirectSupports", "MoeId", "dbo.Moes", "MoeId", cascadeDelete: true);
        }
    }
}
