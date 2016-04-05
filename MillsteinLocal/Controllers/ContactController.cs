using System.Web.Mvc;
using MillsteinLocal.Models;

namespace MillsteinLocal.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ContactModel CM = new ContactModel();
            return View(CM);
        }
        public ActionResult NyCity(int id)
        {
            ContactModel CM = new ContactModel();
            CM.setLocation(id);
            return View(CM);
        }

        public ActionResult WashingtonDCCity(int id)
        {
            ContactModel CM = new ContactModel();
            CM.setLocation(id);
            return View(CM);
        }
    }
}