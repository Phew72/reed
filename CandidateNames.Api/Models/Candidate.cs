using System;
using System.Text.RegularExpressions;

namespace CandidateNames.Api.Models
{
    public class Candidate
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string FirstInitial => !string.IsNullOrWhiteSpace(FirstName) ? FirstName.Substring(0, 1).ToUpper() : null;

        private bool _isValid;
        public bool IsValid => _isValid;

        public Candidate(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentNullException(nameof(fullName));

            ParseName(fullName);
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }

        private void ParseName(string fullName)
        {
            var regEx = new Regex("^([A-Za-z]+),\\s*([A-Za-z]+)$");
            Match m = regEx.Match(fullName);
            _isValid = m.Success;

            if (IsValid)
            {
                LastName = m.Groups[1].Value;
                FirstName = m.Groups[2].Value;
            }
        }
    }
}
