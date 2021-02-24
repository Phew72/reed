using CandidateNames.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CandidateNames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateNamesController : ControllerBase
    {
        private readonly ICandidates _candidates;

        public CandidateNamesController(ICandidates candidates)
        {
            _candidates = candidates;
        }

        [HttpGet]
        public IActionResult GetCandidateNames()
        {
            return Ok(_candidates.GetAll());
        }
    }
}
