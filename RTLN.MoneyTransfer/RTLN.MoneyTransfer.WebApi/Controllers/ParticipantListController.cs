namespace RTLN.MoneyTransfer.WebApi.Controllers
{
    [Route("v2/[controller]")]
    [ApiController]
    public class ParticipantListController : ControllerBase
    {
        private readonly IParticipantListService _participantListService;

        public ParticipantListController(IParticipantListService participantListService)
        {
            _participantListService = participantListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetParticipantList(ParticipantListModelRequest modelRequest)
        {
            var result = _participantListService.GetParticipantListTest();
            return Ok(result); 
        }
    }
}
