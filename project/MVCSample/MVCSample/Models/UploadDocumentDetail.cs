using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCSample.Models
{
    public class UploadDocumentDetail
    {
        [Required]
        public string DocumentName { get; set; }

        [Required]
        public HttpPostedFileBase AttachmentFile { get; set; }
    }
}