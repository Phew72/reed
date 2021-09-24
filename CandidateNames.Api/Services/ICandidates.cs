namespace CandidateNames.Api.Services
{
    public interface ICandidates
    {
        int TotalInitialsCounted { get; }
        
        string[] CleanList(string[] candidates);
        string[] GetAll();
        string GetInitialCountOutput();
    }
}