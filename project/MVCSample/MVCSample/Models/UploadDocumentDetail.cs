using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCSample.Models
{
    public class UploadDocumentDetail
    {

        public long AttachmentTypeId { get; set; }


        [Required]
        public string DocumentName { get; set; }

        [Required]
        public HttpPostedFileBase AttachmentFile { get; set; }
    }
}