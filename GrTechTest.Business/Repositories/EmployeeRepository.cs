using GrTechTest.Business.Models;
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
    }
}