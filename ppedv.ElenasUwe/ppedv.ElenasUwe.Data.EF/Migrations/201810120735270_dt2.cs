namespace ppedv.ElenasUwe.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dt2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produkt", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Zubereitung", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Vorgang", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Stoff", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stoff", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vorgang", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Zubereitung", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Produkt", "Modified", c => c.DateTime(nullable: false));
        }
    }
}
