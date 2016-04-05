using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class AdvisoryRepository : GenericRepository<Advisory>
    {
        public AdvisoryRepository(DbContext db)
            : base(db) { }
    }
}
