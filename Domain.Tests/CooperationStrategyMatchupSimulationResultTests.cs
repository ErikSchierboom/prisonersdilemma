namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using System;
    using System.Collections.Generic;

    using Xunit;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyMatchupSimulationResult"/> class.
    /// </summary>
    public class CooperationStrategyMatchupSimulationResultTests
    {
        /// <summary>
        /// Test that calling the constructor with a <c>null</c> cooperation strategy matchup
        /// will throw an exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullCooperationStrategyMatchupThrowsArgumentNullException()
        {
            // Arrange
            CooperationStrategyMatchup nullCooperationStrategyMatchup = null;
            var matchupResults = new List<CooperationStrategyMatchupResult>();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new CooperationStrategyMatchupSimulationResult(nullCooperationStrategyMatchup, matchupResults));
        }

        /// <summary>
        /// Test that calling the constructor with match results being <c>null</c> throws an exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullMatchupResultsThrowsArgumentNullException()
        {
            // Arrange
            var cooperationStrategyMatchup = CreateCooperationStrategyMatchup();
            IList<CooperationStrategyMatchupResult> nullMatchupResults = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new CooperationStrategyMatchupSimulationResult(cooperationStrategyMatchup, nullMatchupResults));
        }

        /// <summary>
        /// Test that the Matchup property returns the cooperation strategy matchup 
        /// supplied to the constructor.
        /// </summary>
        [Fact]
        public void MatchupReturnsCooperationStrategyMatchupSuppliedToConstructor()
        {
            // Arrange
            var cooperationStrategyMatchup = CreateCooperationStrategyMatchup();
            var matchupResults = new List<CooperationStrategyMatchupResult>();

            // Act
            var matchupSimulationResult = new CooperationStrategyMatchupSimulationResult(cooperationStrategyMatchup, matchupResults);

            // Assert
            Assert.Equal(cooperationStrategyMatchup, matchupSimulationResult.Matchup);
        }

        /// <summary>
        /// Test that the MatchupResult property is not null after the constructor has been called.
        /// </summary>
        [Fact]
        public void MatchupResultsMatchupReturnsCooperationStrategyMatchupResultsSuppliedToConstructor()
        {
            // Arrange
            var cooperationStrategyMatchup = CreateCooperationStrategyMatchup();
            var matchupResults = new List<CooperationStrategyMatchupResult>();

            // Act
            var matchupSimulationResult = new CooperationStrategyMatchupSimulationResult(cooperationStrategyMatchup, matchupResults);

            // Assert
            Assert.Equal(matchupResults, matchupSimulationResult.MatchupResults);
        }

        /// <summary>
        /// Test that the NumberOfRounds property is equal to the number of matchup results.
        /// </summary>
        [Fact]
        public void NumberOfRoundsEqualsToNumberOfMatchupResults()
        {
            // Arrange
            var cooperationStrategyMatchup = CreateCooperationStrategyMatchup();
            var matchupResults = new List<CooperationStrategyMatchupResult>()
                                     {
                                         new CooperationStrategyMatchupResult(new CooperationStrategyResult(), new CooperationStrategyResult()),
                                         new CooperationStrategyMatchupResult(new CooperationStrategyResult(), new CooperationStrategyResult()),
                                         new CooperationStrategyMatchupResult(new CooperationStrategyResult(), new CooperationStrategyResult()),
                                     };

            // Act
            var matchupSimulationResult = new CooperationStrategyMatchupSimulationResult(cooperationStrategyMatchup, matchupResults);

            // Assert
            Assert.Equal(matchupResults.Count, matchupSimulationResult.NumberOfRounds);
        }

        /// <summary>
        /// Test that the PayoffForStrategyA payoff property returns the correct payoff.
        /// </summary>
        [Fact]
        public void PayoffForStrategyAReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationStrategyMatchup = CreateCooperationStrategyMatchup();
            var matchupResults = new List<CooperationStrategyMatchupResult>
                                     {
                                         new CooperationStrategyMatchupResult(new CooperationStrategyResult { Payoff = 3 }, new CooperationStrategyResult()),
                                         new CooperationStrategyMatchupResult(new CooperationStrategyResult { Payoff = 7 }, new CooperationStrategyResult()),
                                         new CooperationStrategyMatchupResult(new CooperationStrategyResult { Payoff = 9 }, new CooperationStrategyResult()),
                                     };

            // Act
            var matchupSimulationResult = new CooperationStrategyMatchupSimulationResult(cooperationStrategyMatchup, matchupResults);

            // Assert
            Assert.Equal(19, matchupSimulationResult.PayoffForStrategyA);
        }

        /// <summary>
        /// Test that the PayoffForStrategyA payoff property returns the correct payoff.
        /// </summary>
        [Fact]
        public void PayoffForStrategyBReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationStrategyMatchup = CreateCooperationStrategyMatchup();
            var matchupResults = new List<CooperationStrategyMatchupResult>
                                     {
                                         new CooperationStrategyMatchupResult(new CooperationStrategyResult(), new CooperationStrategyResult { Payoff = 3 }),
                                         new CooperationStrategyMatchupResult(new CooperationStrategyResult(), new CooperationStrategyResult { Payoff = 5 }),
                                         new CooperationStrategyMatchupResult(new CooperationStrategyResult(), new CooperationStrategyResult { Payoff = 7 }),
                                     };

            // Act
            var matchupSimulationResult = new CooperationStrategyMatchupSimulationResult(cooperationStrategyMatchup, matchupResults);

            // Assert
            Assert.Equal(15, matchupSimulationResult.PayoffForStrategyB);
        }

        /// <summary>
        /// Creates the cooperation strategy matchup.
        /// </summary>
        /// <returns>The matchup.</returns>
        private static CooperationStrategyMatchup CreateCooperationStrategyMatchup()
        {
            return new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(),
                new EvilCooperationStrategy(),
                new CooperationChoicesPayoff());
        }
    }
}