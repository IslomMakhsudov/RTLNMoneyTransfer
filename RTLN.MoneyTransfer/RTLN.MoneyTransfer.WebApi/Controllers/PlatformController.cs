namespace RTLN.MoneyTransfer.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly MoneyTransferDbContext _context;
        public PlatformController(MoneyTransferDbContext context)
        {
            _context = context;
          
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            //var result = _context.Users.FromSqlRaw("GetAllUsers").ToList();

            var participant1 = new Participant { ParticipantId = 1 };
            var participant2 = new Participant { ParticipantId = 2 };
            var participant3 = new Participant { ParticipantId = 3 };

            var User = new User { Id = 1, Name = "Name", Age = 3, Participants = new List<Participant>() { participant1, participant2, participant3 } };

            return Ok(User);
        }
    }
}
