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
        public async Task<IActionResult> CheckTransfer(ToPlatformCheckModelRequest modelRequest)
        {
            var result = _checkTransferService.ToPlatform(modelRequest);

            return Ok(result);
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmTransfer(ToPlatformConfirmModelRequest modelRequest)
        {
            var result = _confirmTransferService.ToPlatform(modelRequest);

            return Ok(result);
        }

        [HttpGet("state")]
        public async Task<IActionResult> ToPlatformTransferState(ToPlatformStateModelRequest modelRequest)
        {
            var result = await _stateOfTransferService.ToPlatform(modelRequest);

            return Ok(result);
        }

        [HttpPost("state")]
        public async Task<IActionResult> FromPlatformTransferState(FromPlatformStateModelRequest modelRequest)
        {
            var result = await _stateOfTransferService.FromPlatform(modelRequest);

            return Ok(result);
        }
    }
}
