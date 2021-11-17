using CandidateNames.Api.Services;
using CandidateNames.Sources;
using Moq;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace CandidateNames.Tests
{
    [ExcludeFromCodeCoverage]
    public class CandidatesTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;

        public CandidatesTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public void GetArrayOfValidCandidates_WhenCalled_ReturnsCandidatesNoDuplicates()
        {
            _mockUserRepository.Setup(r => r.GetDeveloperJobApplicants()).Returns(TestData.GetDirtyDeveloperCandidates);
            _mockUserRepository.Setup(r => r.GetTesterJobApplicants()).Returns(TestData.GetDirtyTesterCandidates);

            var service = new Candidates(_mockUserRepository.Object);

            var results = service.GetArrayOfValidCandidates();

            Assert.Equal(TestData.GetCleanCandidates, results);
        }

        [Fact]
        public void GetCandidatesInitialCountOutput_WhenNoCandidates_ThenOutputIsEmpty()
        {
            var service = new Candidates(_mockUserRepository.Object);

            Assert.Empty(service.GetCandidatesInitialCountOutput());
        }
    }
}
