using GrTechTest.Business.Models;
using System;
using System.Data.Entity.Migrations;

namespace GrTechTest.Business.Seeders
{
    class insert_table_Role
    {
        public insert_table_Role(GrTechTestDbContext context)
        {
            Role role;

            role = new Role()
            {
                Id = "976cf7d1-2a4a-4e8f-a419-ab265ab3a003",
                CreatedOn = new DateTime(2021, 10, 12),
                UpdatedOn = new DateTime(2021, 10, 12),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                Code = "ADMIN",
                Description = "Full Access",
            };
            context.Role.AddOrUpdate(role);

            role = new Role()
            {
                Id = "b6d085e4-eea7-41e9-b260-fc65aa1ca490",
                CreatedOn = new DateTime(2021, 10, 12),
                UpdatedOn = new DateTime(2021, 10, 12),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                Code = "USER",
                Description = "Standard Access",
            };
            context.Role.AddOrUpdate(role);
        }
    }
}