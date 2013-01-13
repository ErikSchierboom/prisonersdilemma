namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyRepository"/> class.
    /// </summary>
    [TestClass]
    public class CooperationStrategyRepositoryTests
    {
        /// <summary>
        /// Test that the GetAll methods returns all strategies.
        /// </summary>
        [TestMethod]
        public void GetAll_ReturnsAllStrategies()
        {
            // Arrange:
            var cooperationStrategyRepository = new CooperationStrategyRepository();

            // Act:
            var strategies = cooperationStrategyRepository.GetAll();

            // Assert
            var allStrategies = new List<CooperationStrategy>
                {
                    new NaiveCooperationStrategy(),
                    new EvilCooperationStrategy(),
                    new TitForTatCooperationStrategy(),
                };
            Assert.IsTrue(allStrategies.SequenceEqual(strategies));
        }
    }
}