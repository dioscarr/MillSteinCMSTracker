using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class Slider_logRepository : GenericRepository<Slider_log>
    {
        public Slider_logRepository(DbContext db)
            : base(db) { }
    }
}
