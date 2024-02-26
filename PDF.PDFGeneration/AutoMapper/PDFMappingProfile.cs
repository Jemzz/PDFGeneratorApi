using AutoMapper;
using PDF.Data.Entities;
using PDF.Data.Entities.ClientReport;
using PDF.Data.Entities.CostDisclosure;
using PDF.Data.Entities.ISATransfer;
using PDF.Data.Entities.Suitability;
using PDF.Models.ClientReportModels;
using PDF.Models.CostDisclosureModels;
using PDF.Models.ISAReportModels;
using PDF.Models.SuitabilityReportModels;
using PDF.Models.ValuationReportModels;
using PDF.Services.Dtos;
using PDF.Services.Dtos.ClientReport;

namespace PDF.PDFGeneration.AutoMapper
{
    public class PDFMappingProfile : Profile
    {
        public PDFMappingProfile()
        {
            CreateMap<SuitabilityIndividualDetails, SuitabilityIndividualDetailsDto>();
            CreateMap<SuitabilityIndividualDetailsDto, SuitabilityIndividualDetailsModel>();
            CreateMap<SuitabilityAttitudeToRiskDto, SuitabilityAttitudeToRiskModel>();
            CreateMap<SuitabilityTargetAllocation, SuitabilityTargetAllocationDto>();
            CreateMap<SuitabilityTargetAllocationDto, SuitabilityTargetAllocationModel>();
            CreateMap<SuitabilityPortfilio, SuitabilityPortfilioDto>();
            CreateMap<SuitabilityPortfilioDto, SuitabilityPortfilioModel>();
            CreateMap<QuestionAnswerDto, QuestionAnswerModel>();
            CreateMap<ISATransferData, ISATransferDto>();
            CreateMap<ISATransferDto, ISATransferModel>();
            CreateMap<CostDisclosureSummaryDto, CostDisclosureSummaryModel>();
            CreateMap<CostDisclosureSummary, CostDisclosureSummaryDto>();
            CreateMap<CostDisclosureOngoingChargeDto, CostDisclosureOngoingChargeModel>();
            CreateMap<CostDisclosureOngoingCharge, CostDisclosureOngoingChargeDto>();
            CreateMap<CostDisclosureAnalysisOfMovementDto, CostDisclosureAnalysisOfMovementModel>();
            CreateMap<CostDisclosureAnalysisOfMovement, CostDisclosureAnalysisOfMovementDto>();

            CreateMap<ReportSummary, ReportSummaryDto>();
            CreateMap<ReportSummaryDto, ReportSummaryModel>();
            CreateMap<ReportHoldings, ReportHoldingsDto>();
            CreateMap<ReportHoldingsDto, ReportHoldingsModel>();
            CreateMap<CashAccount, CashAccountDto>();
            CreateMap<CashAccountDto, CashAccountModel>();
            CreateMap<SecurityTrades, SecurityTradesDto>();
            CreateMap<SecurityTradesDto, SecurityTradesModel>();
            CreateMap<AnalysisOfMovementsDto, AnalysisOfMovementsModel>();
            CreateMap<AnalysisOfMovements, AnalysisOfMovementsDto>();

            CreateMap<RequestedParticipantPersonalDetailsDto, RequestedParticipantPersonalDetailsModel>();
            CreateMap<TaxEmploymentDto, TaxEmploymentModel>();

            CreateMap<ResidentialAddressDto, ResidentialAddressModel>();
            CreateMap<IndividualContactInformation, ParticipantContactInformationDto>();
            CreateMap<ParticipantContactInformationDto, ParticipantContactInformationModel>();
            CreateMap<IndividualAddress, ResidentialAddressDto>();

            CreateMap<TaxResidency, ParticipantTaxResidencyDto>();
            CreateMap<ParticipantTaxResidencyDto, ParticipantTaxResidencyModel>();

            CreateMap<SummaryMainDetail, SummaryMainDetailDto>();
            CreateMap<SummaryInterestedParty, SummaryInterestedPartyDto>();
            CreateMap<SummaryTaxDetail, SummaryTaxDetailDto>();
            CreateMap<SummaryIsaProvider, SummaryIsaProviderDto>();
            CreateMap<SummaryPreviousAddress, SummaryPreviousAddressDto>();
            CreateMap<SummaryFinancialDependent, SummaryFinancialDependentDto>();

            CreateMap<SummaryMainDetailDto, SummaryMainDetailModel>();
            CreateMap<SummaryInterestedPartyDto, SummaryInterestedPartyModel>();
            CreateMap<SummaryTaxDetailDto, SummaryTaxDetailModel>();
            CreateMap<SummaryIsaProviderDto, SummaryIsaProviderModel>();
            CreateMap<SummaryPreviousAddressDto, SummaryPreviousAddressModel>();
            CreateMap<SummaryFinancialDependentDto, SummaryFinancialDependentModel>();

            CreateMap<IndividualSummaryReportDataDto, IndividualSummaryReportDataModel>()
                .ForMember(dest => dest.ParticipantMainDetail, src => src.MapFrom(x => x.ParticipantMainDetail))
                .ForMember(dest => dest.SummaryInterestedParties, src => src.MapFrom(x => x.SummaryInterestedParties))
                .ForMember(dest => dest.SummaryIsaProviders, src => src.MapFrom(x => x.SummaryIsaProviders))
                .ForMember(dest => dest.SummaryPreviousAddresses, src => src.MapFrom(x => x.SummaryPreviousAddresses))
                .ForMember(dest => dest.SummaryTaxDetails, src => src.MapFrom(x => x.SummaryTaxDetails));


        }
    }
}
