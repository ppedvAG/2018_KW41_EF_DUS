namespace Hallo_EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SourceAnimal", "TieroberflächeFarbe", c => c.String());
            AddColumn("dbo.SourceAnimal", "TierFleischFarbe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SourceAnimal", "TierFleischFarbe");
            DropColumn("dbo.SourceAnimal", "TieroberflächeFarbe");
        }
    }
}
