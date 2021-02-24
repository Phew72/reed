using CandidateNames.Api.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace CandidateNames.Tests
{
    [ExcludeFromCodeCoverage]
    public class InitialCounterTests
    {
        [Fact]
        public void ParseAndIncrement_WhenFullNameIsNull_ThenThrowsException()
        {
            var initialCounter = new InitialCounter();

            Assert.Throws<ArgumentNullException>(() => initialCounter.ParseAndIncrement(null));
        }

        [Fact]
        public void ParseAndIncrement_WhenFullNameSupplied_ThenInitialTallyIncremented()
        {
            var initialCounter = new InitialCounter();

            initialCounter.ParseAndIncrement("Smith, David");

            var result = initialCounter.ToString();

            Assert.Contains("D - 1", result);
        }

        [Fact]
        public void ToString_WhenMultipleNames_ThenOutputIsCorrect()
        {
            const string expectedOutput = "A - 2\r\nD - 2\r\nJ - 1\r\n";
            var initialCounter = new InitialCounter();

            foreach (var fullName in TestData.GetCleanCandidates)
            {
                initialCounter.ParseAndIncrement(fullName);
            }

            var result = initialCounter.ToString();

            Assert.Equal(expectedOutput, result);
        }
    }
}
