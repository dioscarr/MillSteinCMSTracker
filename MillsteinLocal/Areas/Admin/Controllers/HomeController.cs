using System.Web.Mvc;
using MillsteinLocal.Areas.Admin.Models;

namespace MillsteinLocal.Areas.Admin.Controllers

{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {


            return View(new HomeModel());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(HomeModel model)
        {
            var result = model.Update(model);
            return View();
        }

     

    }
}