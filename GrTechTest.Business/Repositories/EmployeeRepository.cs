using GrTechTest.Business.Models;
using GrTechTest.Business.Utils;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GrTechTest.Business.Repositories
{
    public class EmployeeRepository
    {
        public int InsertEmployee(Employee employee)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            grTechTestDbContext.Employee.Add(employee);
            return grTechTestDbContext.SaveChanges();
        }

        public int UpdateEmployee(Employee employee)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var employeeExist = grTechTestDbContext.Employee.Find(employee.Id);
            grTechTestDbContext.Entry(employeeExist).State = EntityState.Detached;
            grTechTestDbContext.Entry(employee).State = EntityState.Modified;
            return grTechTestDbContext.SaveChanges();
        }

        public int PermanentDeleteEmployee(string id)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var employee = grTechTestDbContext.Employee.Find(id);
            grTechTestDbContext.Employee.Remove(employee);
            return grTechTestDbContext.SaveChanges();
        }

        public List<Employee> GetEmployees()
        {
            return new GrTechTestDbContext().Employee
                .Include(employee => employee.Company)
                .Where(employee => !employee.IsDeleted)
                .OrderByDescending(employee => employee.UpdatedOn).ToList();
        }

        public List<Employee> GetDeletedEmployees()
        {
            return new GrTechTestDbContext().Employee
                .Include(employee => employee.Company)
                .Where(employee => employee.IsDeleted)
                .OrderByDescending(employee => employee.UpdatedOn).ToList();
        }

        public Employee GetEmployeeById(string id)
        {
            return new GrTechTestDbContext().Employee
                .Include(employee => employee.Company)
                .FirstOrDefault(employee => !employee.IsDeleted && employee.Id == id);
        }

        public Employee GetDeletedEmployeeById(string id)
        {
            return new GrTechTestDbContext().Employee.FirstOrDefault(employee => employee.IsDeleted && employee.Id == id);
        }

        public List<Employee> GetFilteredEmployees(EmployeeFilter employeeFilter)
        {
            return new GrTechTestDbContext().Employee
                .Include(employee => employee.Company)
                .Where(employee => !employee.IsDeleted
                && (!(employeeFilter.DateAddedFrom.HasValue && employeeFilter.DateAddedFrom.HasValue)
                    || (employeeFilter.DateAddedFrom.Value <= employee.CreatedOn && employee.CreatedOn <= employeeFilter.DateAddedTo.Value))
                && (string.IsNullOrEmpty(employeeFilter.Email) || employee.Email.Trim().ToUpper().Contains(employeeFilter.Email.Trim().ToUpper()))
                && (string.IsNullOrEmpty(employeeFilter.FirstName) || employee.FirstName.Trim().ToUpper().Contains(employeeFilter.FirstName.Trim().ToUpper()))
                && (string.IsNullOrEmpty(employeeFilter.LastName) || employee.LastName.Trim().ToUpper().Contains(employeeFilter.LastName.Trim().ToUpper()))
                && (string.IsNullOrEmpty(employeeFilter.CompanyName) || employee.Company.Name.Trim().ToUpper().Contains(employeeFilter.CompanyName.Trim().ToUpper()))
                )
                .OrderByDescending(employee => employee.UpdatedOn).ToList();
        }
    }
}