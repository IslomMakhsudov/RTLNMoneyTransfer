using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.Services
{
    public interface IExchangeRateService
    {
        public Task<ExchangeRateModelsResponse> GetExchangeRatesAsync(ExchangeRateModelRequest modelRequest);
    }
}
