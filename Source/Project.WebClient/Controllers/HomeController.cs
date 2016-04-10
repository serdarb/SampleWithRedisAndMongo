using System.Web.Mvc;

namespace Project.WebClient.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult NotFound()
        {
            return View();
        }
    }
}