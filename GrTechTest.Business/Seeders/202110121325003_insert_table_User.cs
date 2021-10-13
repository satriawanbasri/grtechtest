using GrTechTest.Business.Models;
using System;
using System.Data.Entity.Migrations;

namespace GrTechTest.Business.Seeders
{
    class insert_table_User
    {
        public insert_table_User(GrTechTestDbContext context)
        {
            User user;

            user = new User()
            {
                Id = "b1821f91-97be-4358-9283-7e2b17769130",
                CreatedOn = new DateTime(2021, 10, 12),
                UpdatedOn = new DateTime(2021, 10, 12),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                Email = "admin@grtech.com.my",
                Password = "APUL9f3lRtRwAE51AICVOBf5uNBtJR8d0owUrbVKWvNsraYs1QSizGWrZK8fItpP4g==",
            };
            context.User.AddOrUpdate(user);

            user = new User()
            {
                Id = "b995e4c3-b244-49ea-8993-ed820c7a1df5",
                CreatedOn = new DateTime(2021, 10, 12),
                UpdatedOn = new DateTime(2021, 10, 12),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                Email = "user@grtech.com.my",
                Password = "APUL9f3lRtRwAE51AICVOBf5uNBtJR8d0owUrbVKWvNsraYs1QSizGWrZK8fItpP4g==",
            };
            context.User.AddOrUpdate(user);
        }
    }
}