using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.Services;

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
