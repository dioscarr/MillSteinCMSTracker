using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class Team_logRepository : GenericRepository<Team_log>
    {
        public Team_logRepository(DbContext db)
            : base(db) { }
    }
}
