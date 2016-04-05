using System.Web.Mvc;
using MillsteinLocal.Models;
namespace MillsteinLocal.Controllers
{
    public class FirmController : Controller
    {
        // GET: Firm
        public ActionResult Index()
        {
            FirmModel FM = new FirmModel();

            return View(FM);
        }
        public ActionResult Ceo()
        {
            CEOModel CM = new CEOModel();

            return View(CM);
        }
    }
}