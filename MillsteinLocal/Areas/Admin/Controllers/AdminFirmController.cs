using System.Linq;
using System.Web.Mvc;
using MillsteinLocal.Areas.Admin.Models;
using System.IO;

namespace MillsteinLocal.Areas.Admin.Controllers
{

    [Authorize]
    public class AdminFirmController : Controller
    {
        public ActionResult Index()
        {
            FirmModel FM = new FirmModel();

            return View(FM);
        }
        public ActionResult Ceo()
        {
            CEOModel CM = new CEOModel();

            return View(CM);
        }
          [ValidateInput(false)]
    [HttpPost]
        public ActionResult UpdateFirm(FirmModel model)
        {
            if (model.isNewPicture)
            {
                model.FirmDetail.picture = ImageUloadFirm(model, "~/Images");
            }
          
            model.Update(model);
            return RedirectToAction("index");
        }
          [ValidateInput(false)]
    [HttpPost]
        public ActionResult UpdateCeo(CEOModel model)
        {
            if (model.isNewPicture)
            {
                model.CEODetail.Picture = ImageUloadCeo(model, "~/Images");
            }
            model.Update(model);
            return RedirectToAction("Ceo");
        }




        //upload image
        public string ImageUloadFirm(FirmModel model, string url)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/jpg",
                "image/pjpeg",
                "image/png"
            };

            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = url;
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ImageUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(imagePath);
                    return model.ImageUpload.FileName;
                }
            } return "noimg.jpg";
        }

        //upload image
        public string ImageUloadCeo(CEOModel model, string url)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/jpg",
                "image/pjpeg",
                "image/png"
            };

            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = url;
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ImageUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(imagePath);
                    return model.ImageUpload.FileName;
                }
            } return "noimg.jpg";
        }

    }
}