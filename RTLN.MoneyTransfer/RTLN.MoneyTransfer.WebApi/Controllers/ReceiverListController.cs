namespace RTLN.MoneyTransfer.WebApi.Controllers
{
    [Route("v2/[controller]")]
    [ApiController]
    public class ReceiverListController : ControllerBase
    {
        private readonly IReceiverListService _receiverListService;
        public ReceiverListController(IReceiverListService receiverListService)
        {
            _receiverListService = receiverListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReceiverList(ReceiverListModelRequest modelRequest)
        {
            var result = _receiverListService.GetReceiverListTest();
            return Ok(result);
        }
    }
}
