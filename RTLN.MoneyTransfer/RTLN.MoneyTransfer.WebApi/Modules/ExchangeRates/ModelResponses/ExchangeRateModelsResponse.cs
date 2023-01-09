using RTLN.MoneyTransfer.Core.Entities;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;

namespace RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelResponses
{
    public class ExchangeRateModelsResponse
    {
        public SqlDateTime EffectiveDate { get; set; }
        public IList<ExchangeRate> ExchangeRatesList { get; set; }
    }
}
