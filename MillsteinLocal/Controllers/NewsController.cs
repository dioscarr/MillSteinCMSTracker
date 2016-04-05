using System.Web.Mvc;
using MillsteinLocal.Models;

namespace MillsteinLocal.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [Route("News")]
        public ActionResult Index(int? id, string archive)
        {
             NewsModel NM1 = new NewsModel();
             if (id != null )
             {
               
                ViewBag.Archive = archive;
                 ViewBag.CurrentYear = id;
                ViewBag.Active = "";

                NewsModel NM = new NewsModel((int)id);
                  if (archive == "archive")
                {
                    NM.loadArchive((int)id);
                }

                 return View(NM);
             }
             else if(archive == "archive")
             {
                ViewBag.Archive = archive;
                ViewBag.Active = "adv_active";
                NewsModel NM = new NewsModel();
                 NM.loadArchive();
                 return View(NM);
             }

            return View(NM1);
        }
        //[HttpPost]
        //public ActionResult Index(int year)
        //{
             
        //    return View();
        //}
       [HttpGet]
        public ActionResult Article(int id)
        {
            NewsModel NM = new NewsModel();
            NM.setArticle(id);
            NM.setPersonContact(id);

            return View(NM);
        }
    }
}