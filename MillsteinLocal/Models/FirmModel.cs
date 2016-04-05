using System.Linq;
using DAL.Models;
using BLL;

namespace MillsteinLocal.Models
{
    public class FirmModel:BaseModel
    {
    
        public Firm FirmDetail { get; set; }
       
        public FirmModel()
        {
            FirmDetail = ManageFirm.GetAllFirm().FirstOrDefault();
          
        }


    }
}