using System.Threading.Tasks;
using PDF.Models;
using PDF.Models.ViewModels;

namespace PDF.Implementations.Interfaces
{
    public interface IReport
    {
        Task<IBaseModel> GetReport(ReportsParameters parameters);
    }
}
