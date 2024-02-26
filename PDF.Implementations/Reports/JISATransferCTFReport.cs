using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PDF.Implementations.Interfaces;
using PDF.Models;
using PDF.Models.ISAReportModels;
using PDF.Models.ViewModels;
using PDF.Services.Interfaces;

namespace PDF.Implementations.Reports
{
    public class JISATransferCTFReport : IReport
    {
        private readonly IMapper _mapper;
        private readonly ITransferReportService _isaTransferService;
        public readonly IWebHostEnvironment _hostingEnvironment;

        public JISATransferCTFReport(IWebHostEnvironment hostingEnvironment, IMapper mapper, ITransferReportService isaTransferService)
        {
            _isaTransferService = isaTransferService;
            this._hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        public async Task<IBaseModel> GetReport(ReportsParameters parameters)
        {
            var model = new ISATransferViewModel();

            if (parameters.IsaTransferId != 0)
            {
                var isaTransfer = await this._isaTransferService.GetTransferData(parameters.IsaTransferId);

                if (isaTransfer == null)
                {
                    model.ErrorList.Add("Missing JISA CTF Transfer data");
                }

                if (!model.ErrorList.Any())
                {
                    var mainCss = Path.Combine(_hostingEnvironment.ContentRootPath, "Content/isa-transfer-report.css");
                    var css = File.ReadAllText(mainCss);
                    model.AdditionalContent.Add("externalReferenceid", isaTransfer.ExternalReferenceId);
                    model.ISATransfer = _mapper.Map<ISATransferModel>(isaTransfer);

                    model.Css = css;
                    model.ViewPath = "JISATransferCTFReport";
                    model.LayoutPath = "~/Views/Shared/_Layout.cshtml";
                    model.FileName = $"JISATransferCTF_Report_{DateTime.UtcNow:yyyyMMMMdd_HHmmss}.pdf";
                    model.ReportName = "JISA Transfer CTF Report";
                }
            }
            else
            {
                model.ErrorList.Add("Missing IsaTransferId");
            }

            return model;
        }
    }
}
