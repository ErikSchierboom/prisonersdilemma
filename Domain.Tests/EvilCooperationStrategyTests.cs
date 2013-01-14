namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Xunit;

    /// <summary>
    /// Tests for the <see cref="EvilCooperationStrategy"/> class.
    /// </summary>
    public class EvilCooperationStrategyTests : CooperationStrategyTestsBase
    {
        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Defect"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.None"/>.
        /// </summary>
        [Fact]
        public void ChooseWithLastChoiceByOpponentIsNoneReturnsDefect()
        {
            // Arrange
            var strategy = new EvilCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.None);

            // Assert
            Assert.Equal(CooperationChoice.Defect, choice);
        }

        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Defect"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.Cooperate"/>.
        /// </summary>
        [Fact]
        public void ChooseWithLastChoiceByOpponentIsCooperateReturnsDefect()
        {
            // Arrange
            var strategy = new EvilCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.Cooperate);

            // Assert
            Assert.Equal(CooperationChoice.Defect, choice);
        }

        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Defect"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.Defect"/>.
        /// </summary>
        [Fact]
        public void ChooseWithLastChoiceByOpponentIsDefectReturnsDefect()
        {
            // Arrange
            var strategy = new EvilCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.Defect);

            // Assert
            Assert.Equal(CooperationChoice.Defect, choice);
        }

        /// <summary>
        /// Gets the correct name.
        /// </summary>
        /// <returns>The name.</returns>
        protected override string GetCorrectName()
        {
            return "Evil";
        }

        /// <summary>
        /// Gets the correct description.
        /// </summary>
        /// <returns>
        /// The description.
        /// </returns>
        protected override string GetCorrectDescription()
        {
            return "Always defect.";
        }

        /// <summary>
        /// Creates a strategy.
        /// </summary>
        /// <returns>The strategy.</returns>
        protected override CooperationStrategy CreateStrategy()
        {
            return new EvilCooperationStrategy();
        }

        /// <summary>
        /// Creates a different strategy.
        /// </summary>
        /// <returns>The different strategy.</returns>
        protected override CooperationStrategy CreateDifferentStrategy()
        {
            return new NaiveCooperationStrategy();
        }
    }
}