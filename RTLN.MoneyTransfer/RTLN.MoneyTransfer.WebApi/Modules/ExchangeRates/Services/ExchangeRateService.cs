using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelResponses;
using RestSharp.Serializers.Json;
using RestSharp;
using RTLN.MoneyTransfer.Core.Entities;

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
                .AddJsonBody(modelRequest);*/

            //var response = await client.PostAsync<ExchangeRateModelsResponse>(request);

            var response = FillExchangeRate();

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }

        private ExchangeRateModelsResponse FillExchangeRate()
        {
            var exchangeRates = new ExchangeRateModelsResponse();
            exchangeRates.EffectiveDate = DateTime.Now;

            var exchangeRateList = new List<ExchangeRate>
            {
                new ExchangeRate{BuyRate = 0, SellRate = 0, CurrencyCode = "1", ParticipantId = 1},
                new ExchangeRate{BuyRate = 0, SellRate = 0, CurrencyCode = "2", ParticipantId = 2}
            };

            exchangeRates.ExchangeRatesList = exchangeRateList;

            return exchangeRates;
        }
    }
}
