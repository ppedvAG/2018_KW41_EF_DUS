namespace Hallo_EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Essen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tierdings = c.String(maxLength: 89),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SourceAnimal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Art = c.String(),
                        LegCount = c.Byte(),
                        Oberfläche = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TierMahlzeit",
                c => new
                    {
                        Tier_Id = c.Int(nullable: false),
                        Mahlzeit_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tier_Id, t.Mahlzeit_Id })
                .ForeignKey("dbo.SourceAnimal", t => t.Tier_Id, cascadeDelete: true)
                .ForeignKey("dbo.Essen", t => t.Mahlzeit_Id, cascadeDelete: true)
                .Index(t => t.Tier_Id)
                .Index(t => t.Mahlzeit_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TierMahlzeit", "Mahlzeit_Id", "dbo.Essen");
            DropForeignKey("dbo.TierMahlzeit", "Tier_Id", "dbo.SourceAnimal");
            DropIndex("dbo.TierMahlzeit", new[] { "Mahlzeit_Id" });
            DropIndex("dbo.TierMahlzeit", new[] { "Tier_Id" });
            DropTable("dbo.TierMahlzeit");
            DropTable("dbo.SourceAnimal");
            DropTable("dbo.Essen");
        }
    }
}
