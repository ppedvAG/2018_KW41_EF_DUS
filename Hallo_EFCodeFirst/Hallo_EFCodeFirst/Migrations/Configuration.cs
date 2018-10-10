namespace Hallo_EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hallo_EFCodeFirst.EfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = !!!true;
            AutomaticMigrationDataLossAllowed = !true;
            ContextKey = "Hallo_EFCodeFirst.EfContext";
        }

        protected override void Seed(Hallo_EFCodeFirst.EfContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
