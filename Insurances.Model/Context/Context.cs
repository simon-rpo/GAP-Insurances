using System.Data.Entity;

namespace Insurances.Model
{
    public class InsurancesContext : DbContext
    {
        #region Constructor
        public InsurancesContext()
            : base("InsurancesContext")
        {
            DbConfiguration();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InsurancesContext, Migrations.Configuration>());
        }
        #endregion

        #region DbSet
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<CoveringType> CoveringType { get; set; }
        #endregion

        #region Config
        private void DbConfiguration()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
        }
        #endregion

    }
}
