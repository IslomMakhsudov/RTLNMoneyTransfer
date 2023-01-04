using RestSharp;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.Services
{
    public class StateOfTransferService : IStateOfTransferService
    {
        private readonly IConfiguration _config;
        public StateOfTransferService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<StateOfTransferModelResponse> StateOfTransferAsync(StateOfTransferModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/transfer/confirm");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<StateOfTransferModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }
    }
}
