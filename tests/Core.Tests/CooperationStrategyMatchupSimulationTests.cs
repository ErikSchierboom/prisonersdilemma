namespace PrisonersDilemma.Domain.Tests
{
    using System;

    using Xunit;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyMatchupSimulation"/> class.
    /// </summary>
    public class CooperationStrategyMatchupSimulationTests
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

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new CooperationStrategyMatchupSimulation(nullCooperationStrategyMatchup));
        }

        /// <summary>
        /// Test that the Matchup property returns the <see cref="CooperationStrategyMatchup"/>
        /// instance supplied to the constructor.
        /// </summary>
        [Fact]
        public void CooperationStrategyMatchupReturnsCooperationStrategyMatchupSuppliedToConstructor()
        {
            // Arrange
            var strategyA = new NaiveCooperationStrategy();
            var strategyB = new EvilCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();
            var matchup = new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicePayoff);

            // Act
            var simulation = new CooperationStrategyMatchupSimulation(matchup);

            // Assert
            Assert.Equal(matchup, simulation.Matchup);
        }

        /// <summary>
        /// Test that calling the Simulate method with a number of rounds equal to zero 
        /// will throw an exception.
        /// </summary>
        [Fact]
        public void SimulateWithNumberOfRoundsEqualToZeroThrowsArgumentException()
        {
            // Arrange
            var matchup = new CooperationStrategyMatchup(new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var matchupSimulation = new CooperationStrategyMatchupSimulation(matchup);
            const int NumberOfRounds = 0;

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => matchupSimulation.Simulate(NumberOfRounds));
        }
        
        /// <summary>
        /// Test that calling the Simulate method with a specific number of rounds will
        /// return a number of matchup results equal to the number of rounds.
        /// </summary>
        [Fact]
        public void SimulateWillReturnSimulationResultsWithNumberOfMatchupResultsEqualToSuppliedNumberOfRounds()
        {
            // Arrange
            var matchup = new CooperationStrategyMatchup(new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var matchupSimulation = new CooperationStrategyMatchupSimulation(matchup);
            const int NumberOfRounds = 20;

            // Act
            var simulationResults = matchupSimulation.Simulate(NumberOfRounds);

            // Assert
            Assert.Equal(NumberOfRounds, simulationResults.MatchupResults.Count);
        }

        /// <summary>
        /// Test that calling the Simulate method will return the correct matchup results.
        /// </summary>
        [Fact]
        public void SimulateWillReturnCorrectMatchupResults()
        {
            // Arrange
            var matchup = new CooperationStrategyMatchup(new TitForTatCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var matchupSimulation = new CooperationStrategyMatchupSimulation(matchup);
            const int NumberOfRounds = 2;

            // Act
            var simulationResults = matchupSimulation.Simulate(NumberOfRounds);

            // Assert
            Assert.Equal(CooperationChoice.Cooperate, simulationResults.MatchupResults[0].StrategyAResult.ChoiceMade);
            Assert.Equal(CooperationChoice.Defect, simulationResults.MatchupResults[1].StrategyBResult.ChoiceMade);
        }
    }
}