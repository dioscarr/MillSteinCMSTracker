using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageAdvisory 
    {
        #region Select Methods -- GetAllAdvisory, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Advisory> GetAllAdvisory()
        {
            return Manage<Advisory, AdvisoryRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Advisory GetById(int id)
        {
            return Manage<Advisory, AdvisoryRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Advisory GetById(string id)
        {
            return Manage<Advisory, AdvisoryRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddAdvisory
        public static bool AddAdvisory(Advisory n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            Advisory_log a = new Advisory_log()
            {
                Content1 = n.Content1,
                Content2 = n.Content2,
                Content3 = n.Content3,
                ContentTitle1 = n.ContentTitle1,
                ContentTitle2 = n.ContentTitle2,
                ContentTitle3 = n.ContentTitle3,
                Quote = n.Quote,
                Created = DateTime.Now.Date,
                Picture = n.Picture,
                Modified = n.Modified,
                isDeleted = n.isDeleted,
                Type = "Insert"
            };
            var result = Manage<Advisory, AdvisoryRepository>.Add(n);
            if (result != false)
            {
                 Manage<Advisory_log,Advisory_logRepository>.Add(a);
            }
            return result;
           
        }
        #endregion

        #region Update Methods -- UpdateAdvisory
        public static bool UpdateAdvisory(Advisory n)
        {

            n.Modified = DateTime.Now.Date;

            Advisory_log a = new Advisory_log()
            {
                Content1 = n.Content1,
                Content2 = n.Content2,
                Content3 = n.Content3,
                ContentTitle1 = n.ContentTitle1,
                ContentTitle2 = n.ContentTitle2,
                ContentTitle3 = n.ContentTitle3,
                Quote = n.Quote,
                Created = DateTime.Now.Date,
                Picture = n.Picture,
                Modified = n.Modified,
                isDeleted = n.isDeleted,
                Type = "Update"
            };

            var result = Manage<Advisory, AdvisoryRepository>.Update(n);
            if (result != false)
            {
                if (n.isDeleted == true)
                {
                    a.Type = "Delete";
                }
                Manage<Advisory_log, Advisory_logRepository>.Add(a);
            }
            return result;
        }
        #endregion

        #region Delete Methods -- DeleteAdvisory
        public static bool DeleteAdvisory(Advisory n)
        {
            n.isDeleted = true;

            return UpdateAdvisory(n);
        }
        #endregion
    }
}
