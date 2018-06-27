using MVCSample.Utils;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCSample.Models
{
    public class UploadDocumentDetail
    {

        private const string extNames = "pdf,png,bmp";

        public long AttachmentTypeId { get; set; }


        [Required]
        public string DocumentName { get; set; }

        [Required]
        [FileUpload(1, extNames)]
        public HttpPostedFileBase AttachmentFile { get; set; }
    }
}