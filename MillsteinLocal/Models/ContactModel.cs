﻿using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using BLL;

namespace MillsteinLocal.Models
{
    public class ContactModel:BaseModel
    {
    
        public Contact ContactDetail { get; set; }
        public List<Locations> Locations { get; set;}
        public Locations location { get; set; }

       
        public ContactModel()
        {
            ContactDetail = ManageContact.GetAllContact().FirstOrDefault();
            Locations = ManageLocations.GetAllLocations().OrderBy(c => c.LocationName).ToList();
            location = null;          
        }
        public void setLocation(int id) {
            location = ManageLocations.GetById(id);        
        }


    }
}