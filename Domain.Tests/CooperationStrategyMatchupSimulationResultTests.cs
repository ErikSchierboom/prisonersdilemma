namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StudioDonder.PrisonersDilemma.Domain.Tests.Helpers;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyMatchupSimulationResult"/> class.
    /// </summary>
    [TestClass]
    public class CooperationStrategyMatchupSimulationResultTests
    {
        /// <summary>
        /// Test that calling the constructor with a <c>null</c> cooperation strategy matchup
        /// will throw an exception.
        /// </summary>
        [TestMethod, ExpectException]
        public void Constructor_WithNullCooperationStrategyMatchup_ThrowsException()
        {
            // Arrange
            CooperationStrategyMatchup nullCooperationStrategyMatchup = null;
            var matchupResults = new List<CooperationStrategyMatchupResult>();

            // Act
            new CooperationStrategyMatchupSimulationResult(nullCooperationStrategyMatchup, matchupResults);

            // Assert
        }

        /// <summary>
        /// Test that calling the constructor with match results being <c>null</c> throws an exception.
        /// </summary>
        [TestMethod, ExpectException]
        public void Constructor_WithNullMatchupResults_ThrowsException()
        {
            // Arrange
            var cooperationStrategyMatchup = CreateCooperationStrategyMatchup();
            IList<CooperationStrategyMatchupResult> nullMatchupResults = null;

            // Act
            new CooperationStrategyMatchupSimulationResult(cooperationStrategyMatchup, nullMatchupResults);

            // Assert
        }

        /// <summary>
        /// Test that the Matchup property returns the cooperation strategy matchup 
        /// supplied to the constructor.
        /// </summary>
        [TestMethod]
        public void Matchup_ReturnsCooperationStrategyMatchupSuppliedToConstructor()
        {
            // Arrange
            var cooperationStrategyMatchup = CreateCooperationStrategyMatchup();
            var matchupResults = new List<CooperationStrategyMatchupResult>();

            // Act
            var matchupSimulationResult = new CooperationStrategyMatchupSimulationResult(cooperationStrategyMatchup, matchupResults);

            // Assert
            Assert.AreEqual(cooperationStrategyMatchup, matchupSimulationResult.Matchup);
        }

        /// <summary>
        /// Test that the MatchupResult property is not null after the constructor has been called.
        /// </summary>
        [TestMethod]
        public void MatchupResults_Matchup_ReturnsCooperationStrategyMatchupResultsSuppliedToConstructor()
        {
            // Arrange
            var cooperationStrategyMatchup = CreateCooperationStrategyMatchup();
            var matchupResults = new List<CooperationStrategyMatchupResult>();

            // Act
            var matchupSimulationResult = new CooperationStrategyMatchupSimulationResult(cooperationStrategyMatchup, matchupResults);

            // Assert
            Assert.AreEqual(matchupResults, matchupSimulationResult.MatchupResults);
        }

        /// <summary>
        /// Test that the NumberOfRounds property is equal to the number of matchup results.
        /// </summary>
        [TestMethod]
        public void NumberOfRounds_EqualsToNumberOfMatchupResults()
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
            Assert.AreEqual(matchupResults.Count, matchupSimulationResult.NumberOfRounds);
        }

        /// <summary>
        /// Test that the PayoffForStrategyA payoff property returns the correct payoff.
        /// </summary>
        [TestMethod]
        public void PayoffForStrategyA_ReturnsCorrectPayoff()
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
            Assert.AreEqual(19, matchupSimulationResult.PayoffForStrategyA);
        }

        /// <summary>
        /// Test that the PayoffForStrategyA payoff property returns the correct payoff.
        /// </summary>
        [TestMethod]
        public void PayoffForStrategyB_ReturnsCorrectPayoff()
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
            Assert.AreEqual(15, matchupSimulationResult.PayoffForStrategyB);
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