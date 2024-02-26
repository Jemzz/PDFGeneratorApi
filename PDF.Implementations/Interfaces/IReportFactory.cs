using System.Threading.Tasks;
using PDF.Models;
using PDF.Models.ViewModels;

namespace PDF.Implementations.Implementations.Interfaces
{
    public interface IReportFactory
    {
        // might change id parameter to enum
        Task<IBaseModel> GetReportById(int id, ReportsParameters parameters);
    }
}
