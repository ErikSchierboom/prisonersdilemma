namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StudioDonder.PrisonersDilemma.Domain.Tests.Helpers;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyMatchupSimulation"/> class.
    /// </summary>
    [TestClass]
    public class CooperationStrategyMatchupSimulationTests
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

            // Act
            new CooperationStrategyMatchupSimulation(nullCooperationStrategyMatchup);

            // Assert
        }

        /// <summary>
        /// Test that the Matchup property returns the <see cref="CooperationStrategyMatchup"/>
        /// instance supplied to the constructor.
        /// </summary>
        [TestMethod]
        public void CooperationStrategyMatchup_ReturnsCooperationStrategyMatchup_SuppliedToConstructor()
        {
            // Arrange
            var strategyA = new NaiveCooperationStrategy();
            var strategyB = new EvilCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();
            var matchup = new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicePayoff);

            // Act
            var simulation = new CooperationStrategyMatchupSimulation(matchup);

            // Assert
            Assert.AreEqual(matchup, simulation.Matchup);
        }

        /// <summary>
        /// Test that calling the Simulate method with a number of rounds equal to zero 
        /// will throw an exception.
        /// </summary>
        [TestMethod, ExpectException]
        public void Simulate_WithNumberOfRoundsEqualToZero_ThrowsException()
        {
            // Arrange
            var matchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var matchupSimulation = new CooperationStrategyMatchupSimulation(matchup);
            const int NumberOfRounds = 0;

            // Act
            matchupSimulation.Simulate(NumberOfRounds);

            // Assert
        }

        /// <summary>
        /// Test that calling the Simulate method with a number of rounds less than zero 
        /// will throw an exception.
        /// </summary>
        [TestMethod, ExpectException]
        public void Simulate_WithNumberOfRoundsLessThanZero_ThrowsException()
        {
            // Arrange
            var matchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var matchupSimulation = new CooperationStrategyMatchupSimulation(matchup);
            const int NumberOfRounds = -1;

            // Act
            matchupSimulation.Simulate(NumberOfRounds);

            // Assert
        }

        /// <summary>
        /// Test that calling the Simulate method with a specific number of rounds will
        /// return a number of matchup results equal to the number of rounds.
        /// </summary>
        [TestMethod]
        public void Simulate_WillReturnSimulationResultsWithNumberOfMatchupResultsEqualToSuppliedNumberOfRounds()
        {
            // Arrange
            var matchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var matchupSimulation = new CooperationStrategyMatchupSimulation(matchup);
            const int NumberOfRounds = 20;

            // Act
            var simulationResults = matchupSimulation.Simulate(NumberOfRounds);

            // Assert
            Assert.AreEqual(NumberOfRounds, simulationResults.MatchupResults.Count);
        }

        /// <summary>
        /// Test that calling the Simulate method will return the correct matchup results.
        /// </summary>
        [TestMethod]
        public void Simulate_WillReturnCorrectMatchupResults()
        {
            // Arrange
            var matchup = new CooperationStrategyMatchup(
                new TitForTatCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var matchupSimulation = new CooperationStrategyMatchupSimulation(matchup);
            const int NumberOfRounds = 2;

            // Act
            var simulationResults = matchupSimulation.Simulate(NumberOfRounds);

            // Assert
            Assert.AreEqual(CooperationChoice.Cooperate, simulationResults.MatchupResults[0].StrategyAResult.ChoiceMade);
            Assert.AreEqual(CooperationChoice.Defect, simulationResults.MatchupResults[1].StrategyBResult.ChoiceMade);
        }
    }
}