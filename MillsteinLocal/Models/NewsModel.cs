using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using BLL;

namespace MillsteinLocal.Models
{
    public class NewsModel : BaseModel
    {
        public IList<News> NewsList { get; set; }
        public News Article { get; set; }
        public IList<int> Years { get; set; }
        public List<Person_> PersontContacts { get; set; }




        public NewsModel()
        {
            NewsList = ManageNews.GetAllNews().OrderByDescending(n => n.NewsDate).Take(5).ToList();
            Years = null;
            Article = null;
            PersontContacts = null;
        }
       
        public NewsModel(int year)
        {
            NewsList = ManageNews.GetAllNews().Where(n=>n.NewsDate.Year == year).OrderByDescending(n => n.NewsDate).ToList();
            //Years = SetYears(ManageNews.GetAllNews());
            Article = null;
            PersontContacts = null;
        }

       

        public void setArticle(int id) {
            Article = ManageNews.GetById(id);
            var count = ManageNews.GetAllNews().OrderByDescending(n => n.NewsDate).ToList();
            Years = SetYears(count);
        }

        public void setPersonContact(int newsID)
        {
            PersontContacts =  ManagePerson.GetAllPerson().Where(p => p.FKkey == newsID).ToList();        
        }

        private IList<int> SetYears(IList<News> newsList)
        {
            IList<int> result = new List<int>();

            foreach (var news in newsList.Select(n => new { n.NewsDate.Year }).Distinct())
            {
                result.Add(news.Year);
            }

            return result;
        }
        internal void loadArchive()
        {
            NewsList = ManageNews.GetAllNews().OrderByDescending(n => n.NewsDate).ToList();
            Years = SetYears(NewsList);
        }

        internal void loadArchive(int year)
        {
          //  NewsList = ManageNews.GetAllNews().Where(n => n.NewsDate.Year == year).OrderByDescending(n => n.NewsDate).ToList();
          var  count = ManageNews.GetAllNews().OrderByDescending(n => n.NewsDate).ToList();
            Years = SetYears(count);
        }
    }
}