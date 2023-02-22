using System.Reflection.Metadata.Ecma335;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelRequests
{
    public class FromPlatformCheckModelRequest
    {
        public string PlatformReferenceNumber { get; set; }
        public string PlatformSignature { get; set; }
        public Receiver Receiver { get; set; }
        public PaymentAmount PaymentAmount { get; set; }
        public List<Fee>? FeeAmount { get; set; }
        public SettlementAmount SettlementAmount { get; set; }
        public ReceivingAmount ReceivingAmount { get; set; }
        public ConversionRateSell? ConversionRateSell { get; set; }
    }
}
