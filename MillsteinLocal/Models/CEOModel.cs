using System.Linq;
using DAL.Models;
using BLL;

namespace MillsteinLocal.Models
{
    public class CEOModel:BaseModel
    {
    
        public CEO CEODetail { get; set; }
       
        public CEOModel()
        {
            CEODetail = ManageCEO.GetAllCEO().FirstOrDefault();
          
        }


    }
}