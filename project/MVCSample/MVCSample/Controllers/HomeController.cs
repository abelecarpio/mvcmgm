using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }







        //public ActionResult ApplyAttachment_old()
        //{
        //    var model = new DocumentAttachmentModel();
        //    var vidlist = new List<DocumentAttachmentMaster>();
        //    vidlist.Add(new DocumentAttachmentMaster()
        //    {
        //        AttachmentTypeId=1,
        //        DocumentName="UMID",
        //        DocumentTypeId=1,
        //        DocumentTypeName="ValidId",
        //        ExistingCustomerRequired=true
        //    });

        //    vidlist.Add(new DocumentAttachmentMaster()
        //    {
        //        AttachmentTypeId = 1,
        //        DocumentName = "Drivers Licensed",
        //        DocumentTypeId = 2,
        //        DocumentTypeName = "ValidId",
        //        ExistingCustomerRequired = true
        //    });

        //    vidlist.Add(new DocumentAttachmentMaster()
        //    {
        //        AttachmentTypeId = 1,
        //        DocumentName = "PRC Licensed",
        //        DocumentTypeId = 3,
        //        DocumentTypeName = "ValidId",
        //        ExistingCustomerRequired = true
        //    });
        //    model.ValidIdList = vidlist;
        //    return View(model);
        //}




        public ActionResult ApplyAttachment()
        {
            var source = MockData.UploadMockData.MockAttachmentModel;
            var isexistingcustomer = false;
            var model = new UploadAttachmentModel();

            model.MaxFileSize = 1024;
            model.IsValidIdRequired = (source != null && source.Any(x => x.DocumentTypeId == 1)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 1).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 1).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 1).IsOptional)
                );

            model.IsProofOfIncomeRequired = (source != null && source.Any(x => x.DocumentTypeId == 2)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 2).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 2).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 2).IsOptional)
                );

            model.IsOtherRequired = (source != null && source.Any(x => x.DocumentTypeId == 3)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 3).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 3).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 3).IsOptional)
                );

            model.ValidIdLabel = source.First(x => x.DocumentTypeId == 1).DocumentTypeName;
            model.ProofOfIncomeLabel = source.First(x => x.DocumentTypeId == 2).DocumentTypeName;
            model.OthersLabel = source.First(x => x.DocumentTypeId == 3).DocumentTypeName;


            model.ValidIdList = source.First(x => x.DocumentTypeId == 1).DocumentAttachments;
            model.ProofOfIncomeList = source.First(x => x.DocumentTypeId == 2).DocumentAttachments;
            model.OthersList = source.First(x => x.DocumentTypeId == 3).DocumentAttachments;

            return View(model);
        }

        [HttpPost]
        public ActionResult ApplyAttachment(UploadAttachmentModel model, IEnumerable<UploadDocumentDetail> ValidIdAttachment, IEnumerable<UploadDocumentDetail> ProofOfIncomeAttachment, IEnumerable<UploadDocumentDetail> OthersAttachment)
        {
            var source = MockData.UploadMockData.MockAttachmentModel;
            var isexistingcustomer = false;
            if (model == null) model = new UploadAttachmentModel();

            model.MaxFileSize = 1024;
            model.IsValidIdRequired = (source != null && source.Any(x => x.DocumentTypeId == 1)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 1).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 1).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 1).IsOptional)
                );

            model.IsProofOfIncomeRequired = (source != null && source.Any(x => x.DocumentTypeId == 2)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 2).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 2).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 2).IsOptional)
                );

            model.IsOtherRequired = (source != null && source.Any(x => x.DocumentTypeId == 3)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 3).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 3).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 3).IsOptional)
                );

            model.ValidIdLabel = source.First(x => x.DocumentTypeId == 1).DocumentTypeName;
            model.ProofOfIncomeLabel = source.First(x => x.DocumentTypeId == 2).DocumentTypeName;
            model.OthersLabel = source.First(x => x.DocumentTypeId == 3).DocumentTypeName;
            
            model.ValidIdList = source.First(x => x.DocumentTypeId == 1).DocumentAttachments;
            model.ProofOfIncomeList = source.First(x => x.DocumentTypeId == 2).DocumentAttachments;
            model.OthersList = source.First(x => x.DocumentTypeId == 3).DocumentAttachments;

            model.ValidIdAttachment = new List<UploadDocumentDetail>();
            model.ProofOfIncomeAttachment = new List<UploadDocumentDetail>();
            model.OthersAttachment = new List<UploadDocumentDetail>();

            return View(model);
        }




        public ActionResult TestApplyAttachment()
        {
            var source = MockData.UploadMockData.MockAttachmentModel;
            var isexistingcustomer = false;
            var model = new UploadAttachmentModel();


            model.IsValidIdRequired = (source != null && source.Any(x => x.DocumentTypeId == 1)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 1).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 1).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 1).IsOptional)
                );

            model.IsProofOfIncomeRequired = (source != null && source.Any(x => x.DocumentTypeId == 2)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 2).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 2).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 2).IsOptional)
                );

            model.IsOtherRequired = (source != null && source.Any(x => x.DocumentTypeId == 3)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 3).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 3).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 3).IsOptional)
                );

            model.ValidIdLabel = source.First(x => x.DocumentTypeId == 1).DocumentTypeName;
            model.ProofOfIncomeLabel = source.First(x => x.DocumentTypeId == 2).DocumentTypeName;
            model.OthersLabel = source.First(x => x.DocumentTypeId == 3).DocumentTypeName;


            model.ValidIdList = source.First(x => x.DocumentTypeId == 1).DocumentAttachments;
            model.ProofOfIncomeList = source.First(x => x.DocumentTypeId == 2).DocumentAttachments;
            model.OthersList = source.First(x => x.DocumentTypeId == 3).DocumentAttachments;

            model.ValidIdAttachment.Add(new UploadDocumentDetail() { DocumentName = "test1" });
            model.ValidIdAttachment.Add(new UploadDocumentDetail() { DocumentName = "test2" });

            return View(model);
        }


        [HttpPost]
        public ActionResult TestApplyAttachment(UploadAttachmentModel modelx, IEnumerable<UploadDocumentDetail> ValidIdAttachment, IEnumerable<UploadDocumentDetail> ProofOfIncomeAttachment)
        {
            var source = MockData.UploadMockData.MockAttachmentModel;
            var isexistingcustomer = false;
            var model = new UploadAttachmentModel();


            model.IsValidIdRequired = (source != null && source.Any(x => x.DocumentTypeId == 1)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 1).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 1).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 1).IsOptional)
                );

            model.IsProofOfIncomeRequired = (source != null && source.Any(x => x.DocumentTypeId == 2)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 2).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 2).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 2).IsOptional)
                );

            model.IsOtherRequired = (source != null && source.Any(x => x.DocumentTypeId == 3)) && (
                    /*NOT EXISTING CUSTOMER AND NOT OPTIONAL*/
                    (!isexistingcustomer && !source.First(x => x.DocumentTypeId == 3).IsOptional) ||
                    /*EXISTING CUSTOMER,  EXISTINGOPTON IS TRUE AND NOT OPTIONAL*/
                    (isexistingcustomer && source.First(x => x.DocumentTypeId == 3).ExistingCustomerRequired && !source.First(x => x.DocumentTypeId == 3).IsOptional)
                );

            model.ValidIdLabel = source.First(x => x.DocumentTypeId == 1).DocumentTypeName;
            model.ProofOfIncomeLabel = source.First(x => x.DocumentTypeId == 2).DocumentTypeName;
            model.OthersLabel = source.First(x => x.DocumentTypeId == 3).DocumentTypeName;


            model.ValidIdList = source.First(x => x.DocumentTypeId == 1).DocumentAttachments;
            model.ProofOfIncomeList = source.First(x => x.DocumentTypeId == 2).DocumentAttachments;
            model.OthersList = source.First(x => x.DocumentTypeId == 3).DocumentAttachments;

            model.ValidIdAttachment.Add(new UploadDocumentDetail() { DocumentName = "test1" });
            model.ValidIdAttachment.Add(new UploadDocumentDetail() { DocumentName = "test2" });

            return View(model);
        }

        [HttpPost]
        public ActionResult ValidateFile(UploadFileModel model)
        {
            ModelState.Clear();
            if (model == null)
            {
                model = new UploadFileModel();
                ModelState.AddModelError("UploadedFile", "File should not be empty.");
            }
            model.MaximumFileSize = 1;
            TryValidateModel(model);
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}