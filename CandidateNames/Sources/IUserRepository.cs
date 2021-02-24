namespace CandidateNames.Sources
{
    public interface IUserRepository
    {
        string[] GetDeveloperJobApplicants();

        string[] GetTesterJobApplicants();
    }
}