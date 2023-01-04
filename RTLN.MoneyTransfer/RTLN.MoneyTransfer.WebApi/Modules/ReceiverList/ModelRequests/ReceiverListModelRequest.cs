using RTLN.MoneyTransfer.Core.Entities;
using System.Text.Json.Serialization;

namespace RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelRequests
{
    public class ReceiverListModelRequest
    {
        [JsonRequired]
        public Originator Originator { get; set; }
    }
}
