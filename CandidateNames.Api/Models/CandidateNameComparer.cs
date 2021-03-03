using System.Collections.Generic;

namespace CandidateNames.Api.Models
{
    public class CandidateNameComparer : IEqualityComparer<Candidate>
    {
        public bool Equals(Candidate first, Candidate second)
        {
            if (first == null && second == null)
                return true;

            if (first == null || second == null)
                return false;

            return first.ToString().Equals(second.ToString());
        }

        public int GetHashCode(Candidate candidate)
        {
            string hCode = candidate.LastName + candidate.FirstName;
            return hCode.GetHashCode();
        }
    }
}
