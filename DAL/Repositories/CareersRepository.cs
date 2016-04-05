using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class CareersRepository : GenericRepository<Careers>
    {
        public CareersRepository(DbContext db)
            : base(db) { }
    }
}
