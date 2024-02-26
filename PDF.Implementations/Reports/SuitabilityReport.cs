using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using PDF.Implementations.Interfaces;
using PDF.Models;
using PDF.Models.Enums;
using PDF.Models.SuitabilityReportModels;
using PDF.Models.ViewModels;
using PDF.Services.Interfaces;

namespace PDF.Implementations.Reports
{
    public class SuitabilityReport : IReport
    {
        private readonly IMapper _mapper;
        private readonly ISuitabilityReportService _suitabilityService;
        public readonly IWebHostEnvironment _hostingEnvironment;

        public SuitabilityReport(IWebHostEnvironment hostingEnvironment, IMapper mapper, ISuitabilityReportService suitabilityService)
        {
            _suitabilityService = suitabilityService;
            this._hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        public async Task<IBaseModel> GetReport(ReportsParameters parameters)
        {
            var model = new SuitabilityReportViewModel();

            if (parameters.MandateId != 0)
            {
                var isChangeOfRisk = (parameters.ReportSubType ?? 0) == (int)ReportServiceSubTypes.ChangeOfRisk;

                var suitabilityData = await _suitabilityService.GetSuitabilityIndividualDetails(parameters.MandateId, isChangeOfRisk);
                var attitudeToRiskData = await _suitabilityService.GetSuitabilityAttitudeToRisk(parameters.MandateId, isChangeOfRisk);
                var targetAllocationData = await _suitabilityService.GetSuitabilityTargetAllocation(parameters.MandateId, isChangeOfRisk);
                var portfolioData = await _suitabilityService.GetSuitabilityPortfolioData(parameters.MandateId, isChangeOfRisk);

                if (suitabilityData == null)
                {
                    model.ErrorList.Add("Missing Suitability data");
                }

                if (!attitudeToRiskData.Any())
                {
                    model.ErrorList.Add("Missing Attitude to risk data");
                }

                if (!targetAllocationData.Any())
                {
                    model.ErrorList.Add("Missing Target allocation data");
                }

                if (portfolioData == null)
                {
                    model.ErrorList.Add("Missing portfolio data");
                }

                if (!model.ErrorList.Any())
                {
                    model.AdditionalContent.Add("referenceid", suitabilityData.PortfolioReference);
                    model.AdditionalContent.Add("mandatereferenceid", suitabilityData.MandateRererence);
                    model.Suitability = _mapper.Map<SuitabilityIndividualDetailsModel>(suitabilityData);
                    model.AttitudeToRisk = _mapper.Map<List<SuitabilityAttitudeToRiskModel>>(attitudeToRiskData);
                    model.TargetAllocation = _mapper.Map<List<SuitabilityTargetAllocationModel>>(targetAllocationData);
                    model.PortfolioData = _mapper.Map<SuitabilityPortfilioModel>(portfolioData);
                    model.IsChangeOfRisk = isChangeOfRisk;

                    // convert datetime to uk date
                    TimeZoneInfo ukZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                    DateTime ukTime = TimeZoneInfo.ConvertTimeFromUtc(model.Suitability.GeneratedDateTime, ukZone);

                    model.Suitability.GeneratedDateTime = ukTime;

                    var mainCss = Path.Combine(_hostingEnvironment.ContentRootPath, "Content/suitability-report.css");
                    var css = File.ReadAllText(mainCss);

                    model.Css = css;
                    model.ViewPath = "SuitabilityReport";
                    model.LayoutPath = "~/Views/Shared/_Layout.cshtml";
                    model.FileName = $"Suitability_Report_{DateTime.UtcNow:yyyyMMMMdd_HHmmss}.pdf";
                    model.ReportName = "Suitability Report";

                    return model;
                }

                return model;
            }

            model.ErrorList.Add("Missing MandateId");

            return model;
        }
    }
}
