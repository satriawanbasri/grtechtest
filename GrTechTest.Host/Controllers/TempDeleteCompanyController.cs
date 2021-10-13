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
    public class TempDeleteCompanyController : Controller
    {
        CompanyService _companyService = new CompanyService();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult RestoreDeletedCompany(string id)
        {
            var result = _companyService.RestoreDeletedCompany(id, User.Identity.GetUserId());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PermanentDeleteCompany(string id)
        {
            var result = _companyService.PermanentDeleteCompany(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDeletedCompanies()
        {
            var companies = _companyService.GetDeletedCompanies();
            return Json(new ResponseMessage()
            {
                Success = true,
                Status = ResponseStatus.Success.ToString(),
                Data = JsonConvert.DeserializeObject<List<Company>>(JsonConvert.SerializeObject(companies, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }))
            }, JsonRequestBehavior.AllowGet);
        }
    }
}