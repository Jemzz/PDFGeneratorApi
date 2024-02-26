using System;
using System.Collections.Generic;
using PDF.Models.Enums;
using PDF.Models.VerifyModel.Address;
using PDF.Models.VerifyModel.AdverseMedia;
using PDF.Models.VerifyModel.Bank;
using PDF.Models.VerifyModel.Comments;
using PDF.Models.VerifyModel.CustomerInformation;
using PDF.Models.VerifyModel.Liveness;
using PDF.Models.VerifyModel.PepAndSanction;
using PDF.Models.VerifyModel.SourceOfFunds;

namespace PDF.Models.ViewModels
{
    public class VerifyViewModel : BaseModel
    {
        public VerifyViewModel()
        {
            Comments = new List<CommentsModel>();
            PageSections = new List<int>();
        }

        public ReportServiceTypes ReportServiceType { get; set; }
        public DateTime MandateDate { get; set; }
        public string MandateReference { get; set; }
        public string TenantName { get; set; }
        public string ConsultantName { get; set; }
        public string CreatedBy { get; set; }
        public CustomerInfoVerifyModel CustomerInfo { get; set; }
        public LivenessVerifyModel IdAndLiveness { get; set; }
        public PepAndSanctionModel PepAndSanction { get; set; }
        public PepAndSanctionModel PepAndSanctionV2 { get; set; }
        public AdverseMediaModel AdverseMedia { get; set; }
        public AddressVerificationModel AddressVerification { get; set; }
        public AddressProofModel ProofOfAddress { get; set; }
        public GEOLocationModel GEOlocation { get; set; }
        public BankModel BankDetail { get; set; }
        public SourceOfFundsModel SourceOfFunds { get; set; }
        public List<CommentsModel> Comments { get; set; }
        public List<int> PageSections { get; set; }
    }
}
