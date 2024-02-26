using System;

namespace PDF.Models.ValuationReportModels
{
    public class CashAccountModel
    {
        public decimal Balance { get; set; }

        public decimal Credit { get; set; }

        public decimal Debit { get; set; }

        public DateTime TransactionDate { get; set; }
        public DateTime SettlementDate { get; set; }
        public int TransactionTypeId { get; set; }

        public string TransactionType { get; set; }

        public string Narrative { get; set; }
        public string SecurityName { get; set; }
    }
}