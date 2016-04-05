using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using BLL;

namespace MillsteinLocal.Models
{
    public class InvestmentModel:BaseModel
    {
      
        public Investment InvestmentDetail { get; set; }
        public bool isNewPicture { get; set; } 
        public List<Team> teamList { get; set; }

       
        public InvestmentModel() {
            InvestmentDetail = ManageInvestment.GetAllInvestment().FirstOrDefault();
          
        }
        public void LoadAllManagement()
        {
            teamList = ManageTeam.GetAllTeam().Where(u => u.Type == "manage").OrderBy(u => u.Order).ToList();
        }
       

    }
}