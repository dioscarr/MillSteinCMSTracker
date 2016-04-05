using DAL.Models;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class NewsRepository : GenericRepository<News>
    {
        public NewsRepository(DbContext db)
            : base(db)
        {

        }
    }
}
