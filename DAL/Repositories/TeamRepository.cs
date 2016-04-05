using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class TeamRepository : GenericRepository<Team>
    {
        public TeamRepository(DbContext db)
            : base(db) { }
    }
}
