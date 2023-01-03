using RestSharp;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.Services
{
    public class ReceiverListService : IReceiverListService
    {
        private readonly IConfiguration _config;
        public ReceiverListService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ReceiverListModelResponse> GetReceiverListAsync(ReceiverListModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/participantlist");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<ReceiverListModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }
    }
}
