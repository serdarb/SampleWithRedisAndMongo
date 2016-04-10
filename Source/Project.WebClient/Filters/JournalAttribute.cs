using System.Web.Mvc;

using Newtonsoft.Json;

namespace Project.WebClient.Filters
{
    public class JournalAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            var method = request.HttpMethod;
            var url = request.RawUrl;
            var ip = request.UserHostAddress;

            var rd = request.RequestContext.RouteData;
            var currentAction = rd.GetRequiredString("action");
            var currentController = rd.GetRequiredString("controller");
            var currentModel = filterContext.Controller.ViewData.Model;

            var modelString = JsonConvert.SerializeObject(currentModel);

            //todo:save to journal db.

            base.OnResultExecuting(filterContext);
        }
    }
}