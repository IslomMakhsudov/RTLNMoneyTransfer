using RTLN.MoneyTransfer.Core.Entities;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelRequests
{
    public class FromPlatformConfirmModelRequest
    {
        public string PlatformReferenceNumber { get; set; }
        public string PlatformSingature { get; set; }
        public Originator Originator { get; set; }
        public Receiver Receiver { get; set; }
        public PaymentAmount PaymentAmount { get; set; }
        public List<Fee>? FeeAmount { get; set; }
        public SettlementAmount SettlementAmount { get; set; }
        public ReceivingAmount ReceivingAmount { get; set; }
        public string CheckDate { get; set; }
        public string TransferDate { get; set; }
        public ConversionRateBuy ConversionRateBuy { get; set; }
        public ConversionRateSell ConversionRateSell { get; set; }
        public string? Comment { get; set; }

    }
}
