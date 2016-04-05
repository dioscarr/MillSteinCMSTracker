using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MillsteinLocal.Areas.Admin.Models
{
    public class ImageViewModel
    {
        [Required]
        public string Title { get; set; }

        public string AltText { get; set; }

        [DataType(DataType.Html)]
        public string Caption { get; set; }
        [Required]
        [DataType(DataType.Upload)]
       public HttpPostedFileBase ImageUpload { get; set; }
    }
}