using MVCSample.Utils;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCSample.Models
{
    public class UploadFileModel
    {
        private const string extNames = "pdf,png,bmp";

        public long AttachmentTypeId { get; set; }

        public string DocumentName { get; set; }
        
        public HttpPostedFileBase AttachmentFile { get; set; }
    }
}