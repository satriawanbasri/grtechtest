using GrTechTest.Business.Models;
using System;
using System.Data.Entity.Migrations;

namespace GrTechTest.Business.Seeders
{
    class insert_table_Company
    {
        public insert_table_Company(GrTechTestDbContext context)
        {
            Company company;

            company = new Company()
            {
                Id = "69a2880d-b23a-4f7a-b99c-d2071a26810c",
                CreatedOn = new DateTime(2021, 10, 12),
                UpdatedOn = new DateTime(2021, 10, 12),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                Name = "Google",
                Email = "suport@google.com",
                LogoFileId = "2cfb1d72-9be1-4017-9e10-5c87c82150d9",
                Website = "https://google.com",
            };
            context.Company.AddOrUpdate(company);

            company = new Company()
            {
                Id = "4e9f40f7-998e-48b3-b32c-6cdaa45b497d",
                CreatedOn = new DateTime(2021, 10, 12),
                UpdatedOn = new DateTime(2021, 10, 12),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                Name = "Facebook",
                Email = "suport@facebook.com",
                LogoFileId = "e2f0a8d2-7823-49fa-8c9b-7110541680e3",
                Website = "https://facebook.com",
            };
            context.Company.AddOrUpdate(company);
        }
    }
}