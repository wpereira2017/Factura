using System.Web.Mvc;

namespace Pos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Mi página de contacto";

            return View();
        }
    }
}