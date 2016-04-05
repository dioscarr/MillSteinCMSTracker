using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;


namespace BLL
{
   public class ManagePages
    {
        #region Select Methods -- GetAllPages, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
       public static IList<Pages> GetAllPages()
        {
            return Manage<Pages, PagesRepository>.GetAll().ToList();
        }
        public static Pages GetById(int id)
        {
            return Manage<Pages, PagesRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Pages GetById(string id)
        {
            return Manage<Pages, PagesRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddPages
        public static bool AddPages(Pages n)
        {
           
            //Home Page Log Update
            Pages_log nn = new Pages_log()
            {
                Type = "Insert",
                Content = n.Content,
                Order = n.Order,              
                Modified = DateTime.Now.Date,
                Created = DateTime.Now.Date,
                isDeleted = false,
            };
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;
            var nnn =  Manage<Pages, PagesRepository>.Add(n);
            if (nnn != false)
            {
                return Manage<Pages_log, Pages_logRepository>.Add(nn);
            }
            else
            {
                return nnn;
            }


        }
        #endregion

        #region Update Methods -- UpdatePages
        public static bool UpdatePages(Pages n)
        {
            //Home Page Log Update
            Pages_log nn = new Pages_log()
            {
                Content = n.Content,
                Order = n.Order,
                Type = "Update"
            };
            //save to database
           


            n.Modified = DateTime.Now.Date;
            var nnn  = Manage<Pages, PagesRepository>.Update(n);
            if (nnn != false)
            {
                Manage<Pages_log, Pages_logRepository>.Add(nn);
            } 

            return nnn;
        }
        #endregion

        #region Delete Methods -- DeletePages
        public static bool DeletePages(Pages n)
        {
            n.isDeleted = true;

            return UpdatePages(n);
        }
        #endregion
    }
}
