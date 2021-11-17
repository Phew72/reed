using System.Collections.Generic;

namespace CandidateNames.Api.Comparers
{
    public class FirstNameComparer : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            var firstName = first.Split(',')[1].Trim().ToUpper();
            var secondName = second.Split(',')[1].Trim().ToUpper();

            return firstName.CompareTo(secondName);
        }
    }
}