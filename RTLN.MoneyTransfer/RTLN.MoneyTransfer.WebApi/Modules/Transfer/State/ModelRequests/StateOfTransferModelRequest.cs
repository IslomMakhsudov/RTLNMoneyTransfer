namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelRequests
{
    public class ToPlatformStateModelRequest
    {
        [JsonRequired]
        public string OriginatorReferenceNumber { get; set; }
    }
}
