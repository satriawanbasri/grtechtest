using GrTechTest.Business.Models;
using System;
using System.Data.Entity.Migrations;

namespace GrTechTest.Business.Seeders
{
    class insert_table_UserRole
    {
        public insert_table_UserRole(GrTechTestDbContext context)
        {
            UserRole userRole;

            userRole = new UserRole()
            {
                Id = "163ab327-ecf7-4382-9c21-593f80afca03",
                CreatedOn = new DateTime(2021, 10, 12),
                UpdatedOn = new DateTime(2021, 10, 12),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                UserId = "b1821f91-97be-4358-9283-7e2b17769130",
                RoleId = "976cf7d1-2a4a-4e8f-a419-ab265ab3a003",
            };
            context.UserRole.AddOrUpdate(userRole);

            userRole = new UserRole()
            {
                Id = "01dd483b-7c01-4a3c-bfdd-94b1327813cb",
                CreatedOn = new DateTime(2021, 10, 12),
                UpdatedOn = new DateTime(2021, 10, 12),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                UserId = "b995e4c3-b244-49ea-8993-ed820c7a1df5",
                RoleId = "b6d085e4-eea7-41e9-b260-fc65aa1ca490",
            };
            context.UserRole.AddOrUpdate(userRole);
        }
    }
}