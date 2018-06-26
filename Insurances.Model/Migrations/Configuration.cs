namespace Insurances.Model.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<InsurancesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }


        protected override void Seed(InsurancesContext context)
        {
            // Pending...
         );
        }
    }
}
