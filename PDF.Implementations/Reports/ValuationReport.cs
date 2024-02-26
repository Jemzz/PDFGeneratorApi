using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using PDF.Implementations.Interfaces;
using PDF.Models;
using PDF.Models.ValuationReportModels;
using PDF.Models.ViewModels;
using PDF.Services.Interfaces;

namespace PDF.Implementations.Reports
{
    public class ValuationReport : IReport
    {
        private readonly IValuationReportService _reportService;
        public readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public ValuationReport(IMapper mapper, IWebHostEnvironment hostingEnvironment, IValuationReportService reportService)
        {
            _reportService = reportService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IBaseModel> GetReport(ReportsParameters parameters)
        {
            var startDate = parameters.StartDate ?? DateTime.Now;
            var endDate = parameters.EndDate ?? DateTime.Now;

            var summary = await _reportService.GetReportSummary(parameters.PortfolioId, endDate);
            var cashTransactions = await _reportService.GetCashAccount(parameters.PortfolioId, startDate, endDate);
            var securityTrades = await _reportService.GetSecurityTrades(parameters.PortfolioId, startDate, endDate);
            var analysisMovement = await _reportService.GetAnalysisOfMovements(parameters.PortfolioId, startDate, endDate);
            var holdings = await _reportService.GetReportHoldings(parameters.PortfolioId, endDate);

            var valuationReportViewModel = new ValuationReportViewModel
            {
                ReportSummary = new ReportSummaryModel
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
                SecurityTrades = _mapper.Map<List<SecurityTradesModel>>(securityTrades),
                CashAccount = _mapper.Map<List<CashAccountModel>>(cashTransactions),
                ReportHoldings = _mapper.Map<List<ReportHoldingsModel>>(holdings),
                AnalysisOfMovements = _mapper.Map<List<AnalysisOfMovementsModel>>(analysisMovement),
                StartDate = parameters.StartDate?.AddDays(-1),
                EndDate = parameters.EndDate
            };

            var mainCss = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot/css/custom/valuation/valuation.css");
            var css = await File.ReadAllTextAsync(mainCss ?? throw new InvalidOperationException());

            valuationReportViewModel.AdditionalContent.Add("clientname", $"{summary.ClientName} - Account reference {summary.AccountReference}");
            valuationReportViewModel.Css = css;
            valuationReportViewModel.ViewPath = "ValuationReport";
            valuationReportViewModel.LayoutPath = "~/Views/Shared/_Layout.cshtml";
            valuationReportViewModel.FileName = $"Valuation_Report_{DateTime.UtcNow:yyyyMMMMdd_HHmmss}.pdf";
            valuationReportViewModel.SpecificPageViewPath = "FirstPage/ValuationFirstPage";
            valuationReportViewModel.ReportName = "Valuation Report";
            //valuationReportViewModel.Sections = sections;

            return valuationReportViewModel;
        }
    }
}
