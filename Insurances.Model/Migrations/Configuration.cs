namespace Insurances.Model.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Insurances.Model.InsurancesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Insurances.Model.InsurancesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.CoveringType.AddOrUpdate(x => x.Name,
                new CoveringType() { Name = "Terremoto" },
                new CoveringType() { Name = "Incendio" },
                new CoveringType() { Name = "Robo" },
                new CoveringType() { Name = "Pérdida" }
                );
        }
    }
}
