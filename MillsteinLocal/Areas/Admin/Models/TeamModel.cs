using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;
using System.ComponentModel.DataAnnotations;


namespace MillsteinLocal.Areas.Admin.Models
{
    public class TeamModel:BaseModel
    {
        public Team team { get; set;}
        public List<Team> teamList { get; set;}
        public Advisory advisory { get; set; }
        public bool isNewPicture { get; set; } 
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        public TeamModel()
        {
            teamList = ManageTeam.GetAllTeam().ToList();
            advisory = ManageAdvisory.GetAllAdvisory().FirstOrDefault();
            team = null;
        }
        public void Load(int id)
        {
            team = ManageTeam.GetById(id);
        }


        internal void updateAdvisoryOverview(TeamModel model)
        {           
            ManageAdvisory.UpdateAdvisory(model.advisory);
        }





        internal bool updateMembers(TeamModel model)
        {
            var result = ManageTeam.UpdateTeam(model.team);
            return result;
        }

        internal bool delete(int id)
        {
            Team T = ManageTeam.GetById(id);
           return  ManageTeam.DeleteTeam(T);
        }
    }
    }
