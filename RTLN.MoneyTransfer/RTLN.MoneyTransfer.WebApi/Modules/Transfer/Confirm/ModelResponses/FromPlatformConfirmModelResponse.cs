using RTLN.MoneyTransfer.Core.Entities;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelResponses
{
    public class FromPlatformConfirmModelResponse
    {
        public string PlatformReferenceNumber { get; set; }
        public Receiver Receiver { get; set; } = new();
        public ReceivingAmount ReceivingAmount { get; set; } = new();
        public string CheckDate { get; set; }
        public TransferState TransferState { get; set; } = new();
    }
}