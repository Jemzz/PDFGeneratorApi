using System;
using System.Collections.Generic;

namespace PDF.Services.Dtos.ClientReport;

public class ResidentialAddressDto
{
    public string SubBuilding { get; set; }
    public string BuildingNumber { get; set; }
    public string BuildingName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string ProvinceName { get; set; }
    public string ProvinceCode { get; set; }
    public string PostZipCode { get; set; }
    public string District { get; set; }
    public string Country { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public string Address { get; set; }
}

public class ParticipantAddressDetailsDto
{
    public ResidentialAddressDto CurrentResidentialAddress { get; set; }
    public List<ResidentialAddressDto> PreviousAddresses { get; set; }
    public ResidentialAddressDto PostalAddress { get; set; }
}