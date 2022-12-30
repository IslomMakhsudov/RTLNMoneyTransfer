using RTLN.MoneyTransfer.Core.Entities;
using System.Reflection.Metadata.Ecma335;

namespace RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelResponses
{
    public class ExchangeRateModelsResponse
    {
        public DateTime EffectiveDate { get; set; }
        public List<ExchangeRate> ExchangeRatesList { get; set; }
    }
}
