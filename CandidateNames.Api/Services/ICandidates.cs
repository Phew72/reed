namespace CandidateNames.Api.Services
{
    public interface ICandidates
    {
        string[] CleanList(string[] candidates);
        string[] GetAll();
        string GetInitialCountOutput();
    }
}