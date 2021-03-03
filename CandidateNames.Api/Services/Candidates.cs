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

        private List<Candidate> _candidateList;

        public Candidates(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _initialCounter = new InitialCounter();
        }

        public string[] GetArrayOfValidCandidates()
        {
            var developerNames = _userRepository.GetDeveloperJobApplicants();
            var testerNames = _userRepository.GetTesterJobApplicants();

            var developerCandidates =
                developerNames.Select(developer => new Candidate(developer))
                    .Where(c => c.IsValid)
                    .ToList();

            var testerCandidates =
                testerNames.Select(tester => new Candidate(tester))
                    .Where(c => c.IsValid)
                    .ToList();

            _candidateList = new List<Candidate>();
            _candidateList = developerCandidates.Union(testerCandidates, new CandidateNameComparer()).ToList();

            return _candidateList.Select(c => c.ToString()).ToArray();
        }

        public string GetCandidatesInitialCountOutput()
        {
            var initialCounter = new InitialCounter();
            initialCounter.ParseCandidatesList(_candidateList);
            return initialCounter.ToString();
        }

        public string[] GetAll()
        {
            var developers = CleanList(_userRepository.GetDeveloperJobApplicants());

            var testers = CleanList(_userRepository.GetTesterJobApplicants());

            var allCandidates = developers.Union(testers).ToArray();

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
                    _initialCounter.ParseAndIncrement(fullName);
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
