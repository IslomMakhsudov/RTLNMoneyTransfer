namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelResponses
{
    public class FromPlatformCheckModelResponse
    {
        public string PlatformReferenceNumber { get; set; }
        public Receiver Receiver { get; set; }
        public ReceivingAmount ReceivingAmount { get; set; }
        public string CheckDate { get; set; }
        public TransferState TransferState { get; set; }
    }
}
