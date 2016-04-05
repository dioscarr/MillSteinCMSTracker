using System.Web.Mvc;

using MillsteinLocal.Models;

namespace MillsteinLocal.Controllers
{
    public class InvestmentController : Controller
    {
        // GET: Investment
        public ActionResult Index()
        {

            InvestmentModel IM = new InvestmentModel();
            IM.LoadAllManagement();
            return View(IM);
        }
        [HttpGet]
        public ActionResult MenegInfo(int id)
        {

            TeamModel TM = new TeamModel();
            TM.Load(id);
            TM.LoadAllManagement();
            return View(TM);
        }

       

    }
}