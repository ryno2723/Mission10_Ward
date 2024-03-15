using APIBowling.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBowling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlingRepository _bowlingRepository;

        public BowlerController(IBowlingRepository temp) { 
            _bowlingRepository = temp;
        }

        [HttpGet]
        public IEnumerable<Bowler> Get()
        {
            var teams = new List<string> { "Marlins", "Sharks" };

            var bowlers = _bowlingRepository.GetAllBowlers()
                 .Where(b => teams.Contains(b.Team.TeamName))
                 .ToArray();

            return bowlers;
        }
    }
}
