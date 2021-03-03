namespace CandidateNames.Api.Services
{
    public interface ICandidates
    {
        string[] GetArrayOfValidCandidates();
        string GetCandidatesInitialCountOutput();
    }
}