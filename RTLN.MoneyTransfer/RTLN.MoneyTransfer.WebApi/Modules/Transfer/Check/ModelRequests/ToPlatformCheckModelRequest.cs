using RTLN.MoneyTransfer.Core.Entities;
using System.Text.Json.Serialization;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelRequests
{
    public class ToPlatformCheckModelRequest
    {
        [JsonRequired]
        public string OriginatorReferenceNumber { get; set; }
        [JsonRequired]
        public string OriginatorSignature { get; set; }
        [JsonRequired]
        public CheckReqeustOriginator Originator { get; set; }
        [JsonRequired]
        public Receiver Receiver { get; set; }
        [JsonRequired]
        public PaymentAmount PaymentAmount { get; set; }
        [JsonRequired]
        public ReceivingAmount ReceivingAmount { get; set; }
    }
}
