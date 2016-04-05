using System.Linq;
using System.Web.Mvc;
using MillsteinLocal.Areas.Admin.Models;
using System.IO;


namespace MillsteinLocal.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminInvestmentController : Controller
    {
        // GET: Investment
        public ActionResult Index()
        {
            return View(new InvestmentModel());
        }
         [ValidateInput(false)]
        public ActionResult UpdateInvestment(InvestmentModel model)
        {
            if (model.isNewPicture)
            {
                model.InvestmentDetail.Picture = ImageUloadInvestment(model, "~/Images");
            }
           
            model.update(model);
            return RedirectToAction("index");
        }

        //upload image
        public string ImageUloadInvestment(InvestmentModel model, string url)
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