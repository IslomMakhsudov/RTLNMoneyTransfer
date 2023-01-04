using RestSharp;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.Services
{
    public class CheckTransferService : ICheckTransferService
    {
        private readonly IConfiguration _config;
        public CheckTransferService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<CheckTransferModelResponse> CheckTransfer(CheckTransferModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/transfer/check");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<CheckTransferModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }
    }
}
