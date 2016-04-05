using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class Investment_logRepository : GenericRepository<Investment_log>
    {
        public Investment_logRepository(DbContext db)
            : base(db) { }
    }
}
