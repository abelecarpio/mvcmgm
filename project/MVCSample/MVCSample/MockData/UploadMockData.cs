using MVCSample.Models;
using System.Collections.Generic;

namespace MVCSample.MockData
{
    public class UploadMockData
    {

        private static List<DocumentAttachmentMaster> result = new List<DocumentAttachmentMaster>();

        public static List<DocumentAttachmentMaster> MockAttachmentModel
        {
            get
            {
                result.Add(new DocumentAttachmentMaster() {
                    DocumentTypeId = 1,
                    DocumentTypeName = "ID",
                    DocumentAttachments = valididlist,
                    ExistingCustomerRequired=true,
                    IsOptional=false
                });
                result.Add(new DocumentAttachmentMaster()
                {
                    DocumentTypeId = 2,
                    DocumentTypeName = "Proof of Income",
                    DocumentAttachments = incomelist,
                    ExistingCustomerRequired = false,
                    IsOptional = false
                });

                result.Add(new DocumentAttachmentMaster()
                {
                    DocumentTypeId = 3,
                    DocumentTypeName = "Others",
                    DocumentAttachments = otherlist,
                    ExistingCustomerRequired = false,
                    IsOptional = true
                }); return result;
            }

        }


        private static List<DocumentAttachmentDetail> valididlist
        {
            get
            {
                var result = new List<DocumentAttachmentDetail>();
                result.Add(new DocumentAttachmentDetail() {
                    AttachmentTypeId=1,
                    DocumentName= "UMID"
                });
                result.Add(new DocumentAttachmentDetail()
                {
                    AttachmentTypeId = 2,
                    DocumentName = "Driver's Licensed"
                });
                result.Add(new DocumentAttachmentDetail()
                {
                    AttachmentTypeId = 3,
                    DocumentName = "PRC Licensed"
                });
                result.Add(new DocumentAttachmentDetail()
                {
                    AttachmentTypeId = 4,
                    DocumentName = "Voter's ID"
                });
                return result;
            }
        }



        private static List<DocumentAttachmentDetail> incomelist
        {
            get
            {
                var result = new List<DocumentAttachmentDetail>();
                result.Add(new DocumentAttachmentDetail()
                {
                    AttachmentTypeId = 5,
                    DocumentName = "Banking Statement"
                });
                result.Add(new DocumentAttachmentDetail()
                {
                    AttachmentTypeId = 6,
                    DocumentName = "Investment Certificate"
                });
                result.Add(new DocumentAttachmentDetail()
                {
                    AttachmentTypeId = 7,
                    DocumentName = "Creditcard Statement"
                });
                return result;
            }
        }

        private static List<DocumentAttachmentDetail> otherlist
        {
            get
            {
                var result = new List<DocumentAttachmentDetail>();
                result.Add(new DocumentAttachmentDetail()
                {
                    AttachmentTypeId = 8,
                    DocumentName = "Allien Entry Certification"
                });
                result.Add(new DocumentAttachmentDetail()
                {
                    AttachmentTypeId = 9,
                    DocumentName = "Purchase Receipt"
                });
                return result;
            }
        }
    }
}