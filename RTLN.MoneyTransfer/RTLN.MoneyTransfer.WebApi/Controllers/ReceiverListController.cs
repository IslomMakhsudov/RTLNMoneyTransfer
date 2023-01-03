using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.Services;

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
            var result = await _receiverListService.GetReceiverListAsync(modelRequest);
            return Ok(result);
        }
    }
}
