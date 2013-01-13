namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StudioDonder.PrisonersDilemma.Domain.Tests.Helpers;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyFitness"/> class.
    /// </summary>
    [TestClass]
    public class CooperationStrategyFitnessTests
    {
        /// <summary>
        /// Test that calling the constructor with a <c>null</c> <see cref="CooperationChoicesPayoff"/>
        /// will throw an exception.
        /// </summary>
        [TestMethod, ExpectException]
        public void Constructor_WithNullCooperationStrategy_ThrowsException()
        {
            // Arrange
            CooperationStrategy nullCooperationStrategy = null;

            // Act
            new CooperationStrategyFitness(nullCooperationStrategy, 0);

            // Assert
        }

        /// <summary>
        /// Test that calling the Strategy property returns the strategy parameter
        /// supplied to the constructor.
        /// </summary>
        [TestMethod]
        public void Strategy_ReturnsStrategySuppliedToConstructor()
        {
            // Arrange
            var cooperationStrategy = new NaiveCooperationStrategy();

            // Act
            var cooperationStrategyFitness = new CooperationStrategyFitness(cooperationStrategy, 0);

            // Assert
            Assert.AreEqual(cooperationStrategy, cooperationStrategyFitness.Strategy);
        }
    }
}