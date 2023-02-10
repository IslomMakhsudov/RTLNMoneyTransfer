using Microsoft.AspNetCore.Authorization;
using RTLN.MoneyTransfer.Core.Entities;
using RTLN.MoneyTransfer.WebApi.Controllers;
using System.Reflection.Metadata.Ecma335;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelResponses
{
    public class FromPlatformStateModelResponse
    {
        public string PlatformReferenceNumber { get; set; }
        public Receiver Receiver { get; set; }
        public ReceivingAmount ReceivingAmount { get; set; }
        public string ReceivedDate { get; set; }
        public TransferState TransferState { get; set; }
    }
}
