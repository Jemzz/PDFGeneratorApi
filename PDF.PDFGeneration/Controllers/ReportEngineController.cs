
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NLog;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PDF.Implementations.Implementations.Interfaces;
using PDF.Implementations.PDFConfigs.PDFFactoryImplementation.GenerationService;
using PDF.Models;
using PDF.Models.Enums;
using PDF.Models.ViewModels;
using PDF.PDFGeneration.ViewRender;

namespace PDF.PDFGeneration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportEngineController : ControllerBase
    {
        protected static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IReportFactory _factory;
        private readonly IPdfGenerationService _pdfService;
        private readonly IRenderView _renderView;
        private readonly IOptions<CurrentUrl> _configuration;

        /// <summary>
        /// Controller for report generation
        /// </summary>
        public ReportEngineController(IReportFactory factory, IPdfGenerationService pdfService, IRenderView renderView, IOptions<CurrentUrl> configuration)
        {
            _factory = factory;
            _pdfService = pdfService;
            _renderView = renderView;
            _configuration = configuration;
        }

        /// <summary>
        /// Download report based on ID and additional parameters. Reports are returned as model
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Route("download")]
        [HttpGet]
        public async Task<IActionResult> Download([FromQuery] ReportsParameters parameters)
        {
            try
            {
                var model = await this.GetReportModel(parameters);

                if (model.ReportData != null)
                {
                    if (model.ReportData.Length == 0)
                    {
                        Logger.Error("Error generating report. Zero byte document generated", model.ReportData.Length);
                        throw new Exception("Error generating report. A zero byte document has been generated.");
                    }

                    Logger.Debug("Download report. File Length {length}", model.ReportData.Length);

                    return Ok(new ReportModel
                    {
                        File = model.ReportData,
                        FileName = model.FileName,
                        Extension = ".pdf",
                        Size = model.ReportData.Length,
                        ContentType = "application/pdf",
                        ReportName = model.ReportName,
                        Status = System.Net.HttpStatusCode.OK
                    });
                }
                else
                {
                    model.ErrorList.Add($"Pdf config for {(ReportServiceTypes)parameters.ReportType} not found");
                }

                Logger.Debug("Download report requested but has model errors. Errors: ", string.Join(", ", model.ErrorList));

                var serErrors = JsonConvert.SerializeObject(model.ErrorList);
                Logger.Error(serErrors);
                return NotFound(serErrors);
            }
            catch (Exception ex)
            {
                ex.Data.Add("MandateId", parameters.MandateId);
                ex.Data.Add("StartDate", parameters.StartDate);
                ex.Data.Add("EndDate", parameters.EndDate);
                if (!ex.Data.Contains("ReportType"))
                    ex.Data.Add("ReportType", parameters.ReportType);
                Logger.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Download html report based on ID and additional parameters. Reports are returned as model
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Route("downloadashtml")]
        [HttpGet]
        public async Task<IActionResult> DownloadHtml([FromQuery] ReportsParameters parameters)
        {
            try
            {
                var model = await this.GetReportModel(parameters, 2);
                if (!string.IsNullOrWhiteSpace(model.ReportRender))
                {
                    var response = Content(model.ReportRender);
                    response.ContentType = "text/html; charset=UTF-8";
                    return response;
                }

                model.ErrorList.Add($"Pdf config for {(ReportServiceTypes)parameters.ReportType} not found");

                var serErrors = JsonConvert.SerializeObject(model.ErrorList);
                Logger.Error(serErrors);
                Logger.Debug("Download report requested but has model errors. Errors: ", string.Join(", ", model.ErrorList));
                return NotFound(serErrors);
            }
            catch (Exception ex)
            {
                ex.Data.Add("MandateId", parameters.MandateId);
                ex.Data.Add("StartDate", parameters.StartDate);
                ex.Data.Add("EndDate", parameters.EndDate);
                if (!ex.Data.Contains("ReportType"))
                    ex.Data.Add("ReportType", parameters.ReportType);
                Logger.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Download report based on ID and additional parameters. Reports are returned as byte
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Route("downloadasbyte")]
        [HttpGet]
        public async Task<IActionResult> DownloadByte([FromQuery] ReportsParameters parameters)
        {
            try
            {
                var model = await this.GetReportModel(parameters);

                if (!model.ErrorList.Any())
                {

                    if (model.ReportData != null)
                    {
                        if (model.ReportData.Length == 0)
                        {
                            Logger.Error("Error generating report. Zero byte document generated", model.ReportData.Length);
                            throw new Exception("Error generating report. A zero byte document has been generated.");
                        }

                        Logger.Debug("Download report. File Length {length}", model.ReportData.Length);

                        var dataStream = new MemoryStream(model.ReportData);
                        Logger.Debug("Download Complete");
                        return File(dataStream, "application/pdf", model.FileName);
                    }
                    else
                    {
                        model.ErrorList.Add($"Pdf config for {(ReportServiceTypes)parameters.ReportType} not found");
                    }

                }

                Logger.Debug("Download report requested but has model errors. Errors: ", string.Join(", ", model.ErrorList));

                var serErrors = JsonConvert.SerializeObject(model.ErrorList);
                Logger.Error(serErrors);
                return NotFound(serErrors);
            }
            catch (Exception ex)
            {
                ex.Data.Add("MandateId", parameters.MandateId);
                ex.Data.Add("StartDate", parameters.StartDate);
                ex.Data.Add("EndDate", parameters.EndDate);
                if (!ex.Data.Contains("ReportType"))
                    ex.Data.Add("ReportType", parameters.ReportType);
                Logger.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Download report based on ID and additional parameters. Reports are returned as byte
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="reportType"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Route("downloadpostasbyte/{reportType}")]
        [HttpPost]
        public async Task<IActionResult> DownloadPostByte(int reportType, [FromBody] JsonElement json)
        {
            try
            {
                var parameters = new PostReportParameters
                {
                    ReportType = reportType,
                    Json = System.Text.Json.JsonSerializer.Serialize(json)
                };

                var model = await this.PostReportModel(parameters);

                if (!model.ErrorList.Any())
                {

                    if (model.ReportData != null)
                    {
                        if (model.ReportData.Length == 0)
                        {
                            Logger.Error("Error generating report. Zero byte document generated", model.ReportData.Length);
                            throw new Exception("Error generating report. A zero byte document has been generated.");
                        }

                        Logger.Debug("Download report. File Length {length}", model.ReportData.Length);

                        var dataStream = new MemoryStream(model.ReportData);
                        Logger.Debug("Download Complete");
                        return File(dataStream, "application/pdf", model.FileName);
                    }
                    else
                    {
                        model.ErrorList.Add($"Pdf config for {(ReportServiceTypes)parameters.ReportType} not found");
                    }

                }

                Logger.Debug("Download report requested but has model errors. Errors: ", string.Join(", ", model.ErrorList));

                var serErrors = JsonConvert.SerializeObject(model.ErrorList);
                Logger.Error(serErrors);
                return NotFound(serErrors);
            }
            catch (Exception ex)
            {
                if (!ex.Data.Contains("ReportType"))
                    ex.Data.Add("ReportType", reportType);
                Logger.Error(ex);
                throw;
            }
        }

        [Route("downloadtestasbyte")]
        public async Task<ActionResult> TestPost()
        {
            //const string apiKeyString = "x-apikey";
            //if (!HttpContext.Request.Headers.TryGetValue(apiKeyString, out var extractedApiKey))
            //{
            //    return Unauthorized();
            //}

            var json = TestJson();

            var webClient = new HttpClient();
            using var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            // webClient.DefaultRequestHeaders.Add(apiKeyString, extractedApiKey.ToString());
            var response = await webClient.PostAsync($"{_configuration.Value.Host}reportengine/downloadpostasbyte/8", content);
            var ress = await response.Content.ReadAsStringAsync();
            var res = await response.Content.ReadAsByteArrayAsync();

            var dataStream = new MemoryStream(res);
            return File(dataStream, "application/pdf", "Test.pdf");
        }

        [Route("downloadtestgetasbyte")]
        public async Task<ActionResult> TestGet()
        {
            var json = TestJson();


            var parameters = new PostReportParameters
            {
                ReportType = 8,
                Json = json
            };

            var model = await this.PostReportModel(parameters, 2);

            var response = Content(model.ReportRender);
            response.ContentType = "text/html; charset=UTF-8";
            return response;
        }

        private async Task<IBaseModel> GetReportModel(ReportsParameters parameters, int mode = 1)
        {
            Logger.Debug("Download report requested. Report Type: {reportType}, User: {clientId}, MandateId: {mandateId}, PortfolioId: {portfolioId}", parameters.ReportType, parameters.ClientId, parameters.MandateId, parameters.PortfolioId);
            var model = await _factory.GetReportById(parameters.ReportType, parameters);
            model.Mode = mode;
            if (model == null)
                throw new Exception("Report factory returned no object");

            Logger.Debug("Download report requested. Report: {fileName}, User: {clientId}", model.FileName, parameters.ClientId);

            // due to azure GDI handling, there is a chance that the report generation will fail.
            try
            {
                if (!string.IsNullOrEmpty(model.SpecificPageViewPath))
                {
                    // purely for specific extra content because the view engine should only be called in a controller no where else
                    var customAdditionalHtml = await _renderView.RenderViewToString(ControllerContext, model.SpecificPageViewPath, model);
                    model.AdditionalContent.Add("content", customAdditionalHtml);
                    //  model.ReportRender = customAdditionalHtml;
                    // return model;
                }

                if (model.ErrorList.Any()) return model;

                var render = await _renderView.RenderViewToString(ControllerContext, model.ViewPath, model);

                if (mode == 1)
                {
                    var byteArr = await _pdfService.RenderPdf(render, parameters.ReportType, model.AdditionalContent);

                    model.ReportData = byteArr;
                }
                else
                    model.ReportRender = render;

                return model;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Failed to render report");
                throw;
            }
        }

        private async Task<IBaseModel> PostReportModel(PostReportParameters parameters, int mode = 1)
        {
            var model = await GetReportModel(parameters, mode);

            return model;
        }

        private string TestJson()
        {
            var json = System.IO.File.ReadAllText("testdata.json");
            return json;
        }
    }
}
