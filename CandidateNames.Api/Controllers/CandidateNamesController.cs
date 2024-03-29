﻿using CandidateNames.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
            var output = new StringBuilder();

            var candidates = _candidates.GetAll();
            output.AppendLine(string.Join("\n", candidates));

            output.AppendLine();

            output.Append(_candidates.GetInitialCountOutput());

            return Ok(output.ToString());
        }
    }
}
