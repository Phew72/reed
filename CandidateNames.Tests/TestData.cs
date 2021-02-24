using System.Diagnostics.CodeAnalysis;

namespace CandidateNames.Tests
{
    [ExcludeFromCodeCoverage]
    public class TestData
    {
        public static string[] GetDirtyDeveloperCandidates => new[]
        {
            "Morgan, Arthur",
            "Smith, Andy",
            "Johnny",
            "Lloyd, Jonathon",
            "Peters, Damian",
            "Jones;&nbsp;, Charlie"
        };

        public static string[] GetDirtyTesterCandidates => new[]
        {
            "Jones, David",
            "Charles ,,John",
            "Susan",
            "Smith, Andy",
            "Matthews ,Meg"
        };

        public static string[] GetCleanCandidates => new[]
        {
            "Morgan, Arthur",
            "Smith, Andy",
            "Lloyd, Jonathon",
            "Peters, Damian",
            "Jones, David"
        };
    }
}
