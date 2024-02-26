using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Implementations.Interfaces;
using PDF.Models;
using PDF.Models.ClientReportModels;
using PDF.Models.Enums;
using PDF.Models.ViewModels;
using PDF.Services.Implementations;

namespace PDF.Implementations.Reports
{
    public class ClientReport : IReport
    {
        private readonly IClientReportService _reportService;
        private readonly IMapper _mapper;

        public ClientReport(IMapper mapper, IClientReportService reportService)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        public async Task<IBaseModel> GetReport(ReportsParameters parameters)
        {
            var mandateId = parameters.MandateId;
            var individualId = parameters.IndividualId;
            if (mandateId == default || individualId == default)
            {
                throw new Exception("mandateId and individualId is required");
            }

            var summaryDetails = await _reportService.GetParticipantSummaryDetails(individualId);
            //var personalDetails = await _reportService.GetParticipantPersonalDetails(mandateId, individualId);
            //var addressDetails = await _reportService.GetParticipantAddresses(individualId);
            //var contactInfo = await _reportService.GetParticipantContactInfo(individualId);
            //var taxResidencies = await _reportService.GetParticipantTaxResidencies(individualId);
            var model = new PrimaryParticipantSummaryViewModel
            {
                //PersonalDetail = _mapper.Map<RequestedParticipantPersonalDetailsModel>(personalDetails),
                //TaxResidencies = _mapper.Map<IEnumerable<ParticipantTaxResidencyModel>>(taxResidencies),
                //CurrentResidentialAddress = _mapper.Map<ResidentialAddressModel>(addressDetails.CurrentResidentialAddress),
                //PreviousAddresses = _mapper.Map<List<ResidentialAddressModel>>(addressDetails.PreviousAddresses),
                //PostalAddress = _mapper.Map<ResidentialAddressModel>(addressDetails.PostalAddress),
                //ContactDetails = _mapper.Map<ParticipantContactInformationModel>(contactInfo),
                IndividualDetails = _mapper.Map<IndividualSummaryReportDataModel>(summaryDetails)
            };

            var reportNumber = "2";

        //if (parameters.ReportType == (int)ReportServiceTypes.ClientReportParticipant1)
        //{
        //    model.PersonalDetail.IsMainApplicant = true;
        //    reportNumber = "1";
        //    //other model details
        //}

        if (parameters.ReportType == (int) ReportServiceTypes.ClientReportParticipant1)
        {
            model.IndividualDetails.ParticipantMainDetail.IsMainApplicant = true;
            reportNumber = "1";
            //other model details
        }

        //model.AdditionalContent.Add("clientname", $"{model.PersonalDetail.FirstName} {model.PersonalDetail.MiddleName} {model.PersonalDetail.Surname}");
        model.AdditionalContent.Add("clientname", $"{model.IndividualDetails.ParticipantMainDetail.FirstName} {model.IndividualDetails.ParticipantMainDetail.MiddleName} {model.IndividualDetails.ParticipantMainDetail.Surname}");
            model.AdditionalContent.Add("footerStampText", "Client Report -");
            model.ViewPath = "ParticipantClientReport";
            model.LayoutPath = "~/Views/Shared/_Layout.cshtml";
            model.FileName = $"client_report_participant{reportNumber}_{DateTime.UtcNow:yyyyMMMMdd_HHmmss}.pdf";
            model.SpecificPageViewPath = "FirstPage/ClientReportFirstPage";
            model.ReportName = $"Client Report - Participant{reportNumber}";
            return model;
        }
    }
}