namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategiesFitnessEvaluator"/> class.
    /// </summary>
    public class CooperationStrategiesFitnessEvaluatorTests
    {
        private const uint DefaultNumberOfRounds = 10;

        /// <summary>
        /// Test that calling the default constructor will use the default cooperation choices payoff.
        /// </summary>
        [Fact]
        public void DefaultConstructorUsesDefaultCooperationChoicesPayoffThrowsException()
        {
            // Arrange
            var defaultCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

            // Assert
            Assert.Equal(defaultCooperationChoicesPayoff, cooperationStrategiesFitnessEvaluator.CooperationChoicesPayoff);
        }

        /// <summary>
        /// Test that calling the default constructor will use the default number of rounds.
        /// </summary>
        [Fact]
        public void DefaultConstructorUsesDefaultNumberOfRoundsThrowsException()
        {
            // Arrange

            // Act
            var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

            // Assert
            Assert.Equal(DefaultNumberOfRounds, cooperationStrategiesFitnessEvaluator.NumberOfRounds);
        }

        /// <summary>
        /// Test that calling the default constructor will use all strategies by default.
        /// </summary>
        [Fact]
        public void DefaultConstructorUsesAllStrategiesByDefaultThrowsException()
        {
            // Arrange
            var cooperationStrategyRepository = new CooperationStrategyRepository();

            // Act
            var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

            // Assert
            Assert.True(cooperationStrategiesFitnessEvaluator.CooperationStrategies.SequenceEqual(cooperationStrategyRepository.GetAll()));
        }

        /// <summary>
        /// Test that calling the constructor with a <c>null </c>cooperation strategies repository will throw an exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullCooperationStrategiesRepositoryThrowsArgumentNullException()
        {
            // Arrange
            CooperationStrategyRepository nullCooperationStrategyRepository = null;

            // Act
            
            // Assert
            Assert.Throws<ArgumentNullException>(() => new CooperationStrategiesFitnessEvaluator(nullCooperationStrategyRepository));
        }

        /// <summary>
        /// Test that calling the constructor with a cooperation strategies repository sets the cooperation strategies
        /// to the value returned by repository.
        /// </summary>
        [Fact]
        public void ConstructorWithCooperationStrategiesRepositorySetsCooperationStrategiesToValueReturnedByRepository()
        {
            // Arrange
            var cooperationStrategyRepository = new CooperationStrategyRepository();

            // Act
            var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator(cooperationStrategyRepository);

            // Assert
            Assert.True(cooperationStrategiesFitnessEvaluator.CooperationStrategies.SequenceEqual(cooperationStrategyRepository.GetAll()));
        }
        
        /// <summary>
        /// Test that calling the Evaluate method with a no cooperation strategies will not throw an exception.
        /// </summary>
        [Fact]
        public void EvaluateWithEmptyCooperationStrategiesDoesNotThrowException()
        {
            // Arranged
            var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();
            cooperationStrategiesFitnessEvaluator.CooperationStrategies.Clear();

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
            Assert.Equal(0, fitnesses.Count);
        }

        /// <summary>
        /// Test that calling the Evaluate method with a <c>null</c> cooperation strategy
        /// will ignore that cooperation strategy.
        /// </summary>
        [Fact]
        public void EvaluateWithNullCooperationStrategyIgnoresNullCooperationStrategyException()
        {
            // Arranged
            var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();
            cooperationStrategiesFitnessEvaluator.CooperationStrategies.Clear();
            cooperationStrategiesFitnessEvaluator.CooperationStrategies.Add(new NaiveCooperationStrategy());
            cooperationStrategiesFitnessEvaluator.CooperationStrategies.Add(null);

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
            Assert.Equal(1, fitnesses.Count);
        }

        /// <summary>
        /// Test that the Evaluate method returns a cooperation strategy fitness
        /// for each strategy.
        /// </summary>
        [Fact]
        public void EvaluateReturnsCooperationStrategyFitnessForEachStrategy()
        {
            // Arrange
            var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
            Assert.True(cooperationStrategiesFitnessEvaluator.CooperationStrategies.All(strategy => fitnesses.Any(fitness => fitness.Strategy == strategy)));
        }

        /// <summary>
        /// Test that the Evaluate method returns only one cooperation strategy fitness
        /// for each strategy.
        /// </summary>
        [Fact]
        public void EvaluateReturnsOneCooperationStrategyFitnessForEachStrategy()
        {
            // Arrange
            var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
            Assert.Equal(cooperationStrategiesFitnessEvaluator.CooperationStrategies.Count(), fitnesses.Count);
        }

        /// <summary>
        /// Test that the Evaluate method returns the cooperation strategy fitnesses
        /// in order of input for the strategies.
        /// </summary>
        [Fact]
        public void EvaluateReturnsCooperationStrategyFitnessesInOrderOfInput()
        {
            // Arrange
            var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
            Assert.Equal(cooperationStrategiesFitnessEvaluator.CooperationStrategies.First(), fitnesses[0].Strategy);
            Assert.Equal(cooperationStrategiesFitnessEvaluator.CooperationStrategies.Skip(1).First(), fitnesses[1].Strategy);
            Assert.Equal(cooperationStrategiesFitnessEvaluator.CooperationStrategies.Skip(2).First(), fitnesses[2].Strategy);
        }

        /// <summary>
        /// Test that the Evaluate method returns the correct total payoff for each strategy.
        /// </summary>
        [Fact]
        public void EvaluateReturnsCorrectTotalPayoffForEachStrategy()
        {
            // Arrange
            var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator
                                                            {
                                                                NumberOfRounds = 3,
                                                            };

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
            Assert.Equal(27, fitnesses[0].TotalPayoff);
            Assert.Equal(28, fitnesses[1].TotalPayoff);
            Assert.Equal(29, fitnesses[2].TotalPayoff);
        }
    }
}