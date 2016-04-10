using System.Web.Mvc;

using NLog;

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

            _logger.Info(" HttpMethod> " + method + ", Url> " + url + ", VisitorIp> " + ip);

            base.OnResultExecuting(filterContext);
        }
    }
}