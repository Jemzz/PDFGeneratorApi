using System;

namespace PDF.Services.Dtos
{
    public class DailyPortfolioDto
    {
        public DateTime HoldingDate { get; set; }

        public decimal MarketValue { get; set; }
    }
}