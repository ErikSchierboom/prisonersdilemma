namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the <see cref="EvilCooperationStrategy"/> class.
    /// </summary>
    [TestClass]
    public class EvilCooperationStrategyTests : CooperationStrategyTestsBase
    {
        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Defect"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.None"/>.
        /// </summary>
        [TestMethod]
        public void Choose_WithLastChoiceByOpponentIsNone_ReturnsDefect()
        {
            // Arrange
            var strategy = new EvilCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.None);

            // Assert
            Assert.AreEqual(CooperationChoice.Defect, choice);
        }

        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Defect"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.Cooperate"/>.
        /// </summary>
        [TestMethod]
        public void Choose_WithLastChoiceByOpponentIsCooperate_ReturnsDefect()
        {
            // Arrange
            var strategy = new EvilCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.Cooperate);

            // Assert
            Assert.AreEqual(CooperationChoice.Defect, choice);
        }

        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Defect"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.Defect"/>.
        /// </summary>
        [TestMethod]
        public void Choose_WithLastChoiceByOpponentIsDefect_ReturnsDefect()
        {
            // Arrange
            var strategy = new EvilCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.Defect);

            // Assert
            Assert.AreEqual(CooperationChoice.Defect, choice);
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