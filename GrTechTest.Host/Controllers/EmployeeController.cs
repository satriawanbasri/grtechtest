using GrTechTest.Business.Models;
using GrTechTest.Business.Services;
using GrTechTest.Business.Utils;
using GrTechTest.Host.Utils;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GrTechTest.Host.Controllers
{
    [Layout, Authorize(Roles = "ADMIN")]
    public class EmployeeController : Controller
    {
        EmployeeService _employeeService = new EmployeeService();
        CompanyService _companyService = new CompanyService();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveEmployee(Employee employee)
        {
            employee.FullName = employee.FirstName + " " + employee.LastName;
            employee.UpdatedBy = User.Identity.GetUserId();
            var result = _employeeService.SaveEmployee(employee);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteEmployee(string id)
        {
            var result = _employeeService.DeleteEmployee(id, User.Identity.GetUserId());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmployees()
        {
            var employees = _employeeService.GetEmployees();
            return Json(new ResponseMessage()
            {
                Success = true,
                Status = ResponseStatus.Success.ToString(),
                Data = JsonConvert.DeserializeObject<List<Employee>>(JsonConvert.SerializeObject(employees, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }))
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmployeeById(string id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            return Json(new ResponseMessage()
            {
                Success = true,
                Status = ResponseStatus.Success.ToString(),
                Data = JsonConvert.DeserializeObject<Employee>(JsonConvert.SerializeObject(employee, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }))
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanies()
        {
            var companies = _companyService.GetCompanies();
            return Json(new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Data = companies }, JsonRequestBehavior.AllowGet);
        }
    }
}