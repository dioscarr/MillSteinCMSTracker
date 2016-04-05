using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageLocations 
    {
        #region Select Methods -- GetAllLocations, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Locations> GetAllLocations()
        {
            return Manage<Locations, LocationsRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Locations GetById(int id)
        {
            return Manage<Locations, LocationsRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Locations GetById(string id)
        {
            return Manage<Locations, LocationsRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddLocations
        public static bool AddLocations(Locations n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Locations, LocationsRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateLocations
        public static bool UpdateLocations(Locations n)
        {

            n.Modified = DateTime.Now.Date;

           

            return Manage<Locations, LocationsRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteLocations
        public static bool DeleteLocations(Locations n)
        {
            n.isDeleted = true;

            return UpdateLocations(n);
        }
        #endregion
    }
}
