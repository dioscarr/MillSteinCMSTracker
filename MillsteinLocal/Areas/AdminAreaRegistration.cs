using System.Web.Mvc;

namespace MillsteinLocal.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
           


            context.MapRoute(
                "AdminLogin",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Account", action = "login", id = UrlParameter.Optional }
            );

           

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new string[] { "MillsteinLocal.Areas.Admin.Controllers" }
            );


            context.MapRoute(
               "AdminNews",
               "Admin/{controller}/{action}/{id}",
               new { controller = "AdminNews", action = "Index", id = UrlParameter.Optional }, new string[] { "MillsteinLocal.Areas.Admin.Controllers" }
           );


            context.MapRoute(
               "AdminFirmDefault",
               "Admin/{controller}/{action}/{id}",
               new { controller = "AdminFirm", action = "Ceo", id = UrlParameter.Optional }, new string[] { "MillsteinLocal.Areas.Admin.Controllers" }
           );

           
        }
    }
}