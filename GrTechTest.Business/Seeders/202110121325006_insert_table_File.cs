﻿using GrTechTest.Business.Models;
using System;
using System.Data.Entity.Migrations;

namespace GrTechTest.Business.Seeders
{
    class insert_table_File
    {
        public insert_table_File(GrTechTestDbContext context)
        {
            File file;

            file = new File()
            {
                Id = "2cfb1d72-9be1-4017-9e10-5c87c82150d9",
                CreatedOn = new DateTime(2021, 10, 12),
                UpdatedOn = new DateTime(2021, 10, 12),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                FileName = "Google Logo.png",
                ContentType = "image/png",
                DataByte = Convert.FromBase64String("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"),
            };
            context.File.AddOrUpdate(file);

            file = new File()
            {
                Id = "e2f0a8d2-7823-49fa-8c9b-7110541680e3",
                CreatedOn = new DateTime(2021, 10, 12),
                UpdatedOn = new DateTime(2021, 10, 12),
                CreatedBy = "Seeder",
                UpdatedBy = "Seeder",
                IsDeleted = false,
                FileName = "Facebook Logo.png",
                ContentType = "image/jpg",
                DataByte = Convert.FromBase64String("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"),
            };
            context.File.AddOrUpdate(file);
        }
    }
}