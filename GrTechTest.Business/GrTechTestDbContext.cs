using GrTechTest.Business.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GrTechTest.Business
{
    public class GrTechTestDbContext : DbContext
    {
        public GrTechTestDbContext() : base("GR_TECH_TEST_CONN")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GrTechTestDbContext, GrTechTestDbMigrationConfiguration>());
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<File> File { get; set; }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //dbModelBuilder.Entity<RequestItem>().HasOptional(c => c.OfficeSupply);
            //dbModelBuilder.Entity<RequestItem>().HasOptional(c => c.Request);
            //dbModelBuilder.Entity<Delivery>().HasOptional(c => c.RequestItem);
        }
    }
}