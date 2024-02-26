using System;
using System.Threading.Tasks;
using PDF.Implementations.Implementations.Interfaces;
using PDF.Implementations.Interfaces;
using PDF.Models;
using PDF.Models.Enums;
using PDF.Models.ViewModels;

namespace PDF.Implementations
{
    public class ReportFactory : IReportFactory
    {
        public Func<ReportServiceTypes, IReport> _provider;

        public ReportFactory(Func<ReportServiceTypes, IReport> provider)
        {
            this._provider = provider;
        }

        public async Task<IBaseModel> GetReportById(int id, ReportsParameters parameters)
        {
            return await _provider((ReportServiceTypes)id).GetReport(parameters);
        }
    }
}
