using RestSharp;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.Services
{
    public class ParticipantListService : IParticipantListService
    {
        private readonly IConfiguration _config;
        public ParticipantListService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ParticipantListModelResponse> GetParticipantListAsync(ParticipantListModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/participantlist");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<ParticipantListModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }
    }
}
