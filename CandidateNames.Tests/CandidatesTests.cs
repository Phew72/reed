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
        public void CleanList_WhenArrayIsNull_ThenReturnsNull()
        {
            var service = new Candidates(_mockUserRepository.Object);

            Assert.Null(service.CleanList(null));
        }

        [Fact]
        public void CleanList_WhenArrayIsEmpty_ThenReturnsEmpty()
        {
            var service = new Candidates(_mockUserRepository.Object);

            var emptyArray = new string[] { };
            Assert.Empty(service.CleanList(emptyArray));
        }

        [Fact]
        public void CleanList_WhenArrayHasInvalidItems_ThenReturnsCleanItems()
        {
            var service = new Candidates(_mockUserRepository.Object);

            var results = service.CleanList(TestData.GetDirtyTesterCandidates);

            Assert.Collection(results,
                name => Assert.Equal("Jones, David", name),
                name => Assert.Equal("Smith, Andy", name));
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsCandidatesNoDuplicates()
        {
            _mockUserRepository.Setup(r => r.GetDeveloperJobApplicants()).Returns(TestData.GetDirtyDeveloperCandidates);
            _mockUserRepository.Setup(r => r.GetTesterJobApplicants()).Returns(TestData.GetDirtyTesterCandidates);

            var service = new Candidates(_mockUserRepository.Object);

            var results = service.GetAll();

            Assert.Equal(TestData.GetCleanCandidates, results);
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
    }
}
