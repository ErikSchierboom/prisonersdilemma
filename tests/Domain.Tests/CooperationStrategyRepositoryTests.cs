namespace PrisonersDilemma.Domain.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyRepository"/> class.
    /// </summary>
    public class CooperationStrategyRepositoryTests
    {
        /// <summary>
        /// Test that the GetAll methods returns all strategies.
        /// </summary>
        [Fact]
        public void GetAllReturnsAllStrategies()
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
            Assert.True(allStrategies.SequenceEqual(strategies));
        }
    }
}