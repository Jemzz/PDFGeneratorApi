using System;

namespace PDF.Models
{
    public class ReportsParameters
    {
        public ReportsParameters()
        {
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
        }

        public long MandateId { get; set; }

        public int ClientId { get; set; }

        public int PortfolioId { get; set; }

        public int IsaTransferId { get; set; }

        public long IndividualId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int ReportType { get; set; }

        public int? ReportSubType { get; set; }
        public string CorrelationId { get; set; }

        public string ReportSpecificData { get; set; }
    }
}