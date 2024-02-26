using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Data.Interface;
using PDF.Services.Dtos;
using PDF.Services.Interfaces;

namespace PDF.Services.Implementations
{
    public class ValuationReportService : ReportServiceBase, IValuationReportService
    {
        private readonly IValuationRepository _valuationRepository;
        private readonly IMapper _mapper;

        public ValuationReportService(IValuationRepository valuationRepository, IMapper mapper)
        {
            _valuationRepository = valuationRepository;
            _mapper = mapper;
        }

        public async Task<List<AnalysisOfMovementsDto>> GetAnalysisOfMovements(long portfolioId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var analysisOfMovements = await _valuationRepository.GetAnalysisOfMovements(portfolioId, startDate, endDate);
                var analysisOfMovementsDto = _mapper.Map<List<AnalysisOfMovementsDto>>(analysisOfMovements);

                return analysisOfMovementsDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error Analysis Of Movements details");

                throw;
            }
        }

        public async Task<List<CashAccountDto>> GetCashAccount(long portfolioId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var cashAccount = await _valuationRepository.GetCashAccount(portfolioId, startDate, endDate);
                var cashAccountDto = _mapper.Map<List<CashAccountDto>>(cashAccount);

                return cashAccountDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error Cash Account details");
                throw;
            }
        }

        public async Task<List<ReportHoldingsDto>> GetReportHoldings(long portfolioId, DateTime asAtDate)
        {
            try
            {
                var reportHolding = await _valuationRepository.GetReportHoldings(portfolioId, asAtDate);
                var reportHoldingDto = _mapper.Map<List<ReportHoldingsDto>>(reportHolding);

                return reportHoldingDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error Holdings details");
                throw;
            }
        }

        public async Task<ReportSummaryDto> GetReportSummary(long portfolioId, DateTime asAtDate)
        {
            try
            {
                var summary = await _valuationRepository.GetReportSummary(portfolioId, asAtDate);
                var summaryDto = _mapper.Map<ReportSummaryDto>(summary);

                return summaryDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error Report Summary details");
                throw;
            }
        }

        public async Task<List<SecurityTradesDto>> GetSecurityTrades(long portfolioId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var securityTrades = await _valuationRepository.GetSecurityTrades(portfolioId, startDate, endDate);
                var securityTradesDto = _mapper.Map<List<SecurityTradesDto>>(securityTrades);

                return securityTradesDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error Security Trade details");
                throw;
            }
        }
    }
}
