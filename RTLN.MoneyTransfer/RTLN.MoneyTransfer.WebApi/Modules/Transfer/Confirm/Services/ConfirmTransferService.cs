using RestSharp;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.Services
{
    public class ConfirmTransferService : IConfirmTransferService
    {
        private readonly IConfiguration _config;
        public ConfirmTransferService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ConfirmTransferModelResponse> ConfirmTransferAsync(ConfirmTransferModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/transfer/confirm");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<ConfirmTransferModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }
    }
}
