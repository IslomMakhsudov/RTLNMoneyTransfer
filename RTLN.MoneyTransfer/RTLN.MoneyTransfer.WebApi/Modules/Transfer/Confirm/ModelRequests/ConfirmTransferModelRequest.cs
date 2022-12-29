using RTLN.MoneyTransfer.Core.Entities;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelRequests
{
    public class ConfirmTransferModelRequest
    {
        public string OriginatorSignature { get; set; }
        public string PlatformReferenceNumber { get; set; }
        public ConfirmRequestOriginator Originator { get; set; }
        public Receiver Receiver { get; set; }
        public PaymentAmount PaymentAmount { get; set; }
        public List<Fee> FeeAmount { get; set; }
        public SettlementAmount SettlementAmount { get; set; }
        public ReceivingAmount ReceivingAmount { get; set; }
        public DateTime CheckDate { get; set; }
        public ConversionRateBuy ConversionRateBuy { get; set; }
        public ConversionRateSell ConversionRateSell { get; set; }
        public string Comment { get; set; }
    }
}
