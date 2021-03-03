using System;
using System.Collections.Generic;
using System.Text;
using CandidateNames.Api.Models;
using Xunit;

namespace CandidateNames.Tests
{
    public class CandidateTests
    {
        [Fact]
        public void Constructor_WhenValidName_ThenCandidatePropertiesSet()
        {
            var candidate = new Candidate("lastname, firstname");
            Assert.True(candidate.IsValid);
            Assert.Equal("lastname", candidate.LastName);
            Assert.Equal("firstname", candidate.FirstName);
        }

        [Theory]
        [InlineData("lastname,,   firstname")]
        [InlineData("name")]
        [InlineData("lastname&nbsp; firstname")]
        public void Constructor_WhenInvalidName_TheCandidatePropertiesNotSet(string name)
        {
            var candidate = new Candidate(name);
            Assert.False(candidate.IsValid);
            Assert.Null(candidate.LastName);
            Assert.Null(candidate.FirstName);
        }
    }
}
