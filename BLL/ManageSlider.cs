using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageSlider 
    {
        #region Select Methods -- GetAllSlider, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Slider> GetAllSlider()
        {
            return Manage<Slider, SliderRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Slider GetById(int id)
        {
            return Manage<Slider, SliderRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Slider GetById(string id)
        {
            return Manage<Slider, SliderRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddSlider
        public static bool AddSlider(Slider n)
        {
           
            //Home Page Log Update
            Slider_log nn = new Slider_log()
            {
                Type = "Insert",
                HomeId = n.HomeId,
                Order = n.Order,
                Quote = n.Quote,
                QuoteLocation = n.QuoteLocation,
                picture = n.picture,
                Modified = DateTime.Now.Date,
                Created = DateTime.Now.Date,
                isDeleted = false,
            };
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;
            var nnn =   Manage<Slider, SliderRepository>.Add(n);
            if (nnn != false)
            {
                return Manage<Slider_log, Slider_logRepository>.Add(nn);
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region Update Methods -- UpdateSlider
        public static bool UpdateSlider(Slider n)
        {  //Home Page Log Update
            Slider_log nn = new Slider_log()
            {  
                HomeId = n.HomeId,
                Modified = DateTime.Now.Date,
                Id = n.Id,
                QuoteLocation = n.QuoteLocation,
                isDeleted = n.isDeleted,
                Created = n.Created,
                picture = n.picture,
                Quote = n.Quote,
                Order = n.Order,
                Type = "Update"
            };
           
            n.Modified = DateTime.Now.Date;
            var nnn = Manage<Slider, SliderRepository>.Update(n);
            if (nnn != false)
            {
                Manage<Slider_log, Slider_logRepository>.Add(nn);
            }

            return nnn;
        }
        #endregion

        #region Delete Methods -- DeleteSlider
        public static bool DeleteSlider(Slider n)
        {
            n.isDeleted = true;

            return UpdateSlider(n);
        }
        #endregion
    }
}
