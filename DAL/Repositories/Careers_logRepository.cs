using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class Contact_logRepository : GenericRepository<Contact_log>
    {
        public Contact_logRepository(DbContext db)
            : base(db) { }
    }
}
