using System.Web.Mvc;

namespace MillsteinLocal.Models
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult TermsAndConditions()
        {
            return View();
        }
    }
}