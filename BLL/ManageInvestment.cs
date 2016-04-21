using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;



namespace BLL
{
   public class ManageInvestment
    {
        #region Select Methods -- GetAllInvestment, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Investment> GetAllInvestment()
        {
            return Manage<Investment, InvestmentRepository>.GetAll().Where(n => n.isDeleted == false).ToList();
        }
        public static IList<Investment> GetAllInvestmentOf(string type)
        {
            return Manage<Investment, InvestmentRepository>.GetAll().Where(n => n.isDeleted == false).ToList();
        }

        public static Investment GetById(int id)
        {
            return Manage<Investment, InvestmentRepository>.GetById(id);
        }
     
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Investment GetById(string id)
        {
            return Manage<Investment, InvestmentRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddInvestment
        public static bool AddInvestment(Investment n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Investment, InvestmentRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateInvestment
        public static bool UpdateInvestment(Investment n)
        {

            n.Modified = DateTime.Now;

            Investment_log nn = new Investment_log()
            {
                Content2 = n.Content1,
                ContentTitle1 = n.ContentTitle1,
                ContentTitle2 = n.ContentTitle2,
                Created = DateTime.Now,
                HeaderContent = n.HeaderContent,
                isDeleted = n.isDeleted,
                Modified = n.Modified,
                Picture = n.Picture,
                PictureContent = n.PictureContent,
                Type = "Update"

            };

            if (nn.isDeleted == true)
            {
                nn.Type = "Deleted";
                //save to database
                Manage<Investment_log, Investment_logRepository>.Add(nn);
                n.Modified = DateTime.Now;
                var nnn1 = Manage<Investment, InvestmentRepository>.Update(n);
                if (nnn1 != false) { Manage<Investment_log, Investment_logRepository>.Add(nn); }
                return nnn1;
            }

            var result = Manage<Investment, InvestmentRepository>.Update(n);
            if (result != false)
            {
                Manage<Investment_log, Investment_logRepository>.Add(nn);
            }

            return result;
        }
        #endregion

        #region Delete Methods -- DeleteInvestment
        public static bool DeleteInvestment(Investment n)
        {
            n.isDeleted = true;

            return UpdateInvestment(n);
        }
        #endregion

       
    }
}
