using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class FirmRepository : GenericRepository<Firm>
    {
        public FirmRepository(DbContext db)
            : base(db) { }
    }
}
