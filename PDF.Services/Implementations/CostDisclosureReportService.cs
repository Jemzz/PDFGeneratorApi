using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Data.Interface;
using PDF.Services.Dtos;
using PDF.Services.Interfaces;

namespace PDF.Services.Implementations
{
    public class CostDisclosureReportService : ReportServiceBase, ICostDisclosureReportService
    {
        private readonly ICostDisclosureRepository _costDisclosureRepository;
        private readonly IMapper _mapper;

        public CostDisclosureReportService(ICostDisclosureRepository costDisclosureRepository, IMapper mapper)
        {
            _costDisclosureRepository = costDisclosureRepository;
            _mapper = mapper;
        }

        public async Task<List<CostDisclosureAnalysisOfMovementDto>> GetAnalysisOfMovements(long portfolioId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var analysisOfMovements = await _costDisclosureRepository.GetAnalysisOfMovements(portfolioId, startDate, endDate);
                var analysisOfMovementsDto = _mapper.Map<List<CostDisclosureAnalysisOfMovementDto>>(analysisOfMovements);

                return analysisOfMovementsDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error retrieving cost disclosure Analysis Of Movements details");

                throw;
            }
        }

        public async Task<CostDisclosureOngoingChargeDto> GetOngoingCharge(long portfolioId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var cashAccount = await _costDisclosureRepository.GetOngoingCharge(portfolioId, startDate, endDate);
                var cashAccountDto = _mapper.Map<CostDisclosureOngoingChargeDto>(cashAccount);

                return cashAccountDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error retrieving cost disclosure ongoing charge details");
                throw;
            }
        }

        public async Task<CostDisclosureSummaryDto> GetCostDisclosureReportSummary(long portfolioId, DateTime asAtDate)
        {
            try
            {
                var summary = await _costDisclosureRepository.GetCostDisclosureReportSummary(portfolioId, asAtDate);
                var summaryDto = _mapper.Map<CostDisclosureSummaryDto>(summary);

                return summaryDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error Report Summary details");
                throw;
            }
        }
    }
}
