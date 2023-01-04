using RTLN.MoneyTransfer.Core.Entities;
using System.Text.Json.Serialization;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelRequests
{
    public class ConfirmTransferModelRequest
    {
        [JsonRequired]
        public string OriginatorSignature { get; set; }

        [JsonRequired]
        public string PlatformReferenceNumber { get; set; }

        [JsonRequired]
        public ConfirmRequestOriginator Originator { get; set; }

        [JsonRequired]
        public Receiver Receiver { get; set; }

        [JsonRequired]
        public PaymentAmount PaymentAmount { get; set; }

        public List<Fee> FeeAmount { get; set; }

        [JsonRequired]
        public SettlementAmount SettlementAmount { get; set; }

        [JsonRequired]
        public ReceivingAmount ReceivingAmount { get; set; }

        [JsonRequired]
        public DateTime CheckDate { get; set; }

        [JsonRequired]
        public ConversionRateBuy ConversionRateBuy { get; set; }

        [JsonRequired]
        public ConversionRateSell ConversionRateSell { get; set; }

        public string Comment { get; set; }
    }
}
