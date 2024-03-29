﻿using CandidateNames.Api.Comparers;
using CandidateNames.Api.Models;
using CandidateNames.Sources;
using System.Collections.Generic;
using System.Linq;

namespace CandidateNames.Api.Services
{
    public class Candidates : ICandidates
    {
        private readonly IUserRepository _userRepository;

        private List<Candidate> _candidateList;
        private InitialCounter _initialCounter;

        public int TotalInitialsCounted => _initialCounter.TotalInitialCount;

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
            _initialCounter = new InitialCounter();
            _initialCounter.ParseCandidatesList(_candidateList);
            return _initialCounter.ToString();
        }
    }
}
