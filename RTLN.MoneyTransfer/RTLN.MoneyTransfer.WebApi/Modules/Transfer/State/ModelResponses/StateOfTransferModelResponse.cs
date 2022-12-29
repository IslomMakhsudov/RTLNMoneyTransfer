using RTLN.MoneyTransfer.Core.Entities;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelResponses
{
    public class StateOfTransferModelResponse
    {
        public string PlatformReferenceNumber { get; set; }
        public Originator Originator { get; set; }
        public Receiver Receiver { get; set; }
        public PaymentAmount PaymentAmount { get; set; }
        public List<Fee> FeeAmount { get; set; }
        public SettlementAmount SettlementAmount { get; set; }
        public ReceivingAmount ReceivingAmount { get; set; }
        public DateTime CheckDate { get; set; }
        public DateTime TransferDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public ConversionRateSell ConversionRateSell { get; set; }
        public StateResponseConversionRateBuy ConversionRateBuy { get; set; }
        public TransferState TransferState { get; set; }
    }
}
