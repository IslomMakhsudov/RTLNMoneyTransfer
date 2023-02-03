using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelResponses;
using RestSharp.Serializers.Json;
using RestSharp;
using RTLN.MoneyTransfer.Core.Entities;
using System.Text.Json;
using System.Data.SqlTypes;

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

        public string GetExchangeRatesTest()
        {
            return "{\"effectiveDate\": \"2020-01-01T08:00:00Z\",\"exchangeRatesList\":[{\"currencyCode\": \"TJS\",\"sellRate\": 0.1519,\"buyRate\": 0.1533,\"participantId\": 10003},{\"currencyCode\": \"TJS\",\"sellRate\": 0.1518,\"buyRate\": 0.1534,\"participantId\": 10004}]}";
        }
    }
}
