using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MillsteinLocal.Models;

namespace MillsteinLocal.Controllers
{
    public class JimMillsteinController : Controller
    {
        // GET: Jim_Millstein

        public ActionResult Index()
        {
            CEOModel CM = new CEOModel();

            return View(CM);
        }
    }
}