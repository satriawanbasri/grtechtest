using GrTechTest.Business.Services;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GrTechTest.Host.Utils
{
    public class LayoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            var controller = actionExecutedContext.Controller as Controller;
            if (controller.User.Identity.IsAuthenticated)
            {
                controller.ViewBag.Username = new UserService().GetUserById(controller.User.Identity.GetUserId()).Email;
            }
            else
            {
                controller.ViewBag.Username = "Anonymous";
            }
        }
    }
}