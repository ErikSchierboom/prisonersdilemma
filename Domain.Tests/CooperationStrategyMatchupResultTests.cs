namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using System;

    using Xunit;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyMatchupResult"/> class.
    /// </summary>
    public class CooperationStrategyMatchupResultTests
    {
        /// <summary>
        /// Test that calling the constructor with a <c>null</c> strategy A result choice
        /// will throw an exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullStrategyAChoiceThrowsArgumentNullException()
        {
            // Arrange
            CooperationStrategyResult nullStrategyAResult = null;
            var strategyBResult = new CooperationStrategyResult();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new CooperationStrategyMatchupResult(nullStrategyAResult, strategyBResult));
        }

        /// <summary>
        /// Test that calling the constructor with a <c>null</c> strategy B result choice
        /// will throw an exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullStrategyBChoiceThrowsArgumentNullException()
        {
            // Arrange
            var strategyAResult = new CooperationStrategyResult();
            CooperationStrategyResult nullStrategyBResult = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new CooperationStrategyMatchupResult(strategyAResult, nullStrategyBResult));
        }

        /// <summary>
        /// Test that calling the StrategyAResult property returns the strategy A result choice
        /// parameter supplied to the constructor.
        /// </summary>
        [Fact]
        public void StrategyAChoiceReturnsStrategyAChoideASuppliedToConstructor()
        {
            var strategyAResult = new CooperationStrategyResult();
            var strategyBResult = new CooperationStrategyResult();

            // Act
            var matchupResult = new CooperationStrategyMatchupResult(strategyAResult, strategyBResult);

            // Assert
            Assert.Equal(strategyAResult, matchupResult.StrategyAResult);
        }

        /// <summary>
        /// Test that calling the StrategyBResult property returns the strategy B result choice
        /// parameter supplied to the constructor.
        /// </summary>
        [Fact]
        public void StrategyBChoiceReturnsStrategyAChoideASuppliedToConstructor()
        {
            var strategyAResult = new CooperationStrategyResult();
            var strategyBResult = new CooperationStrategyResult();

            // Act
            var matchupResult = new CooperationStrategyMatchupResult(strategyAResult, strategyBResult);

            // Assert
            Assert.Equal(strategyBResult, matchupResult.StrategyBResult);
        }
    }
}