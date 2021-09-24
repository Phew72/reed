using CandidateNames.Api.Models;
using CandidateNames.Sources;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CandidateNames.Api.Services
{
    public class Candidates : ICandidates
    {
        private readonly IUserRepository _userRepository;
        private readonly InitialCounter _initialCounter;

        public int TotalInitialsCounted => _initialCounter.TotalInitialCount;

        public Candidates(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _initialCounter = new InitialCounter();
        }

        public string[] GetAll()
        {
            var developers = CleanList(_userRepository.GetDeveloperJobApplicants());

            var testers = CleanList(_userRepository.GetTesterJobApplicants());

            var allCandidates = developers.Union(testers).ToArray();

            // Count all first name initials (w/o duplicates!)
            allCandidates.ToList()
                .ForEach(n => _initialCounter.ParseAndIncrement(n));

            return allCandidates;
        }

        public string[] CleanList(string[] candidates)
        {
            if (candidates == null || candidates.Length == 0)
                return candidates;

            var regEx = new Regex("^([A-Za-z]+),\\s*([A-Za-z]+)$");
            var cleanList = new List<string>();

            // Loop through all items
            foreach (var fullName in candidates)
            {
                // Check name against regular expression
                if (regEx.IsMatch(fullName))
                {
                    cleanList.Add(fullName);
                }
            }

            return cleanList.ToArray();
        }

        public string GetInitialCountOutput()
        {
            return _initialCounter.ToString();
        }
    }
}
