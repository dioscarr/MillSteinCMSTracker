using System.Web.Mvc;
using MillsteinLocal.Models;

namespace MillsteinLocal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeModel HM =  new HomeModel();  
           
            return View(HM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}