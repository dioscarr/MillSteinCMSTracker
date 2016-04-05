using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MillsteinLocal.Areas.Admin.Models;
using DAL.Models;
using BLL;


namespace MillsteinLocal.Areas.Admin.Controllers
{
    public class LogController : Controller
    {
        DB_Entities db = new DB_Entities();
        // GET: Log
        public ActionResult Index()
        {
            return View(new LogModel());
        }

        public ActionResult Home(int id)
        {            
            return View(db.Pages_log.Find(id));
        }


        public ActionResult JimMillstein(int id)
        {
            return View(db.CEO_log.Find(id));
        }

        public ActionResult AdvisoryPage(int id)
        {
            return View(db.Advisory_log.Find(id));
           
        }

        public ActionResult Advisory(int id)
        {
            return View(db.Team_log.Find(id));
        }

        public ActionResult news(int id)
        {
            return View(db.News_log.Find(id));
        }

        public ActionResult contact(int id)
        {
            return View(db.Contact_log.Find(id));
        }
        public ActionResult Assetmanagement(int id)
        {
            return View(db.Investment_log.Find(id));
        }
        public ActionResult Careers(int id)
        {
            return View(db.Careers_log.Find(id));
        }
    }
}