namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StudioDonder.PrisonersDilemma.Domain.Tests.Helpers;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyMatchupResult"/> class.
    /// </summary>
    [TestClass]
    public class CooperationStrategyMatchupResultTests
    {
        /// <summary>
        /// Test that calling the constructor with a <c>null</c> strategy A result choice
        /// will throw an exception.
        /// </summary>
        [TestMethod, ExpectException]
        public void Constructor_WithNullStrategyAChoice_ThrowsException()
        {
            // Arrange
            CooperationStrategyResult nullStrategyAResult = null;
            var strategyBResult = new CooperationStrategyResult();

            // Act
            new CooperationStrategyMatchupResult(nullStrategyAResult, strategyBResult);

            // Assert
        }

        /// <summary>
        /// Test that calling the constructor with a <c>null</c> strategy B result choice
        /// will throw an exception.
        /// </summary>
        [TestMethod, ExpectException]
        public void Constructor_WithNullStrategyBChoice_ThrowsException()
        {
            // Arrange
            var strategyAResult = new CooperationStrategyResult();
            CooperationStrategyResult nullStrategyBResult = null;

            // Act
            new CooperationStrategyMatchupResult(strategyAResult, nullStrategyBResult);

            // Assert
        }

        /// <summary>
        /// Test that calling the StrategyAResult property returns the strategy A result choice
        /// parameter supplied to the constructor.
        /// </summary>
        [TestMethod]
        public void StrategyAChoice_ReturnsStrategyAChoideASuppliedToConstructor()
        {
            var strategyAResult = new CooperationStrategyResult();
            var strategyBResult = new CooperationStrategyResult();

            // Act
            var matchupResult = new CooperationStrategyMatchupResult(strategyAResult, strategyBResult);

            // Assert
            Assert.AreEqual(strategyAResult, matchupResult.StrategyAResult);
        }

        /// <summary>
        /// Test that calling the StrategyBResult property returns the strategy B result choice
        /// parameter supplied to the constructor.
        /// </summary>
        [TestMethod]
        public void StrategyBChoice_ReturnsStrategyAChoideASuppliedToConstructor()
        {
            var strategyAResult = new CooperationStrategyResult();
            var strategyBResult = new CooperationStrategyResult();

            // Act
            var matchupResult = new CooperationStrategyMatchupResult(strategyAResult, strategyBResult);

            // Assert
            Assert.AreEqual(strategyBResult, matchupResult.StrategyBResult);
        }
    }
}