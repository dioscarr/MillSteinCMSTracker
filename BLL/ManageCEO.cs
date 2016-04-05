using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageCEO 
    {
        #region Select Methods -- GetAllCEO, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<CEO> GetAllCEO()
        {
            return Manage<CEO, CEORepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static CEO GetById(int id)
        {
            return Manage<CEO, CEORepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static CEO GetById(string id)
        {
            return Manage<CEO, CEORepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddCEO
        public static bool AddCEO(CEO n)
        {
           
            //Home Page Log Update
            CEO_log nn = new CEO_log()
            {
                Type = "Insert",
                Content = n.Content,
                Description = n.Description,
                FirstName = n.FirstName,
                LastName = n.LastName,
                Picture = n.Picture,
                pictureQuote = n.pictureQuote,
                PictureQuoteDate = n.PictureQuoteDate,
                pictureQuoteSource = n.pictureQuoteSource,
                Title = n.Title,
                Modified = DateTime.Now.Date,
                Created = DateTime.Now.Date,
                isDeleted = false,
            };
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;
            var nnn = Manage<CEO, CEORepository>.Add(n);
            if (nnn != false)
            {
                return Manage<CEO_log, CEO_logRepository>.Add(nn);
            }
            else
            {
                return false;
            }




        }
        #endregion

        #region Update Methods -- UpdateCEO
        public static bool UpdateCEO(CEO n)
        {
            n.Modified = DateTime.Now.Date;
            CEO_log CE = new CEO_log()
            {
                Content = n.Content,
                Created = DateTime.Now.Date,
                Description = n.Description,
                FirstName = n.FirstName,
                LastName = n.LastName,
                isDeleted = false,
                Modified = n.Modified,
                Picture = n.Picture,
                pictureQuote = n.pictureQuote,
                pictureQuoteSource = n.pictureQuoteSource,
                PictureQuoteDate = n.PictureQuoteDate,
                Title = n.Title,
                Type = "Update"
            };
           var result =  Manage<CEO, CEORepository>.Update(n);
            if(result!=false)
            {
                var check = false;
                return check= Manage<CEO_log, CEO_logRepository>.Add(CE);            
            }

            return result;
        }
        #endregion

        #region Delete Methods -- DeleteCEO
        public static bool DeleteCEO(CEO n)
        {
            n.isDeleted = true;

            return UpdateCEO(n);
        }
        #endregion
    }
}
