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
    public class TempDeleteEmployeeController : Controller
    {
        EmployeeService _employeeService = new EmployeeService();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult RestoreDeletedEmployee(string id)
        {
            var result = _employeeService.RestoreDeletedEmployee(id, User.Identity.GetUserId());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PermanentDeleteEmployee(string id)
        {
            var result = _employeeService.PermanentDeleteEmployee(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDeletedEmployees()
        {
            var employees = _employeeService.GetDeletedEmployees();
            return Json(new ResponseMessage()
            {
                Success = true,
                Status = ResponseStatus.Success.ToString(),
                Data = JsonConvert.DeserializeObject<List<Employee>>(JsonConvert.SerializeObject(employees, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }))
            }, JsonRequestBehavior.AllowGet);
        }
    }
}