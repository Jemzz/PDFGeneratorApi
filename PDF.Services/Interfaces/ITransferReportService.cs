using System.Threading.Tasks;
using PDF.Services.Dtos;

namespace PDF.Services.Interfaces
{
    public interface ITransferReportService
    {
        Task<ISATransferDto> GetTransferData(int isaTransferId);
    }
}
