using System;
using System.Collections.Generic;

namespace PDF.Services.Dtos.ClientReport;

public class TaxEmploymentDto
{
    public string EmploymentStatus { get; set; }
    public string Position { get; set; }
    public DateTime? StartDate { get; set; }
    public double? Salary { get; set; }
    public bool? IsDirectorship { get; set; }
    public string DirectorshipDetails { get; set; }
    public bool? IsPep { get; set; }
    public string PepDetails { get; set; }
}