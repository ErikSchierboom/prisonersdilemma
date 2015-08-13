namespace PrisonersDilemma.Domain.Tests
{
    using System;

    using Xunit;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyFitness"/> class.
    /// </summary>
    public class CooperationStrategyFitnessTests
    {
        /// <summary>
        /// Test that calling the constructor with a <c>null</c> <see cref="CooperationChoicesPayoff"/>
        /// will throw an exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullCooperationStrategyThrowsArgumentNullException()
        {
            // Arrange
            CooperationStrategy nullCooperationStrategy = null;

            // Act
            
            // Assert
            Assert.Throws<ArgumentNullException>(() => new CooperationStrategyFitness(nullCooperationStrategy, 0));
        }

        /// <summary>
        /// Test that calling the Strategy property returns the strategy parameter
        /// supplied to the constructor.
        /// </summary>
        [Fact]
        public void StrategyReturnsStrategySuppliedToConstructor()
        {
            // Arrange
            var cooperationStrategy = new NaiveCooperationStrategy();

            // Act
            var cooperationStrategyFitness = new CooperationStrategyFitness(cooperationStrategy, 0);

            // Assert
            Assert.Equal(cooperationStrategy, cooperationStrategyFitness.Strategy);
        }
    }
}