using System.Web.Mvc;
using MillsteinLocal.Areas.Admin.Models;

namespace MillsteinLocal.Areas.Admin.Controllers
{
    public class AdminContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ContactModel CM = new ContactModel();
            return View(CM);
        }
       [HttpPost]
        public ActionResult Index(ContactModel model)
        {
            model.update(model);
            return View(model);
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