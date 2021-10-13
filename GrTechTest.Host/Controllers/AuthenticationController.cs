using GrTechTest.Business.Services;
using GrTechTest.Business.Utils;
using GrTechTest.Host.Models;
using GrTechTest.Host.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GrTechTest.Host.Controllers
{
    [Layout, Authorize(Roles = "ADMIN, USER")]
    public class AuthenticationController : Controller
    {
        UserService _userService = new UserService();
        UserRoleService _userRoleService = new UserRoleService();

        IAuthenticationManager _authenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }
        DummyUserManager _dummyUserManager { get; set; }

        public AuthenticationController() : this(new DummyUserManager()) { }

        public AuthenticationController(DummyUserManager dummyUserManager)
        {
            _dummyUserManager = dummyUserManager;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            new FileService().GetFiles();

            return View();
        }

        [AllowAnonymous]
        public JsonResult Login_(LoginViewModel login)
        {
            var user = _userService.GetUserByEmail(login.Username);
            if (user == null)
                return Json(new ResponseMessage() { Success = true, Status = ResponseStatus.Error.ToString(), Message = "User not found!" }, JsonRequestBehavior.AllowGet);

            var passwordVerificationResult = new PasswordHasher().VerifyHashedPassword(user.Password, login.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                var dummyUser = _dummyUserManager.FindAsync("username", "password").Result;
                dummyUser.Id = user.Id;
                var claimsIdentity = _dummyUserManager.CreateIdentity(dummyUser, DefaultAuthenticationTypes.ApplicationCookie);

                var userRoles = _userRoleService.GetUserRolesByUserId(user.Id);
                if (userRoles != null)
                    foreach (var userRole in userRoles)
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, userRole.Role.Code));

                _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, claimsIdentity);

                return Json(new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString() }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new ResponseMessage() { Success = true, Status = ResponseStatus.Error.ToString(), Message = "Incorrect password!" }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Anonymous()
        {
            return View();
        }

        public ActionResult Logout()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}