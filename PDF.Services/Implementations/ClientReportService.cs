using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDF.Data.Implementation;
using PDF.Services.Dtos.ClientReport;

namespace PDF.Services.Implementations
{
    public class ClientReportService : ReportServiceBase, IClientReportService
    {
        private readonly IClientReportRepository _repository;
        private readonly IMapper _mapper;

        public ClientReportService(IClientReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RequestedParticipantPersonalDetailsDto> GetParticipantPersonalDetails(long mandateId, long individualId)
        {
            try
            {
                var data = await _repository.GetParticipantSummary(mandateId, individualId);
                var mappedData = new RequestedParticipantPersonalDetailsDto
                {
                    CustomerReference = data.ReferenceId,
                    FirstName = data.FirstName,
                    MiddleName = data.MiddleName,
                    Surname = data.Lastname,
                    MaidenName = data.MaidenName,
                    KnownAs = data.KnownByName,
                    Title = data.Title,
                    DateOfBirth = data.DateOfBirth,
                    Sex = data.GenderTypeName,
                    PlaceOfBirth = data.CountryOfBirthCountryName,
                    TownOfBirth = data.TownOfBirth,
                    CountryOfDomicile = data.CountryOfDomicileCountryName,
                    MaritalStatus = data.MaritalStatusTypeName,
                    EmailAddress = data.EmailAddress,
                    Nationality = new[] { data.CountryOfNationalityName, data.IsDualNationality ? data.CountryOfSecondNationalityName : null },
                    TaxEmployment = new TaxEmploymentDto()
                    {
                        EmploymentStatus = data.EmploymentStatusTypeName,
                        Position = data.Position,
                        StartDate = data.PositionStartDate,
                        Salary = data.Salary,
                        IsDirectorship = data.IsDirectorship,
                        DirectorshipDetails = data.DirectorshipDetails,
                        IsPep = data.IsPep,
                        PepDetails = data.PepDetails
                    }
                };

                return mappedData;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error retrieving Participant Personal details");

                throw;
            }
        }

        public async Task<ParticipantAddressDetailsDto> GetParticipantAddresses(long individualId)
        {
            try
            {
                var data = await _repository.GetParticipantAddresses(individualId);
                var individualAddresses = data?.ToList();
                if (individualAddresses == null)
                {
                    throw new Exception($"No addresses found against the individual {{individualId}} {individualId}");
                }

                var mappedData = new ParticipantAddressDetailsDto();
                var currentAddress = individualAddresses.FirstOrDefault(a =>
                    a.IsCurrentAddress &&
                    a.AddressTypeName.Equals("Residential", StringComparison.OrdinalIgnoreCase));
                var postalAddress = individualAddresses.FirstOrDefault(a =>
                    a.AddressTypeName.Equals("Postal", StringComparison.OrdinalIgnoreCase));
                var previousAddresses = individualAddresses.Where(a =>
                        a.AddressTypeName.Equals("Residential", StringComparison.OrdinalIgnoreCase) && !a.IsCurrentAddress).ToList();

                mappedData.CurrentResidentialAddress = currentAddress != null ? _mapper.Map<ResidentialAddressDto>(currentAddress) : null;
                mappedData.PostalAddress = postalAddress != null ? _mapper.Map<ResidentialAddressDto>(postalAddress) : null;
                mappedData.PreviousAddresses = previousAddresses.Any() ? _mapper.Map<List<ResidentialAddressDto>>(previousAddresses) : null;

                return mappedData;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error retrieving Participant address details");

                throw;
            }
        }

        public async Task<ParticipantContactInformationDto> GetParticipantContactInfo(long individualId)
        {
            try
            {
                var data = await _repository.GetParticipantContactInfo(individualId);
                return _mapper.Map<ParticipantContactInformationDto>(data);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error retrieving Participant contact information.");

                throw;

            }
        }
        public async Task<IEnumerable<ParticipantTaxResidencyDto>> GetParticipantTaxResidencies(long individualId)
        {
            try
            {
                var data = await _repository.GetParticipantTaxResidencies(individualId);
                return _mapper.Map<IEnumerable<ParticipantTaxResidencyDto>>(data);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error retrieving Participant contact information.");

                throw;
            }
        } 

        public async Task<IndividualSummaryReportDataDto> GetParticipantSummaryDetails(long individualId)
        {
            try
            {
                var data = await _repository.ReadIndividualSummaryAsync(individualId);

                var model = new IndividualSummaryReportDataDto
                {
                    ParticipantMainDetail = _mapper.Map<SummaryMainDetailDto>(data.Item1),
                    SummaryInterestedParties = _mapper.Map<IEnumerable<SummaryInterestedPartyDto>>(data.Item6),
                    SummaryIsaProviders = _mapper.Map<IEnumerable<SummaryIsaProviderDto>>(data.Item3),
                    SummaryTaxDetails = _mapper.Map<IEnumerable<SummaryTaxDetailDto>>(data.Item5),
                    SummaryPreviousAddresses = _mapper.Map<IEnumerable<SummaryPreviousAddressDto>>(data.Item2)
                };

                return model;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error retrieving Participant summary information.");

                throw;
            }
        }
    }
}
