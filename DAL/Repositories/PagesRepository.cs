using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class PagesRepository : GenericRepository<Pages>
    {
        public PagesRepository(DbContext db)
            : base(db) { }
    }
}
