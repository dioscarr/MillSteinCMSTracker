using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageTeam 
    {
        #region Select Methods -- GetAllTeam, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Team> GetAllTeam()
        {
            return Manage<Team, TeamRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Team GetById(int id)
        {
            return Manage<Team, TeamRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Team GetById(string id)
        {
            return Manage<Team, TeamRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddTeam
        public static bool AddTeam(Team n)
        {
            //Home Page Log Update
            Team_log nn = new Team_log()
            {
                Type = "Insert",
                Image = n.Image,
                Note = n.Note,
                LastName = n.LastName,
                FirstName = n.FirstName,
                Description = n.Description,
                Content = n.Content,
                Order = n.Order,
                NoteWriter = n.NoteWriter,
                NoteWriterTitle = n.NoteWriterTitle,
                Modified = DateTime.Now.Date,
                Created = DateTime.Now.Date,
                isDeleted = false,
            };

            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            var nnn = Manage<Team, TeamRepository>.Add(n);
            if (nnn != false)
            {
                return Manage<Team_log, Team_logRepository>.Add(nn);
            }
            else {

                return false;
            }
        }
        #endregion

        #region Update Methods -- UpdateTeam
        public static bool UpdateTeam(Team n)
        {
            //Home Page Log Update
            Team_log nn = new Team_log()
            {
                Type = "Update",
                Image = n.Image,
                Note = n.Note,
                LastName = n.LastName,
                FirstName = n.FirstName,
                Description = n.Description,
                Content = n.Content,
                Order = n.Order,
                NoteWriter = n.NoteWriter,
                NoteWriterTitle = n.NoteWriterTitle,
                Modified = DateTime.Now,
                Created = n.Created,
                isDeleted = n.isDeleted,
            };
            if (nn.isDeleted == true)
            {
                nn.Type = "Deleted";
                //save to database 
                var nnn = Manage<Team, TeamRepository>.Update(n); 
                if (nnn != false) { Manage<Team_log, Team_logRepository>.Add(nn); }
                return nnn;
            }
            else
            {
                //save to database
               
                n.Modified = DateTime.Now;
                var nnn = Manage<Team, TeamRepository>.Update(n);
                if (nnn != false) { Manage<Team_log, Team_logRepository>.Add(nn); }
                return nnn;
            }
           
        }
        #endregion

        #region Delete Methods -- DeleteTeam
        public static bool DeleteTeam(Team n)
        {
            n.isDeleted = true;

            return UpdateTeam(n);
        }
        #endregion
    }
}
