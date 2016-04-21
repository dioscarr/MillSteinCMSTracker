using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManagePerson 
    {
        #region Select Methods -- GetAllPerson, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Person_> GetAllPerson()
        {
            return Manage<Person_, PersonRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Person_ GetById(int id)
        {
            return Manage<Person_, PersonRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Person_ GetById(string id)
        {
            return Manage<Person_, PersonRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddPerson
        public static bool AddPerson(Person_ n)
        {
            //Home Page Log Update
            Person_log nn = new Person_log()
            {
                Type = "Insert",
                Address = n.Address,
                Address1 = n.Address1,
                City = n.City,
                Email = n.Email,
                FirstName = n.FirstName,
                LastName = n.LastName,
                News = n.News,
                Phone = n.Phone,
                State = n.State,
                Title = n.Title,
                Zipcode = n.Zipcode,
                Modified = DateTime.Now.Date,
                Created = DateTime.Now.Date,
                isDeleted = false
            };
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;
            var nnn =  Manage<Person_, PersonRepository>.Add(n);
            if (nnn != false)
            {
                return Manage<Person_log, Person_logRepository>.Add(nn);
            }
            else
            {
                return false;
            }



        }
        #endregion

        #region Update Methods -- UpdatePerson
        public static bool UpdatePerson(Person_ n)
        {

            n.Modified = DateTime.Now;

            Person_log p = new Person_log()
            {
                Address = n.Address,
                Address1 = n.Address1,
                City = n.City,
                Created = n.Created,
                Email = n.Email,
                FirstName = n.FirstName,
                isDeleted = n.isDeleted,
                LastName = n.LastName,
                Modified = n.Modified,
                News = n.News,
                State = n.State,
                Phone = n.Phone,
                Title = n.Title,
                Zipcode = n.Zipcode,
                Type = "Update"
            };

            var result = Manage<Person_, PersonRepository>.Update(n);

            if (result != false)
            {
                Manage<Person_log, Person_logRepository>.Update(p);
            }

            return result;
        }
        #endregion

        #region Delete Methods -- DeletePerson
        public static bool DeletePerson(Person_ n)
        {
            n.isDeleted = true;

            return UpdatePerson(n);
        }
        #endregion
    }
}
