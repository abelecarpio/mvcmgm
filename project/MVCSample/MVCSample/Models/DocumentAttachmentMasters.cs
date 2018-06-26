using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class DocumentAttachmentMaster
    {
        public long DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public bool ExistingCustomerRequired { get; set; }
        public bool IsOptional { get; set; }
        public List<DocumentAttachmentDetail> DocumentAttachments { get; set; }
    }
}