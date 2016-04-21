using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;


namespace BLL
{
    public class ManageCareers
    {
        #region Select Methods -- GetAllCareers, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Careers> GetAllCareers()
        {
            return Manage<Careers, CareersRepository>.GetAll().ToList();
        }
        public static Careers GetById(int id)
        {
            return Manage<Careers, CareersRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Careers GetById(string id)
        {
            return Manage<Careers, CareersRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddCareers
        public static bool AddCareers(Careers n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;
            var nnn = Manage<Careers, CareersRepository>.Add(n);
            //Home Page Log Update
            //Careers_log nn = new Careers_log()
            //{
            //    Type = "Insert",
            //    Content = n.Content,
            //    Order = n.Order,
            //    Modified = DateTime.Now.Date,
            //    Created = DateTime.Now.Date,
            //    isDeleted = false,
            //};

            //if (nnn != false)
            //{
            //    return Manage<Careers_log, Careers_logRepository>.Add(nn);
            //}
            //else
            //{
            //    
            //}

            return nnn;


        }
        #endregion

        #region Update Methods -- UpdateCareers
        public static bool UpdateCareers(Careers n)
        {
            //Home Page Log Update

            n.Modified = DateTime.Now;
            Careers_log nn = new Careers_log()
            {
                Content1 = n.Content1,
                Content2 = n.Content2,
                Header1 = n.Header1,
                Header2 = n.Header2,
                Email = n.Email,
                Created = n.Created,
                isDeleted = n.isDeleted,
                Modified = n.Modified,
                type = "Update"
            };
            //save to database
            var nnn = Manage<Careers, CareersRepository>.Update(n);
            if (nnn != false)
            {
                Manage<Careers_log, Careers_logRepository>.Add(nn);
            }

            return nnn;
        }
        #endregion

        #region Delete Methods -- DeleteCareers
        public static bool DeleteCareers(Careers n)
        {
            n.isDeleted = true;

            return UpdateCareers(n);
        }
        #endregion
    }
}
