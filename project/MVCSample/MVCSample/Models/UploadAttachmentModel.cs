using MVCSample.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class UploadAttachmentModel
    {

        public UploadAttachmentModel()
        {
            ValidIdAttachment = new List<UploadDocumentDetail>();
            ProofOfIncomeAttachment = new List<UploadDocumentDetail>();
            OthersAttachment = new List<UploadDocumentDetail>();
        }

        #region GET PROPERTIES

        // LABELS
        public string ValidIdLabel { get; set; }
        public string ProofOfIncomeLabel { get; set; }
        public string OthersLabel { get; set; }


        //CONDITIONAL
        public bool HasValidIdList { get { return ValidIdList != null && ValidIdList.Count > 0; } }
        public bool HasProofOfIncomeList { get { return ProofOfIncomeList != null && ProofOfIncomeList.Count > 0; } }
        public bool HasOtherList { get { return OthersList != null && OthersList.Count > 0; } }



        public bool IsProofOfIncomeRequired { get; set; }
        public bool IsValidIdRequired { get; set; }
        public bool IsOtherRequired { get; set; }
        

        //DOCUMENT LIST
        public List<DocumentAttachmentDetail> ValidIdList { get; set; }
        public List<DocumentAttachmentDetail> ProofOfIncomeList { get; set; }
        public List<DocumentAttachmentDetail> OthersList { get; set; }

        #endregion GET PROPERTIES


        #region POST PROPERTIES
        
        [Required]
        public List<UploadDocumentDetail> ValidIdAttachment { get; set; }

        [RequiredIf(nameof(IsProofOfIncomeRequired), true)]
        public List<UploadDocumentDetail> ProofOfIncomeAttachment { get; set; }
        public List<UploadDocumentDetail> OthersAttachment { get; set; }

        #endregion

    }
}