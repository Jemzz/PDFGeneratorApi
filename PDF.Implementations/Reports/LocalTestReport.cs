using System.Threading.Tasks;
using PDF.Implementations.Interfaces;
using PDF.Models;
using PDF.Models.ViewModels;

namespace PDF.Implementations.Reports
{
    public class LocalTestReport : IReport
    {
        private readonly IReport _report;

        public LocalTestReport(VerifyReport report)
        {
            _report = report;
        }

        public async Task<IBaseModel> GetReport(ReportsParameters parameters)
        {
            var model = await this._report.GetReport(parameters);

            return model;
        }
    }
}
