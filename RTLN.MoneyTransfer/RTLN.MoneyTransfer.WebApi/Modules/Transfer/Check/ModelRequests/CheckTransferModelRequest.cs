using RTLN.MoneyTransfer.Core.Entities;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelRequests
{
    public class CheckTransferModelRequest
    {
        public string OriginatorReferenceNumber { get; set; }
        public string OriginatorSignature { get; set; }
        public CheckReqeustOriginator Originator { get; set; }
        public Receiver Receiver { get; set; }
        public PaymentAmount PaymentAmount { get; set; }
        public ReceivingAmount ReceivingAmount { get; set; }
    }
}
