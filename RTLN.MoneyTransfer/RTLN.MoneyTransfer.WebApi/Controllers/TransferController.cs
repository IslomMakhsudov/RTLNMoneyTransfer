using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.Services;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.Services;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.Services;

namespace RTLN.MoneyTransfer.WebApi.Controllers
{
    [Route("v2/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ICheckTransferService _checkTransferService;
        private readonly IConfirmTransferService _confirmTransferService;
        private readonly IStateOfTransferService _stateOfTransferService;
        public TransferController(ICheckTransferService checkTransferService, IConfirmTransferService confirmTransferService, IStateOfTransferService stateOfTransferService)
        {
            _checkTransferService = checkTransferService;
            _confirmTransferService = confirmTransferService;
            _stateOfTransferService = stateOfTransferService;
        }

        [HttpGet("check")]
        public async Task<IActionResult> CheckTransfer(CheckTransferModelRequest modelRequest)
        {
            var result = _checkTransferService.CheckTransferTest();
            return Ok(result);
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmTransfer(ConfirmTransferModelRequest modelRequest)
        {
            var result = _confirmTransferService.ConfirmTransferTest();

            return Ok(result);
        }

        [HttpGet("state")]
        public async Task<IActionResult> StateOfTransfer(StateOfTransferModelRequest modelRequest)
        {
            var result = _stateOfTransferService.StateOfTransferTest();
            return Ok(result);
        }

    }
}
