using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class PersonRepository : GenericRepository<Person_>
    {
        public PersonRepository(DbContext db)
            : base(db) { }
    }
}
