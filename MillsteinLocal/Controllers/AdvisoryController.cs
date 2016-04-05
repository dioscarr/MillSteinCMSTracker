using System.Web.Mvc;
using MillsteinLocal.Models;


namespace MillsteinLocal.Controllers
{
    public class AdvisoryController : Controller
    {
        // GET: Advisory
        public ActionResult Index()
        {
            TeamModel TM = new TeamModel();
            return View(TM);
        }
        public ActionResult Info(int id)
        {
            TeamModel TM = new TeamModel();
            TM.Load(id);
            
            return View(TM);
        }

        public ActionResult LoadTeamMember(int id)
        {
          

            TeamModel TM = new TeamModel();
            TM.Load(id);
            return PartialView(TM);
        }
    }
}