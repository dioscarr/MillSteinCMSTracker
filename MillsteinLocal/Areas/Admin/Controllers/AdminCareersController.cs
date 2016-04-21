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
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Careers model)
        {
            if (ModelState.IsValid)
            {
                DB_Entities db = new DB_Entities();
                model.Modified = DateTime.Now;
                db.Careers.Add(model);

               db.SaveChanges();
                Careers_log cl = new Careers_log()
                {
                    Content1 = model.Content1,
                    Content2 = model.Content2,
                    Email = model.Email,
                    Header1 = model.Header1,
                    Header2 = model.Header2,
                    Created = model.Created,
                    Modified = model.Modified,
                    isDeleted = model.isDeleted,
                    type = "Update"

                };
                db.Careers_log.Add(cl);
                db.SaveChanges();




                return View(db.Careers.First());
            }
            return View(model);
        }
    }
}