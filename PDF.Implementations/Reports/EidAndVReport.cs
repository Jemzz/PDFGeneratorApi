using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using PDF.Core.Utilities;
using PDF.Implementations.Interfaces;
using PDF.Models;
using PDF.Models.Enums;
using PDF.Models.ViewModels;

namespace PDF.Implementations.Reports
{
    public class EidAndVReport : IReport
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EidAndVReport(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IBaseModel> GetReport(ReportsParameters parameters)
        {
            var postParams = (PostReportParameters)parameters;
            var verifyViewModel = postParams.Json.FromJsonString<VerifyViewModel>();
            verifyViewModel.ReportServiceType = (ReportServiceTypes)parameters.ReportType;

            var mainCss = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot/css/custom/verify/verify-report.css");
            var css = await File.ReadAllTextAsync(mainCss);

            var coverCssPath = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot/css/custom/verify/verify-cover.css");
            var coverCss = await File.ReadAllTextAsync(coverCssPath);

            verifyViewModel.AdditionalContent.Add("clientname", $"{verifyViewModel.CustomerInfo.PersonalDetails.FirstName} {verifyViewModel.CustomerInfo.PersonalDetails.MiddleName} {verifyViewModel.CustomerInfo.PersonalDetails.Surname}");
            verifyViewModel.AdditionalContent.Add("footerStampText", "Customer Verification Report ");
            verifyViewModel.Css = css;
            verifyViewModel.FirstPageCss = coverCss;
            verifyViewModel.ViewPath = "VerifyReport";
            verifyViewModel.LayoutPath = "~/Views/Shared/_Layout.cshtml";
            verifyViewModel.FileName = $"e-ID&V_Report_{DateTime.UtcNow:yyyyMMMMdd_HHmmss}.pdf";
            verifyViewModel.SpecificPageViewPath = "FirstPage/EidVFirstPage";
            verifyViewModel.ReportName = "e-ID&V Report";

            return await Task.Run(() => verifyViewModel);
        }
    }
}
