using GrTechTest.Host.Utils;
using System.Web.Mvc;

namespace GrTechTest.Host.Controllers
{
    [Layout, Authorize(Roles = "ADMIN, USER")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}