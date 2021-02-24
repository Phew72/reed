using CandidateNames.Api.Services;
using CandidateNames.Sources;
using Moq;
using Xunit;

namespace CandidateNames.Tests
{
    public class CandidatesTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;

        string[] _developerCandidates;
        string[] _testCandidates;
        string[] _validCandidates;

        public CandidatesTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();

            _developerCandidates = new[]
            {
                "Morgan, Arthur",
                "Smith, Andy",
                "Johnny",
                "Lloyd, Jonathon",
                "Peters, Damian",
                "Jones;&nbsp;, Charlie"
            };

            _testCandidates = new[]
            {
                "Jones, David",
                "Charles ,,John",
                "Susan",
                "Smith, Andy",
                "Matthews ,Meg"
            };

            _validCandidates = new[]
            {
                "Morgan, Arthur",
                "Smith, Andy",
                "Lloyd, Jonathon",
                "Peters, Damian",
                "Jones, David"
            };
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

            var results = service.CleanList(_testCandidates);

            Assert.Collection(results,
                name => Assert.Equal("Jones, David", name),
                name => Assert.Equal("Smith, Andy", name));
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsCandidatesNoDuplicates()
        {
            _mockUserRepository.Setup(r => r.GetDeveloperJobApplicants()).Returns(_developerCandidates);
            _mockUserRepository.Setup(r => r.GetTesterJobApplicants()).Returns(_testCandidates);

            var service = new Candidates(_mockUserRepository.Object);

            var results = service.GetAll();

            Assert.Equal(_validCandidates, results);
        }
    }
}
