using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class CEORepository : GenericRepository<CEO>
    {
        public CEORepository(DbContext db)
            : base(db) { }
    }
}
