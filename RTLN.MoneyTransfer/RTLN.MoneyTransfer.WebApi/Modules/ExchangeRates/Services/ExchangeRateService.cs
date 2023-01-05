using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelResponses;
using RestSharp.Serializers.Json;
using RestSharp;
using RTLN.MoneyTransfer.Core.Entities;
using System.Text.Json;

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
/*            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/exchangerates");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<string>(request);*/

            var response = FillExchangeRate();

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }

        private ExchangeRateModelsResponse FillExchangeRate()
        {
            string jsonText = "{\r\n\"effectiveDate\": \"2020-01-01T08:00:00Z\",\r\n\"exchangeRatesList\": [\r\n{\r\n\"currencyCode\": \"TJS\",\r\n\"sellRate\": 0.1519,\r\n\"buyRate\": 0.1533,\r\n\"participantId\": 10003\r\n},\r\n{\r\n\"currencyCode\": \"TJS\",\r\n\"sellRate\": 0.1518,\r\n\"buyRate\": 0.1534,\r\n\"participantId\": 10004\r\n}\r\n]\r\n}";

            var exchangeRates = JsonSerializer.Deserialize<ExchangeRateModelsResponse>(jsonText);

            return exchangeRates;

        }
    }
}
