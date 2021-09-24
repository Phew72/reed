using System.Collections.Generic;

namespace CandidateNames.Api.Comparers
{
    public class FirstNameComparer : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            // Get initial from first name
            char firstInitial = first.Split(',')[1].Trim().ToUpper().ToCharArray()[0];
            char secondInitial = second.Split(',')[1].Trim().ToUpper().ToCharArray()[0];

            if (firstInitial.Equals(secondInitial))
                return 0;
            
            if (firstInitial < secondInitial)
                return -1;
            else
                return 1;
        }
    }
}