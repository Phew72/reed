using CandidateNames.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace CandidateNames.Tests
{
    [ExcludeFromCodeCoverage]
    public class InitialCounterTests
    {
        [Fact]
        public void ParseCandidatesList_WhenCollectionIsNull_TheOutputIsEmpty()
        {
            var initialCounter = new InitialCounter();

            initialCounter.ParseCandidatesList(null);

            Assert.Empty(initialCounter.ToString());
        }

        [Fact]
        public void ParseCandidatesList_WhenCollectionSupplied_ThenOutputIsCorrect()
        {
            var candidates = new List<Candidate>()
            {
                new Candidate("Morgan, Arthur"),
                new Candidate("Smith, Andy"),
                new Candidate("Lloyd, Jonathon"),
                new Candidate("Peters, Damian"),
                new Candidate("Jones, David")
            };

            const string expectedOutput = "A - 2\r\nD - 2\r\nJ - 1\r\n";

            var initialCounter = new InitialCounter();

            initialCounter.ParseCandidatesList(candidates);

            Assert.Equal(expectedOutput, initialCounter.ToString());
        }

        [Fact]
        public void ParseCandidatesList_WhenCollectionSuppliedIsDirty_ThenOutputIsCorrect()
        {
            var candidates = new List<Candidate>()
            {
                new Candidate("Morgan, Arthur"),
                new Candidate("Smith,,, Andy"),
                new Candidate("Lloyd, Jonathon"),
                new Candidate("Peter"),
                new Candidate("Jones, David")
            };

            const string expectedOutput = "A - 1\r\nD - 1\r\nJ - 1\r\n";

            var initialCounter = new InitialCounter();

            initialCounter.ParseCandidatesList(candidates);

            Assert.Equal(expectedOutput, initialCounter.ToString());
        }
    }
}
