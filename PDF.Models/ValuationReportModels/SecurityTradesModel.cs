﻿using System;

namespace PDF.Models.ValuationReportModels
{
    public class SecurityTradesModel
    {
        public int SecurityId { get; set; }
        public string Trade { get; set; }

        public string TradeType { get; set; }

        public DateTime TradeDate { get; set; }

        public DateTime SettlementDate { get; set; }

        public string DealCurrency { get; set; }
        public string Reference { get; set; }

        public decimal Price { get; set; }

        public decimal TradeValue { get; set; }

        public string TradeStatus { get; set; }

        public decimal BookCost { get; set; }

        public decimal Units { get; set; }

        public decimal PrevHolding { get; set; }

        public decimal NewHolding { get; set; }
    }
}