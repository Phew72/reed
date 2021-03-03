using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateNames.Api.Models
{
    public class InitialCounter
    {
        private readonly SortedList<char, int> _initialCount;

        public InitialCounter()
        {
            _initialCount = new SortedList<char, int>();
        }

        public void ParseCandidatesList(List<Candidate> candidates)
        {
            if (candidates == null || candidates.Count == 0)
                return;

            _initialCount.Clear();

            foreach (var candidate in candidates)
            {
                if (!candidate.IsValid) continue;

                var key = char.Parse(candidate.FirstInitial);
                Increment(key);
            }
        }

        public void ParseAndIncrement(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentNullException(nameof(fullName));

            var initialChar = fullName
                .ToUpper()
                .Split(',')[1]
                .Trim()
                .ToCharArray()[0];

            Increment(initialChar);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            foreach (var (key, value) in _initialCount)
            {
                output.AppendLine($"{key} - {value}");
            }

            return output.ToString();
        }

        private void Increment(char key)
        {
            if (_initialCount.TryGetValue(key, out var currentCount))
            {
                _initialCount.Remove(key);
            }

            var newCount = ++currentCount;
            _initialCount.Add(key, newCount);
        }
    }
}
