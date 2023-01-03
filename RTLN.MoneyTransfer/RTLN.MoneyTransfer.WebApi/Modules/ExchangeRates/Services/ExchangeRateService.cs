using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelResponses;
using RestSharp.Serializers.Json;
using RestSharp;

namespace RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IConfiguration _config;
        public ExchangeRateService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ExchangeRateModelsResponse> GetExchangeRatesAsync(ExchangeRateModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/exchangerates");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<ExchangeRateModelsResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }
    }
}
