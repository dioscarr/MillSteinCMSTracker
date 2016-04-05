using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class Careers_logRepository : GenericRepository<Careers_log>
    {
        public Careers_logRepository(DbContext db)
            : base(db) { }
    }
}
