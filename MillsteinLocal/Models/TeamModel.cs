using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using BLL;


namespace MillsteinLocal.Models
{
    public class TeamModel:BaseModel
    {
        public Team team { get; set;}
        public List<Team> teamList { get; set;}
        public Advisory advisory { get; set; }
        public TeamModel()
        {
            teamList = ManageTeam.GetAllTeam().Where(u => u.Type != "manage").ToList();
            advisory = ManageAdvisory.GetAllAdvisory().FirstOrDefault();
            team = null;
        }
        public void LoadAllManagement()
        {
            teamList = ManageTeam.GetAllTeam().Where(u => u.Type == "manage").ToList();
        }

        public void Load(int id)
        {
            team = ManageTeam.GetById(id);
        }
        
    }
}