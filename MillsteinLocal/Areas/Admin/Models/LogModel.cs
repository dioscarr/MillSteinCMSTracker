using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;

namespace MillsteinLocal.Areas.Admin.Models
{
   
    public class LogModel
    {
        DB_Entities db = new DB_Entities();
        public List<Pages_log> HomeLogs { get; set; } //--------list -- done
        public Pages_log HomeLog { get; set; } //---------------single
        public List<Team_log> TeamsLog { get; set; } //---------List -- done
        public Team_log TeamLog { get; set; }//-----------------single
        public Firm_log FirmLog { get; set; }//-----------------single
        public List<Firm_log> FirmsLog { get; set; }//----------List -- done
        public CEO_log CEOLog { get; set; } //------------------single
        public List<CEO_log> CEOsLog { get; set; }//------------List -- done
        public Slider_log sliderlog { get; set; }//-------------single
        public List<Slider_log> sliderslog { get; set; }//------List -- done
        public Person_log personlog { get; set; }//-------------single
        public List<Person_log> personslog { get; set; }//------List -- done
        public Pages_log pagelog { get; set; }//----------------single
        public List<Pages_log> pageslog { get; set; }//---------List -- done
        public News_log newslog { get; set; }//-----------------single
        public List<News_log> newsslog { get; set; }//----------List -- done
        public Contact_log contactlog { get; set; }//-----------single
        public List<Contact_log> contactslog { get; set; }//----List -- done
        public Advisory_log Advisorylog { get; set; }//---------single
        public List<Advisory_log> Advisorieslog { get; set; }//-List -- done
        public List<Careers_log> Careerslog { get; set; } //----List -- done
        public Careers_log Careerlog { get; set; }
        public List<Investment_log> AssetManagements { get; set; } //----List -- done
        public Investment_log AssetManagement { get; set; }



        public LogModel() {
            TeamLog = null;
            HomeLog = null;
            FirmLog = null;
            Careerlog = null;
            AssetManagement = null;
            AssetManagements = db.Investment_log.ToList();
            Careerslog = db.Careers_log.ToList();
            HomeLogs = db.Pages_log.ToList();
            TeamsLog = db.Team_log.ToList();
            FirmsLog = db.Firm_log.ToList();
            CEOsLog = db.CEO_log.ToList();
            sliderslog = db.Slider_log.ToList();
            contactslog = db.Contact_log.ToList();
            Advisorieslog = db.Advisory_log.ToList();
            newsslog = db.News_log.ToList();

        }
    }
}