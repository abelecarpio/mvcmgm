using MVCSample.Utils;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCSample.Models
{
    public class UploadFileModel
    {
        private const string extNames = "pdf,png,bmp";

        public int MaximumFileSize { get; set; }

        //[Required(ErrorMessage = "Upload file should not be empty.")]
        //[FileUpload(nameof(MaximumFileSize), extNames)]
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}