using System.Text.Json.Serialization;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelRequests
{
    public class StateOfTransferModelRequest
    {
        [JsonRequired]
        public string OriginatorReferenceNumber { get; set; }
    }
}
