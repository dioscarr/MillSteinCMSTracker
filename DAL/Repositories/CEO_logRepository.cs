using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class CEO_logRepository : GenericRepository<CEO_log>
    {
        public CEO_logRepository(DbContext db)
            : base(db) { }
    }
}
