using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class News_logRepository : GenericRepository<News_log>
    {
        public News_logRepository(DbContext db)
            : base(db) { }
    }
}
