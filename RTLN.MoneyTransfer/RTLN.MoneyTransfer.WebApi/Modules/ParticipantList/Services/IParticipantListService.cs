using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelRequests;

namespace RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.Services
{
    public interface IParticipantListService
    {
        public Task<ParticipantListModelResponse> GetParticipantListAsync(ParticipantListModelRequest modelRequest);
    }
}
