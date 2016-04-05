using DAL.Models;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class SliderRepository : GenericRepository<Slider>
    {
        public SliderRepository(DbContext db)
            : base(db){}
    }
}
