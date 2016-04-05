using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class Pages_logRepository : GenericRepository<Pages_log>
    {
        public Pages_logRepository(DbContext db)
            : base(db) { }
    }
}
