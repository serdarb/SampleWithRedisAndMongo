using System.Web.Mvc;

using Project.Common.Models;

namespace Project.WebClient.Controllers
{
    [AllowAnonymous]
    public class BaseController : Controller
    {
        public CurrentUserModel CurrentUser { get; set; }

        public RedirectResult RedirectToHome()
        {
            return Redirect("/");
        }

        public RedirectResult RedirectToNotFound()
        {
            return Redirect("/Home/NotFound");
        }

        public string GetRefererUrl()
        {
            return Request.UrlReferrer?.AbsoluteUri ?? "/";
        }
    }
}