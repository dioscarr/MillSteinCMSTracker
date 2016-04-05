using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class Firm_logRepository : GenericRepository<Firm_log>
    {
        public Firm_logRepository(DbContext db)
            : base(db) { }
    }
}
