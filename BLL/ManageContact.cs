using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;



namespace BLL
{
    public class ManageContact
    {
        #region Select Methods -- GetSingleContact, GetAllContact, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Contact> GetAllContact()
        {
            return Manage<Contact, ContactRepository>.GetAll().Where(n => n.isDeleted == false).ToList();
        }
        
        public static Contact GetSingleContact()
        {
            return Manage<Contact, ContactRepository>.GetAll().Where(n => n.isDeleted == false).First();
        }
        public static Contact GetById(int id)
        {
            return Manage<Contact, ContactRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Contact GetById(string id)
        {
            return Manage<Contact, ContactRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddContact
        public static bool AddContact(Contact n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;
            Contact_log c = new Contact_log()
            {
                CareersEmail = n.CareersEmail,
                CareersHeader = n.CareersHeader,
                ContentHeader = n.ContentHeader,
                Created = DateTime.Now.Date,
                Email = n.Email,
                FirstName = n.FirstName,
                isDeleted = n.isDeleted,
                Tel = n.Tel,
                LastName = n.LastName,
                Modified = n.Modified,
                Type = "Insert"
            };

          
            var result = Manage<Contact, ContactRepository>.Add(n);
            if (result != null)
            {
                Manage<Contact_log, Contact_logRepository>.Add(c);
                return result;
            }


            return result;


           

            return Manage<Contact, ContactRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateContact
        public static bool UpdateContact(Contact n)
        {
            Contact_log c = new Contact_log()
            {
                CareersEmail = n.CareersEmail,
                CareersHeader = n.CareersHeader,
                ContentHeader = n.ContentHeader,
                Created = DateTime.Now.Date,
                Email = n.Email,
                FirstName = n.FirstName,
                isDeleted = n.isDeleted,
                Tel = n.Tel,
                LastName = n.LastName,
                Modified = n.Modified,
                Type = "Update"
            };
             
            n.Modified = DateTime.Now.Date;
            var result = Manage<Contact, ContactRepository>.Update(n);
            if(result!=false)
            {
               Manage<Contact_log, Contact_logRepository>.Add(c);
                return result;
            }

           
            return result;
        }
        #endregion

        #region Delete Methods -- DeleteContact
        public static bool DeleteContact(Contact n)
        {
            n.isDeleted = true;

            return UpdateContact(n);
        }
        #endregion
    }
}
