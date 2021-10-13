using GrTechTest.Business.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GrTechTest.Business.Repositories
{
    public class CompanyRepository
    {
        public int InsertCompany(Company company)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            grTechTestDbContext.Company.Add(company);
            return grTechTestDbContext.SaveChanges();
        }

        public int UpdateCompany(Company company)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var companyExist = grTechTestDbContext.Company.Find(company.Id);
            grTechTestDbContext.Entry(companyExist).State = EntityState.Detached;
            grTechTestDbContext.Entry(company).State = EntityState.Modified;
            return grTechTestDbContext.SaveChanges();
        }

        public int PermanentDeleteCompany(string id)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var company = grTechTestDbContext.Company.Find(id);
            grTechTestDbContext.Company.Remove(company);
            return grTechTestDbContext.SaveChanges();
        }

        public List<Company> GetCompanies()
        {
            return new GrTechTestDbContext().Company.Where(company => !company.IsDeleted).OrderByDescending(company => company.UpdatedOn).ToList();
        }

        public List<Company> GetDeletedCompanies()
        {
            return new GrTechTestDbContext().Company.Where(company => company.IsDeleted).OrderByDescending(company => company.UpdatedOn).ToList();
        }

        public Company GetCompanyById(string id)
        {
            return new GrTechTestDbContext().Company.FirstOrDefault(company => !company.IsDeleted && company.Id == id);
        }

        public Company GetDeletedCompanyById(string id)
        {
            return new GrTechTestDbContext().Company.FirstOrDefault(company => company.IsDeleted && company.Id == id);
        }
    }
}