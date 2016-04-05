using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class Person_logRepository : GenericRepository<Person_log>
    {
        public Person_logRepository(DbContext db)
            : base(db) { }
    }
}
