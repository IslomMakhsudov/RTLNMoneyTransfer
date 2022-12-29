using RTLN.MoneyTransfer.Core.Entities;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelResponses
{
    public class CheckTransferModelResponse
    {
        public string PlatformReferenceNumber { get; set; }
        public Originator Originator { get; set; }
        public ReceiverResponse Receiver { get; set; }
        public PaymentAmount PaymentAmount { get; set; }
        public SettlementAmount SettlementAmount { get; set; }
        public ReceivingAmount ReceivingAmount { get; set; }
        public DateTime CheckDate { get; set; }
        public ConversionRateSell ConversionRateSell { get; set; }
        public TransferState TransferState { get; set; }
    }
}
