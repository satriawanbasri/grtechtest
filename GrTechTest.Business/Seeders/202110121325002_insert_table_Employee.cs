using GrTechTest.Business.Models;
using System;
using System.Data.Entity.Migrations;

namespace GrTechTest.Business.Seeders
{
    class insert_table_Employee
    {
        public insert_table_Employee(GrTechTestDbContext context)
        {
            Employee employee;

            employee = new Employee()
            {
                Id = "b7ce3c71-327c-404d-a849-25f53f760962",
                CreatedOn = new DateTime(2020, 10, 10),
                UpdatedOn = new DateTime(2020, 10, 10),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                FirstName = "Jason",
                LastName = "Statom",
                FullName = "Jason Statom",
                CompanyId = "69a2880d-b23a-4f7a-b99c-d2071a26810c",
                Email = "jason@google.com",
                Phone = "+198739459",
            };
            context.Employee.AddOrUpdate(employee);

            employee = new Employee()
            {
                Id = "4e9f40f7-998e-48b3-b32c-6cdaa45b497d",
                CreatedOn = new DateTime(2021, 10, 10),
                UpdatedOn = new DateTime(2021, 10, 10),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                FirstName = "Nicholas",
                LastName = "Cage",
                FullName = "Nicholas Cage",
                CompanyId = "69a2880d-b23a-4f7a-b99c-d2071a26810c",
                Email = "cage@google.com",
                Phone = "+198734574",
            };
            context.Employee.AddOrUpdate(employee);

            employee = new Employee()
            {
                Id = "3372c399-9736-495b-b8f8-0324cf246fcd",
                CreatedOn = new DateTime(2020, 10, 10),
                UpdatedOn = new DateTime(2020, 10, 10),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                FirstName = "Tom",
                LastName = "Cruise",
                FullName = "Tom Cruise",
                CompanyId = "69a2880d-b23a-4f7a-b99c-d2071a26810c",
                Email = "tom@google.com",
                Phone = "+19355790",
            };
            context.Employee.AddOrUpdate(employee);


            employee = new Employee()
            {
                Id = "ffe14b79-9d59-471d-a20c-2a4adba48368",
                CreatedOn = new DateTime(2021, 10, 10),
                UpdatedOn = new DateTime(2021, 10, 10),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                FirstName = "Jhonny",
                LastName = "Deep",
                FullName = "Jhonny Deep",
                CompanyId = "4e9f40f7-998e-48b3-b32c-6cdaa45b497d",
                Email = "deep@google.com",
                Phone = "+18767234",
            };
            context.Employee.AddOrUpdate(employee);

            employee = new Employee()
            {
                Id = "67493ceb-e2e3-4085-82f5-9080df802155",
                CreatedOn = new DateTime(2020, 10, 10),
                UpdatedOn = new DateTime(2020, 10, 10),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                FirstName = "Dwayne",
                LastName = "Johnson",
                FullName = "Dwayne Johnson",
                CompanyId = "4e9f40f7-998e-48b3-b32c-6cdaa45b497d",
                Email = "johnson@google.com",
                Phone = "+167529358",
            };
            context.Employee.AddOrUpdate(employee);
        }
    }
}