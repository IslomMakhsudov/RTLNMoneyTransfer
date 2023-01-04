using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.Services;

namespace RTLN.MoneyTransfer.WebApi.Controllers
{
    [Route("v2/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRateService _exchangeRateService;
        public ExchangeRatesController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExchangeRate([FromBody] ExchangeRateModelRequest modelRequest)
        {
            var result = await _exchangeRateService.GetExchangeRatesAsync(modelRequest);
            return Ok(result);
        }
    }
}
