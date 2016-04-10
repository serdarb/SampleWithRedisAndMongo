using System.Web.Mvc;

using NLog;
using Newtonsoft.Json;

namespace Project.WebClient.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

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

            _logger.Info(" HttpMethod> " + method + ", Url> " + url + ", VisitorIp> " + ip + ", Model> " + modelString);

            base.OnResultExecuting(filterContext);
        }
    }
}