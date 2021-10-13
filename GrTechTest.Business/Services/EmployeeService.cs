using GrTechTest.Business.Models;
using GrTechTest.Business.Repositories;
using GrTechTest.Business.Utils;
using System;
using System.Collections.Generic;

namespace GrTechTest.Business.Services
{
    public class EmployeeService
    {
        EmployeeRepository _employeeRepository = new EmployeeRepository();

        public ResponseMessage SaveEmployee(Employee employee)
        {
            try
            {
                var employeeExist = _employeeRepository.GetEmployeeById(employee.Id);
                if (employeeExist == null)
                {
                    if (employee.Id == null) employee.Id = Guid.NewGuid().ToString();
                    employee.CreatedBy = employee.UpdatedBy;
                    employee.CreatedOn = DateTime.Now;
                    employee.UpdatedOn = DateTime.Now;
                    employee.IsDeleted = false;
                    employee.Company = null;
                    var result = _employeeRepository.InsertEmployee(employee);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Employee has been saved successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed saving Employee!" };
                }
                else
                {
                    employee.CreatedBy = employeeExist.CreatedBy;
                    employee.CreatedOn = employeeExist.CreatedOn;
                    employee.UpdatedOn = DateTime.Now;
                    employee.IsDeleted = false;
                    employee.Company = null;
                    var result = _employeeRepository.UpdateEmployee(employee);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Employee has been updated successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Success.ToString(), Message = "Failed saving Employee!" };
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage DeleteEmployee(string id, string updatedBy)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeById(id);
                if (employee != null)
                {
                    employee.UpdatedBy = updatedBy;
                    employee.UpdatedOn = DateTime.Now;
                    employee.IsDeleted = true;
                    var result = _employeeRepository.UpdateEmployee(employee);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Employee has been deleted successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting Employee!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting Employee!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage RestoreDeletedEmployee(string id, string updatedBy)
        {
            try
            {
                var employee = _employeeRepository.GetDeletedEmployeeById(id);
                if (employee != null)
                {
                    employee.UpdatedBy = updatedBy;
                    employee.UpdatedOn = DateTime.Now;
                    employee.IsDeleted = false;
                    var result = _employeeRepository.UpdateEmployee(employee);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Employee has been restored successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted Employee!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted Employee!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage PermanentDeleteEmployee(string id)
        {
            try
            {
                var employee = _employeeRepository.GetDeletedEmployeeById(id);
                if (employee != null)
                {
                    var result = _employeeRepository.PermanentDeleteEmployee(id);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Employee has been deleted permanently successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting Employee!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting Employee!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                return _employeeRepository.GetEmployees();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Employee> GetDeletedEmployees()
        {
            try
            {
                return _employeeRepository.GetDeletedEmployees();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Employee GetEmployeeById(string id)
        {
            try
            {
                return _employeeRepository.GetEmployeeById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Employee GetDeletedEmployeeById(string id)
        {
            try
            {
                return _employeeRepository.GetDeletedEmployeeById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}