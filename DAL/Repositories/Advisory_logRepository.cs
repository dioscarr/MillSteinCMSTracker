using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class Advisory_logRepository : GenericRepository<Advisory_log>
    {
        public Advisory_logRepository(DbContext db)
            : base(db) { }
    }
}
