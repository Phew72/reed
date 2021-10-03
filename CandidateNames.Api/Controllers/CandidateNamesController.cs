using CandidateNames.Api.Comparers;
using CandidateNames.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Collections.Generic;

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

            // 24-09-2021 - Added after assessment
            IComparer<string> myFirstNameComparer = new FirstNameComparer();
            Array.Sort(candidates, myFirstNameComparer);
            // Array.Sort(candidates);

            output.AppendLine($"Total candidates: {candidates.Length}");
            output.AppendLine("---------------------");
            // ------

            output.AppendLine(string.Join("\n", candidates));

            output.AppendLine();

            output.Append(_candidates.GetInitialCountOutput());

            // 24-09-2021 - Added after assessment
            output.AppendLine();
            output.AppendLine($"Total initial count: {_candidates.TotalInitialsCounted}");
            // ------

            return Ok(output.ToString());
        }
    }
}
