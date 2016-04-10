using System.Web.Mvc;

using Project.Common.Models;
using Project.WebClient.Controllers;

namespace Project.WebClient.Helpers
{
    public static class HtmlHelpers
    {
        public static CurrentUserModel CurrentUser(this HtmlHelper htmlHelper)
        {
            var controller = htmlHelper.ViewContext.Controller as BaseController;
            if (controller == null) return new CurrentUserModel();

            return controller.CurrentUser ?? new CurrentUserModel();
        }
    }
}