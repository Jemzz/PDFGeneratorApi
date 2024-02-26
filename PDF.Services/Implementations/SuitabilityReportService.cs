using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDF.Data.Interface;
using PDF.Services.Dtos;
using PDF.Services.Interfaces;

namespace PDF.Services.Implementations
{
    public class SuitabilityReportService : ReportServiceBase, ISuitabilityReportService
    {
        private readonly ISuitabilityRepository _suitabilityRepository;
        private readonly IMapper _mapper;

        public SuitabilityReportService(ISuitabilityRepository suitabilityRepository, IMapper mapper)
        {
            _suitabilityRepository = suitabilityRepository;
            _mapper = mapper;
        }

        public async Task<SuitabilityIndividualDetailsDto> GetSuitabilityIndividualDetails(long mandateId, bool isChangeOfRisk)
        {
            try
            {
                var summary = await _suitabilityRepository.GetSuitabilityIndividualDetails(mandateId);
                var summaryDto = _mapper.Map<SuitabilityIndividualDetailsDto>(summary);
                Logger.Debug("Individual details retrieved");

                return summaryDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error retrieving individual details");
                throw;
            }
        }

        public async Task<List<SuitabilityAttitudeToRiskDto>> GetSuitabilityAttitudeToRisk(long mandateId, bool isChangeOfRisk)
        {
            try
            {
                var attitudeToRisk = await _suitabilityRepository.GetSuitabilityAttitudeToRisk(mandateId, isChangeOfRisk);
                var attitudeToRiskList = attitudeToRisk.ToList();
                var attitudeGroups = attitudeToRiskList.GroupBy(x => x.QuestionText).ToList();
                var attitudeToRiskDtoList = new List<SuitabilityAttitudeToRiskDto>();

                foreach (var i in attitudeGroups)
                {
                    var attitudeToRiskDto = new SuitabilityAttitudeToRiskDto
                    {
                        Question = i.Key,
                        SelectedResponse = i.Select(x => x.SelectedResponseOrder).FirstOrDefault(),
                        QuestionOrder = i.Select(x => x.QuestionOrder).FirstOrDefault()
                    };

                    foreach (var x in i)
                    {
                        var answer = new QuestionAnswerDto
                        {
                            ResponseText = x.ResponseText,
                            ResponseOrder = x.ResponseOrder,
                            DisplayText = x.DisplayText
                        };

                        attitudeToRiskDto.Answers.Add(answer);
                    }

                    attitudeToRiskDtoList.Add(attitudeToRiskDto);
                }

                Logger.Debug("Attitiude to risk data retrieved");
                return attitudeToRiskDtoList;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error retrieving attitude to risk data");
                throw;
            }
        }

        public async Task<List<SuitabilityTargetAllocationDto>> GetSuitabilityTargetAllocation(long mandateId, bool isChangeOfRisk)
        {
            try
            {
                var summaryTargetAllocation = await _suitabilityRepository.GetSuitabilityTargetAllocation(mandateId, isChangeOfRisk);
                var summaryTargetAllocationDto = _mapper.Map<List<SuitabilityTargetAllocationDto>>(summaryTargetAllocation);
                Logger.Debug("Target allocation data retrieved");
                return summaryTargetAllocationDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error retrieving target allocation data");
                throw;
            }
        }

        public async Task<SuitabilityPortfilioDto> GetSuitabilityPortfolioData(long mandateId, bool isChangeOfRisk)
        {
            try
            {
                var summaryPortfolio = await _suitabilityRepository.GetSuitabilityPortfolioData(mandateId, isChangeOfRisk);
                var summaryPortfolioDto = _mapper.Map<SuitabilityPortfilioDto>(summaryPortfolio);
                Logger.Debug("Portfolio data retrieved");
                return summaryPortfolioDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error retrieving portfolio data");
                throw;
            }
        }

        public async Task<SuitabilityPortfilioDto> GetPostSuitabilityPortfolioData(long mandateId, int reportType, int correlationId)
        {
            try
            {
                var summaryPortfolio = await _suitabilityRepository.GetPostSuitabilityPortfolioData(mandateId, reportType, correlationId);
                var summaryPortfolioDto = _mapper.Map<SuitabilityPortfilioDto>(summaryPortfolio);
                Logger.Debug("Portfolio data retrieved");
                return summaryPortfolioDto;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error retrieving portfolio data");
                throw;
            }
        }
    }
}
