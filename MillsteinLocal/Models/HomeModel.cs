using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using BLL;


namespace MillsteinLocal.Models
{
    public class HomeModel:BaseModel
    {
        public Pages Home { get; set;}
         public List<Slider> SliderList { get; set;}
         public List<News> NewslIST { get; set; }
        public HomeModel()
        {
            Home = ManagePages.GetAllPages().FirstOrDefault();
            SliderList = ManageSlider.GetAllSlider().Where(p => p.HomeId == Home.Id).ToList();
            NewslIST = ManageNews.GetAllNews().OrderByDescending(c => c.NewsDate).Take(2).ToList(); ;
        }
       
    }
}