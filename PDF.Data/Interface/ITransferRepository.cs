using System.Threading.Tasks;
using PDF.Data.Entities.ISATransfer;

namespace PDF.Data.Interface
{
    public interface ITransferRepository
    {
        Task<ISATransferData> GetISATransferData(int isaTransferId);
    }
}
