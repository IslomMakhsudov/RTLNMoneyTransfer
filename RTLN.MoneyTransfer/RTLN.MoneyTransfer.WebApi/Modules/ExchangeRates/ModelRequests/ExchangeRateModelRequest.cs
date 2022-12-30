using RTLN.MoneyTransfer.Core.Entities;
using System.Reflection.Metadata.Ecma335;

namespace RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelRequests
{
    public class ExchangeRateModelRequest
    {
        public string RateType { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
