using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using BLL;

namespace MillsteinLocal.Areas.Admin.Models
{
    public class NewsModel : BaseModel
    {
        public IList<News> NewsList { get; set; }
        public News Article { get; set; }
        public IList<int> Years { get; set; }
        public List<Person_> PersontContacts { get; set; }




        public NewsModel()
        {
            NewsList = ManageNews.GetAllNews().OrderByDescending(n => n.NewsDate).ToList();
            Years = SetYears(NewsList);
            Article = null;
            PersontContacts = null;
        }
       
        public NewsModel(int year)
        {
            NewsList = ManageNews.GetAllNews().Where(n=>n.NewsDate.Year == year).OrderByDescending(n => n.NewsDate).ToList();
            Years = SetYears(ManageNews.GetAllNews());
            Article = null;
            PersontContacts = null;
        }

       

        public void setArticle(int id) {
            Article = ManageNews.GetById(id);

        }

        public void setPersonContact(int newsID)
        {
            PersontContacts =  ManagePerson.GetAllPerson().Where(p => p.FKkey == newsID).ToList();        
        }

        private IList<int> SetYears(IList<News> newsList)
        {
            IList<int> result = new List<int>();

            foreach (var news in NewsList.Select(n => new { n.NewsDate.Year }).Distinct())
            {
                result.Add(news.Year);
            }

            return result;
        }


        //Admin
        public bool Update(News model)
        {
          
            return ManageNews.UpdateNews(model);
        }


        internal void UdpdateNewsContact(List<Person_> list)
        {
            foreach (var person in list)
            {
                ManagePerson.UpdatePerson(person);
            }

        }

        public bool insert(News model)
        {
            return ManageNews.AddNews(model);
        }

        internal void InsertnewsContacts(List<Person_> list)
        {
          foreach (var person in list)
            {
                ManagePerson.AddPerson(person);
            }
        }

        public bool delete(News model)
        {
            return ManageNews.DeleteNews(model);
        }



       
    }
}