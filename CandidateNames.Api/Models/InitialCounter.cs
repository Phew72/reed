using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateNames.Api.Models
{
    public class InitialCounter
    {
        private readonly SortedList<char, int> _intialCount;

        public InitialCounter()
        {
            _intialCount = new SortedList<char, int>();
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

            foreach (var (key, value) in _intialCount)
            {
                output.AppendLine($"{key} - {value}");
            }

            return output.ToString();
        }

        private void Increment(char key)
        {
            if (_intialCount.TryGetValue(key, out var currentCount))
            {
                _intialCount.Remove(key);
            }

            var newCount = ++currentCount;
            _intialCount.Add(key, newCount);
        }
    }
}
