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
            var result = _exchangeRateService.GetExchangeRatesTest();
            return Ok(result);
        }
    }
}
