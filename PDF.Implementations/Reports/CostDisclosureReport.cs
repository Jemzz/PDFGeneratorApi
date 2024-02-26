using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Implementations.Interfaces;
using PDF.Models;
using PDF.Models.CostDisclosureModels;
using PDF.Models.ViewModels;
using PDF.Services.Interfaces;

namespace PDF.Implementations.Reports
{
    public class CostDisclosureReport : IReport
    {
        private readonly ICostDisclosureReportService _reportService;
        public readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public CostDisclosureReport(IMapper mapper, IWebHostEnvironment hostingEnvironment, ICostDisclosureReportService reportService)
        {
            _reportService = reportService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IBaseModel> GetReport(ReportsParameters parameters)
        {
            var startDate = parameters.StartDate ?? DateTime.Now;
            var endDate = parameters.EndDate ?? DateTime.Now;

            var summary = await _reportService.GetCostDisclosureReportSummary(parameters.PortfolioId, endDate);
            var ongoingCharge = await _reportService.GetOngoingCharge(parameters.PortfolioId, startDate, endDate);
            var analysisOfMovement = await _reportService.GetAnalysisOfMovements(parameters.PortfolioId, startDate, endDate);

            var valuationReportViewModel = new CostDisclosureReportViewModel
            {
                ReportSummary = new CostDisclosureSummaryModel
                {
                    AccountReference = summary.AccountReference,
                    ClientName = summary.ClientName,
                    PortfolioReference = summary.PortfolioReference,
                    PortfolioName = summary.PortfolioName,
                    PortfolioInception = summary.PortfolioInception,
                    ProductCode = summary.ProductCode,
                    ProductTitle = summary.ProductTitle,
                    StrategyTitle = summary.StrategyTitle,
                    InitialAmount = summary.InitialAmount,
                    MarketValue = summary.MarketValue,
                    TargetRisk = summary.TargetRisk
                },
                OngoingCharge = _mapper.Map<CostDisclosureOngoingChargeModel>(ongoingCharge),
                AnalysisOfMovements = _mapper.Map<List<CostDisclosureAnalysisOfMovementModel>>(analysisOfMovement),
                StartDate = parameters.StartDate,
                EndDate = parameters.EndDate
            };

            //var mainCss = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot/css/custom/valuation/valuation.css");
            //var css = File.ReadAllText(mainCss ?? throw new InvalidOperationException());

            valuationReportViewModel.AdditionalContent.Add("clientname", $"{summary.ClientName} - Account reference {summary.AccountReference}");
            //valuationReportViewModel.Css = css;
            valuationReportViewModel.ViewPath = "CostDisclosureReport";
            valuationReportViewModel.LayoutPath = "~/Views/Shared/_Layout.cshtml";
            valuationReportViewModel.FileName = $"Cost_Disclosure_Report_{DateTime.UtcNow:yyyyMMMMdd_HHmmss}.pdf";
            valuationReportViewModel.SpecificPageViewPath = "FirstPage/CostDisclosureFirstPage";
            valuationReportViewModel.ReportName = "Cost Disclosure Report";
            //valuationReportViewModel.Sections = sections;

            return valuationReportViewModel;
        }
    }
}
