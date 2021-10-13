using GrTechTest.Business.Seeders;
using System.Data.Entity.Migrations;

namespace GrTechTest.Business
{
    internal sealed class GrTechTestDbMigrationConfiguration : DbMigrationsConfiguration<GrTechTestDbContext>
    {
        public GrTechTestDbMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GrTechTestDbContext context)
        {
            new insert_table_Company(context);
            new insert_table_Employee(context);
            new insert_table_User(context);
            new insert_table_Role(context);
            new insert_table_UserRole(context);
            new insert_table_File(context);
        }
    }
}