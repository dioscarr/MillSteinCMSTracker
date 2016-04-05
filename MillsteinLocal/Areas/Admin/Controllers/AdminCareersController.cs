using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL.Models;

namespace MillsteinLocal.Areas.Admin.Controllers
{
    public class AdminCareersController : Controller
    {
        // GET: Careers
        public ActionResult Index()
        {
            DB_Entities db = new DB_Entities();

            
            return View(db.Careers.First());
        }
    }
}