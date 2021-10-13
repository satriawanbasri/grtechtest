using GrTechTest.Business.Models;
using GrTechTest.Business.Services;
using GrTechTest.Business.Utils;
using GrTechTest.Host.Models;
using GrTechTest.Host.Utils;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace GrTechTest.Host.Controllers
{
    [Layout, Authorize(Roles = "ADMIN")]
    public class CompanyController : Controller
    {
        CompanyService _companyService = new CompanyService();
        FileService _fileService = new FileService();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveCompany(Company company)
        {
            company.UpdatedBy = User.Identity.GetUserId();
            var result = _companyService.SaveCompany(company);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCompany(string id)
        {
            var result = _companyService.DeleteCompany(id, User.Identity.GetUserId());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanies()
        {
            var companies = _companyService.GetCompanies();
            return Json(new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Data = companies }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanyById(string id)
        {
            var company = _companyService.GetCompanyById(id);
            return Json(new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Data = company }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Upload(HttpPostedFileBase fileUploadTemplate)
        {
            byte[] bytes;
            using (var stream = fileUploadTemplate.InputStream)
            using (var binaryReader = new BinaryReader(stream))
            {
                bytes = binaryReader.ReadBytes((int)stream.Length);
            }
            var file = new Business.Models.File()
            {
                Id = Guid.NewGuid().ToString(),
                FileName = fileUploadTemplate.FileName,
                ContentType = fileUploadTemplate.ContentType,
                DataByte = bytes,
                UpdatedBy = User.Identity.GetUserId(),
            };
            _fileService.SaveFile(file);
            var fileLogo = new FileLogoViewModel()
            {
                LogoFileId = file.Id,
                LogoFileBase64 = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(file.DataByte)),
            };
            return Json(new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Data uploaded successfully!", Data = fileLogo });
        }

        public JsonResult GetLogoFileById(string logoFileId)
        {
            var file = _fileService.GetFileById(logoFileId);
            var fileLogo = new FileLogoViewModel();
            if (file != null)
                fileLogo = new FileLogoViewModel()
                {
                    LogoFileBase64 = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(file.DataByte)),
                };
            return Json(new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Data = fileLogo }, JsonRequestBehavior.AllowGet);
        }
    }
}