using RestSharp;
using RTLN.MoneyTransfer.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelRequests
{
    public class ExchangeRateModelRequest
    {
        [JsonRequired]
        public string RateType { get; set; }
        [JsonRequired]
        public string CurrencyCode { get; set; }
        [JsonRequired]
        public DateTime EffectiveDate { get; set; }
    }
}
