using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageFirm 
    {
        #region Select Methods -- GetAllFirm, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Firm> GetAllFirm()
        {
            return Manage<Firm, FirmRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Firm GetById(int id)
        {
            return Manage<Firm, FirmRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Firm GetById(string id)
        {
            return Manage<Firm, FirmRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddFirm
        public static bool AddFirm(Firm n)
        {           
            //Home Page Log Update
            Firm_log nn = new Firm_log()
            {
                Type = "Insert",
                Content = n.Content,
                FirmQuote = n.FirmQuote,
                FirmTitle = n.FirmTitle,
                picture = n.picture,
                Modified = DateTime.Now.Date,
                Created = DateTime.Now.Date,
                isDeleted = false,
            };
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;
            var nnn = Manage<Firm, FirmRepository>.Add(n);
            if (nnn != false)
            {
                return Manage<Firm_log, Firm_logRepository>.Add(nn);
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Update Methods -- UpdateFirm
        public static bool UpdateFirm(Firm n)
        {

            n.Modified = DateTime.Now;

            Firm_log nn = new Firm_log()
            {
                Content = n.Content,
                Created = n.Created,
                FirmQuote = n.FirmQuote,
                FirmTitle = n.FirmTitle,
                isDeleted = n.isDeleted,
                Modified = n.Modified,
                picture = n.picture,
                Type = "Update"

            };

            if (nn.isDeleted == true)
            {
                nn.Type = "Deleted";
                //save to database
                Manage<Firm_log, Firm_logRepository>.Add(nn);
                n.Modified = DateTime.Now;
                var nnn1 = Manage<Firm, FirmRepository>.Update(n);
                if (nnn1 != false) { Manage<Firm_log, Firm_logRepository>.Add(nn); }
                return nnn1;
            }
            var result =  Manage<Firm, FirmRepository>.Update(n);

           if (result != false)
           {
               Manage<Firm_log, Firm_logRepository>.Add(nn);
           
           }
           return result;
        }
        #endregion

        #region Delete Methods -- DeleteFirm
        public static bool DeleteFirm(Firm n)
        {
            n.isDeleted = true;

            return UpdateFirm(n);
        }
        #endregion
    }
}
