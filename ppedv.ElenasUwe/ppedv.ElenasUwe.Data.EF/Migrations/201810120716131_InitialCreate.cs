namespace ppedv.ElenasUwe.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produkt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Preis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zubereitung",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vorgang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aktion = c.String(),
                        Zeit = c.Time(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Zubereitung_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zubereitung", t => t.Zubereitung_Id, cascadeDelete: true)
                .Index(t => t.Zubereitung_Id);
            
            CreateTable(
                "dbo.Stoff",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Aggregatzustand = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ZubereitungProdukt",
                c => new
                    {
                        Zubereitung_Id = c.Int(nullable: false),
                        Produkt_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Zubereitung_Id, t.Produkt_Id })
                .ForeignKey("dbo.Zubereitung", t => t.Zubereitung_Id, cascadeDelete: true)
                .ForeignKey("dbo.Produkt", t => t.Produkt_Id, cascadeDelete: true)
                .Index(t => t.Zubereitung_Id)
                .Index(t => t.Produkt_Id);
            
            CreateTable(
                "dbo.StoffVorgang",
                c => new
                    {
                        Stoff_Id = c.Int(nullable: false),
                        Vorgang_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stoff_Id, t.Vorgang_Id })
                .ForeignKey("dbo.Stoff", t => t.Stoff_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vorgang", t => t.Vorgang_Id, cascadeDelete: true)
                .Index(t => t.Stoff_Id)
                .Index(t => t.Vorgang_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vorgang", "Zubereitung_Id", "dbo.Zubereitung");
            DropForeignKey("dbo.StoffVorgang", "Vorgang_Id", "dbo.Vorgang");
            DropForeignKey("dbo.StoffVorgang", "Stoff_Id", "dbo.Stoff");
            DropForeignKey("dbo.ZubereitungProdukt", "Produkt_Id", "dbo.Produkt");
            DropForeignKey("dbo.ZubereitungProdukt", "Zubereitung_Id", "dbo.Zubereitung");
            DropIndex("dbo.StoffVorgang", new[] { "Vorgang_Id" });
            DropIndex("dbo.StoffVorgang", new[] { "Stoff_Id" });
            DropIndex("dbo.ZubereitungProdukt", new[] { "Produkt_Id" });
            DropIndex("dbo.ZubereitungProdukt", new[] { "Zubereitung_Id" });
            DropIndex("dbo.Vorgang", new[] { "Zubereitung_Id" });
            DropTable("dbo.StoffVorgang");
            DropTable("dbo.ZubereitungProdukt");
            DropTable("dbo.Stoff");
            DropTable("dbo.Vorgang");
            DropTable("dbo.Zubereitung");
            DropTable("dbo.Produkt");
        }
    }
}
