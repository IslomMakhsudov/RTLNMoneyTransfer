using RTLN.MoneyTransfer.Core.Entities;
using System.Text.Json.Serialization;

namespace RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelRequests
{
    public class ParticipantListModelRequest
    {
        [JsonRequired]
        public ParticipantListOriginator Originator { get; set; }
    }
}
