using System.Web.Mvc;
using MillsteinLocal.Areas.Admin.Models;
using DAL.Models;
using BLL;


namespace MillsteinLocal.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminNewsController : Controller
    {
        // GET: News
        public ActionResult Index(int? id)
        {
             NewsModel NM1 = new NewsModel();
            if (id != null)
            {
                ViewBag.CurrentYear = id;
                NewsModel NM = new NewsModel((int)id);               
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


       [ValidateInput(false)]
       [HttpPost]
       public ActionResult Article(NewsModel model)
       {
           
           model.Update(model.Article);
            if (model.PersontContacts != null)
            {
                model.UdpdateNewsContact(model.PersontContacts);
            }
          

           return RedirectToAction("index");
       }



       public ActionResult Action()
       {
           return View();
       }
       [HttpGet]
       public ActionResult Insert()
       {   
           NewsModel insertnews = new NewsModel();
           return View(insertnews);
       }
       [ValidateInput(false)]
       [HttpPost]
       public ActionResult Insert(NewsModel model, string InvestmentId)
       {
           model.Article.isDeleted = false;
           model.insert(model.Article);
           model.InsertnewsContacts(model.PersontContacts);
           return RedirectToAction("index");
       }

       public ActionResult delete(int id)
       {
           News n = ManageNews.GetById(id);
           NewsModel NM = new NewsModel();
           NM.delete(n);
           return RedirectToAction("index");
       }
        
    }
}