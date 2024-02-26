using AutoMapper;
using System;
using System.Threading.Tasks;
using PDF.Data.Interface;
using PDF.Services.Dtos;
using PDF.Services.Interfaces;

namespace PDF.Services.Implementations
{
    public class TransferReportService : ReportServiceBase, ITransferReportService
    {
        private readonly ITransferRepository _isaTransferRepository;
        private readonly IMapper _mapper;

        public TransferReportService(ITransferRepository isaTransferRepository,
                                        IMapper mapper)
        {
            _isaTransferRepository = isaTransferRepository;
            _mapper = mapper;
        }

        public async Task<ISATransferDto> GetTransferData(int isaTransferId)
        {
            try
            {
                var isaTransfer = await _isaTransferRepository.GetISATransferData(isaTransferId);
                var isaTransferDto = _mapper.Map<ISATransferDto>(isaTransfer);
                Logger.Debug("Transfer data retrieved");
                return isaTransferDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error retrieving Transfer data");
                throw;
            }
        }
    }
}
